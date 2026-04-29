using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class DiscountsForm : Form
    {
        public DiscountsForm()
        {
            InitializeComponent();
            LoadDiscounts();
            dataGridViewDiscounts.SelectionChanged += DataGridViewDiscounts_SelectionChanged;
            buttonSave.Click += ButtonSave_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonAdd.Click += ButtonAdd_Click;
        }

        private void LoadDiscounts()
        {
            try
            {
                dataGridViewDiscounts.Rows.Clear();
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id, name, 
                                    CASE type 
                                        WHEN 'season' THEN 'Сезонная'
                                        WHEN 'loyalty' THEN 'Пост. клиент'
                                        WHEN 'promo' THEN 'Промокод'
                                        WHEN 'special' THEN 'Специальная'
                                    END AS type_name, 
                                    percent, min_days, description, is_active 
                                    FROM discounts ORDER BY name";
                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewDiscounts.Rows.Add(
                                reader["id"],
                                reader["name"],
                                reader["percent"],
                                reader["type_name"],
                                reader["min_days"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки скидок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewDiscounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDiscounts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewDiscounts.SelectedRows[0].Cells["Id"].Value);
                LoadDiscountDetails(id);
            }
        }

        private void LoadDiscountDetails(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM discounts WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["name"].ToString();
                                comboBoxType.SelectedIndex = GetTypeIndex(reader["type"].ToString());
                                numericUpDownPercent.Value = Convert.ToDecimal(reader["percent"]);
                                numericUpDownMinDays.Value = Convert.ToInt32(reader["min_days"]);
                                textBoxDescription.Text = reader["description"].ToString();
                                checkBoxActive.Checked = Convert.ToBoolean(reader["is_active"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetTypeIndex(string type)
        {
            switch (type)
            {
                case "season": return 0;
                case "loyalty": return 1;
                case "promo": return 2;
                case "special": return 3;
                default: return 0;
            }
        }

        private string GetTypeValue(int index)
        {
            switch (index)
            {
                case 0: return "season";
                case 1: return "loyalty";
                case 2: return "promo";
                case 3: return "special";
                default: return "season";
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiscounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите скидку для редактирования.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название скидки.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewDiscounts.SelectedRows[0].Cells["Id"].Value);
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE discounts SET 
                                    name = @name, type = @type, percent = @percent,
                                    min_days = @minDays, description = @description,
                                    is_active = @isActive WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@type", GetTypeValue(comboBoxType.SelectedIndex));
                        cmd.Parameters.AddWithValue("@percent", numericUpDownPercent.Value);
                        cmd.Parameters.AddWithValue("@minDays", (int)numericUpDownMinDays.Value);
                        cmd.Parameters.AddWithValue("@description", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@isActive", checkBoxActive.Checked);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDiscounts();
                MessageBox.Show("Скидка успешно сохранена.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiscounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите скидку для удаления.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string discountName = dataGridViewDiscounts.SelectedRows[0].Cells["Name"].Value.ToString();
            if (MessageBox.Show($"Удалить скидку «{discountName}»?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewDiscounts.SelectedRows[0].Cells["Id"].Value);
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM discounts WHERE id = @id";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDiscounts();
                    ClearEditFields();
                    MessageBox.Show("Скидка удалена.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название скидки.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO discounts (name, type, percent, min_days, description, is_active) 
                                    VALUES (@name, @type, @percent, @minDays, @description, @isActive)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@type", GetTypeValue(comboBoxType.SelectedIndex));
                        cmd.Parameters.AddWithValue("@percent", numericUpDownPercent.Value);
                        cmd.Parameters.AddWithValue("@minDays", (int)numericUpDownMinDays.Value);
                        cmd.Parameters.AddWithValue("@description", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@isActive", checkBoxActive.Checked);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDiscounts();
                ClearEditFields();
                MessageBox.Show("Новая скидка добавлена.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearEditFields()
        {
            textBoxName.Text = "";
            comboBoxType.SelectedIndex = 0;
            numericUpDownPercent.Value = 10;
            numericUpDownMinDays.Value = 1;
            textBoxDescription.Text = "";
            checkBoxActive.Checked = true;
        }

        private void dataGridViewDiscounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}