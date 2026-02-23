using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class ServiceList : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private DataTable allDataTable;
        private DataTable currentPageDataTable;
        private int totalPages = 1;
        private DataTable originalDataTable; // Для хранения ID услуг

        public ServiceList()
        {
            InitializeComponent();
            SetupModernControls();
        }

        private void SetupModernControls()
        {
            this.DoubleBuffered = true;
        }

        private void ServiceList_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;

            LoadAllServicesData();
            UpdatePageInfo();
            ConfigureDataGridViewColumns();

            // ОТКЛЮЧАЕМ СОРТИРОВКУ ДЛЯ ВСЕХ КОЛОНОК
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadAllServicesData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            id,
                            name_services AS `Наименование`,
                            duration AS `Длительность`,
                            price AS `Цена`,
                            description AS `Описание`
                        FROM services
                        ORDER BY name_services";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);

                        // Создаем таблицу для отображения с форматированием
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
            allDataTable.Columns.Add("Наименование", typeof(string));
            allDataTable.Columns.Add("Длительность", typeof(string));
            allDataTable.Columns.Add("Цена", typeof(string));
            allDataTable.Columns.Add("Описание", typeof(string));

            // Заполняем данными с форматированием
            foreach (DataRow row in originalDataTable.Rows)
            {
                DataRow newRow = allDataTable.NewRow();

                // Наименование
                newRow["Наименование"] = row["Наименование"].ToString();

                // Длительность
                if (row["Длительность"] != DBNull.Value && !string.IsNullOrEmpty(row["Длительность"].ToString()))
                {
                    int duration = Convert.ToInt32(row["Длительность"]);
                    newRow["Длительность"] = FormatDuration(duration);
                }
                else
                {
                    newRow["Длительность"] = "Не указана";
                }

                // Цена
                decimal price = Convert.ToDecimal(row["Цена"]);
                newRow["Цена"] = FormatPrice(price);

                // Описание
                newRow["Описание"] = row["Описание"].ToString();

                allDataTable.Rows.Add(newRow);
            }
        }

        private string FormatDuration(int minutes)
        {
            if (minutes == 0) return "Не указана";

            if (minutes < 60)
                return $"{minutes} мин";
            else if (minutes % 60 == 0)
                return $"{minutes / 60} час";
            else
                return $"{minutes / 60} час {minutes % 60} мин";
        }

        private string FormatPrice(decimal price)
        {
            return $"{price:N2} ₽";
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

                // СНОВА ОТКЛЮЧАЕМ СОРТИРОВКУ (на случай перезагрузки данных)
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
                string filter = "";

                if (!string.IsNullOrEmpty(searchText))
                {
                    filter = $"[Наименование] LIKE '%{searchText}%' OR " +
                             $"[Описание] LIKE '%{searchText}%'";
                }

                allDataTable.DefaultView.RowFilter = filter;
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // Устанавливаем заголовки и ширину колонок
                if (dataGridView1.Columns.Contains("Наименование"))
                {
                    dataGridView1.Columns["Наименование"].HeaderText = "Наименование услуги";
                    dataGridView1.Columns["Наименование"].Width = 250;
                }
                if (dataGridView1.Columns.Contains("Длительность"))
                {
                    dataGridView1.Columns["Длительность"].HeaderText = "Длительность";
                    dataGridView1.Columns["Длительность"].Width = 120;
                }
                if (dataGridView1.Columns.Contains("Цена"))
                {
                    dataGridView1.Columns["Цена"].HeaderText = "Цена";
                    dataGridView1.Columns["Цена"].Width = 120;
                    dataGridView1.Columns["Цена"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dataGridView1.Columns.Contains("Описание"))
                {
                    dataGridView1.Columns["Описание"].HeaderText = "Описание";
                    dataGridView1.Columns["Описание"].Width = 360;
                }

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

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
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
                AddService addForm = new AddService();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllServicesData();
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
            EditSelectedService();
        }

        private void EditSelectedService()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите услугу для редактирования.", "Внимание",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем индекс выбранной строки на текущей странице
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Получаем DataRow из currentPageDataTable
                if (selectedRowIndex >= 0 && selectedRowIndex < currentPageDataTable.Rows.Count)
                {
                    DataRow selectedRow = currentPageDataTable.Rows[selectedRowIndex];

                    // Получаем название услуги из выбранной строки
                    string selectedName = selectedRow["Наименование"].ToString();

                    // Ищем соответствующую запись в originalDataTable по названию
                    DataRow[] matchingRows = originalDataTable.Select($"[Наименование] = '{selectedName.Replace("'", "''")}'");

                    if (matchingRows.Length > 0)
                    {
                        int serviceId = Convert.ToInt32(matchingRows[0]["id"]);

                        // Открываем форму редактирования
                        AddService editForm = new AddService(serviceId);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllServicesData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти выбранную услугу в базе данных.", "Ошибка",
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка кликов по ячейкам (если нужно)
        }

        // Двойной клик по строке для редактирования
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedService();
            }
        }

        // Обработчик клика по заголовку столбца (для блокировки сортировки)
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ничего не делаем - сортировка отключена
            // Это предотвратит случайную сортировку, если где-то осталась настройка
        }
    }
}