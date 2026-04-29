using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class DirectoriesForm : Form
    {
        private string currentTable = "positions";
        private DataTable currentDataTable;
        private int currentId = 0;

        public DirectoriesForm()
        {
            InitializeComponent();
            LoadData("positions");
        }

        private void LoadData(string tableName)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "";

                    switch (tableName)
                    {
                        case "positions":
                            query = @"
                                SELECT 
                                    id,
                                    position_name AS 'Название должности',
                                    description AS 'Описание',
                                    base_salary AS 'Оклад',
                                    created_at AS 'Дата создания'
                                FROM positions
                                ORDER BY id";
                            labelTitle.Text = "👔 СПРАВОЧНИК ДОЛЖНОСТЕЙ";
                            break;

                        case "home_class":
                            query = @"
                                SELECT 
                                    id,
                                    class AS 'Класс дома',
                                    description AS 'Описание'
                                FROM home_class
                                ORDER BY id";
                            labelTitle.Text = "🏠 СПРАВОЧНИК КЛАССОВ ДОМОВ";
                            break;
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    currentDataTable = new DataTable();
                    adapter.Fill(currentDataTable);

                    dataGridViewDirectories.DataSource = currentDataTable;

                    // Настройка колонок
                    if (dataGridViewDirectories.Columns["id"] != null)
                        dataGridViewDirectories.Columns["id"].Visible = false;

                    foreach (DataGridViewColumn col in dataGridViewDirectories.Columns)
                    {
                        if (col.Name != "id")
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }

                    if (dataGridViewDirectories.Columns.Contains("Оклад"))
                    {
                        dataGridViewDirectories.Columns["Оклад"].DefaultCellStyle.Format = "N2";
                        dataGridViewDirectories.Columns["Оклад"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    labelCount.Text = $"Всего записей: {currentDataTable.Rows.Count}";
                    currentTable = tableName;

                    // Подсветка активной кнопки
                    ResetMenuButtons();
                    if (tableName == "positions")
                    {
                        buttonPositions.BackColor = Color.FromArgb(90, 160, 210);
                    }
                    else
                    {
                        buttonHouseClass.BackColor = Color.FromArgb(90, 160, 210);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetMenuButtons()
        {
            buttonPositions.BackColor = Color.FromArgb(106, 153, 85);
            buttonHouseClass.BackColor = Color.FromArgb(106, 153, 85);
        }

        private void buttonPositions_Click(object sender, EventArgs e)
        {
            LoadData("positions");
        }

        private void buttonHouseClass_Click(object sender, EventArgs e)
        {
            LoadData("home_class");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (currentTable == "positions")
            {
                // Открываем форму добавления должности
                AddEditPositionForm form = new AddEditPositionForm(0);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(currentTable);
                }
            }
            else if (currentTable == "home_class")
            {
                // Открываем форму добавления класса дома
                AddEditHouseClassForm form = new AddEditHouseClassForm(0);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(currentTable);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDirectories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID выбранной записи
            int id = Convert.ToInt32(dataGridViewDirectories.SelectedRows[0].Cells["id"].Value);

            if (currentTable == "positions")
            {
                // Открываем форму редактирования должности
                AddEditPositionForm form = new AddEditPositionForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(currentTable);
                }
            }
            else if (currentTable == "home_class")
            {
                // Открываем форму редактирования класса дома
                AddEditHouseClassForm form = new AddEditHouseClassForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(currentTable);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDirectories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewDirectories.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = $"DELETE FROM {currentTable} WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Запись успешно удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(currentTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData(currentTable);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Форма добавления/редактирования должности
    public partial class AddEditPositionForm : Form
    {
        private int positionId;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtSalary;
        private Button btnSave;
        private Button btnCancel;

        public AddEditPositionForm(int id)
        {
            positionId = id;
            InitializeComponent();
            if (positionId > 0)
            {
                this.Text = "Редактирование должности";
                LoadPositionData();
            }
            else
            {
                this.Text = "Добавление должности";
            }
        }

        private void InitializeComponent()
        {
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblName = new Label() { Text = "Название должности:", Left = 20, Top = 20, Width = 120 };
            txtName = new TextBox() { Left = 150, Top = 20, Width = 200 };

            Label lblDescription = new Label() { Text = "Описание:", Left = 20, Top = 60, Width = 120 };
            txtDescription = new TextBox() { Left = 150, Top = 60, Width = 200 };

            Label lblSalary = new Label() { Text = "Оклад:", Left = 20, Top = 100, Width = 120 };
            txtSalary = new TextBox() { Left = 150, Top = 100, Width = 200 };

            btnSave = new Button() { Text = "Сохранить", Left = 150, Top = 150, Width = 100, Height = 30 };
            btnSave.BackColor = Color.FromArgb(76, 145, 195);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button() { Text = "Отмена", Left = 260, Top = 150, Width = 100, Height = 30 };
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblName, txtName, lblDescription, txtDescription,
                lblSalary, txtSalary, btnSave, btnCancel });
        }

        private void LoadPositionData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT position_name, description, base_salary FROM positions WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", positionId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["position_name"].ToString();
                                txtDescription.Text = reader["description"].ToString();
                                txtSalary.Text = reader["base_salary"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название должности!");
                return;
            }

            decimal salary = 0;
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                salary = 0;
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query;
                    if (positionId > 0)
                    {
                        query = "UPDATE positions SET position_name = @name, description = @desc, base_salary = @salary WHERE id = @id";
                    }
                    else
                    {
                        query = "INSERT INTO positions (position_name, description, base_salary, created_at) VALUES (@name, @desc, @salary, NOW())";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        if (positionId > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", positionId);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Данные сохранены!", "Успех");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }

    // Форма добавления/редактирования класса дома
    public partial class AddEditHouseClassForm : Form
    {
        private int classId;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;

        public AddEditHouseClassForm(int id)
        {
            classId = id;
            InitializeComponent();
            if (classId > 0)
            {
                this.Text = "Редактирование класса дома";
                LoadClassData();
            }
            else
            {
                this.Text = "Добавление класса дома";
            }
        }

        private void InitializeComponent()
        {
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblName = new Label() { Text = "Название класса:", Left = 20, Top = 20, Width = 120 };
            txtName = new TextBox() { Left = 150, Top = 20, Width = 200 };

            Label lblDescription = new Label() { Text = "Описание:", Left = 20, Top = 60, Width = 120 };
            txtDescription = new TextBox() { Left = 150, Top = 60, Width = 200 };

            btnSave = new Button() { Text = "Сохранить", Left = 150, Top = 110, Width = 100, Height = 30 };
            btnSave.BackColor = Color.FromArgb(76, 145, 195);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button() { Text = "Отмена", Left = 260, Top = 110, Width = 100, Height = 30 };
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblName, txtName, lblDescription, txtDescription, btnSave, btnCancel });
        }

        private void LoadClassData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT class, description FROM home_class WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", classId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["class"].ToString();
                                txtDescription.Text = reader["description"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название класса!");
                return;
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query;
                    if (classId > 0)
                    {
                        query = "UPDATE home_class SET class = @name, description = @desc WHERE id = @id";
                    }
                    else
                    {
                        query = "INSERT INTO home_class (class, description) VALUES (@name, @desc)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        if (classId > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", classId);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Данные сохранены!", "Успех");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}