using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AddClient : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingClientId = -1;
        public bool DataChanged { get; private set; } = false;

        public AddClient()
        {
            InitializeComponent();
            currentMode = FormMode.Add;
            labelHeader.Text = "➕  ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА";
            buttonSave.Text = "✅  ДОБАВИТЬ КЛИЕНТА";
            dateTimePickerBirthDate.MaxDate = DateTime.Now;
            dateTimePickerBirthDate.MinDate = DateTime.Now.AddYears(-100);
        }

        public AddClient(int clientId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingClientId = clientId;
            labelHeader.Text = "✏️  РЕДАКТИРОВАНИЕ КЛИЕНТА";
            buttonSave.Text = "💾  СОХРАНИТЬ ИЗМЕНЕНИЯ";
            dateTimePickerBirthDate.MaxDate = DateTime.Now;
            dateTimePickerBirthDate.MinDate = DateTime.Now.AddYears(-100);
            LoadClientData(clientId);
        }

        private void LoadClientData(int clientId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = "SELECT FIO, passport_series_number, date_of_birth, telephone_number, email, gender FROM client WHERE id=@id";
                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                textBoxFIO.Text = r["FIO"].ToString();
                                string p = r["passport_series_number"].ToString();
                                if (p.Length == 10) maskedTextBoxPassport.Text = $"{p.Substring(0, 2)} {p.Substring(2, 2)} {p.Substring(4)}";
                                else maskedTextBoxPassport.Text = p;
                                if (r["date_of_birth"] != DBNull.Value) dateTimePickerBirthDate.Value = Convert.ToDateTime(r["date_of_birth"]);
                                string ph = r["telephone_number"].ToString();
                                string d = new string(ph.Where(char.IsDigit).ToArray());
                                if (d.Length >= 10) maskedTextBoxPhone.Text = d.Substring(d.Length - 10);
                                textBoxEmail.Text = r["email"].ToString();
                                string g = r["gender"].ToString();
                                comboBoxGender.SelectedIndex = (g == "М" || g == "Мужской") ? 0 : 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); Close(); }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFIO.Text)) { MessageBox.Show("Введите ФИО."); return; }
            string passport = new string(maskedTextBoxPassport.Text.Where(char.IsDigit).ToArray());
            if (passport.Length != 10) { MessageBox.Show("Паспорт должен быть 10 цифр."); return; }
            string phone = new string(maskedTextBoxPhone.Text.Where(char.IsDigit).ToArray());
            if (phone.Length < 10) { MessageBox.Show("Введите телефон полностью."); return; }
            if (phone.Length >= 11) phone = phone.Substring(phone.Length - 10);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql;
                    if (currentMode == FormMode.Add)
                        sql = "INSERT INTO client (FIO, passport_series_number, date_of_birth, telephone_number, email, gender) VALUES (@f, @p, @d, @t, @e, @g)";
                    else
                        sql = "UPDATE client SET FIO=@f, passport_series_number=@p, date_of_birth=@d, telephone_number=@t, email=@e, gender=@g WHERE id=@id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@f", textBoxFIO.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", passport);
                        cmd.Parameters.AddWithValue("@d", dateTimePickerBirthDate.Value);
                        cmd.Parameters.AddWithValue("@t", $"+7({phone.Substring(0, 3)}){phone.Substring(3, 3)}-{phone.Substring(6, 2)}-{phone.Substring(8)}");
                        cmd.Parameters.AddWithValue("@e", string.IsNullOrWhiteSpace(textBoxEmail.Text) ? DBNull.Value : (object)textBoxEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@g", comboBoxGender.SelectedIndex == 0 ? "М" : "Ж");
                        if (currentMode == FormMode.Edit) cmd.Parameters.AddWithValue("@id", editingClientId);
                        cmd.ExecuteNonQuery();
                    }
                }
                DataChanged = true;
                MessageBox.Show(currentMode == FormMode.Add ? "Клиент добавлен!" : "Изменения сохранены!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonMenu_Click(object sender, EventArgs e) { Close(); }
    }
}