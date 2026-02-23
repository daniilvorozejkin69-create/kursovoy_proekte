using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class HousList : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private DataTable allDataTable;
        private DataTable currentPageDataTable;
        private int totalPages = 1;
        private DataTable homeClasses;
        private DataTable originalDataTable; // Для хранения ID домов

        public HousList()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void HousList_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;

            LoadHomeClasses();
            LoadAllHousesData();
            UpdatePageInfo();

            // Отключение сортировки для всех колонок
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadHomeClasses()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, class FROM home_class ORDER BY class";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    homeClasses = new DataTable();
                    adapter.Fill(homeClasses);

                    comboBoxClassFilter.Items.Clear();
                    comboBoxClassFilter.Items.Add("Все классы");

                    foreach (DataRow row in homeClasses.Rows)
                        comboBoxClassFilter.Items.Add(row["class"].ToString());

                    comboBoxClassFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке классов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllHousesData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            h.id AS `ID`,
                            h.name AS `Название`,
                            hc.class AS `Класс`,
                            h.address_number AS `Номер дома`,
                            h.capacity AS `Вместимость`,
                            h.description AS `Описание`
                        FROM house h
                        LEFT JOIN home_class hc ON h.home_class_id = hc.id
                        ORDER BY h.id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);

                        // Создаем таблицу для отображения (без ID)
                        allDataTable = new DataTable();
                        allDataTable.Columns.Add("Название", typeof(string));
                        allDataTable.Columns.Add("Класс", typeof(string));
                        allDataTable.Columns.Add("Номер дома", typeof(string));
                        allDataTable.Columns.Add("Вместимость", typeof(string));
                        allDataTable.Columns.Add("Описание", typeof(string));

                        // Заполняем данными
                        foreach (DataRow row in originalDataTable.Rows)
                        {
                            DataRow newRow = allDataTable.NewRow();
                            newRow["Название"] = row["Название"].ToString();
                            newRow["Класс"] = row["Класс"].ToString();
                            newRow["Номер дома"] = row["Номер дома"].ToString();
                            newRow["Вместимость"] = row["Вместимость"].ToString();
                            newRow["Описание"] = row["Описание"].ToString();
                            allDataTable.Rows.Add(newRow);
                        }

                        totalPages = (int)Math.Ceiling((double)allDataTable.Rows.Count / pageSize);
                        if (totalPages == 0) totalPages = 1;

                        LoadCurrentPage();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке домов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentPage()
        {
            if (allDataTable == null) return;
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
                currentPageDataTable.ImportRow(filteredData.Rows[i]);
            dataGridView1.DataSource = currentPageDataTable;

            // Отключение сортировки по заголовкам колонок
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            UpdatePageInfo();
        }

        private void ApplyFilter()
        {
            if (allDataTable == null) return;

            string searchText = textBoxSearch.Text.Trim().Replace("'", "''");
            string classFilter = comboBoxClassFilter.SelectedItem?.ToString();

            string filter = "";

            if (!string.IsNullOrEmpty(searchText))
                filter += $"[Название] LIKE '%{searchText}%' OR [Номер дома] LIKE '%{searchText}%' OR [Описание] LIKE '%{searchText}%'";

            if (!string.IsNullOrEmpty(classFilter) && classFilter != "Все классы")
            {
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                filter += $"[Класс] = '{classFilter.Replace("'", "''")}'";
            }

            allDataTable.DefaultView.RowFilter = filter;
        }

        private void UpdatePageInfo()
        {
            int totalFilteredRecords = allDataTable?.DefaultView.Count ?? 0;
            labelPageInfo.Text = $"Страница {currentPage} из {totalPages} | Всего записей: {totalFilteredRecords}";

            buttonPrev.Enabled = currentPage > 1;
            buttonNext.Enabled = currentPage < totalPages;

            buttonPrev.BackColor = buttonPrev.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(100, 100, 100);
            buttonNext.BackColor = buttonNext.Enabled ? Color.FromArgb(106, 153, 85) : Color.FromArgb(100, 100, 100);

            // Активируем кнопку редактирования только если есть выделенная строка
            buttonEdit.Enabled = (dataGridView1.SelectedRows.Count > 0);
            buttonEdit.BackColor = buttonEdit.Enabled ? Color.FromArgb(76, 145, 195) : Color.FromArgb(100, 100, 100);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadCurrentPage();
        }

        private void comboBoxClassFilter_SelectedIndexChanged(object sender, EventArgs e)
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddHous addForm = new AddHous();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllHousesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditSelectedHouse();
        }

        private void EditSelectedHouse()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите дом для редактирования.", "Внимание",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем индекс выбранной строки на текущей странице
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Получаем DataRow из currentPageDataTable
                if (selectedRowIndex >= 0 && selectedRowIndex < currentPageDataTable.Rows.Count)
                {
                    DataRow selectedRow = currentPageDataTable.Rows[selectedRowIndex];

                    // Получаем название и класс дома из выбранной строки
                    string selectedName = selectedRow["Название"].ToString();
                    string selectedClass = selectedRow["Класс"].ToString();

                    // Ищем соответствующую запись в originalDataTable по названию и классу
                    DataRow[] matchingRows = originalDataTable.Select(
                        $"[Название] = '{selectedName.Replace("'", "''")}' AND " +
                        $"[Класс] = '{selectedClass.Replace("'", "''")}'");

                    if (matchingRows.Length > 0)
                    {
                        int houseId = Convert.ToInt32(matchingRows[0]["ID"]);

                        // Открываем форму редактирования
                        AddHous editForm = new AddHous(houseId);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllHousesData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти выбранный дом в базе данных.", "Ошибка",
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // только просмотр
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
                EditSelectedHouse();
            }
        }

        // Обработчик клика по заголовку столбца (для блокировки сортировки)
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ничего не делаем - сортировка отключена
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelBackground_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}