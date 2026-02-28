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
            else
            {
                labelUserInfo.Text = "Сотрудник";
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

            dataGridViewStaff.SelectionChanged += DataGridViewStaff_SelectionChanged;
            dataGridViewStaff.CellDoubleClick += DataGridViewStaff_CellDoubleClick;

            textBoxSearch.Enter += TextBoxSearch_Enter;
            textBoxSearch.Leave += TextBoxSearch_Leave;

            // Эффекты наведения
            buttonAdd.MouseEnter += ButtonAdd_MouseEnter;
            buttonAdd.MouseLeave += ButtonAdd_MouseLeave;
            buttonEdit.MouseEnter += ButtonEdit_MouseEnter;
            buttonEdit.MouseLeave += ButtonEdit_MouseLeave;
            buttonDelete.MouseEnter += ButtonDelete_MouseEnter;
            buttonDelete.MouseLeave += ButtonDelete_MouseLeave;
            buttonRefresh.MouseEnter += ButtonRefresh_MouseEnter;
            buttonRefresh.MouseLeave += ButtonRefresh_MouseLeave;
            buttonPrev.MouseEnter += ButtonPrev_MouseEnter;
            buttonPrev.MouseLeave += ButtonPrev_MouseLeave;
            buttonNext.MouseEnter += ButtonNext_MouseEnter;
            buttonNext.MouseLeave += ButtonNext_MouseLeave;
            buttonBackToMenu.MouseEnter += ButtonBackToMenu_MouseEnter;
            buttonBackToMenu.MouseLeave += ButtonBackToMenu_MouseLeave;
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
                            pos.position_name as Должность,
                            p.job_title,
                            p.email,
                            p.telephone_number,
                            p.photo,
                            p.hire_date,
                            p.is_active,
                            u.id as user_id,
                            u.login,
                            u.role_id,
                            r.role_name
                        FROM personal p
                        LEFT JOIN positions pos ON p.position_id = pos.id
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
                            newRow["Должность"] = row["Должность"]?.ToString() ?? row["job_title"].ToString();
                            newRow["Роль"] = row["role_name"]?.ToString() ?? "Нет доступа";
                            newRow["Логин"] = row["login"]?.ToString() ?? "-";
                            newRow["Телефон"] = MaskPhone(row["telephone_number"].ToString());
                            newRow["Email"] = MaskEmail(row["email"].ToString());

                            if (row["hire_date"] != DBNull.Value)
                            {
                                DateTime hireDate = Convert.ToDateTime(row["hire_date"]);
                                newRow["Дата приёма"] = hireDate.ToString("dd.MM.yyyy");
                            }
                            else
                            {
                                newRow["Дата приёма"] = "";
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

            buttonEdit.BackColor = buttonEdit.Enabled ? Color.FromArgb(46, 204, 113) : Color.FromArgb(200, 200, 200);
            buttonDelete.BackColor = buttonDelete.Enabled ? Color.FromArgb(231, 76, 60) : Color.FromArgb(200, 200, 200);
        }

        private void ApplyFilter()
        {
            if (allStaffData == null) return;

            string search = textBoxSearch.Text.Trim();
            if (search == "Поиск по ФИО, должности..." || string.IsNullOrEmpty(search))
            {
                search = "";
            }

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

        // ============================================
        // ОБРАБОТЧИКИ СОБЫТИЙ
        // ============================================

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Поиск по ФИО, должности...")
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
                textBoxSearch.Text = "Поиск по ФИО, должности...";
                textBoxSearch.ForeColor = Color.Gray;
            }
            textBoxSearch.BackColor = Color.White;
        }

        private void Filter_Changed(object sender, EventArgs e)
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
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadAllStaffData();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            EditSelectedStaff();
        }

        private void EditSelectedStaff()
        {
            if (dataGridViewStaff.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridViewStaff.SelectedRows[0].Cells["ID"].Value);

            AddStaff editForm = new AddStaff(id);
            editForm.ShowDialog();
            if (editForm.DialogResult == DialogResult.OK)
            {
                LoadAllStaffData();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStaff.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridViewStaff.SelectedRows[0].Cells["ID"].Value);
            int userId = 0;

            // Находим userId в originalStaffData
            DataRow[] rows = originalStaffData.Select($"id = {id}");
            if (rows.Length > 0 && rows[0]["user_id"] != DBNull.Value)
            {
                userId = Convert.ToInt32(rows[0]["user_id"]);
            }

            if (userId == Session.UserId)
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
                EditSelectedStaff();
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

        private void ButtonDelete_MouseEnter(object sender, EventArgs e)
        {
            if (buttonDelete.Enabled)
            {
                buttonDelete.BackColor = Color.FromArgb(192, 57, 43);
                buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Bold);
            }
        }

        private void ButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            if (buttonDelete.Enabled)
            {
                buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
            }
            buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Regular);
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
    }
}