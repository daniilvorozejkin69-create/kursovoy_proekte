using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class StaffList : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private DataTable allStaffData;
        private DataTable filteredStaffData;
        private DataTable currentPageData;
        private int totalPages = 1;
        private DataTable originalStaffData;

        public StaffList()
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

            // Настройка DataGridView
            dataGridViewStaff.AutoGenerateColumns = false;
            dataGridViewStaff.ReadOnly = true;
            dataGridViewStaff.AllowUserToAddRows = false;
            dataGridViewStaff.AllowUserToDeleteRows = false;
            dataGridViewStaff.AllowUserToResizeRows = false;
            dataGridViewStaff.RowHeadersVisible = false;
            dataGridViewStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStaff.MultiSelect = false;
            dataGridViewStaff.BackgroundColor = Color.White;
            dataGridViewStaff.BorderStyle = BorderStyle.None;
            dataGridViewStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewStaff.GridColor = Color.FromArgb(220, 235, 210);
            dataGridViewStaff.RowTemplate.Height = 45;
            dataGridViewStaff.ScrollBars = ScrollBars.None;
            dataGridViewStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Заголовки
            dataGridViewStaff.EnableHeadersVisualStyles = false;
            dataGridViewStaff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewStaff.ColumnHeadersHeight = 50;
            dataGridViewStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 145, 195);
            dataGridViewStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            dataGridViewStaff.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Строки
            dataGridViewStaff.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewStaff.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewStaff.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewStaff.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 210);
            dataGridViewStaff.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewStaff.RowsDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Альтернативные строки
            dataGridViewStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 245);

            // Создаем колонки
            CreateColumns();

            // Настройка поиска
            SetupSearchBox();

            // Настройка кнопок
            SetupButtons();

            // Подписка на события
            this.Load += StaffList_Load;

            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            buttonPrev.Click += ButtonPrev_Click;
            buttonNext.Click += ButtonNext_Click;
            buttonAdd.Click += ButtonAdd_Click;
            buttonEdit.Click += ButtonEdit_Click;
            buttonRefresh.Click += ButtonRefresh_Click;
            buttonBackToMenu.Click += ButtonBackToMenu_Click;
            buttonApplyFilter.Click += ButtonApplyFilter_Click;

            comboBoxRoleFilter.SelectedIndexChanged += Filter_Changed;
            comboBoxStatusFilter.SelectedIndexChanged += Filter_Changed;

            dataGridViewStaff.SelectionChanged += DataGridViewStaff_SelectionChanged;
            dataGridViewStaff.CellDoubleClick += DataGridViewStaff_CellDoubleClick;

            textBoxSearch.Enter += TextBoxSearch_Enter;
            textBoxSearch.Leave += TextBoxSearch_Leave;

            // Эффекты наведения
            buttonAdd.MouseEnter += ButtonAdd_MouseEnter;
            buttonAdd.MouseLeave += ButtonAdd_MouseLeave;
            buttonEdit.MouseEnter += ButtonEdit_MouseEnter;
            buttonEdit.MouseLeave += ButtonEdit_MouseLeave;
            buttonRefresh.MouseEnter += ButtonRefresh_MouseEnter;
            buttonRefresh.MouseLeave += ButtonRefresh_MouseLeave;
            buttonPrev.MouseEnter += ButtonPrev_MouseEnter;
            buttonPrev.MouseLeave += ButtonPrev_MouseLeave;
            buttonNext.MouseEnter += ButtonNext_MouseEnter;
            buttonNext.MouseLeave += ButtonNext_MouseLeave;
            buttonBackToMenu.MouseEnter += ButtonBackToMenu_MouseEnter;
            buttonBackToMenu.MouseLeave += ButtonBackToMenu_MouseLeave;
            buttonApplyFilter.MouseEnter += ButtonApplyFilter_MouseEnter;
            buttonApplyFilter.MouseLeave += ButtonApplyFilter_MouseLeave;
        }

        private void CreateColumns()
        {
            dataGridViewStaff.Columns.Clear();

            // ID - скрытая колонка
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "ID";
            colId.DataPropertyName = "ID";
            colId.Visible = false;
            dataGridViewStaff.Columns.Add(colId);

            // ФИО
            DataGridViewTextBoxColumn colFIO = new DataGridViewTextBoxColumn();
            colFIO.HeaderText = "ФИО";
            colFIO.Name = "ФИО";
            colFIO.DataPropertyName = "ФИО";
            colFIO.Width = 250;
            colFIO.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            colFIO.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewStaff.Columns.Add(colFIO);

            // Должность
            DataGridViewTextBoxColumn colPosition = new DataGridViewTextBoxColumn();
            colPosition.HeaderText = "Должность";
            colPosition.Name = "Должность";
            colPosition.DataPropertyName = "Должность";
            colPosition.Width = 180;
            dataGridViewStaff.Columns.Add(colPosition);

            // Телефон
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "Телефон";
            colPhone.DataPropertyName = "Телефон";
            colPhone.Width = 150;
            colPhone.DefaultCellStyle.Font = new Font("Consolas", 10);
            colPhone.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
            dataGridViewStaff.Columns.Add(colPhone);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Name = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 200;
            colEmail.DefaultCellStyle.Font = new Font("Consolas", 10);
            colEmail.DefaultCellStyle.ForeColor = Color.FromArgb(155, 89, 182);
            dataGridViewStaff.Columns.Add(colEmail);

            // Паспорт
            DataGridViewTextBoxColumn colPassport = new DataGridViewTextBoxColumn();
            colPassport.HeaderText = "Паспорт";
            colPassport.Name = "Паспорт";
            colPassport.DataPropertyName = "Паспорт";
            colPassport.Width = 130;
            colPassport.DefaultCellStyle.Font = new Font("Consolas", 10);
            colPassport.DefaultCellStyle.ForeColor = Color.FromArgb(41, 128, 185);
            colPassport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colPassport);

            // Дата приёма
            DataGridViewTextBoxColumn colHireDate = new DataGridViewTextBoxColumn();
            colHireDate.HeaderText = "Дата приёма";
            colHireDate.Name = "Дата приёма";
            colHireDate.DataPropertyName = "Дата приёма";
            colHireDate.Width = 100;
            colHireDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colHireDate);

            // Статус
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.HeaderText = "Статус";
            colStatus.Name = "Статус";
            colStatus.DataPropertyName = "Статус";
            colStatus.Width = 80;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colStatus);

            // Учетка
            DataGridViewTextBoxColumn colAccount = new DataGridViewTextBoxColumn();
            colAccount.HeaderText = "Учетная запись";
            colAccount.Name = "Учетка";
            colAccount.DataPropertyName = "Учетка";
            colAccount.Width = 200;
            colAccount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewStaff.Columns.Add(colAccount);
        }

        private void SetupSearchBox()
        {
            textBoxSearch.Font = new Font("Segoe UI", 11);
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.Size = new Size(300, 30);
            textBoxSearch.Text = "🔍 Поиск по ФИО, должности...";
            textBoxSearch.ForeColor = Color.Gray;
        }

        private void SetupButtons()
        {
            // Кнопки уже настроены в дизайнере
        }

        private void StaffList_Load(object sender, EventArgs e)
        {
            LoadAllStaffData();
        }

        private void LoadAllStaffData()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            p.id,
                            p.FIO,
                            p.job_title as Должность,
                            p.telephone_number,
                            p.email,
                            p.passport_series_number,
                            p.hire_date,
                            p.is_active,
                            u.id as user_id,
                            u.login,
                            u.is_active as user_active,
                            r.role_name
                        FROM personal p
                        LEFT JOIN users u ON p.id = u.personal_id
                        LEFT JOIN role r ON u.role_id = r.id
                        ORDER BY p.FIO";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        originalStaffData = new DataTable();
                        adapter.Fill(originalStaffData);

                        DataTable displayTable = new DataTable();
                        displayTable.Columns.Add("ID", typeof(int));
                        displayTable.Columns.Add("ФИО", typeof(string));
                        displayTable.Columns.Add("Должность", typeof(string));
                        displayTable.Columns.Add("Телефон", typeof(string));
                        displayTable.Columns.Add("Email", typeof(string));
                        displayTable.Columns.Add("Паспорт", typeof(string));
                        displayTable.Columns.Add("Дата приёма", typeof(string));
                        displayTable.Columns.Add("Статус", typeof(string));
                        displayTable.Columns.Add("Учетка", typeof(string));

                        foreach (DataRow row in originalStaffData.Rows)
                        {
                            DataRow newRow = displayTable.NewRow();
                            newRow["ID"] = row["id"];
                            newRow["ФИО"] = row["FIO"].ToString();
                            newRow["Должность"] = row["Должность"].ToString();
                            newRow["Телефон"] = FormatPhone(row["telephone_number"].ToString());
                            newRow["Email"] = MaskEmail(row["email"].ToString());
                            newRow["Паспорт"] = MaskPassport(row["passport_series_number"].ToString());

                            if (row["hire_date"] != DBNull.Value)
                            {
                                DateTime hireDate = Convert.ToDateTime(row["hire_date"]);
                                newRow["Дата приёма"] = hireDate.ToString("dd.MM.yyyy");
                            }

                            bool isActive = row["is_active"] != DBNull.Value && Convert.ToBoolean(row["is_active"]);
                            newRow["Статус"] = isActive ? "Активен" : "Уволен";

                            bool hasAccount = row["user_id"] != DBNull.Value;
                            if (hasAccount)
                            {
                                bool userActive = row["user_active"] != DBNull.Value && Convert.ToBoolean(row["user_active"]);
                                string role = row["role_name"]?.ToString() ?? "Нет роли";
                                newRow["Учетка"] = $"{role} ({(userActive ? "активна" : "неактивна")})";
                            }
                            else
                            {
                                newRow["Учетка"] = "Нет";
                            }

                            displayTable.Rows.Add(newRow);
                        }

                        allStaffData = displayTable;
                        filteredStaffData = allStaffData.Copy();

                        UpdatePagination();
                        LoadCurrentPage();
                        toolStripStatusLabel.Text = $"Всего сотрудников: {originalStaffData.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "";

            string digits = new string(phone.Where(char.IsDigit).ToArray());
            if (digits.Length == 11)
            {
                return $"+7 ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9, 2)}";
            }
            return phone;
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@")) return email;

            var parts = email.Split('@');
            if (parts[0].Length <= 1)
                return $"{parts[0]}***@{parts[1]}";
            if (parts[0].Length <= 3)
                return $"{parts[0][0]}{new string('*', parts[0].Length - 1)}@{parts[1]}";
            return $"{parts[0][0]}{new string('*', parts[0].Length - 2)}{parts[0][parts[0].Length - 1]}@{parts[1]}";
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

        private void ApplyFilter()
        {
            if (allStaffData == null) return;

            string search = textBoxSearch.Text.Trim();
            if (search == "🔍 Поиск по ФИО, должности..." || string.IsNullOrEmpty(search))
            {
                filteredStaffData = allStaffData.Copy();
            }
            else
            {
                DataView dv = allStaffData.DefaultView;
                dv.RowFilter = $"ФИО LIKE '%{search.Replace("'", "''")}%' OR " +
                               $"Должность LIKE '%{search.Replace("'", "''")}%'";
                filteredStaffData = dv.ToTable();
            }

            // Фильтр по роли
            if (comboBoxRoleFilter.SelectedIndex > 0)
            {
                string selectedRole = comboBoxRoleFilter.SelectedItem.ToString();
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = $"Учетка LIKE '%{selectedRole}%'";
                filteredStaffData = dv.ToTable();
            }

            // Фильтр по статусу
            if (comboBoxStatusFilter.SelectedIndex == 1) // Активные
            {
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = "Статус = 'Активен'";
                filteredStaffData = dv.ToTable();
            }
            else if (comboBoxStatusFilter.SelectedIndex == 2) // Уволенные
            {
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = "Статус = 'Уволен'";
                filteredStaffData = dv.ToTable();
            }

            currentPage = 1;
            UpdatePagination();
            LoadCurrentPage();
        }

        private void UpdatePagination()
        {
            totalPages = (int)Math.Ceiling((double)filteredStaffData.Rows.Count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;
        }

        private void LoadCurrentPage()
        {
            if (filteredStaffData == null) return;

            int start = (currentPage - 1) * pageSize;
            int end = Math.Min(start + pageSize, filteredStaffData.Rows.Count);

            currentPageData = filteredStaffData.Clone();
            currentPageData.Rows.Clear();

            for (int i = start; i < end; i++)
            {
                currentPageData.ImportRow(filteredStaffData.Rows[i]);
            }

            dataGridViewStaff.DataSource = currentPageData;

            // Включаем сортировку
            EnableSorting();

            UpdatePageInfo();
        }

        private void EnableSorting()
        {
            if (dataGridViewStaff.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in dataGridViewStaff.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void UpdatePageInfo()
        {
            labelPageInfo.Text = $"Страница {currentPage} из {totalPages} | Всего: {filteredStaffData.Rows.Count}";

            buttonPrev.Enabled = currentPage > 1;
            buttonNext.Enabled = currentPage < totalPages;

            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);

            buttonEdit.Enabled = dataGridViewStaff.SelectedRows.Count > 0;
            buttonEdit.BackColor = buttonEdit.Enabled ? Color.FromArgb(46, 204, 113) : Color.FromArgb(200, 200, 200);
        }

        // ============================================
        // ОБРАБОТЧИКИ
        // ============================================

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "🔍 Поиск по ФИО, должности...")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.FromArgb(64, 64, 64);
            }
            textBoxSearch.BackColor = Color.FromArgb(255, 255, 220);
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = "🔍 Поиск по ФИО, должности...";
                textBoxSearch.ForeColor = Color.Gray;
            }
            textBoxSearch.BackColor = Color.White;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadAllStaffData();
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadCurrentPage();
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadCurrentPage();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddStaff addForm = new AddStaff();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllStaffData();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewStaff.SelectedRows[0].Cells["ID"].Value);

                AddStaff editForm = new AddStaff(id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllStaffData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewStaff_SelectionChanged(object sender, EventArgs e)
        {
            UpdatePageInfo();
        }

        private void DataGridViewStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ButtonEdit_Click(sender, e);
            }
        }

        // ============================================
        // ЭФФЕКТЫ НАВЕДЕНИЯ
        // ============================================

        private void ButtonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(41, 128, 185);
            buttonAdd.Font = new Font(buttonAdd.Font, FontStyle.Bold);
        }

        private void ButtonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(52, 152, 219);
            buttonAdd.Font = new Font(buttonAdd.Font, FontStyle.Regular);
        }

        private void ButtonEdit_MouseEnter(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
            {
                buttonEdit.BackColor = Color.FromArgb(39, 174, 96);
                buttonEdit.Font = new Font(buttonEdit.Font, FontStyle.Bold);
            }
        }

        private void ButtonEdit_MouseLeave(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
            {
                buttonEdit.BackColor = Color.FromArgb(46, 204, 113);
            }
            buttonEdit.Font = new Font(buttonEdit.Font, FontStyle.Regular);
        }

        private void ButtonRefresh_MouseEnter(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = Color.FromArgb(86, 133, 65);
            buttonRefresh.Font = new Font(buttonRefresh.Font, FontStyle.Bold);
        }

        private void ButtonRefresh_MouseLeave(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = Color.FromArgb(106, 153, 85);
            buttonRefresh.Font = new Font(buttonRefresh.Font, FontStyle.Regular);
        }

        private void ButtonPrev_MouseEnter(object sender, EventArgs e)
        {
            if (buttonPrev.Enabled)
            {
                buttonPrev.BackColor = Color.FromArgb(126, 173, 105);
                buttonPrev.Font = new Font(buttonPrev.Font, FontStyle.Bold);
            }
        }

        private void ButtonPrev_MouseLeave(object sender, EventArgs e)
        {
            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonPrev.Font = new Font(buttonPrev.Font, FontStyle.Regular);
        }

        private void ButtonNext_MouseEnter(object sender, EventArgs e)
        {
            if (buttonNext.Enabled)
            {
                buttonNext.BackColor = Color.FromArgb(126, 173, 105);
                buttonNext.Font = new Font(buttonNext.Font, FontStyle.Bold);
            }
        }

        private void ButtonNext_MouseLeave(object sender, EventArgs e)
        {
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonNext.Font = new Font(buttonNext.Font, FontStyle.Regular);
        }

        private void ButtonBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.ForeColor = Color.White;
            buttonBackToMenu.Font = new Font(buttonBackToMenu.Font, FontStyle.Bold);
        }

        private void ButtonBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.Transparent;
            buttonBackToMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.Font = new Font(buttonBackToMenu.Font, FontStyle.Regular);
        }

        private void ButtonApplyFilter_MouseEnter(object sender, EventArgs e)
        {
            buttonApplyFilter.BackColor = Color.FromArgb(86, 133, 65);
            buttonApplyFilter.Font = new Font(buttonApplyFilter.Font, FontStyle.Bold);
        }

        private void ButtonApplyFilter_MouseLeave(object sender, EventArgs e)
        {
            buttonApplyFilter.BackColor = Color.FromArgb(106, 153, 85);
            buttonApplyFilter.Font = new Font(buttonApplyFilter.Font, FontStyle.Regular);
        }
    }
}