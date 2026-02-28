using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class ClientList : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private DataTable allDataTable;
        private DataTable filteredDataTable;
        private DataTable currentPageDataTable;
        private int totalPages = 1;
        private DataTable originalDataTable;

        public ClientList()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.DoubleBuffered = true;

            if (Session.IsLoggedIn)
            {
                labelUserInfo.Text = Session.UserName;
            }
            else
            {
                labelUserInfo.Text = "Сотрудник";
            }

            // Настройка DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(220, 235, 210);
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Заголовки
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 145, 195);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Строки
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 210);
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridView1.RowsDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Альтернативные строки
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 245);

            // Создаем колонки
            CreateColumns();

            // Настраиваем поиск
            SetupSearchBox();

            // Настраиваем кнопки
            SetupButtons();

            // Подписываемся на события
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
        }

        private void SetupSearchBox()
        {
            // Настройка поля поиска
            textBoxSearch.Font = new Font("Segoe UI", 11);
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.ForeColor = Color.FromArgb(64, 64, 64);
            textBoxSearch.Size = new Size(350, 30);

            // Добавляем иконку поиска (если есть pictureBoxSearch)
        }

        private void SetupButtons()
        {
            // Кнопка ДОБАВИТЬ
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.BackColor = Color.FromArgb(52, 152, 219); // Ярко-синий
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonAdd.Text = "➕  ДОБАВИТЬ";
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;
            buttonAdd.Cursor = Cursors.Hand;

            // Кнопка РЕДАКТИРОВАТЬ
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.BackColor = Color.FromArgb(46, 204, 113); // Ярко-зеленый
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonEdit.Text = "✏️  РЕДАКТИРОВАТЬ";
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;
            buttonEdit.Cursor = Cursors.Hand;

            // Кнопка НАЗАД
            buttonBackToMenu.FlatStyle = FlatStyle.Flat;
            buttonBackToMenu.FlatAppearance.BorderSize = 2;
            buttonBackToMenu.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.BackColor = Color.Transparent;
            buttonBackToMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            buttonBackToMenu.Text = "🏠  В МЕНЮ";
            buttonBackToMenu.Cursor = Cursors.Hand;

            // Кнопки пагинации
            buttonPrev.FlatStyle = FlatStyle.Flat;
            buttonPrev.FlatAppearance.BorderSize = 0;
            buttonPrev.BackColor = Color.FromArgb(106, 153, 85);
            buttonPrev.ForeColor = Color.White;
            buttonPrev.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonPrev.Cursor = Cursors.Hand;

            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.BackColor = Color.FromArgb(106, 153, 85);
            buttonNext.ForeColor = Color.White;
            buttonNext.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonNext.Cursor = Cursors.Hand;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Clear();

            // ФИО
            DataGridViewTextBoxColumn colFIO = new DataGridViewTextBoxColumn();
            colFIO.HeaderText = "ФИО";
            colFIO.Name = "ФИО";
            colFIO.DataPropertyName = "ФИО";
            colFIO.FillWeight = 30;
            colFIO.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            colFIO.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridView1.Columns.Add(colFIO);

            // Паспорт
            DataGridViewTextBoxColumn colPassport = new DataGridViewTextBoxColumn();
            colPassport.HeaderText = "Паспорт";
            colPassport.Name = "Паспорт";
            colPassport.DataPropertyName = "Паспорт";
            colPassport.FillWeight = 15;
            colPassport.DefaultCellStyle.Font = new Font("Consolas", 10);
            colPassport.DefaultCellStyle.ForeColor = Color.FromArgb(41, 128, 185);
            colPassport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(colPassport);

            // Дата рождения
            DataGridViewTextBoxColumn colBirth = new DataGridViewTextBoxColumn();
            colBirth.HeaderText = "Дата рождения";
            colBirth.Name = "Дата рождения";
            colBirth.DataPropertyName = "Дата рождения";
            colBirth.FillWeight = 12;
            colBirth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBirth.DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridView1.Columns.Add(colBirth);

            // Телефон
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "Телефон";
            colPhone.DataPropertyName = "Телефон";
            colPhone.FillWeight = 18;
            colPhone.DefaultCellStyle.Font = new Font("Consolas", 10);
            colPhone.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
            dataGridView1.Columns.Add(colPhone);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Name = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 18;
            colEmail.DefaultCellStyle.Font = new Font("Consolas", 10);
            colEmail.DefaultCellStyle.ForeColor = Color.FromArgb(155, 89, 182);
            dataGridView1.Columns.Add(colEmail);

            // Пол
            DataGridViewTextBoxColumn colGender = new DataGridViewTextBoxColumn();
            colGender.HeaderText = "Пол";
            colGender.Name = "Пол";
            colGender.DataPropertyName = "Пол";
            colGender.FillWeight = 7;
            colGender.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGender.DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridView1.Columns.Add(colGender);

            // Отключаем сортировку
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            LoadAllClientsData();
        }

        private void LoadAllClientsData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            id,
                            FIO,
                            passport_series_number,
                            date_of_birth,
                            telephone_number,
                            email,
                            gender
                        FROM client
                        ORDER BY FIO";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);

                        // Создаем DataTable для отображения
                        DataTable displayTable = new DataTable();
                        displayTable.Columns.Add("ФИО", typeof(string));
                        displayTable.Columns.Add("Паспорт", typeof(string));
                        displayTable.Columns.Add("Дата рождения", typeof(string));
                        displayTable.Columns.Add("Телефон", typeof(string));
                        displayTable.Columns.Add("Email", typeof(string));
                        displayTable.Columns.Add("Пол", typeof(string));

                        foreach (DataRow row in originalDataTable.Rows)
                        {
                            DataRow newRow = displayTable.NewRow();
                            newRow["ФИО"] = row["FIO"].ToString();

                            string passport = row["passport_series_number"].ToString();
                            newRow["Паспорт"] = MaskPassport(passport);

                            if (row["date_of_birth"] != DBNull.Value)
                            {
                                DateTime birthDate = Convert.ToDateTime(row["date_of_birth"]);
                                newRow["Дата рождения"] = birthDate.ToString("dd.MM.yyyy");
                            }
                            else
                            {
                                newRow["Дата рождения"] = "";
                            }

                            newRow["Телефон"] = MaskPhone(row["telephone_number"].ToString());
                            newRow["Email"] = MaskEmail(row["email"].ToString());
                            newRow["Пол"] = row["gender"].ToString();

                            displayTable.Rows.Add(newRow);
                        }

                        allDataTable = displayTable;
                        filteredDataTable = allDataTable.Copy();

                        UpdatePagination();
                        LoadCurrentPage();
                        toolStripStatusLabel.Text = $"Всего клиентов: {originalDataTable.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MaskPassport(string passport)
        {
            if (string.IsNullOrEmpty(passport)) return "";
            if (passport.Length >= 4)
            {
                string visible = passport.Substring(0, 4);
                string masked = new string('•', passport.Length - 4);
                return visible + masked;
            }
            return passport;
        }

        private string MaskPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "";

            string digits = new string(phone.Where(char.IsDigit).ToArray());
            if (digits.Length == 11)
            {
                return $"+7 ({digits.Substring(1, 3)}) ••• •• {digits.Substring(7, 4)}";
            }
            return phone;
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@")) return email;

            var parts = email.Split('@');
            if (parts[0].Length <= 1)
                return $"{parts[0]}•••@{parts[1]}";
            return $"{parts[0][0]}{new string('•', parts[0].Length - 2)}{parts[0][parts[0].Length - 1]}@{parts[1]}";
        }

        private void UpdatePagination()
        {
            totalPages = (int)Math.Ceiling((double)filteredDataTable.Rows.Count / pageSize);
            if (totalPages == 0) totalPages = 1;

            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;
        }

        private void LoadCurrentPage()
        {
            if (filteredDataTable == null) return;

            int start = (currentPage - 1) * pageSize;
            int end = Math.Min(start + pageSize, filteredDataTable.Rows.Count);

            currentPageDataTable = filteredDataTable.Clone();
            currentPageDataTable.Rows.Clear();

            for (int i = start; i < end; i++)
            {
                currentPageDataTable.ImportRow(filteredDataTable.Rows[i]);
            }

            dataGridView1.DataSource = currentPageDataTable;
            UpdatePageInfo();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (allDataTable == null) return;

            string search = textBoxSearch.Text.Trim();

            filteredDataTable = allDataTable.Copy();

            if (!string.IsNullOrEmpty(search))
            {
                DataView dv = filteredDataTable.DefaultView;
                dv.RowFilter = $"ФИО LIKE '%{search.Replace("'", "''")}%'";
                filteredDataTable = dv.ToTable();
            }

            currentPage = 1;
            UpdatePagination();
            LoadCurrentPage();
        }

        private void UpdatePageInfo()
        {
            labelPageInfo.Text = $"Страница {currentPage} из {totalPages} | Всего: {filteredDataTable.Rows.Count}";

            buttonPrev.Enabled = currentPage > 1;
            buttonNext.Enabled = currentPage < totalPages;

            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);

            buttonEdit.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            textBoxSearch.BackColor = Color.FromArgb(255, 255, 220);
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            textBoxSearch.BackColor = Color.White;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadCurrentPage();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadCurrentPage();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddClient addForm = new AddClient();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllClientsData();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fio = dataGridView1.SelectedRows[0].Cells["ФИО"].Value?.ToString();
            if (string.IsNullOrEmpty(fio)) return;

            var rows = originalDataTable.Select($"FIO = '{fio.Replace("'", "''")}'");
            if (rows.Length > 0)
            {
                int id = Convert.ToInt32(rows[0]["id"]);
                AddClient editForm = new AddClient(id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllClientsData();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdatePageInfo();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            switch (Session.RoleId)
            {
                case 1:
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    break;
                case 2:
                    RecephenForm recepForm = new RecephenForm();
                    recepForm.Show();
                    break;
                case 3:
                    ManagerForm managerForm = new ManagerForm();
                    managerForm.Show();
                    break;
            }
            this.Close();
        }

        // Эффекты наведения для кнопок
        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(41, 128, 185); // Темнее при наведении
            buttonAdd.Font = new Font(buttonAdd.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(52, 152, 219);
            buttonAdd.Font = new Font(buttonAdd.Font, FontStyle.Bold);
        }

        private void buttonEdit_MouseEnter(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
            {
                buttonEdit.BackColor = Color.FromArgb(39, 174, 96); // Темнее при наведении
                buttonEdit.Font = new Font(buttonEdit.Font, FontStyle.Bold | FontStyle.Underline);
            }
        }

        private void buttonEdit_MouseLeave(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
            {
                buttonEdit.BackColor = Color.FromArgb(46, 204, 113);
            }
            buttonEdit.Font = new Font(buttonEdit.Font, FontStyle.Bold);
        }

        private void buttonPrev_MouseEnter(object sender, EventArgs e)
        {
            if (buttonPrev.Enabled)
            {
                buttonPrev.BackColor = Color.FromArgb(126, 173, 105);
                buttonPrev.Font = new Font(buttonPrev.Font, FontStyle.Bold);
            }
        }

        private void buttonPrev_MouseLeave(object sender, EventArgs e)
        {
            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonPrev.Font = new Font(buttonPrev.Font, FontStyle.Regular);
        }

        private void buttonNext_MouseEnter(object sender, EventArgs e)
        {
            if (buttonNext.Enabled)
            {
                buttonNext.BackColor = Color.FromArgb(126, 173, 105);
                buttonNext.Font = new Font(buttonNext.Font, FontStyle.Bold);
            }
        }

        private void buttonNext_MouseLeave(object sender, EventArgs e)
        {
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonNext.Font = new Font(buttonNext.Font, FontStyle.Regular);
        }

        private void buttonBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.ForeColor = Color.White;
            buttonBackToMenu.Font = new Font(buttonBackToMenu.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void buttonBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.Transparent;
            buttonBackToMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.Font = new Font(buttonBackToMenu.Font, FontStyle.Bold);
        }

        private void labelUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}