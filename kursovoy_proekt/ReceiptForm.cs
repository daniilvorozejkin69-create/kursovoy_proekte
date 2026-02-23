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
        private decimal houseTotal;
        private decimal servicesTotal;
        private decimal grandTotal;
        private List<ServiceItem> servicesList; // ИСПРАВЛЕНО: ServiceData -> ServiceItem
        private int userId;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private int stayDays;

        // ИСПРАВЛЕННЫЙ КОНСТРУКТОР
        public ReceiptForm(int orderId, int clientId, int houseId, decimal houseTotal,
                          List<ServiceItem> services, int userId, // ИСПРАВЛЕНО: ServiceData -> ServiceItem
                          DateTime checkInDate, DateTime checkOutDate, int stayDays)
        {
            InitializeComponent();

            this.orderId = orderId;
            this.houseTotal = houseTotal;
            this.servicesList = services ?? new List<ServiceItem>(); // ИСПРАВЛЕНО
            this.userId = userId;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.stayDays = stayDays;

            InitializeReceiptDataGridView();
            LoadReceiptData(clientId, houseId);
            LoadServicesToGrid();
            CalculateTotals();
            FormatReceipt();
            MaskConfidentialData();
            DisplayStayDates();
        }

        private void InitializeReceiptDataGridView()
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
                    HeaderText = "Услуга",
                    Width = 200,
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
                    HeaderText = "Цена за ед.",
                    Width = 100,
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
                    HeaderText = "Общая стоимость",
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
                dataGridViewServices.GridColor = Color.FromArgb(220, 235, 210);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации таблицы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReceiptData(int clientId, int houseId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Загрузка клиента
                    string queryClient = "SELECT FIO, passport_series_number, telephone_number, email FROM client WHERE id = @clientId";
                    using (MySqlCommand cmdClient = new MySqlCommand(queryClient, connection))
                    {
                        cmdClient.Parameters.AddWithValue("@clientId", clientId);
                        using (MySqlDataReader readerClient = cmdClient.ExecuteReader())
                        {
                            if (readerClient.Read())
                            {
                                labelClientName.Text = readerClient["FIO"].ToString();
                                labelClientPassport.Text = $"Паспорт: {readerClient["passport_series_number"]}";
                                labelClientPhone.Text = $"Телефон: {readerClient["telephone_number"]}";
                                labelClientEmail.Text = $"Email: {readerClient["email"]}";
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
                                labelHouseName.Text = $"Дом: {readerHouse["name"]}";
                                labelHouseClass.Text = $"Класс: {readerHouse["class"]}";
                                labelHouseAddress.Text = $"Адрес: {readerHouse["address_number"]}";
                                labelHouseCapacity.Text = $"Вместимость: {readerHouse["capacity"]} чел.";
                                labelHouseDescription.Text = $"Описание: {readerHouse["description"]}";
                            }
                        }
                    }

                    // Загрузка сотрудника
                    LoadCurrentUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных чека: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentUser()
        {
            try
            {
                if (Session.IsLoggedIn && Session.UserId > 0)
                {
                    labelStaffName.Text = $"Сотрудник: {Session.UserName}";
                    labelStaffLogin.Text = $"Логин: {Session.UserLogin}";
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
                                labelStaffName.Text = $"Сотрудник: {reader["FIO"]}";
                                labelStaffLogin.Text = $"Логин: {reader["login"]}";
                            }
                            else
                            {
                                labelStaffName.Text = "Сотрудник: Не указан";
                                labelStaffLogin.Text = "Логин: -";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки сотрудника: {ex.Message}");
                labelStaffName.Text = "Сотрудник: Ошибка загрузки";
                labelStaffLogin.Text = "Логин: -";
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

            labelHouseCost.Text = $"Стоимость проживания: {houseTotal:N2} ₽";
            labelServicesCost.Text = $"Дополнительные услуги: {servicesTotal:N2} ₽";
            labelTotalCost.Text = $"ВСЕГО К ОПЛАТЕ: {grandTotal:N2} ₽";
            labelAmountInWords.Text = NumberToWords((int)Math.Round(grandTotal));
        }

        private void FormatReceipt()
        {
            labelOrderNumber.Text = $"КАССОВЫЙ ЧЕК № {orderId:00000}";
            labelOrderDate.Text = $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}";
            labelReceiptDate.Text = DateTime.Now.ToString("dd.MM.yyyy");

            string qrText = $"Заказ #{orderId}\nот {DateTime.Now:dd.MM.yyyy}\nСумма: {grandTotal:N2} ₽";
            labelQRInfo.Text = qrText;
        }

        private void DisplayStayDates()
        {
            labelCheckInDate.Text = $"Дата заезда: {checkInDate:dd.MM.yyyy}";
            labelCheckOutDate.Text = $"Дата выезда: {checkOutDate:dd.MM.yyyy}";
            labelStayPeriod.Text = $"Период проживания: {stayDays} дней";
        }

        private void MaskConfidentialData()
        {
            try
            {
                // Паспорт: 4005******
                if (labelClientPassport.Text.StartsWith("Паспорт: "))
                {
                    string passport = labelClientPassport.Text.Replace("Паспорт: ", "");
                    if (passport.Length >= 4)
                    {
                        string maskedPassport = passport.Substring(0, 4) + new string('*', Math.Max(0, passport.Length - 4));
                        labelClientPassport.Text = $"Паспорт: {maskedPassport}";
                    }
                }

                // Телефон: +7 *** ***-**-**
                if (labelClientPhone.Text.StartsWith("Телефон: "))
                {
                    string phone = labelClientPhone.Text.Replace("Телефон: ", "");
                    string maskedPhone = MaskPhoneNumber(phone);
                    labelClientPhone.Text = $"Телефон: {maskedPhone}";
                }

                // Email: n******@mail.ru
                if (labelClientEmail.Text.StartsWith("Email: "))
                {
                    string email = labelClientEmail.Text.Replace("Email: ", "");
                    string maskedEmail = MaskEmail(email);
                    labelClientEmail.Text = $"Email: {maskedEmail}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка маскировки данных: {ex.Message}");
            }
        }

        private string MaskPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "***";

            string result = "";

            if (phone.StartsWith("+7") || phone.StartsWith("8"))
            {
                result = "+7 ";
                if (phone.StartsWith("+7")) phone = phone.Substring(2);
                else if (phone.StartsWith("8")) phone = phone.Substring(1);
            }

            string digits = new string(phone.Where(char.IsDigit).ToArray());

            if (digits.Length >= 10)
            {
                result += $"*** ***-{digits.Substring(digits.Length - 4, 2)}-{digits.Substring(digits.Length - 2, 2)}";
            }
            else
            {
                result += "*** ***-**-**";
            }

            return result;
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@")) return email;

            try
            {
                var parts = email.Split('@');
                if (parts.Length != 2) return email;

                string local = parts[0];
                string domain = parts[1];

                if (local.Length <= 1)
                {
                    return $"{local}***@{domain}";
                }
                else
                {
                    return $"{local.First()}{new string('*', local.Length - 1)}@{domain}";
                }
            }
            catch
            {
                return email;
            }
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

            if (number >= 1000000)
            {
                int millions = number / 1000000;
                AppendNumberPart(millions, result, units, teens, tens, hundreds);

                if (millions == 1) result.Append(" миллион ");
                else if (millions >= 2 && millions <= 4) result.Append(" миллиона ");
                else result.Append(" миллионов ");

                number %= 1000000;
            }

            if (number >= 1000)
            {
                int thousands = number / 1000;
                AppendNumberPart(thousands, result, units, teens, tens, hundreds);

                if (thousands == 1) result.Append(" тысяча ");
                else if (thousands >= 2 && thousands <= 4) result.Append(" тысячи ");
                else result.Append(" тысяч ");

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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintReceiptPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Чек отправлен на печать.", "Печать",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font boldFont = new Font("Arial", 10, FontStyle.Bold);
                Font totalFont = new Font("Arial", 12, FontStyle.Bold);

                float yPos = e.MarginBounds.Top;
                float leftMargin = e.MarginBounds.Left;
                float rightMargin = e.MarginBounds.Right;
                float pageWidth = e.MarginBounds.Width;

                // Заголовок
                string title = "БАЗА ОТДЫХА \"ПРЕМИУМ КОТТЕДЖИ\"";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    leftMargin + (pageWidth - titleSize.Width) / 2, yPos);
                yPos += titleSize.Height + 10;

                // Номер чека
                string receiptNumber = $"КАССОВЫЙ ЧЕК № {orderId}";
                SizeF numberSize = e.Graphics.MeasureString(receiptNumber, headerFont);
                e.Graphics.DrawString(receiptNumber, headerFont, Brushes.Black,
                    leftMargin + (pageWidth - numberSize.Width) / 2, yPos);
                yPos += numberSize.Height + 15;

                // Дата
                e.Graphics.DrawString($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 20;

                // Клиент
                e.Graphics.DrawString("КЛИЕНТ:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString(labelClientName.Text.Replace("Клиент: ", ""),
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString(labelClientPassport.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString(labelClientPhone.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString(labelClientEmail.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 20;

                // Проживание
                e.Graphics.DrawString("ПРОЖИВАНИЕ:", boldFont, Brushes.Black, leftMargin, yPos);
                yPos += boldFont.GetHeight() + 5;

                e.Graphics.DrawString(labelHouseName.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString(labelHouseClass.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString(labelHouseAddress.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                // Даты проживания
                e.Graphics.DrawString($"Дата заезда: {checkInDate:dd.MM.yyyy}",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString($"Дата выезда: {checkOutDate:dd.MM.yyyy}",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString($"Период проживания: {stayDays} дней",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString($"Стоимость проживания: {houseTotal:N2} ₽",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 20;

                // Услуги
                if (servicesList.Count > 0)
                {
                    e.Graphics.DrawString("ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ:", boldFont, Brushes.Black, leftMargin, yPos);
                    yPos += boldFont.GetHeight() + 10;

                    float[] columnWidths = { 200, 70, 100, 100 };
                    string[] headers = { "Услуга", "Кол-во", "Цена за ед.", "Сумма" };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        e.Graphics.DrawString(headers[i], boldFont, Brushes.Black,
                            leftMargin + (i > 0 ? columnWidths.Take(i).Sum() : 0), yPos);
                    }
                    yPos += boldFont.GetHeight() + 5;

                    e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + columnWidths.Sum(), yPos);
                    yPos += 5;

                    foreach (var service in servicesList)
                    {
                        if (yPos > e.MarginBounds.Bottom - 50)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                        decimal totalPrice = service.Price * service.Quantity;

                        e.Graphics.DrawString(service.Name, normalFont, Brushes.Black, leftMargin, yPos);
                        e.Graphics.DrawString(service.Quantity.ToString(), normalFont, Brushes.Black,
                            leftMargin + columnWidths[0], yPos);
                        e.Graphics.DrawString($"{service.Price:N2} ₽", normalFont, Brushes.Black,
                            leftMargin + columnWidths[0] + columnWidths[1], yPos);
                        e.Graphics.DrawString($"{totalPrice:N2} ₽", normalFont, Brushes.Black,
                            leftMargin + columnWidths[0] + columnWidths[1] + columnWidths[2], yPos);

                        yPos += normalFont.GetHeight() + 5;
                    }

                    e.Graphics.DrawString($"Итого услуг: {servicesTotal:N2} ₽",
                        normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += normalFont.GetHeight() + 20;
                }

                // Итог
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + 300, yPos);
                yPos += 10;

                e.Graphics.DrawString($"Стоимость проживания: {houseTotal:N2} ₽",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawString($"Дополнительные услуги: {servicesTotal:N2} ₽",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 5;

                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + 250, yPos);
                yPos += 10;

                e.Graphics.DrawString($"ВСЕГО К ОПЛАТЕ: {grandTotal:N2} ₽",
                    totalFont, Brushes.Black, leftMargin, yPos);
                yPos += totalFont.GetHeight() + 10;

                string words = $"({labelAmountInWords.Text})";
                e.Graphics.DrawString(words, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 30;

                // Подпись
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + 200, yPos);
                yPos += 15;

                e.Graphics.DrawString(labelStaffName.Text, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 10;

                e.Graphics.DrawString("Подпись сотрудника: _________________________",
                    normalFont, Brushes.Black, leftMargin, yPos);
                yPos += normalFont.GetHeight() + 20;

                e.Graphics.DrawString("СПАСИБО ЗА ВАШ ЗАКАЗ!",
                    new Font("Arial", 11, FontStyle.Italic), Brushes.Black,
                    leftMargin + (pageWidth - 200) / 2, yPos);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании страницы для печати: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSavePDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf|Текстовые файлы (*.txt)|*.txt|HTML файлы (*.html)|*.html";
                saveDialog.FileName = $"Чек_{orderId}_{DateTime.Now:yyyyMMdd_HHmm}";
                saveDialog.DefaultExt = "pdf";
                saveDialog.OverwritePrompt = true;
                saveDialog.Title = "Сохранить чек";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".pdf":
                            SaveAsPDFWithMicrosoftPrintToPDF(saveDialog.FileName);
                            break;
                        case ".html":
                            SaveAsHTML(saveDialog.FileName);
                            break;
                        default:
                            SaveReceiptAsText(saveDialog.FileName);
                            break;
                    }

                    try
                    {
                        if (File.Exists(saveDialog.FileName))
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsPDFWithMicrosoftPrintToPDF(string pdfFilePath)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintReceiptPage;

                // Ищем Microsoft Print to PDF
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
                    MessageBox.Show("Принтер 'Microsoft Print to PDF' не найден.\n\nСохранено как текстовый файл.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SaveReceiptAsText(pdfFilePath.Replace(".pdf", ".txt"));
                    return;
                }

                // Настройки печати
                pd.PrinterSettings.PrinterName = pdfPrinterName;
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = pdfFilePath;

                // Настройка размера страницы
                foreach (PaperSize size in pd.PrinterSettings.PaperSizes)
                {
                    if (size.Kind == PaperKind.A4)
                    {
                        pd.DefaultPageSettings.PaperSize = size;
                        break;
                    }
                }

                pd.DefaultPageSettings.Landscape = false;
                pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                // Создаем PDF
                pd.Print();

                MessageBox.Show($"Чек успешно сохранен в PDF:\n{pdfFilePath}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении PDF: {ex.Message}\nСохранено как текстовый файл.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SaveReceiptAsText(pdfFilePath.Replace(".pdf", ".txt"));
            }
        }

        private void SaveReceiptAsText(string filePath)
        {
            try
            {
                StringBuilder txt = new StringBuilder();

                txt.AppendLine("БАЗА ОТДЫХА \"ПРЕМИУМ КОТТЕДЖИ\"");
                txt.AppendLine(new string('=', 50));
                txt.AppendLine($"КАССОВЫЙ ЧЕК № {orderId:00000}");
                txt.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}");
                txt.AppendLine();

                txt.AppendLine("КЛИЕНТ:");
                txt.AppendLine($"ФИО: {labelClientName.Text.Replace("Клиент: ", "")}");
                txt.AppendLine(labelClientPassport.Text);
                txt.AppendLine(labelClientPhone.Text);
                txt.AppendLine(labelClientEmail.Text);
                txt.AppendLine();

                txt.AppendLine("ПРОЖИВАНИЕ:");
                txt.AppendLine(labelHouseName.Text);
                txt.AppendLine(labelHouseClass.Text);
                txt.AppendLine(labelHouseAddress.Text);
                txt.AppendLine(labelHouseCapacity.Text);
                txt.AppendLine(labelHouseDescription.Text);
                txt.AppendLine($"Дата заезда: {checkInDate:dd.MM.yyyy}");
                txt.AppendLine($"Дата выезда: {checkOutDate:dd.MM.yyyy}");
                txt.AppendLine($"Период проживания: {stayDays} дней");
                txt.AppendLine($"Стоимость проживания: {houseTotal:N2} ₽");
                txt.AppendLine();

                if (servicesList.Count > 0)
                {
                    txt.AppendLine("ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ:");
                    txt.AppendLine(new string('-', 70));
                    txt.AppendLine(string.Format("{0,-30} {1,-8} {2,-15} {3,-15}",
                        "Услуга", "Кол-во", "Цена за ед.", "Общая стоимость"));
                    txt.AppendLine(new string('-', 70));

                    foreach (var service in servicesList)
                    {
                        string serviceName = service.Name.Length > 30 ?
                            service.Name.Substring(0, 27) + "..." : service.Name;
                        decimal totalPrice = service.Price * service.Quantity;

                        txt.AppendLine(string.Format("{0,-30} {1,-8} {2,-15} {3,-15}",
                            serviceName,
                            service.Quantity,
                            $"{service.Price:N2} ₽",
                            $"{totalPrice:N2} ₽"));
                    }

                    txt.AppendLine(new string('-', 70));
                    txt.AppendLine($"Итого услуг: {servicesTotal:N2} ₽");
                    txt.AppendLine();
                }

                txt.AppendLine("ИТОГ:");
                txt.AppendLine(new string('=', 50));
                txt.AppendLine($"Стоимость проживания: {houseTotal:N2} ₽");
                txt.AppendLine($"Дополнительные услуги: {servicesTotal:N2} ₽");
                txt.AppendLine(new string('-', 40));
                txt.AppendLine($"ВСЕГО К ОПЛАТЕ: {grandTotal:N2} ₽");
                txt.AppendLine($"({labelAmountInWords.Text})");
                txt.AppendLine();

                txt.AppendLine(new string('_', 40));
                txt.AppendLine(labelStaffName.Text);
                txt.AppendLine(labelStaffLogin.Text);
                txt.AppendLine("Подпись сотрудника: _________________________");
                txt.AppendLine();
                txt.AppendLine("СПАСИБО ЗА ВАШ ЗАКАЗ!");

                File.WriteAllText(filePath, txt.ToString(), Encoding.UTF8);

                MessageBox.Show($"Чек успешно сохранен:\n{filePath}",
                    "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения текстового файла: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsHTML(string htmlFilePath)
        {
            try
            {
                StringBuilder html = new StringBuilder();

                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html lang='ru'>");
                html.AppendLine("<head>");
                html.AppendLine("    <meta charset='UTF-8'>");
                html.AppendLine("    <meta name='viewport' content='width=device-width, initial-scale=1.0'>");
                html.AppendLine($"    <title>Чек №{orderId}</title>");
                html.AppendLine("    <style>");
                html.AppendLine("        body { font-family: Arial, sans-serif; margin: 40px; line-height: 1.6; color: #333; }");
                html.AppendLine("        .header { text-align: center; margin-bottom: 30px; }");
                html.AppendLine("        .title { font-size: 24px; font-weight: bold; color: #2c3e50; }");
                html.AppendLine("        .receipt-number { font-size: 18px; color: #27ae60; font-weight: bold; margin: 20px 0; }");
                html.AppendLine("        .section { margin-bottom: 25px; border-bottom: 1px solid #eee; padding-bottom: 15px; }");
                html.AppendLine("        .section-title { font-weight: bold; color: #2c3e50; margin-bottom: 10px; font-size: 16px; }");
                html.AppendLine("        .item { margin-bottom: 5px; }");
                html.AppendLine("        .total { font-weight: bold; font-size: 18px; color: #27ae60; margin-top: 20px; }");
                html.AppendLine("        table { width: 100%; border-collapse: collapse; margin: 20px 0; }");
                html.AppendLine("        th { background-color: #f8f9fa; padding: 12px; text-align: left; border: 1px solid #dee2e6; font-weight: bold; }");
                html.AppendLine("        td { padding: 12px; border: 1px solid #dee2e6; }");
                html.AppendLine("        .signature { margin-top: 40px; border-top: 1px solid #333; padding-top: 20px; }");
                html.AppendLine("        .footer { text-align: center; margin-top: 40px; font-style: italic; color: #7f8c8d; }");
                html.AppendLine("        .stay-dates { background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0; }");
                html.AppendLine("    </style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");

                html.AppendLine("    <div class='header'>");
                html.AppendLine("        <div class='title'>БАЗА ОТДЫХА \"ПРЕМИУМ КОТТЕДЖИ\"</div>");
                html.AppendLine($"        <div class='receipt-number'>КАССОВЫЙ ЧЕК № {orderId:00000}</div>");
                html.AppendLine($"        <div>Дата: {DateTime.Now:dd.MM.yyyy HH:mm}</div>");
                html.AppendLine("    </div>");

                html.AppendLine("    <div class='section'>");
                html.AppendLine("        <div class='section-title'>КЛИЕНТ</div>");
                html.AppendLine($"        <div class='item'>ФИО: {labelClientName.Text.Replace("Клиент: ", "")}</div>");
                html.AppendLine($"        <div class='item'>{labelClientPassport.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelClientPhone.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelClientEmail.Text}</div>");
                html.AppendLine("    </div>");

                html.AppendLine("    <div class='section'>");
                html.AppendLine("        <div class='section-title'>ПРОЖИВАНИЕ</div>");
                html.AppendLine($"        <div class='item'>{labelHouseName.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelHouseClass.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelHouseAddress.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelHouseCapacity.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelHouseDescription.Text}</div>");

                html.AppendLine("        <div class='stay-dates'>");
                html.AppendLine($"            <div class='item'><strong>Дата заезда:</strong> {checkInDate:dd.MM.yyyy}</div>");
                html.AppendLine($"            <div class='item'><strong>Дата выезда:</strong> {checkOutDate:dd.MM.yyyy}</div>");
                html.AppendLine($"            <div class='item'><strong>Период проживания:</strong> {stayDays} дней</div>");
                html.AppendLine($"            <div class='item'><strong>Стоимость проживания:</strong> {houseTotal:N2} ₽</div>");
                html.AppendLine("        </div>");
                html.AppendLine("    </div>");

                if (servicesList.Count > 0)
                {
                    html.AppendLine("    <div class='section'>");
                    html.AppendLine("        <div class='section-title'>ДОПОЛНИТЕЛЬНЫЕ УСЛУГИ</div>");
                    html.AppendLine("        <table>");
                    html.AppendLine("            <thead>");
                    html.AppendLine("                <tr>");
                    html.AppendLine("                    <th>Услуга</th>");
                    html.AppendLine("                    <th>Кол-во</th>");
                    html.AppendLine("                    <th>Цена за ед.</th>");
                    html.AppendLine("                    <th>Общая стоимость</th>");
                    html.AppendLine("                </tr>");
                    html.AppendLine("            </thead>");
                    html.AppendLine("            <tbody>");

                    foreach (var service in servicesList)
                    {
                        decimal totalPrice = service.Price * service.Quantity;

                        html.AppendLine("                <tr>");
                        html.AppendLine($"                    <td>{service.Name}</td>");
                        html.AppendLine($"                    <td>{service.Quantity}</td>");
                        html.AppendLine($"                    <td>{service.Price:N2} ₽</td>");
                        html.AppendLine($"                    <td>{totalPrice:N2} ₽</td>");
                        html.AppendLine("                </tr>");
                    }

                    html.AppendLine("            </tbody>");
                    html.AppendLine("        </table>");
                    html.AppendLine($"        <div class='item'><strong>Итого услуг:</strong> {servicesTotal:N2} ₽</div>");
                    html.AppendLine("    </div>");
                }

                html.AppendLine("    <div class='section'>");
                html.AppendLine("        <div class='section-title'>ИТОГ</div>");
                html.AppendLine($"        <div class='item'><strong>Стоимость проживания:</strong> {houseTotal:N2} ₽</div>");
                html.AppendLine($"        <div class='item'><strong>Дополнительные услуги:</strong> {servicesTotal:N2} ₽</div>");
                html.AppendLine($"        <div class='total'>ВСЕГО К ОПЛАТЕ: {grandTotal:N2} ₽</div>");
                html.AppendLine($"        <div class='item'>({labelAmountInWords.Text})</div>");
                html.AppendLine("    </div>");

                html.AppendLine("    <div class='signature'>");
                html.AppendLine($"        <div class='item'>{labelStaffName.Text}</div>");
                html.AppendLine($"        <div class='item'>{labelStaffLogin.Text}</div>");
                html.AppendLine("        <div class='item'>Подпись сотрудника: _________________________</div>");
                html.AppendLine("    </div>");

                html.AppendLine("    <div class='footer'>");
                html.AppendLine("        СПАСИБО ЗА ВАШ ЗАКАЗ!");
                html.AppendLine("    </div>");

                html.AppendLine("</body>");
                html.AppendLine("</html>");

                File.WriteAllText(htmlFilePath, html.ToString(), Encoding.UTF8);

                MessageBox.Show($"Чек успешно сохранен как HTML:\n{htmlFilePath}",
                    "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить HTML: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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