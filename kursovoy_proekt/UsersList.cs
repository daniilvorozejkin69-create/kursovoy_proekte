using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class UsersList : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private DataTable allDataTable;
        private DataTable currentPageDataTable;
        private int totalPages = 1;
        private DataTable originalDataTable; // Для хранения ID пользователей и персонала

        public UsersList()
        {
            InitializeComponent();
            InactivityManager.Start(this);
            SetupModernControls();
        }

        private void SetupModernControls()
        {
            this.DoubleBuffered = true;
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;

            LoadAllUsersData();
            LoadRolesToComboBox();
            UpdatePageInfo();
            ConfigureDataGridViewColumns();

            // Отключаем сортировку для всех колонок
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadAllUsersData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            u.id AS user_id,
                            u.personal_id,
                            u.login,
                            r.role_name,
                            p.FIO,
                            p.email,
                            p.telephone_number
                        FROM users u
                        JOIN role r ON u.role_id = r.id
                        JOIN personal p ON u.personal_id = p.id
                        ORDER BY p.FIO";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);

                        // Создаем таблицу для отображения
                        CreateDisplayDataTable();

                        totalPages = (int)Math.Ceiling((double)allDataTable.Rows.Count / pageSize);
                        if (totalPages == 0) totalPages = 1;

                        LoadCurrentPage();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDisplayDataTable()
        {
            // Создаем структуру таблицы для отображения
            allDataTable = new DataTable();
            allDataTable.Columns.Add("ФИО", typeof(string));
            allDataTable.Columns.Add("Логин", typeof(string));
            allDataTable.Columns.Add("Роль", typeof(string));
            allDataTable.Columns.Add("Email", typeof(string));
            allDataTable.Columns.Add("Телефон", typeof(string));

            // Заполняем данными
            foreach (DataRow row in originalDataTable.Rows)
            {
                DataRow newRow = allDataTable.NewRow();

                newRow["ФИО"] = row["FIO"].ToString();
                newRow["Логин"] = row["login"].ToString();
                newRow["Роль"] = row["role_name"].ToString();
                newRow["Email"] = string.IsNullOrEmpty(row["email"].ToString()) ?
                    "Не указан" : row["email"].ToString();
                newRow["Телефон"] = string.IsNullOrEmpty(row["telephone_number"].ToString()) ?
                    "Не указан" : FormatPhoneNumber(row["telephone_number"].ToString());

                allDataTable.Rows.Add(newRow);
            }
        }

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return "Не указан";

            if (phone.StartsWith("+7") && phone.Length >= 12)
                return $"+7 ({phone.Substring(2, 3)}) {phone.Substring(5, 3)}-{phone.Substring(8, 2)}-{phone.Substring(10, 2)}";
            else
                return phone;
        }

        private void LoadCurrentPage()
        {
            if (allDataTable != null)
            {
                ApplyFilter();

                DataTable filteredData = allDataTable.DefaultView.ToTable();

                totalPages = (int)Math.Ceiling((double)filteredData.Rows.Count / pageSize);
                if (totalPages == 0) totalPages = 1;

                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize, filteredData.Rows.Count);

                currentPageDataTable = filteredData.Clone();
                for (int i = startIndex; i < endIndex; i++)
                {
                    currentPageDataTable.ImportRow(filteredData.Rows[i]);
                }

                dataGridView1.DataSource = currentPageDataTable;
                ConfigureDataGridViewColumns();

                // Отключаем сортировку (на случай перезагрузки данных)
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                UpdatePageInfo();
            }
        }

        private void ApplyFilter()
        {
            if (allDataTable != null)
            {
                string searchText = textBoxSearch.Text.Trim().Replace("'", "''");
                string selectedRole = comboBoxRoles.SelectedItem?.ToString();

                string filter = "";

                if (!string.IsNullOrEmpty(searchText))
                {
                    filter = $"[ФИО] LIKE '%{searchText}%' OR " +
                             $"[Логин] LIKE '%{searchText}%' OR " +
                             $"[Email] LIKE '%{searchText}%' OR " +
                             $"[Телефон] LIKE '%{searchText}%'";
                }

                if (!string.IsNullOrEmpty(selectedRole) && selectedRole != "Все роли")
                {
                    if (!string.IsNullOrEmpty(filter))
                        filter += " AND ";
                    filter += $"[Роль] = '{selectedRole}'";
                }

                allDataTable.DefaultView.RowFilter = filter;
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["ФИО"].HeaderText = "ФИО СОТРУДНИКА";
                dataGridView1.Columns["ФИО"].Width = 250;

                dataGridView1.Columns["Логин"].HeaderText = "ЛОГИН";
                dataGridView1.Columns["Логин"].Width = 150;

                dataGridView1.Columns["Роль"].HeaderText = "РОЛЬ";
                dataGridView1.Columns["Роль"].Width = 150;

                dataGridView1.Columns["Email"].HeaderText = "EMAIL";
                dataGridView1.Columns["Email"].Width = 200;

                dataGridView1.Columns["Телефон"].HeaderText = "ТЕЛЕФОН";
                dataGridView1.Columns["Телефон"].Width = 160;

                // Центрируем заголовки
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    column.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
                }

                // Настраиваем стиль для выделенной строки
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 210);
                dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void UpdatePageInfo()
        {
            int totalFilteredRecords = allDataTable?.DefaultView.Count ?? 0;
            labelPageInfo.Text = $"Страница {currentPage} из {totalPages} | Всего записей: {totalFilteredRecords}";

            buttonPrev.Enabled = (currentPage > 1);
            buttonNext.Enabled = (currentPage < totalPages);

            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(100, 100, 100);
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(100, 100, 100);

            // Активируем кнопку редактирования только если есть выделенная строка
            buttonEdit.Enabled = (dataGridView1.SelectedRows.Count > 0);
            buttonEdit.BackColor = buttonEdit.Enabled ? Color.FromArgb(76, 145, 195) : Color.FromArgb(100, 100, 100);
        }

        private void LoadRolesToComboBox()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT role_name FROM role ORDER BY id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxRoles.Items.Clear();
                            comboBoxRoles.Items.Add("Все роли");

                            while (reader.Read())
                            {
                                comboBoxRoles.Items.Add(reader["role_name"].ToString());
                            }

                            comboBoxRoles.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ролей: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadCurrentPage();
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadCurrentPage();
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

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            // Возвращаем в соответствующую форму по роли
            if (Session.RoleId == 1)
            {
                AdminForm mainForm = new AdminForm();
                mainForm.Show();
                this.Close();
            }
            else if (Session.RoleId == 2)
            {
                RecephenForm recepForm = new RecephenForm();
                recepForm.Show();
                this.Close();
            }
            else if (Session.RoleId == 3)
            {
                ManagerForm managerForm = new ManagerForm();
                managerForm.Show();
                this.Close();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddUser addForm = new AddUser();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllUsersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditSelectedUser();
        }

        private void EditSelectedUser()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите пользователя для редактирования.", "Внимание",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем индекс выбранной строки на текущей странице
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Получаем DataRow из currentPageDataTable
                if (selectedRowIndex >= 0 && selectedRowIndex < currentPageDataTable.Rows.Count)
                {
                    DataRow selectedRow = currentPageDataTable.Rows[selectedRowIndex];

                    // Получаем логин пользователя из выбранной строки
                    string selectedLogin = selectedRow["Логин"].ToString();

                    // Ищем соответствующую запись в originalDataTable по логину
                    DataRow[] matchingRows = originalDataTable.Select($"login = '{selectedLogin.Replace("'", "''")}'");

                    if (matchingRows.Length > 0)
                    {
                        int userId = Convert.ToInt32(matchingRows[0]["user_id"]);
                        int personalId = Convert.ToInt32(matchingRows[0]["personal_id"]);

                        // Открываем форму редактирования
                        AddUser editForm = new AddUser(userId, personalId);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllUsersData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти выбранного пользователя в базе данных.", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdatePageInfo();
        }

        // Двойной клик по строке для редактирования
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedUser();
            }
        }

        // Обработчик клика по заголовку столбца (для блокировки сортировки)
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ничего не делаем - сортировка отключена
        }

        // Для совместимости с существующим кодом
        private void label3_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}