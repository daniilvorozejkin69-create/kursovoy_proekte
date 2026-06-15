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
        private int orderId, clientId, houseId, userId, stayDays;
        private decimal houseTotal, servicesTotal, grandTotal, pricePerDay;
        private List<ServiceItem> servicesList;
        private DateTime checkInDate, checkOutDate, clientBirthDate;
        private string contractNumber, clientFIO, clientPassport, clientPhone, clientEmail;
        private string houseName, houseClass, houseAddress, houseDescription;
        private int houseCapacity;
        private string staffFIO, staffLogin;
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
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = "SELECT FIO, passport_series_number, telephone_number, email, date_of_birth FROM client WHERE id=@id";
                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId);
                        using (var r = cmd.ExecuteReader())
                            if (r.Read())
                            {
                                clientFIO = r["FIO"].ToString();
                                clientPassport = r["passport_series_number"].ToString();
                                clientPhone = r["telephone_number"].ToString();
                                clientEmail = r["email"].ToString();
                                if (r["date_of_birth"] != DBNull.Value) clientBirthDate = Convert.ToDateTime(r["date_of_birth"]);
                            }
                    }
                    q = "SELECT h.name, hc.class, h.address_number, h.capacity, h.description FROM house h JOIN home_class hc ON h.home_class_id=hc.id WHERE h.id=@id";
                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", houseId);
                        using (var r = cmd.ExecuteReader())
                            if (r.Read())
                            {
                                houseName = r["name"].ToString();
                                houseClass = r["class"].ToString();
                                houseAddress = r["address_number"].ToString();
                                houseCapacity = Convert.ToInt32(r["capacity"]);
                                houseDescription = r["description"].ToString();
                                if (houseClass == "Эконом") pricePerDay = 3000;
                                else if (houseClass == "Комфорт") pricePerDay = 5000;
                                else if (houseClass == "Люкс") pricePerDay = 8000;
                                else if (houseClass == "Премиум") pricePerDay = 12000;
                                else if (houseClass == "Бизнес") pricePerDay = 10000;
                                else pricePerDay = 5000;
                            }
                    }
                    LoadCurrentUser();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
        }

        private void LoadCurrentUser()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = "SELECT p.FIO, u.login FROM users u JOIN personal p ON u.personal_id=p.id WHERE u.id=@id";
                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (var r = cmd.ExecuteReader())
                            if (r.Read()) { staffFIO = r["FIO"].ToString(); staffLogin = r["login"].ToString(); }
                            else { staffFIO = "Не указан"; staffLogin = "-"; }
                    }
                }
            }
            catch { staffFIO = "Ошибка"; staffLogin = "-"; }
        }
        public void PrintPageHandlerPublic(object sender, PrintPageEventArgs e)
        {
            PrintPageHandler(sender, e);
        }

        private void LoadServicesToGrid()
        {
            if (dataGridViewServices == null) return;
            dataGridViewServices.Rows.Clear();
            servicesTotal = 0;
            foreach (var s in servicesList)
            {
                decimal t = s.Price * s.Quantity;
                dataGridViewServices.Rows.Add(s.Name, s.Quantity, s.Price, t);
                servicesTotal += t;
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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPageHandler;
            pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                if (ps.Kind == PaperKind.A4) { pd.DefaultPageSettings.PaperSize = ps; break; }
            PrintDialog dlg = new PrintDialog { Document = pd };
            if (dlg.ShowDialog() == DialogResult.OK) { currentPage = 0; pd.Print(); }
        }

        private void buttonSavePDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF|*.pdf", FileName = $"Договор_{contractNumber}_{DateTime.Now:yyyyMMdd_HHmm}.pdf" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPageHandler;
            pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                if (ps.Kind == PaperKind.A4) { pd.DefaultPageSettings.PaperSize = ps; break; }
            string printer = "";
            foreach (string p in PrinterSettings.InstalledPrinters)
                if (p.ToLower().Contains("pdf")) { printer = p; break; }
            if (string.IsNullOrEmpty(printer)) { MessageBox.Show("PDF принтер не найден!"); return; }
            pd.PrinterSettings.PrinterName = printer;
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = sfd.FileName;
            currentPage = 0;
            pd.Print();
            if (System.IO.File.Exists(sfd.FileName)) { MessageBox.Show("Сохранено!"); System.Diagnostics.Process.Start(sfd.FileName); }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;
            float bottom = e.MarginBounds.Bottom;
            float cx = left + width / 2;

            Font tf = new Font("Times New Roman", 13, FontStyle.Bold);
            Font sf = new Font("Times New Roman", 10, FontStyle.Bold);
            Font nf = new Font("Times New Roman", 9);
            Font sm = new Font("Times New Roman", 7.5f);
            Font tn = new Font("Times New Roman", 6.5f);
            Pen lp = new Pen(Color.Black, 0.5f);
            Pen tp = new Pen(Color.Black, 1f);

            float y = top;
            float lh = nf.GetHeight() + 1.5f;

            float Draw(string text, Font font, float x, float yy, float w)
            {
                SizeF s = g.MeasureString(text, font, (int)w);
                g.DrawString(text, font, Brushes.Black, new RectangleF(x, yy, w, s.Height + 2));
                return yy + s.Height + 2;
            }

            // ===== ЗАГОЛОВОК =====
            string t = "ДОГОВОР";
            SizeF sz = g.MeasureString(t, tf);
            g.DrawString(t, tf, Brushes.Black, cx - sz.Width / 2, y); y += sz.Height + 2;
            t = "краткосрочной аренды жилого помещения";
            sz = g.MeasureString(t, new Font("Times New Roman", 9, FontStyle.Bold));
            g.DrawString(t, new Font("Times New Roman", 9, FontStyle.Bold), Brushes.Black, cx - sz.Width / 2, y); y += sz.Height + 6;
            t = $"№ {contractNumber}";
            sz = g.MeasureString(t, sf);
            g.DrawString(t, sf, Brushes.Black, cx - sz.Width / 2, y); y += sz.Height + 8;
            g.DrawString("г. Москва", nf, Brushes.Black, left, y);
            g.DrawString(DateTime.Now.ToString("«dd» MMMM yyyy года"), nf, Brushes.Black, left + 280, y); y += lh + 10;

            // ===== 1. СТОРОНЫ =====
            g.DrawString("1. СТОРОНЫ ДОГОВОРА", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw("1.1. ООО «Премиум Коттеджи» (ОГРН 1234567890123, ИНН 1234567890), в лице Генерального директора Иванова И.И., действующего на основании Устава, именуемое «Арендодатель», с одной стороны,", nf, left + 10, y, width - 20);
            y += 2;
            y = Draw($"1.2. Гражданин(ка) РФ {clientFIO}, паспорт {clientPassport}, тел.: {clientPhone}, email: {clientEmail}, именуемый(ая) «Арендатор», с другой стороны, заключили настоящий Договор о нижеследующем:", nf, left + 10, y, width - 20);
            y += 8;

            // ===== 2. ПРЕДМЕТ =====
            g.DrawString("2. ПРЕДМЕТ ДОГОВОРА", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw("2.1. Арендодатель передаёт, а Арендатор принимает во временное пользование жилой дом для проживания.", nf, left + 10, y, width - 20);
            y += 6;
            g.DrawString("2.2. Характеристики Объекта:", sf, Brushes.Black, left + 10, y); y += lh + 2;
            float by = y, bh = lh * 5 + 8;
            g.DrawRectangle(lp, new Rectangle((int)(left + 10), (int)y, (int)(width - 20), (int)bh)); y += 4;
            string[] sp = { $"Наименование: {houseName}", $"Класс: {houseClass}", $"Адрес: участок №{houseAddress}", $"Вместимость: до {houseCapacity} чел.", $"Цена за сутки: {pricePerDay:N2} ₽" };
            foreach (string s in sp) { g.DrawString(s, nf, Brushes.Black, left + 18, y); y += lh; }
            y = by + bh + 8;

            // ===== 3. СРОК =====
            g.DrawString("3. СРОК АРЕНДЫ", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw($"3.1. Срок аренды: с {checkInDate:dd.MM.yyyy} (заезд с 14:00) по {checkOutDate:dd.MM.yyyy} (выезд до 12:00). Продолжительность: {stayDays} {GetDaysWord(stayDays)}.", nf, left + 10, y, width - 20);
            y += 3;
            y = Draw("3.2. При досрочном выезде оплата не возвращается.", nf, left + 10, y, width - 20);
            y += 8;

            // ===== 4. СТОИМОСТЬ =====
            g.DrawString("4. СТОИМОСТЬ И ПОРЯДОК РАСЧЕТОВ", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw($"4.1. Арендная плата: {houseTotal:N2} ₽ ({NumberToWords((int)Math.Round(houseTotal))}).", nf, left + 10, y, width - 20);
            y += 3;
            if (servicesList.Count > 0)
            {
                y = Draw($"4.2. Дополнительные услуги: {servicesTotal:N2} ₽ ({NumberToWords((int)Math.Round(servicesTotal))}):", nf, left + 10, y, width - 20);
                foreach (var sv in servicesList) { g.DrawString($"• {sv.Name}: {sv.Quantity} × {sv.Price:N2} = {sv.Price * sv.Quantity:N2} ₽", sm, Brushes.Black, left + 20, y); y += sm.GetHeight() + 1; }
                y += 3;
            }
            Rectangle tr = new Rectangle((int)(left + 10), (int)y, (int)(width - 20), 35);
            g.FillRectangle(Brushes.LightGray, tr);
            g.DrawRectangle(tp, tr);
            g.DrawString($"ИТОГО к оплате: {grandTotal:N2} ₽", sf, Brushes.Black, left + 18, y + 3);
            g.DrawString($"({labelAmountInWords.Text})", new Font("Times New Roman", 8, FontStyle.Italic), Brushes.Black, left + 18, y + 18);
            y += 40;
            y = Draw("4.3. Оплата 100% не позднее дня заезда. Наличный или безналичный расчёт.", nf, left + 10, y, width - 20);
            y += 6;

            // ===== 5. ПРАВА =====
            g.DrawString("5. ПРАВА И ОБЯЗАННОСТИ СТОРОН", sf, Brushes.Black, left, y); y += lh + 4;
            g.DrawString("Арендодатель обязан:", sf, Brushes.Black, left + 10, y); y += lh + 2;
            string[] ld = { "• Передать Объект в пригодном для проживания состоянии.", "• Обеспечить работу инженерных систем.", "• Предоставить информацию о правилах проживания." };
            foreach (string s in ld) { g.DrawString(s, sm, Brushes.Black, left + 20, y); y += sm.GetHeight() + 1; }
            y += 2;
            g.DrawString("Арендатор обязан:", sf, Brushes.Black, left + 10, y); y += lh + 2;
            string[] td = { "• Использовать Объект только для проживания.", "• Своевременно оплачивать аренду.", "• Соблюдать тишину с 22:00 до 08:00.", "• Бережно относиться к имуществу.", "• Освободить Объект в расчётный час.", "• Возместить ущерб при порче имущества." };
            foreach (string s in td) { g.DrawString(s, sm, Brushes.Black, left + 20, y); y += sm.GetHeight() + 1; }
            y += 6;

            // ===== 6. ОТВЕТСТВЕННОСТЬ =====
            g.DrawString("6. ОТВЕТСТВЕННОСТЬ", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw("6.1. Арендатор возмещает ущерб в полном объёме.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("6.2. При задержке выезда — штраф в размере стоимости суток.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("6.3. Арендодатель не отвечает за ценные вещи без присмотра.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("6.4. Стороны освобождаются от ответственности при форс-мажоре.", nf, left + 10, y, width - 20);
            y += 6;

            // ===== 7. ЗАКЛЮЧИТЕЛЬНЫЕ =====
            g.DrawString("7. ЗАКЛЮЧИТЕЛЬНЫЕ ПОЛОЖЕНИЯ", sf, Brushes.Black, left, y); y += lh + 4;
            y = Draw("7.1. Договор вступает в силу с момента подписания.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("7.2. Изменения — в письменной форме.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("7.3. Договор составлен в 2-х экземплярах.", nf, left + 10, y, width - 20); y += 2;
            y = Draw("7.4. Споры разрешаются путём переговоров, затем в судебном порядке.", nf, left + 10, y, width - 20);
            y += 10;

            // ===== ПОДПИСИ =====
            float sy = bottom - 130;
            g.DrawLine(tp, left, sy, left + width, sy); sy += 10;
            g.DrawString("АРЕНДОДАТЕЛЬ:", sf, Brushes.Black, left, sy);
            g.DrawString("АРЕНДАТОР:", sf, Brushes.Black, left + width / 2, sy); sy += lh + 3;
            string[] ldd = { "ООО «Премиум Коттеджи»", "ИНН 1234567890", "г. Москва, ул. Лесная, д. 10" };
            float yl = sy;
            foreach (string s in ldd) { g.DrawString(s, sm, Brushes.Black, left, yl); yl += sm.GetHeight() + 1; }
            yl += 8;
            g.DrawString("_______________ /Иванов И.И./", nf, Brushes.Black, left, yl); yl += lh + 2;
            g.DrawString("М.П.", tn, Brushes.Black, left, yl);

            string[] tdd = { clientFIO, $"Паспорт: {clientPassport}", $"Тел.: {clientPhone}" };
            float yr = sy;
            foreach (string s in tdd) { g.DrawString(s, sm, Brushes.Black, left + width / 2, yr); yr += sm.GetHeight() + 1; }
            yr += 8;
            g.DrawString("_______________ /" + GetShortName(clientFIO) + "/", nf, Brushes.Black, left + width / 2, yr);

            g.DrawString($"Сформировано: {DateTime.Now:dd.MM.yyyy HH:mm} | {staffFIO}", new Font("Times New Roman", 5.5f), Brushes.Gray, left, bottom - 6);

            e.HasMorePages = false;
        }

        private void DrawSignatures(Graphics g, float left, float width, float bottom, Font sf, Font nf, Font sm, Font tn, Pen tp, float lh)
        {
            float sy = bottom - 200;
            g.DrawString("8. АДРЕСА, РЕКВИЗИТЫ И ПОДПИСИ СТОРОН", sf, Brushes.Black, left, sy); sy += lh + 8;
            g.DrawLine(tp, left, sy, left + width, sy); sy += 15;
            float cl = left, cr = left + width / 2;

            g.DrawString("АРЕНДОДАТЕЛЬ:", sf, Brushes.Black, cl, sy); sy += lh + 5;
            string[] ld = { "ООО «Премиум Коттеджи»", "ОГРН: 1234567890123", "ИНН/КПП: 1234567890 / 123456789", "г. Москва, ул. Лесная, д. 10", "Тел.: +7 (495) 123-45-67", "", "Банковские реквизиты:", "Р/с: 40702810000000012345", "Банк: ПАО Сбербанк", "К/с: 30101810400000000225", "БИК: 044525225" };
            float yl = sy;
            foreach (string s in ld) { g.DrawString(s, sm, Brushes.Black, cl, yl); yl += sm.GetHeight() + 1; }
            yl += 15;
            g.DrawString("_______________ /Иванов И.И./", nf, Brushes.Black, cl, yl); yl += lh + 2;
            g.DrawString("Генеральный директор", tn, Brushes.Black, cl, yl); yl += tn.GetHeight() + 1;
            g.DrawString("М.П.", tn, Brushes.Black, cl, yl);
            g.DrawRectangle(tp, new Rectangle((int)cl, (int)(yl + 5), 70, 70));
            g.DrawString("Место для печати", tn, Brushes.Gray, cl + 8, yl + 30);

            g.DrawString("АРЕНДАТОР:", sf, Brushes.Black, cr, sy); sy += lh + 5;
            string[] td = { clientFIO, $"Паспорт: {clientPassport}", $"Тел.: {clientPhone}", $"Email: {clientEmail}" };
            float yr = sy;
            foreach (string s in td) { g.DrawString(s, sm, Brushes.Black, cr, yr); yr += sm.GetHeight() + 1; }
            yr += 15;
            g.DrawString("_______________ /" + GetShortName(clientFIO) + "/", nf, Brushes.Black, cr, yr); yr += lh + 2;
            g.DrawString(DateTime.Now.ToString("«dd» MMMM yyyy г."), tn, Brushes.Black, cr, yr);

            g.DrawString($"Сформировано: {DateTime.Now:dd.MM.yyyy HH:mm} | Сотрудник: {staffFIO}", new Font("Times New Roman", 6), Brushes.Gray, left, bottom - 8);
        }

        private float DrawBlock(Graphics g, string text, Font font, float x, float y, float w)
        {
            SizeF s = g.MeasureString(text, font, (int)w);
            g.DrawString(text, font, Brushes.Black, new RectangleF(x, y, w, s.Height + 3));
            return y + s.Height + 3;
        }

        private string GetShortName(string n) { if (string.IsNullOrEmpty(n)) return ""; var p = n.Split(' '); return p.Length >= 2 ? $"{p[0]} {p[1][0]}." + (p.Length > 2 ? $" {p[2][0]}." : "") : n; }

        private string NumberToWords(int number)
        {
            if (number == 0) return "Ноль рублей 00 копеек";
            string[] u = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] uf = { "", "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] tn = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] ts = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] h = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            StringBuilder sb = new StringBuilder();
            if (number >= 1000000) { int m = number / 1000000; AddPart(m, sb, u, uf, tn, ts, h, new[] { "", "миллион", "миллиона", "миллионов" }, false); number %= 1000000; }
            if (number >= 1000) { int t = number / 1000; AddPart(t, sb, u, uf, tn, ts, h, new[] { "", "тысяча", "тысячи", "тысяч" }, true); number %= 1000; }
            if (number > 0) AddPart(number, sb, u, uf, tn, ts, h, new[] { "", "", "", "" }, false);
            int lt = number % 100, lo = number % 10;
            if (lt >= 11 && lt <= 14) sb.Append("рублей");
            else if (lo == 1) sb.Append("рубль");
            else if (lo >= 2 && lo <= 4) sb.Append("рубля");
            else sb.Append("рублей");
            string r = sb.ToString().Trim();
            if (r.Length > 0) r = char.ToUpper(r[0]) + r.Substring(1);
            return r + " 00 копеек";
        }

        private void AddPart(int n, StringBuilder sb, string[] u, string[] uf, string[] tn, string[] ts, string[] h, string[] nm, bool f)
        {
            if (n >= 100) { sb.Append(h[n / 100] + " "); n %= 100; }
            if (n >= 20) { sb.Append(ts[n / 10] + " "); n %= 10; if (n > 0) sb.Append((f ? uf[n] : u[n]) + " "); }
            else if (n >= 10) sb.Append(tn[n - 10] + " ");
            else if (n > 0) sb.Append((f ? uf[n] : u[n]) + " ");
            if (nm[0] != "") { int lt = n % 100; if (lt >= 11 && lt <= 14) sb.Append(nm[3] + " "); else if (n % 10 == 1) sb.Append(nm[1] + " "); else if (n % 10 >= 2 && n % 10 <= 4) sb.Append(nm[2] + " "); else sb.Append(nm[3] + " "); }
        }

        private string GetDaysWord(int d) { int lt = d % 100, lo = d % 10; if (lt >= 11 && lt <= 14) return "суток"; if (lo == 1) return "сутки"; if (lo >= 2 && lo <= 4) return "суток"; return "суток"; }

        private void buttonClose_Click(object sender, EventArgs e) => Close();

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewServices != null && dataGridViewServices.Rows.Count > 0)
                dataGridViewServices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}