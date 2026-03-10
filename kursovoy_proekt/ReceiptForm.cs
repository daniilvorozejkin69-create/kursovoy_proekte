using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class ReceiptForm : Form
    {
        private int orderId;
        private int clientId;
        private int houseId;
        private decimal houseTotal;
        private decimal servicesTotal;
        private decimal grandTotal;
        private List<ServiceItem> servicesList;
        private int userId;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private int stayDays;
        private string contractNumber;

        // Данные клиента
        private string clientFIO;
        private string clientPassport;
        private string clientPhone;
        private string clientEmail;
        private DateTime clientBirthDate;

        // Данные дома
        private string houseName;
        private string houseClass;
        private string houseAddress;
        private int houseCapacity;
        private string houseDescription;
        private decimal pricePerDay;

        // Данные сотрудника
        private string staffFIO;
        private string staffLogin;

        // КОНСТРУКТОР
        public ReceiptForm(int orderId, int clientId, int houseId, decimal houseTotal,
                          List<ServiceItem> services, int userId,
                          DateTime checkInDate, DateTime checkOutDate, int stayDays)
        {
            InitializeComponent();

            this.orderId = orderId;
            this.clientId = clientId;
            this.houseId = houseId;
            this.houseTotal = houseTotal;
            this.servicesList = services ?? new List<ServiceItem>();
            this.userId = userId;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.stayDays = stayDays;

            // Генерация номера договора
            this.contractNumber = $"Д-{DateTime.Now.Year}-{orderId:00000}";

            InitializeDataGridView();
            LoadData();
            LoadServicesToGrid();
            CalculateTotals();
            DisplayData();
        }

        private void InitializeDataGridView()
        {
            try
            {
                if (dataGridViewServices == null)
                {
                    MessageBox.Show("Ошибка: dataGridViewServices не инициализирован");
                    return;
                }

                dataGridViewServices.AutoGenerateColumns = false;
                dataGridViewServices.Columns.Clear();

                DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Наименование услуги",
                    Width = 250,
                    ReadOnly = true,
                    DataPropertyName = "Name"
                };

                DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Кол-во",
                    Width = 70,
                    ReadOnly = true,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                    DataPropertyName = "Quantity"
                };

                DataGridViewTextBoxColumn colUnitPrice = new DataGridViewTextBoxColumn
                {
                    Name = "UnitPrice",
                    HeaderText = "Цена за ед., ₽",
                    Width = 120,
                    ReadOnly = true,
                    DefaultCellStyle = {
                        Format = "N2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    },
                    DataPropertyName = "Price"
                };

                DataGridViewTextBoxColumn colTotalPrice = new DataGridViewTextBoxColumn
                {
                    Name = "TotalPrice",
                    HeaderText = "Сумма, ₽",
                    Width = 120,
                    ReadOnly = true,
                    DefaultCellStyle = {
                        Format = "N2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                };

                dataGridViewServices.Columns.AddRange(colName, colQuantity, colUnitPrice, colTotalPrice);
                dataGridViewServices.RowHeadersVisible = false;
                dataGridViewServices.AllowUserToAddRows = false;
                dataGridViewServices.ReadOnly = true;
                dataGridViewServices.BackgroundColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации таблицы: {ex.Message}");
            }
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Загрузка клиента
                    string queryClient = "SELECT FIO, passport_series_number, telephone_number, email, date_of_birth FROM client WHERE id = @clientId";
                    using (MySqlCommand cmdClient = new MySqlCommand(queryClient, connection))
                    {
                        cmdClient.Parameters.AddWithValue("@clientId", clientId);
                        using (MySqlDataReader readerClient = cmdClient.ExecuteReader())
                        {
                            if (readerClient.Read())
                            {
                                clientFIO = readerClient["FIO"].ToString();
                                clientPassport = readerClient["passport_series_number"].ToString();
                                clientPhone = readerClient["telephone_number"].ToString();
                                clientEmail = readerClient["email"].ToString();

                                if (readerClient["date_of_birth"] != DBNull.Value)
                                    clientBirthDate = Convert.ToDateTime(readerClient["date_of_birth"]);
                            }
                        }
                    }

                    // Загрузка дома
                    string queryHouse = @"SELECT h.name, hc.class, h.address_number, h.capacity, h.description 
                                         FROM house h 
                                         JOIN home_class hc ON h.home_class_id = hc.id 
                                         WHERE h.id = @houseId";
                    using (MySqlCommand cmdHouse = new MySqlCommand(queryHouse, connection))
                    {
                        cmdHouse.Parameters.AddWithValue("@houseId", houseId);
                        using (MySqlDataReader readerHouse = cmdHouse.ExecuteReader())
                        {
                            if (readerHouse.Read())
                            {
                                houseName = readerHouse["name"].ToString();
                                houseClass = readerHouse["class"].ToString();
                                houseAddress = readerHouse["address_number"].ToString();
                                houseCapacity = Convert.ToInt32(readerHouse["capacity"]);
                                houseDescription = readerHouse["description"].ToString();

                                // Расчет цены за сутки по классу
                                switch (houseClass)
                                {
                                    case "Эконом": pricePerDay = 3000; break;
                                    case "Комфорт": pricePerDay = 5000; break;
                                    case "Люкс": pricePerDay = 8000; break;
                                    case "Премиум": pricePerDay = 12000; break;
                                    case "Бизнес": pricePerDay = 10000; break;
                                    default: pricePerDay = 5000; break;
                                }
                            }
                        }
                    }

                    // Загрузка сотрудника
                    LoadCurrentUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void LoadCurrentUser()
        {
            try
            {
                if (Session.IsLoggedIn && Session.UserId > 0)
                {
                    staffFIO = Session.UserName;
                    staffLogin = Session.UserLogin;
                    return;
                }

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT p.FIO, u.login 
                                    FROM users u 
                                    JOIN personal p ON u.personal_id = p.id 
                                    WHERE u.id = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                staffFIO = reader["FIO"].ToString();
                                staffLogin = reader["login"].ToString();
                            }
                            else
                            {
                                staffFIO = "Не указан";
                                staffLogin = "-";
                            }
                        }
                    }
                }
            }
            catch
            {
                staffFIO = "Ошибка загрузки";
                staffLogin = "-";
            }
        }

        private void LoadServicesToGrid()
        {
            try
            {
                if (dataGridViewServices == null) return;

                dataGridViewServices.Rows.Clear();
                servicesTotal = 0;

                foreach (var service in servicesList)
                {
                    decimal totalPrice = service.Price * service.Quantity;

                    int rowIndex = dataGridViewServices.Rows.Add();
                    dataGridViewServices.Rows[rowIndex].Cells["Name"].Value = service.Name;
                    dataGridViewServices.Rows[rowIndex].Cells["Quantity"].Value = service.Quantity;
                    dataGridViewServices.Rows[rowIndex].Cells["UnitPrice"].Value = service.Price;
                    dataGridViewServices.Rows[rowIndex].Cells["TotalPrice"].Value = totalPrice;

                    servicesTotal += totalPrice;
                }

                if (dataGridViewServices.Rows.Count > 0)
                {
                    dataGridViewServices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки услуг: {ex.Message}");
            }
        }

        private void CalculateTotals()
        {
            servicesTotal = servicesList.Sum(s => s.Price * s.Quantity);
            grandTotal = houseTotal + servicesTotal;
        }

        private void DisplayData()
        {
            // Заголовок - меняем на ДОГОВОР
            labelOrderNumber.Text = $"ДОГОВОР № {contractNumber}";
            labelOrderDate.Text = $"г. Москва, {DateTime.Now:dd MMMM yyyy} г.";

            // Клиент
            labelClientName.Text = clientFIO;
            labelClientPassport.Text = $"Паспорт: {clientPassport}";
            labelClientPhone.Text = $"Телефон: {clientPhone}";
            labelClientEmail.Text = $"Email: {clientEmail}";

            // Дом
            labelHouseName.Text = $"Дом: {houseName}";
            labelHouseClass.Text = $"Класс: {houseClass}";
            labelHouseAddress.Text = $"Адрес: участок № {houseAddress}";
            labelHouseCapacity.Text = $"Вместимость: {houseCapacity} чел.";
            labelHouseDescription.Text = $"Описание: {houseDescription}";

            // Даты
            labelCheckInDate.Text = $"Дата заезда: {checkInDate:dd.MM.yyyy} (с 14:00)";
            labelCheckOutDate.Text = $"Дата выезда: {checkOutDate:dd.MM.yyyy} (до 12:00)";
            labelStayPeriod.Text = $"Период проживания: {stayDays} суток";

            // Стоимость
            labelHouseCost.Text = $"Стоимость проживания: {houseTotal:N2} ₽";
            labelServicesCost.Text = $"Дополнительные услуги: {servicesTotal:N2} ₽";
            labelTotalCost.Text = $"ВСЕГО ПО ДОГОВОРУ: {grandTotal:N2} ₽";
            labelAmountInWords.Text = NumberToWords((int)Math.Round(grandTotal));

            // Сотрудник
            labelStaffName.Text = $"Сотрудник: {staffFIO}";
            labelStaffLogin.Text = $"Логин: {staffLogin}";

            // Дополнительная информация для договора
            labelQRInfo.Text = $"Договор действителен\nпри наличии подписей сторон";
            labelReceiptDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private string NumberToWords(int number)
        {
            if (number == 0) return "Ноль рублей";

            string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] teens = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
                              "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] tens = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят",
                             "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот",
                                 "шестьсот", "семьсот", "восемьсот", "девятьсот" };

            StringBuilder result = new StringBuilder();

            if (number >= 1000)
            {
                int thousands = number / 1000;
                AppendNumberPart(thousands, result, units, teens, tens, hundreds);
                result.Append(" тысяч ");
                number %= 1000;
            }

            if (number > 0)
            {
                AppendNumberPart(number, result, units, teens, tens, hundreds);
            }

            int lastTwo = number % 100;
            int lastOne = number % 10;

            if (lastTwo >= 11 && lastTwo <= 14) result.Append(" рублей");
            else if (lastOne == 1) result.Append(" рубль");
            else if (lastOne >= 2 && lastOne <= 4) result.Append(" рубля");
            else result.Append(" рублей");

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToString().Trim());
        }

        private void AppendNumberPart(int number, StringBuilder result, string[] units, string[] teens, string[] tens, string[] hundreds)
        {
            if (number >= 100)
            {
                result.Append(hundreds[number / 100] + " ");
                number %= 100;
            }

            if (number >= 20)
            {
                result.Append(tens[number / 10] + " ");
                number %= 10;
                if (number > 0) result.Append(units[number] + " ");
            }
            else if (number >= 10)
            {
                result.Append(teens[number - 10] + " ");
                number = 0;
            }
            else if (number > 0)
            {
                result.Append(units[number] + " ");
            }
        }

        // ПЕЧАТЬ ДОГОВОРА
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintContractPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Договор отправлен на печать.", "Печать",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintContractPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Times New Roman", 16, FontStyle.Bold);
                Font headerFont = new Font("Times New Roman", 14, FontStyle.Bold);
                Font normalFont = new Font("Times New Roman", 11);
                Font boldFont = new Font("Times New Roman", 11, FontStyle.Bold);
                Font smallFont = new Font("Times New Roman", 9);

                float yPos = e.MarginBounds.Top;
                float leftMargin = e.MarginBounds.Left;
                float pageWidth = e.MarginBounds.Width;

                // Заголовок
                string title = "ДОГОВОР НА ПРОЖИВАНИЕ";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    leftMargin + (pageWidth - titleSize.Width) / 2, yPos);
                yPos += titleSize.Height + 5;

                // Номер договора
                string contractNum = $"№ {contractNumber}";
                SizeF numSize = e.Graphics.MeasureString(contractNum, headerFont);
                e.Graphics.DrawString(contractNum, headerFont, Brushes.Black,
                    leftMargin + (pageWidth - numSize.Width) / 2, yPos);
                yPos += numSize.Height + 15;

                // Дата и место
                e.Graphics.DrawString($"г. Москва", normalFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString($"{DateTime.Now:dd MMMM yyyy г.}", normalFont, Brushes.Black, leftMargin + 500, yPos);
                yPos += normalFont.GetHeight() + 20;

                // ИСПОЛНИТЕЛЬ
                e.Graphics.DrawString("ИСПОЛНИТЕЛЬ:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString("ООО \"Премиум Коттеджи\"", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString("ИНН 1234567890, КПП 123456789", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString("123456, г. Москва, ул. Лесная, д. 10", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight() + 15;

                // ЗАКАЗЧИК
                e.Graphics.DrawString("ЗАКАЗЧИК:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString($"ФИО: {clientFIO}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"Паспорт: {clientPassport}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"Телефон: {clientPhone}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"Email: {clientEmail}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight() + 20;

                // ПРЕДМЕТ ДОГОВОРА
                e.Graphics.DrawString("1. ПРЕДМЕТ ДОГОВОРА", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString("   1.1. Исполнитель предоставляет, а Заказчик принимает во временное пользование", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString("        жилое помещение (далее - Дом) для проживания.", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString("   1.2. Характеристики Дома:", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Наименование: {houseName}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Класс: {houseClass}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Адрес: участок № {houseAddress}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Вместимость: {houseCapacity} чел.", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString("   1.3. Срок проживания:", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Заезд: {checkInDate:dd.MM.yyyy} с 14:00", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Выезд: {checkOutDate:dd.MM.yyyy} до 12:00", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                e.Graphics.DrawString($"        - Количество суток: {stayDays}", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight() + 15;

                // СТОИМОСТЬ
                e.Graphics.DrawString("2. СТОИМОСТЬ И ПОРЯДОК РАСЧЕТОВ", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString($"   2.1. Стоимость проживания: {houseTotal:N2} ₽", normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += normalFont.GetHeight();

                if (servicesList.Count > 0)
                {
                    e.Graphics.DrawString($"   2.2. Дополнительные услуги: {servicesTotal:N2} ₽", normalFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += normalFont.GetHeight();

                    e.Graphics.DrawString("   2.3. Перечень услуг:", normalFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += normalFont.GetHeight();

                    foreach (var service in servicesList)
                    {
                        decimal total = service.Price * service.Quantity;
                        e.Graphics.DrawString($"        - {service.Name}: {service.Quantity} × {service.Price:N2} = {total:N2} ₽",
                            normalFont, Brushes.Black, leftMargin + 40, yPos);
                        yPos += normalFont.GetHeight();
                    }

                    e.Graphics.DrawString($"   2.4. Общая стоимость договора: {grandTotal:N2} ₽", boldFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += boldFont.GetHeight();
                }
                else
                {
                    e.Graphics.DrawString($"   2.2. Общая стоимость договора: {grandTotal:N2} ₽", boldFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += boldFont.GetHeight();
                }

                e.Graphics.DrawString($"       ({labelAmountInWords.Text})", smallFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += smallFont.GetHeight() + 20;

                // ПОДПИСИ
                yPos = e.MarginBounds.Bottom - 70;

                e.Graphics.DrawString("ИСПОЛНИТЕЛЬ:", boldFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString("ЗАКАЗЧИК:", boldFont, Brushes.Black, leftMargin + 400, yPos);
                yPos += 25;

                e.Graphics.DrawString("____________________ /_______________/", normalFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString("____________________ /_______________/", normalFont, Brushes.Black, leftMargin + 400, yPos);
                yPos += 20;

                e.Graphics.DrawString("М.П.", boldFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString($"Сотрудник: {staffFIO}", smallFont, Brushes.Black, leftMargin + 400, yPos);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании страницы для печати: {ex.Message}");
            }
        }

        private void buttonSavePDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveDialog.FileName = $"Договор_{contractNumber}_{DateTime.Now:yyyyMMdd_HHmm}";
                saveDialog.DefaultExt = "pdf";
                saveDialog.Title = "Сохранить договор";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveAsPDF(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void SaveAsPDF(string pdfFilePath)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintContractPage;

                string pdfPrinterName = "";
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    if (printer.Contains("Microsoft Print to PDF"))
                    {
                        pdfPrinterName = printer;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(pdfPrinterName))
                {
                    MessageBox.Show("Принтер 'Microsoft Print to PDF' не найден.");
                    return;
                }

                pd.PrinterSettings.PrinterName = pdfPrinterName;
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = pdfFilePath;

                foreach (PaperSize size in pd.PrinterSettings.PaperSizes)
                {
                    if (size.Kind == PaperKind.A4)
                    {
                        pd.DefaultPageSettings.PaperSize = size;
                        break;
                    }
                }

                pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                pd.Print();

                MessageBox.Show($"Договор сохранен в PDF:\n{pdfFilePath}", "Успех");
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении PDF: {ex.Message}");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewServices != null && dataGridViewServices.Rows.Count > 0)
            {
                dataGridViewServices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            if (buttonClose != null)
            {
                buttonClose.Focus();
            }
        }
    }
}