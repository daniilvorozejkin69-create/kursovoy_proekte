using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class EditBookingForm : Form
    {
        private int bookingId;

        public EditBookingForm(int bookingId)
        {
            InitializeComponent();
            this.bookingId = bookingId;

            textBoxClientName.ReadOnly = true;
            textBoxHouseName.ReadOnly = true;
            dateTimePickerCheckIn.Enabled = false;
            dateTimePickerCheckOut.Enabled = false;
            numericUpDownDays.Enabled = false;
            numericUpDownTotalPrice.Enabled = false;
            numericUpDownDeposit.Enabled = false;
            comboBoxStatus.Enabled = false;

            numericUpDownDays.Minimum = 0;
            numericUpDownTotalPrice.Minimum = 0;
            numericUpDownDeposit.Minimum = 0;

            LoadBookingData();
        }

        private void LoadBookingData()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT b.id, c.FIO AS client_name, h.name AS house_name,
                               b.check_in_date, b.check_out_date, b.days_count,
                               b.total_price, b.deposit_paid, b.status, b.notes
                        FROM booking b
                        JOIN client c ON b.client_id = c.id
                        JOIN house h ON b.house_id = h.id
                        WHERE b.id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", bookingId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxClientName.Text = reader["client_name"].ToString();
                                textBoxHouseName.Text = reader["house_name"].ToString();
                                dateTimePickerCheckIn.Value = Convert.ToDateTime(reader["check_in_date"]);
                                dateTimePickerCheckOut.Value = Convert.ToDateTime(reader["check_out_date"]);

                                int days = Convert.ToInt32(reader["days_count"]);
                                numericUpDownDays.Value = days >= numericUpDownDays.Minimum && days <= numericUpDownDays.Maximum ? days : numericUpDownDays.Minimum;

                                decimal price = Convert.ToDecimal(reader["total_price"]);
                                numericUpDownTotalPrice.Value = price >= numericUpDownTotalPrice.Minimum && price <= numericUpDownTotalPrice.Maximum ? price : numericUpDownTotalPrice.Minimum;

                                decimal deposit = reader["deposit_paid"] != DBNull.Value ? Convert.ToDecimal(reader["deposit_paid"]) : 0;
                                numericUpDownDeposit.Value = deposit >= numericUpDownDeposit.Minimum && deposit <= numericUpDownDeposit.Maximum ? deposit : numericUpDownDeposit.Minimum;

                                textBoxNotes.Text = reader["notes"]?.ToString() ?? "";

                                string status = reader["status"].ToString();
                                if (status == "pending") comboBoxStatus.SelectedItem = "Ожидание";
                                else if (status == "confirmed") comboBoxStatus.SelectedItem = "Подтверждено";
                                else if (status == "cancelled") comboBoxStatus.SelectedItem = "Отменено";
                                else if (status == "completed") comboBoxStatus.SelectedItem = "Завершено";
                                else if (status == "expired") comboBoxStatus.SelectedItem = "Истекло";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dateTimePickerCheckIn.Value >= dateTimePickerCheckOut.Value)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда.");
                return;
            }

            int days = (dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).Days;
            if (days <= 0) { MessageBox.Show("Минимум 1 день."); return; }

            if (MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string st = "";
                    if (comboBoxStatus.SelectedItem.ToString() == "Ожидание") st = "pending";
                    else if (comboBoxStatus.SelectedItem.ToString() == "Подтверждено") st = "confirmed";
                    else if (comboBoxStatus.SelectedItem.ToString() == "Отменено") st = "cancelled";
                    else if (comboBoxStatus.SelectedItem.ToString() == "Завершено") st = "completed";

                    string query = @"UPDATE booking SET check_in_date=@d1, check_out_date=@d2, days_count=@d, total_price=@p, deposit_paid=@dp, status=@s, notes=@n WHERE id=@id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@d1", dateTimePickerCheckIn.Value);
                        cmd.Parameters.AddWithValue("@d2", dateTimePickerCheckOut.Value);
                        cmd.Parameters.AddWithValue("@d", days);
                        cmd.Parameters.AddWithValue("@p", numericUpDownTotalPrice.Value);
                        cmd.Parameters.AddWithValue("@dp", numericUpDownDeposit.Value);
                        cmd.Parameters.AddWithValue("@s", st);
                        cmd.Parameters.AddWithValue("@n", textBoxNotes.Text);
                        cmd.Parameters.AddWithValue("@id", bookingId);
                        cmd.ExecuteNonQuery();
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e) => CalculateDays();
        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e) => CalculateDays();

        private void CalculateDays()
        {
            if (dateTimePickerCheckOut.Value > dateTimePickerCheckIn.Value)
                numericUpDownDays.Value = (dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).Days;
        }
    }
}