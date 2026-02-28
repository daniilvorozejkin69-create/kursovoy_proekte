using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            buttonPrev.Click += ButtonPrev_Click;
            buttonNext.Click += ButtonNext_Click;
            buttonAdd.Click += ButtonAdd_Click;
            buttonEdit.Click += ButtonEdit_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonBackToMenu.Click += ButtonBackToMenu_Click;
            buttonRefresh.Click += ButtonRefresh_Click;

            comboBoxRole.SelectedIndexChanged += Filter_Changed;
            comboBoxStatus.SelectedIndexChanged += Filter_Changed;
        }

        private void CreateColumns()
        {
            dataGridViewStaff.Columns.Clear();

            // ID
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "ID";
            colId.Name = "ID";
            colId.DataPropertyName = "ID";
            colId.FillWeight = 5;
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colId);

            // ФИО
            DataGridViewTextBoxColumn colFIO = new DataGridViewTextBoxColumn();
            colFIO.HeaderText = "ФИО";
            colFIO.Name = "ФИО";
            colFIO.DataPropertyName = "ФИО";
            colFIO.FillWeight = 20;
            colFIO.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            colFIO.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewStaff.Columns.Add(colFIO);

            // Должность
            DataGridViewTextBoxColumn colJobTitle = new DataGridViewTextBoxColumn();
            colJobTitle.HeaderText = "Должность";
            colJobTitle.Name = "Должность";
            colJobTitle.DataPropertyName = "Должность";
            colJobTitle.FillWeight = 15;
            dataGridViewStaff.Columns.Add(colJobTitle);

            // Роль
            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.HeaderText = "Роль";
            colRole.Name = "Роль";
            colRole.DataPropertyName = "Роль";
            colRole.FillWeight = 10;
            colRole.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colRole);

            // Логин
            DataGridViewTextBoxColumn colLogin = new DataGridViewTextBoxColumn();
            colLogin.HeaderText = "Логин";
            colLogin.Name = "Логин";
            colLogin.DataPropertyName = "Логин";
            colLogin.FillWeight = 10;
            colLogin.DefaultCellStyle.Font = new Font("Consolas", 10);
            colLogin.DefaultCellStyle.ForeColor = Color.FromArgb(41, 128, 185);
            dataGridViewStaff.Columns.Add(colLogin);

            // Телефон
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "Телефон";
            colPhone.DataPropertyName = "Телефон";
            colPhone.FillWeight = 12;
            colPhone.DefaultCellStyle.Font = new Font("Consolas", 10);
            colPhone.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
            dataGridViewStaff.Columns.Add(colPhone);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Name = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 15;
            colEmail.DefaultCellStyle.Font = new Font("Consolas", 10);
            colEmail.DefaultCellStyle.ForeColor = Color.FromArgb(155, 89, 182);
            dataGridViewStaff.Columns.Add(colEmail);

            // Дата приёма
            DataGridViewTextBoxColumn colHireDate = new DataGridViewTextBoxColumn();
            colHireDate.HeaderText = "Дата приёма";
            colHireDate.Name = "Дата приёма";
            colHireDate.DataPropertyName = "Дата приёма";
            colHireDate.FillWeight = 10;
            colHireDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colHireDate);

            // Статус
            DataGridViewCheckBoxColumn colIsActive = new DataGridViewCheckBoxColumn();
            colIsActive.HeaderText = "Активен";
            colIsActive.Name = "Активен";
            colIsActive.DataPropertyName = "Активен";
            colIsActive.FillWeight = 8;
            colIsActive.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStaff.Columns.Add(colIsActive);

            // Отключаем сортировку
            foreach (DataGridViewColumn col in dataGridViewStaff.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void SetupSearchBox()
        {
            textBoxSearch.Font = new Font("Segoe UI", 11);
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.Size = new Size(300, 30);
            textBoxSearch.Text = "🔍 Поиск по ФИО, должности, email...";
            textBoxSearch.ForeColor = Color.Gray;
        }

        private void SetupButtons()
        {
            // Кнопка ДОБАВИТЬ
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.BackColor = Color.FromArgb(52, 152, 219);
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonAdd.Text = "➕  ДОБАВИТЬ";
            buttonAdd.Cursor = Cursors.Hand;

            // Кнопка РЕДАКТИРОВАТЬ
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.BackColor = Color.FromArgb(46, 204, 113);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonEdit.Text = "✏️  РЕДАКТИРОВАТЬ";
            buttonEdit.Cursor = Cursors.Hand;

            // Кнопка УДАЛИТЬ
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonDelete.Text = "🗑️  УДАЛИТЬ";
            buttonDelete.Cursor = Cursors.Hand;

            // Кнопка ОБНОВИТЬ
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.FlatAppearance.BorderSize = 0;
            buttonRefresh.BackColor = Color.FromArgb(106, 153, 85);
            buttonRefresh.ForeColor = Color.White;
            buttonRefresh.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            buttonRefresh.Text = "🔄  ОБНОВИТЬ";
            buttonRefresh.Cursor = Cursors.Hand;

            // Кнопка НАЗАД
            buttonBackToMenu.FlatStyle = FlatStyle.Flat;
            buttonBackToMenu.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.FlatAppearance.BorderSize = 2;
            buttonBackToMenu.BackColor = Color.Transparent;
            buttonBackToMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
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
                            p.job_title,
                            p.telephone_number,
                            p.email,
                            p.hire_date,
                            u.id as user_id,
                            u.login,
                            u.role_id,
                            u.is_active,
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

                        // Создаем таблицу для отображения
                        DataTable displayTable = new DataTable();
                        displayTable.Columns.Add("ID", typeof(int));
                        displayTable.Columns.Add("ФИО", typeof(string));
                        displayTable.Columns.Add("Должность", typeof(string));
                        displayTable.Columns.Add("Роль", typeof(string));
                        displayTable.Columns.Add("Логин", typeof(string));
                        displayTable.Columns.Add("Телефон", typeof(string));
                        displayTable.Columns.Add("Email", typeof(string));
                        displayTable.Columns.Add("Дата приёма", typeof(string));
                        displayTable.Columns.Add("Активен", typeof(bool));

                        foreach (DataRow row in originalStaffData.Rows)
                        {
                            DataRow newRow = displayTable.NewRow();
                            newRow["ID"] = row["id"];
                            newRow["ФИО"] = row["FIO"].ToString();
                            newRow["Должность"] = row["job_title"].ToString();
                            newRow["Роль"] = row["role_name"]?.ToString() ?? "Нет доступа";
                            newRow["Логин"] = row["login"]?.ToString() ?? "-";
                            newRow["Телефон"] = MaskPhone(row["telephone_number"].ToString());
                            newRow["Email"] = MaskEmail(row["email"].ToString());

                            if (row["hire_date"] != DBNull.Value)
                            {
                                DateTime hireDate = Convert.ToDateTime(row["hire_date"]);
                                newRow["Дата приёма"] = hireDate.ToString("dd.MM.yyyy");
                            }

                            newRow["Активен"] = row["is_active"] != DBNull.Value && Convert.ToBoolean(row["is_active"]);

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

        private void ApplyFilter()
        {
            if (allStaffData == null) return;

            string search = textBoxSearch.Text.Trim();
            if (search == "🔍 Поиск по ФИО, должности, email...") search = "";

            filteredStaffData = allStaffData.Copy();

            if (!string.IsNullOrEmpty(search))
            {
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = $"ФИО LIKE '%{search.Replace("'", "''")}%' OR " +
                               $"Должность LIKE '%{search.Replace("'", "''")}%' OR " +
                               $"Email LIKE '%{search.Replace("'", "''")}%'";
                filteredStaffData = dv.ToTable();
            }

            // Фильтр по роли
            if (comboBoxRole.SelectedIndex > 0)
            {
                string selectedRole = comboBoxRole.SelectedItem.ToString();
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = $"Роль = '{selectedRole}'";
                filteredStaffData = dv.ToTable();
            }

            // Фильтр по статусу
            if (comboBoxStatus.SelectedIndex == 1) // Активные
            {
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = "Активен = True";
                filteredStaffData = dv.ToTable();
            }
            else if (comboBoxStatus.SelectedIndex == 2) // Неактивные
            {
                DataView dv = filteredStaffData.DefaultView;
                dv.RowFilter = "Активен = False";
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
            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            labelPageInfo.Text = $"Страница {currentPage} из {totalPages} | Всего: {filteredStaffData.Rows.Count}";

            buttonPrev.Enabled = currentPage > 1;
            buttonNext.Enabled = currentPage < totalPages;

            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);

            buttonEdit.Enabled = dataGridViewStaff.SelectedRows.Count > 0;
            buttonDelete.Enabled = dataGridViewStaff.SelectedRows.Count > 0;
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != "🔍 Поиск по ФИО, должности, email...")
            {
                ApplyFilter();
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
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

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadAllStaffData();
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
            if (dataGridViewStaff.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridViewStaff.SelectedRows[0].Cells["ID"].Value);

            var rows = originalStaffData.Select($"id = {id}");
            if (rows.Length > 0)
            {
                int staffId = Convert.ToInt32(rows[0]["id"]);
                AddStaff editForm = new AddStaff(staffId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllStaffData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStaff.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridViewStaff.SelectedRows[0].Cells["ID"].Value);

            if (id == Session.UserId)
            {
                MessageBox.Show("Вы не можете удалить свою собственную учетную запись.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?\n" +
                                        "⚠️ Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteStaff(id);
            }
        }

        private void DeleteStaff(int staffId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Удаляем пользователя
                            string deleteUser = "DELETE FROM users WHERE personal_id = @staffId";
                            using (var cmd = new MySqlCommand(deleteUser, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@staffId", staffId);
                                cmd.ExecuteNonQuery();
                            }

                            // Удаляем сотрудника
                            string deleteStaff = "DELETE FROM personal WHERE id = @staffId";
                            using (var cmd = new MySqlCommand(deleteStaff, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@staffId", staffId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("🗑️ Сотрудник успешно удален!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllStaffData();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("❌ Нельзя удалить сотрудника, который создавал заказы.\n" +
                              "Сначала деактивируйте его учетную запись.",
                              "Ошибка удаления",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBackToMenu_Click(object sender, EventArgs e)
        {
            switch (Session.RoleId)
            {
                case 1:
                    new AdminForm().Show();
                    break;
                case 2:
                    new RecephenForm().Show();
                    break;
                case 3:
                    new ManagerForm().Show();
                    break;
            }
            this.Close();
        }

        private void dataGridViewStaff_SelectionChanged(object sender, EventArgs e)
        {
            UpdatePageInfo();
        }

        private void dataGridViewStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ButtonEdit_Click(sender, e);
            }
        }

        // Эффекты наведения
        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "🔍 Поиск по ФИО, должности, email...")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.FromArgb(64, 64, 64);
            }
            textBoxSearch.BackColor = Color.FromArgb(255, 255, 220);
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = "🔍 Поиск по ФИО, должности, email...";
                textBoxSearch.ForeColor = Color.Gray;
            }
            textBoxSearch.BackColor = Color.White;
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void buttonEdit_MouseEnter(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
                buttonEdit.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void buttonEdit_MouseLeave(object sender, EventArgs e)
        {
            if (buttonEdit.Enabled)
                buttonEdit.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            if (buttonDelete.Enabled)
                buttonDelete.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void buttonDelete_MouseLeave(object sender, EventArgs e)
        {
            if (buttonDelete.Enabled)
                buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void buttonRefresh_MouseEnter(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = Color.FromArgb(86, 133, 65);
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = Color.FromArgb(106, 153, 85);
        }

        private void buttonPrev_MouseEnter(object sender, EventArgs e)
        {
            if (buttonPrev.Enabled)
                buttonPrev.BackColor = Color.FromArgb(126, 173, 105);
        }

        private void buttonPrev_MouseLeave(object sender, EventArgs e)
        {
            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
        }

        private void buttonNext_MouseEnter(object sender, EventArgs e)
        {
            if (buttonNext.Enabled)
                buttonNext.BackColor = Color.FromArgb(126, 173, 105);
        }

        private void buttonNext_MouseLeave(object sender, EventArgs e)
        {
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 200, 200);
        }

        private void buttonBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.FromArgb(52, 152, 219);
            buttonBackToMenu.ForeColor = Color.White;
        }

        private void buttonBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.Transparent;
            buttonBackToMenu.ForeColor = Color.FromArgb(52, 152, 219);
        }
    }
}