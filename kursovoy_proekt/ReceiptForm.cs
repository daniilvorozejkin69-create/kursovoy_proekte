using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private string clientFIO;
        private string clientPassport;
        private string clientPhone;
        private string clientEmail;
        private DateTime clientBirthDate;

        private string houseName;
        private string houseClass;
        private string houseAddress;
        private int houseCapacity;
        private string houseDescription;
        private decimal pricePerDay;

        private string staffFIO;
        private string staffLogin;

        private int currentPage = 0;

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
            this.contractNumber = $"Д-{DateTime.Now.Year}-{orderId:00000}";

            InitializeDataGridView();
            LoadData();
            LoadServicesToGrid();
            CalculateTotals();
            DisplayData();
        }

        private void InitializeDataGridView()
        {
            if (dataGridViewServices == null) return;

            dataGridViewServices.AutoGenerateColumns = false;
            dataGridViewServices.Columns.Clear();

            dataGridViewServices.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Услуга", Width = 250 },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Кол-во", Width = 60 },
                new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Цена, ₽", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Сумма, ₽", Width = 100 }
            );

            dataGridViewServices.RowHeadersVisible = false;
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.ReadOnly = true;
            dataGridViewServices.BackgroundColor = Color.White;
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string queryClient = "SELECT FIO, passport_series_number, telephone_number, email, date_of_birth FROM client WHERE id = @clientId";
                    using (MySqlCommand cmd = new MySqlCommand(queryClient, connection))
                    {
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientFIO = reader["FIO"].ToString();
                                clientPassport = reader["passport_series_number"].ToString();
                                clientPhone = reader["telephone_number"].ToString();
                                clientEmail = reader["email"].ToString();
                                if (reader["date_of_birth"] != DBNull.Value)
                                    clientBirthDate = Convert.ToDateTime(reader["date_of_birth"]);
                            }
                        }
                    }

                    string queryHouse = @"SELECT h.name, hc.class, h.address_number, h.capacity, h.description 
                                         FROM house h JOIN home_class hc ON h.home_class_id = hc.id 
                                         WHERE h.id = @houseId";
                    using (MySqlCommand cmd = new MySqlCommand(queryHouse, connection))
                    {
                        cmd.Parameters.AddWithValue("@houseId", houseId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                houseName = reader["name"].ToString();
                                houseClass = reader["class"].ToString();
                                houseAddress = reader["address_number"].ToString();
                                houseCapacity = Convert.ToInt32(reader["capacity"]);
                                houseDescription = reader["description"].ToString();

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

                    LoadCurrentUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void LoadCurrentUser()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.FIO, u.login FROM users u 
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
                            else { staffFIO = "Не указан"; staffLogin = "-"; }
                        }
                    }
                }
            }
            catch { staffFIO = "Ошибка"; staffLogin = "-"; }
        }

        private void LoadServicesToGrid()
        {
            if (dataGridViewServices == null) return;
            dataGridViewServices.Rows.Clear();
            servicesTotal = 0;
            foreach (var service in servicesList)
            {
                decimal total = service.Price * service.Quantity;
                dataGridViewServices.Rows.Add(service.Name, service.Quantity, service.Price, total);
                servicesTotal += total;
            }
        }

        private void CalculateTotals()
        {
            servicesTotal = servicesList.Sum(s => s.Price * s.Quantity);
            grandTotal = houseTotal + servicesTotal;
        }

        private void DisplayData()
        {
            labelOrderNumber.Text = $"ДОГОВОР № {contractNumber}";
            labelOrderDate.Text = $"г. Москва, {DateTime.Now:dd MMMM yyyy} г.";
            labelClientName.Text = clientFIO;
            labelClientPassport.Text = $"Паспорт: {clientPassport}";
            labelHouseName.Text = $"Дом: {houseName}";
            labelHouseClass.Text = $"Класс: {houseClass}";
            labelTotalCost.Text = $"ИТОГО: {grandTotal:N2} ₽";
            labelAmountInWords.Text = NumberToWords((int)Math.Round(grandTotal));
        }

        // ==========================================
        // КНОПКИ
        // ==========================================
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPageHandler;
                pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                {
                    if (ps.Kind == PaperKind.A4)
                    {
                        pd.DefaultPageSettings.PaperSize = ps;
                        break;
                    }
                }

                PrintDialog dlg = new PrintDialog { Document = pd };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    currentPage = 0;
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}");
            }
        }

        private void buttonSavePDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF файлы (*.pdf)|*.pdf",
                    FileName = $"Договор_{contractNumber}_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += PrintPageHandler;
                    pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                    foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                    {
                        if (ps.Kind == PaperKind.A4)
                        {
                            pd.DefaultPageSettings.PaperSize = ps;
                            break;
                        }
                    }

                    string printer = "";
                    foreach (string p in PrinterSettings.InstalledPrinters)
                    {
                        if (p.ToLower().Contains("pdf") || p.ToLower().Contains("adobe"))
                        { printer = p; break; }
                    }

                    if (string.IsNullOrEmpty(printer))
                    {
                        MessageBox.Show("PDF принтер не найден! Установите Microsoft Print to PDF.", "Ошибка");
                        return;
                    }

                    pd.PrinterSettings.PrinterName = printer;
                    pd.PrinterSettings.PrintToFile = true;
                    pd.PrinterSettings.PrintFileName = sfd.FileName;

                    currentPage = 0;
                    pd.Print();

                    if (System.IO.File.Exists(sfd.FileName))
                    {
                        MessageBox.Show($"Договор сохранен:\n{sfd.FileName}", "Готово",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения PDF: {ex.Message}", "Ошибка");
            }
        }

        // ==========================================
        // ПЕЧАТЬ ДОГОВОРА
        // ==========================================
        // Полная замена PrintPageHandler + PrintSignatures

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;
            float bottom = e.MarginBounds.Bottom;
            float centerX = left + width / 2;

            // Шрифты
            Font titleFont = new Font("Times New Roman", 14, FontStyle.Bold);
            Font sectionFont = new Font("Times New Roman", 11, FontStyle.Bold);
            Font normalFont = new Font("Times New Roman", 9.5f);
            Font smallFont = new Font("Times New Roman", 8);
            Font tinyFont = new Font("Times New Roman", 7);
            Font italicFont = new Font("Times New Roman", 8.5f, FontStyle.Italic);

            Pen linePen = new Pen(Color.Black, 0.5f);
            Pen thickPen = new Pen(Color.Black, 1.5f);

            float y = top;
            float lineH = normalFont.GetHeight() + 1.5f;
            float maxY = bottom - 10;

            // Функция проверки выхода за границу
            bool CheckSpace(float needed)
            {
                if (y + needed > maxY)
                {
                    e.HasMorePages = true;
                    return true;
                }
                return false;
            }

            // ==================== СТРАНИЦА 1 ====================
            if (currentPage == 0)
            {
                // ЗАГОЛОВОК
                string title = "ДОГОВОР";
                SizeF sz = g.MeasureString(title, titleFont);
                g.DrawString(title, titleFont, Brushes.Black, centerX - sz.Width / 2, y);
                y += sz.Height + 3;

                string sub = "краткосрочной аренды жилого помещения";
                sz = g.MeasureString(sub, new Font("Times New Roman", 10, FontStyle.Bold));
                g.DrawString(sub, new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, centerX - sz.Width / 2, y);
                y += sz.Height + 10;

                sz = g.MeasureString($"№ {contractNumber}", sectionFont);
                g.DrawString($"№ {contractNumber}", sectionFont, Brushes.Black, centerX - sz.Width / 2, y);
                y += sz.Height + 15;

                g.DrawString("г. Москва", normalFont, Brushes.Black, left, y);
                g.DrawString(DateTime.Now.ToString("«dd» MMMM yyyy года"), normalFont, Brushes.Black, left + 350, y);
                y += lineH + 15;

                // 1. ТЕРМИНЫ
                g.DrawString("1. ТЕРМИНЫ И ОПРЕДЕЛЕНИЯ", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] terms = {
            "1.1. «Арендодатель» — ООО «Премиум Коттеджи» (ОГРН 1234567890123, ИНН 1234567890), в лице Генерального директора Иванова И.И., действующего на основании Устава.",
            $"1.2. «Арендатор» — гражданин(ка) РФ {clientFIO}, паспорт {clientPassport}, тел.: {clientPhone}, email: {clientEmail}.",
            "1.3. «Объект аренды» — жилое помещение (дом), предоставляемое Арендодателем Арендатору во временное пользование за плату.",
            "1.4. «Расчетный час» — время заезда (14:00) и выезда (12:00)."
        };

                foreach (string s in terms)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 1; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }
                y += 8;

                // 2. ПРЕДМЕТ ДОГОВОРА
                if (CheckSpace(lineH + 10)) { currentPage = 1; return; }
                g.DrawString("2. ПРЕДМЕТ ДОГОВОРА", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] subject = {
            "2.1. Арендодатель передает, а Арендатор принимает во временное пользование жилой дом для временного проживания.",
            "2.2. Объект принадлежит Арендодателю на праве собственности (свидетельство 77-АБ № 123456 от 15.01.2020).",
            "2.3. Объект не заложен, не под арестом, свободен от прав третьих лиц.",
            "2.4. Субаренда запрещена без письменного согласия Арендодателя."
        };

                foreach (string s in subject)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 1; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }
                y += 5;

                // Характеристики
                if (CheckSpace(lineH + 5)) { currentPage = 1; return; }
                g.DrawString("2.5. Характеристики Объекта:", sectionFont, Brushes.Black, left + 15, y);
                y += lineH + 3;

                float boxY = y;
                float boxH = lineH * 7 + 10;
                if (CheckSpace(boxH + 10)) { currentPage = 1; return; }

                g.DrawRectangle(linePen, new Rectangle((int)(left + 15), (int)y, (int)(width - 30), (int)boxH));
                y += 5;

                string[] specs = {
            $"Наименование: {houseName}",
            $"Класс: {houseClass}",
            $"Адрес: МО, база отдыха «Премиум Коттеджи», участок №{houseAddress}",
            $"Площадь: {houseCapacity * 20} кв.м. | Вместимость: до {houseCapacity} чел.",
            $"Описание: {houseDescription}",
            $"Цена за сутки: {pricePerDay:N2} ₽"
        };

                foreach (string s in specs)
                {
                    g.DrawString(s, normalFont, Brushes.Black, left + 25, y);
                    y += lineH;
                }
                y = boxY + boxH + 10;

                // 3. СРОК АРЕНДЫ
                if (CheckSpace(lineH + 5)) { currentPage = 1; return; }
                g.DrawString("3. СРОК АРЕНДЫ", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] period = {
            $"3.1. Срок аренды: с {checkInDate:dd.MM.yyyy} (заезд 14:00) по {checkOutDate:dd.MM.yyyy} (выезд 12:00). Продолжительность: {stayDays} {GetDaysWord(stayDays)}.",
            "3.2. Ранний заезд / поздний выезд — по согласованию, оплачиваются дополнительно (50% от суточной ставки).",
            "3.3. Продление — по дополнительному соглашению Сторон.",
            "3.4. При досрочном выезде оплата за неиспользованные сутки не возвращается."
        };

                foreach (string s in period)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 1; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }
                y += 10;

                // Проверка: осталось ли место для подписей?
                if (y > maxY - 200)
                {
                    currentPage = 1;
                    e.HasMorePages = true;
                    return;
                }

                // Если всё поместилось — рисуем подписи на этой же странице
                DrawSignatures(g, left, width, bottom, sectionFont, normalFont, smallFont, tinyFont, thickPen, lineH);
                currentPage = 0;
                e.HasMorePages = false;
                return;
            }

            // ==================== СТРАНИЦА 2 ====================
            if (currentPage == 1)
            {
                y = top;

                // 4. АРЕНДНАЯ ПЛАТА
                g.DrawString("4. АРЕНДНАЯ ПЛАТА И ПОРЯДОК РАСЧЕТОВ", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] payment = {
            $"4.1. Арендная плата: {houseTotal:N2} ₽ ({NumberToWords((int)Math.Round(houseTotal))}).",
            "4.2. В стоимость включено: проживание, коммунальные услуги, парковка, постельное белье, финальная уборка.",
            "4.3. Не включено: дополнительная уборка, смена белья, баня, трансфер — оплачиваются отдельно."
        };

                foreach (string s in payment)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 2; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }

                if (servicesList != null && servicesList.Count > 0)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 2; return; }
                    y = DrawBlock(g, $"4.4. Дополнительные услуги: {servicesTotal:N2} ₽:", normalFont, left + 15, y, width - 30);
                    y += 3;

                    foreach (var svc in servicesList)
                    {
                        if (CheckSpace(lineH)) { currentPage = 2; return; }
                        decimal t = svc.Price * svc.Quantity;
                        g.DrawString($"• {svc.Name}: {svc.Quantity} × {svc.Price:N2} = {t:N2} ₽", smallFont, Brushes.Black, left + 30, y);
                        y += smallFont.GetHeight() + 1;
                    }
                    y += 5;
                }

                // ИТОГО
                if (CheckSpace(55)) { currentPage = 2; return; }
                Rectangle totalRect = new Rectangle((int)(left + 15), (int)y, (int)(width - 30), 45);
                g.FillRectangle(Brushes.LightGray, totalRect);
                g.DrawRectangle(thickPen, totalRect);
                g.DrawString($"ИТОГО: {grandTotal:N2} ₽", sectionFont, Brushes.Black, left + 25, y + 5);
                g.DrawString($"({labelAmountInWords.Text})", italicFont, Brushes.Black, left + 25, y + 23);
                y += 55;

                if (CheckSpace(lineH * 2)) { currentPage = 2; return; }
                y = DrawBlock(g, "4.5. Оплата 100% не позднее дня заезда. Наличный или безналичный расчет.", normalFont, left + 15, y, width - 30);
                y += 12;

                // 5. ПРАВА И ОБЯЗАННОСТИ
                if (CheckSpace(lineH + 5)) { currentPage = 2; return; }
                g.DrawString("5. ПРАВА И ОБЯЗАННОСТИ СТОРОН", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                g.DrawString("Арендодатель обязан:", sectionFont, Brushes.Black, left + 15, y);
                y += lineH + 2;

                string[] landlord = {
            "• Передать Объект в пригодном для проживания состоянии.",
            "• Обеспечить работу инженерных систем.",
            "• Предоставить информацию о правилах проживания."
        };

                foreach (string s in landlord)
                {
                    if (CheckSpace(lineH)) { currentPage = 2; return; }
                    g.DrawString(s, smallFont, Brushes.Black, left + 30, y);
                    y += smallFont.GetHeight() + 1;
                }
                y += 5;

                g.DrawString("Арендатор обязан:", sectionFont, Brushes.Black, left + 15, y);
                y += lineH + 2;

                string[] tenant = {
            "• Использовать Объект только для проживания.",
            "• Своевременно оплачивать аренду.",
            "• Соблюдать тишину с 22:00 до 08:00.",
            "• Соблюдать пожарную безопасность (не курить в доме).",
            "• Бережно относиться к имуществу.",
            "• Освободить Объект в расчетный час.",
            "• Возместить ущерб при порче имущества.",
            "• Не передавать Объект третьим лицам."
        };

                foreach (string s in tenant)
                {
                    if (CheckSpace(lineH)) { currentPage = 2; return; }
                    g.DrawString(s, smallFont, Brushes.Black, left + 30, y);
                    y += smallFont.GetHeight() + 1;
                }
                y += 10;

                // 6. ОТВЕТСТВЕННОСТЬ
                if (CheckSpace(lineH + 5)) { currentPage = 2; return; }
                g.DrawString("6. ОТВЕТСТВЕННОСТЬ", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] resp = {
            "6.1. Арендатор возмещает ущерб имуществу в полном объеме по рыночной стоимости.",
            "6.2. При задержке выезда — штраф в размере стоимости суток аренды.",
            "6.3. Арендодатель не отвечает за ценные вещи, оставленные без присмотра.",
            "6.4. Стороны освобождаются от ответственности при форс-мажоре."
        };

                foreach (string s in resp)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 2; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }
                y += 10;

                // 7. ЗАКЛЮЧИТЕЛЬНЫЕ ПОЛОЖЕНИЯ
                if (CheckSpace(lineH + 5)) { currentPage = 2; return; }
                g.DrawString("7. ЗАКЛЮЧИТЕЛЬНЫЕ ПОЛОЖЕНИЯ", sectionFont, Brushes.Black, left, y);
                y += lineH + 5;

                string[] final = {
            "7.1. Договор вступает в силу с момента подписания.",
            "7.2. Изменения — в письменной форме.",
            "7.3. Договор составлен в 2-х экземплярах.",
            "7.4. Споры разрешаются путем переговоров, затем в судебном порядке."
        };

                foreach (string s in final)
                {
                    if (CheckSpace(lineH * 2)) { currentPage = 2; return; }
                    y = DrawBlock(g, s, normalFont, left + 15, y, width - 30);
                    y += 2;
                }
                y += 15;

                // Проверка места для подписей
                if (y > maxY - 220)
                {
                    currentPage = 2;
                    e.HasMorePages = true;
                    return;
                }

                DrawSignatures(g, left, width, bottom, sectionFont, normalFont, smallFont, tinyFont, thickPen, lineH);
                currentPage = 0;
                e.HasMorePages = false;
                return;
            }

            // ==================== СТРАНИЦА 3 (ТОЛЬКО ПОДПИСИ) ====================
            if (currentPage == 2)
            {
                DrawSignatures(g, left, width, bottom, sectionFont, normalFont, smallFont, tinyFont, thickPen, lineH);
                currentPage = 0;
                e.HasMorePages = false;
                return;
            }

            e.HasMorePages = false;
        }

        // ==========================================
        // МЕТОД ПОДПИСЕЙ (исправленный)
        // ==========================================
        private void DrawSignatures(Graphics g, float left, float width, float bottom,
            Font sectionFont, Font normalFont, Font smallFont, Font tinyFont, Pen thickPen, float lineH)
        {
            float signStartY = bottom - 230;

            // Заголовок раздела
            g.DrawString("8. АДРЕСА, РЕКВИЗИТЫ И ПОДПИСИ СТОРОН", sectionFont, Brushes.Black, left, signStartY);
            signStartY += lineH + 8;

            // Линия-разделитель
            g.DrawLine(thickPen, left, signStartY, left + width, signStartY);
            signStartY += 15;

            float colLeft = left;
            float colRight = left + width / 2 + 10;
            float colWidth = width / 2 - 20;

            // === АРЕНДОДАТЕЛЬ ===
            float yLeft = signStartY;

            g.DrawString("АРЕНДОДАТЕЛЬ:", sectionFont, Brushes.Black, colLeft, yLeft);
            yLeft += lineH + 5;

            string[] landlordData = {
        "ООО «Премиум Коттеджи»",
        "ОГРН: 1234567890123",
        "ИНН/КПП: 1234567890 / 123456789",
        "Адрес: 123456, г. Москва,",
        "ул. Лесная, д. 10",
        "Тел.: +7 (495) 123-45-67",
        "Email: info@premium-cottages.ru",
        "",
        "Банковские реквизиты:",
        "Р/с: 40702810000000012345",
        "Банк: ПАО Сбербанк",
        "К/с: 30101810400000000225",
        "БИК: 044525225"
    };

            foreach (string s in landlordData)
            {
                g.DrawString(s, smallFont, Brushes.Black, colLeft, yLeft);
                yLeft += smallFont.GetHeight() + 1;
            }

            // Место для подписи и печати
            yLeft += 20;
            g.DrawString("__________________________", normalFont, Brushes.Black, colLeft, yLeft);
            yLeft += lineH + 3;
            g.DrawString("Генеральный директор", tinyFont, Brushes.Black, colLeft, yLeft);
            yLeft += tinyFont.GetHeight() + 1;
            g.DrawString("Иванов И.И.", tinyFont, Brushes.Black, colLeft, yLeft);
            yLeft += 20;

            // Прямоугольник для печати
            g.DrawRectangle(thickPen, new Rectangle((int)colLeft, (int)yLeft, 70, 70));
            g.DrawString("Место", tinyFont, Brushes.Gray, colLeft + 22, yLeft + 25);
            g.DrawString("для", tinyFont, Brushes.Gray, colLeft + 27, yLeft + 38);
            g.DrawString("печати", tinyFont, Brushes.Gray, colLeft + 20, yLeft + 51);

            // === АРЕНДАТОР ===
            float yRight = signStartY;

            g.DrawString("АРЕНДАТОР:", sectionFont, Brushes.Black, colRight, yRight);
            yRight += lineH + 5;

            string[] tenantData = {
        clientFIO,
        $"Паспорт: {clientPassport}",
        "Выдан: _________________",
        "Дата выдачи: ___________",
        "Код подразделения: _____",
        "Адрес регистрации:",
        "______________________",
        $"Тел.: {clientPhone}",
        $"Email: {clientEmail}"
    };

            foreach (string s in tenantData)
            {
                g.DrawString(s, smallFont, Brushes.Black, colRight, yRight);
                yRight += smallFont.GetHeight() + 1;
            }

            // Место для подписи
            yRight += 20;
            g.DrawString("__________________________", normalFont, Brushes.Black, colRight, yRight);
            yRight += lineH + 3;
            g.DrawString(GetShortName(clientFIO), tinyFont, Brushes.Black, colRight, yRight);
            yRight += tinyFont.GetHeight() + 1;
            g.DrawString(DateTime.Now.ToString("«dd» MMMM yyyy г."), tinyFont, Brushes.Black, colRight, yRight);

            // Информация о системе
            g.DrawString($"Сформировано: {DateTime.Now:dd.MM.yyyy HH:mm} | Сотрудник: {staffFIO} | Система Premium Cottages",
                new Font("Times New Roman", 5.5f), Brushes.Gray, left, bottom - 8);
        }

        // Метод подписей
        private void PrintSignatures(Graphics g, float left, float width, float bottom,
            Font sectionFont, Font normalFont, Font smallFont, Pen thickPen, float lineH)
        {
            float signY = bottom - 140;

            g.DrawLine(thickPen, left, signY, left + width, signY);
            signY += 15;

            float colLeft = left;
            float colRight = left + width / 2;

            // АРЕНДОДАТЕЛЬ
            g.DrawString("АРЕНДОДАТЕЛЬ:", sectionFont, Brushes.Black, colLeft, signY);
            signY += lineH + 3;

            g.DrawString("ООО «Премиум Коттеджи»", smallFont, Brushes.Black, colLeft, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString("ИНН 1234567890", smallFont, Brushes.Black, colLeft, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString("г. Москва, ул. Лесная, д. 10", smallFont, Brushes.Black, colLeft, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString("Тел.: +7 (495) 123-45-67", smallFont, Brushes.Black, colLeft, signY);
            signY += smallFont.GetHeight() + 8;

            g.DrawString("_______________ /Иванов И.И./", normalFont, Brushes.Black, colLeft, signY);
            signY += lineH;
            g.DrawString("М.П.", normalFont, Brushes.Black, colLeft, signY);

            // АРЕНДАТОР
            signY = bottom - 140 + 15 + lineH + 3;

            g.DrawString("АРЕНДАТОР:", sectionFont, Brushes.Black, colRight, signY);
            signY += lineH + 3;

            g.DrawString(clientFIO, smallFont, Brushes.Black, colRight, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString($"Паспорт: {clientPassport}", smallFont, Brushes.Black, colRight, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString($"Тел.: {clientPhone}", smallFont, Brushes.Black, colRight, signY);
            signY += smallFont.GetHeight() + 1;
            g.DrawString($"Email: {clientEmail}", smallFont, Brushes.Black, colRight, signY);
            signY += smallFont.GetHeight() + 8;

            g.DrawString($"_______________ /{GetShortName(clientFIO)}/", normalFont, Brushes.Black, colRight, signY);
            signY += lineH;
            g.DrawString(DateTime.Now.ToString("dd.MM.yyyy"), smallFont, Brushes.Black, colRight, signY);

            g.DrawString($"Создано: {DateTime.Now:dd.MM.yyyy HH:mm} | {staffFIO}",
                new Font("Times New Roman", 6), Brushes.Gray, left, bottom - 10);
        }

        // Вспомогательные методы
        private float DrawBlock(Graphics g, string text, Font font, float x, float y, float width)
        {
            SizeF sz = g.MeasureString(text, font, (int)width);
            RectangleF rect = new RectangleF(x, y, width, sz.Height + 3);
            g.DrawString(text, font, Brushes.Black, rect);
            return y + sz.Height + 3;
        }

        private string GetShortName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return "";
            var parts = fullName.Split(' ');
            if (parts.Length >= 2)
                return $"{parts[0]} {parts[1][0]}." + (parts.Length > 2 ? $" {parts[2][0]}." : "");
            return fullName;
        }

        private string NumberToWords(int number)
        {
            if (number == 0) return "Ноль рублей 00 копеек";
            string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] unitsF = { "", "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] teens = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] tens = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };

            StringBuilder result = new StringBuilder();
            if (number >= 1000000) { int m = number / 1000000; AddPart(m, result, units, unitsF, teens, tens, hundreds, new[] { "", "миллион", "миллиона", "миллионов" }, false); number %= 1000000; }
            if (number >= 1000) { int t = number / 1000; AddPart(t, result, units, unitsF, teens, tens, hundreds, new[] { "", "тысяча", "тысячи", "тысяч" }, true); number %= 1000; }
            if (number > 0) AddPart(number, result, units, unitsF, teens, tens, hundreds, new[] { "", "", "", "" }, false);

            int lastTwo = number % 100, lastOne = number % 10;
            if (lastTwo >= 11 && lastTwo <= 14) result.Append("рублей");
            else if (lastOne == 1) result.Append("рубль");
            else if (lastOne >= 2 && lastOne <= 4) result.Append("рубля");
            else result.Append("рублей");

            string res = result.ToString().Trim();
            if (res.Length > 0) res = char.ToUpper(res[0]) + res.Substring(1);
            return res + " 00 копеек";
        }

        private void AddPart(int n, StringBuilder sb, string[] u, string[] uf, string[] tn, string[] ts, string[] h, string[] names, bool female)
        {
            if (n >= 100) { sb.Append(h[n / 100] + " "); n %= 100; }
            if (n >= 20) { sb.Append(ts[n / 10] + " "); n %= 10; if (n > 0) sb.Append((female ? uf[n] : u[n]) + " "); }
            else if (n >= 10) sb.Append(tn[n - 10] + " ");
            else if (n > 0) sb.Append((female ? uf[n] : u[n]) + " ");

            if (names[0] != "")
            {
                int lt = n % 100;
                if (lt >= 11 && lt <= 14) sb.Append(names[3] + " ");
                else if (n % 10 == 1) sb.Append(names[1] + " ");
                else if (n % 10 >= 2 && n % 10 <= 4) sb.Append(names[2] + " ");
                else sb.Append(names[3] + " ");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewServices != null && dataGridViewServices.Rows.Count > 0)
                dataGridViewServices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (buttonClose != null)
                buttonClose.Focus();
        }
        private string GetDaysWord(int days)
        {
            int lastTwo = days % 100;
            int lastOne = days % 10;

            if (lastTwo >= 11 && lastTwo <= 14) return "суток";
            if (lastOne == 1) return "сутки";
            if (lastOne >= 2 && lastOne <= 4) return "суток";
            return "суток";
        }
    }
}