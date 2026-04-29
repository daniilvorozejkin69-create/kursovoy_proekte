using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class EditBookingForm : Form
    {
        private int bookingId;
        private MySqlDataReader bookingData;

        public EditBookingForm(MySqlDataReader reader)
        {
            InitializeComponent();
            this.bookingData = reader;
            LoadBookingData();
        }

        private void LoadBookingData()
        {
            try
            {
                if (bookingData.Read())
                {
                    bookingId = Convert.ToInt32(bookingData["id"]);

                    // Заполняем поля данными
                    textBoxClientName.Text = bookingData["client_name"].ToString();
                    textBoxHouseName.Text = bookingData["house_name"].ToString();
                    dateTimePickerCheckIn.Value = Convert.ToDateTime(bookingData["check_in_date"]);
                    dateTimePickerCheckOut.Value = Convert.ToDateTime(bookingData["check_out_date"]);
                    numericUpDownDays.Value = Convert.ToDecimal(bookingData["days_count"]);
                    numericUpDownTotalPrice.Value = Convert.ToDecimal(bookingData["total_price"]);
                    numericUpDownDeposit.Value = bookingData["deposit_paid"] != DBNull.Value ?
                        Convert.ToDecimal(bookingData["deposit_paid"]) : 0;
                    textBoxNotes.Text = bookingData["notes"].ToString();

                    // Статус
                    string status = bookingData["status"].ToString();
                    comboBoxStatus.SelectedItem = GetStatusDisplay(status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusDisplay(string status)
        {
            switch (status)
            {
                case "pending": return "Ожидание";
                case "confirmed": return "Подтверждено";
                case "cancelled": return "Отменено";
                case "completed": return "Завершено";
                case "expired": return "Истекло";
                default: return status;
            }
        }

        private string GetStatusFromDisplay(string display)
        {
            switch (display)
            {
                case "Ожидание": return "pending";
                case "Подтверждено": return "confirmed";
                case "Отменено": return "cancelled";
                case "Завершено": return "completed";
                case "Истекло": return "expired";
                default: return display.ToLower();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем даты
                if (dateTimePickerCheckIn.Value >= dateTimePickerCheckOut.Value)
                {
                    MessageBox.Show("Дата выезда должна быть позже даты заезда", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подсчитываем количество дней
                int days = (dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).Days;
                if (days <= 0)
                {
                    MessageBox.Show("Минимальное время проживания - 1 день", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите сохранить изменения?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        UPDATE booking 
                        SET 
                            check_in_date = @check_in,
                            check_out_date = @check_out,
                            days_count = @days,
                            total_price = @price,
                            deposit_paid = @deposit,
                            status = @status,
                            notes = @notes
                        WHERE id = @booking_id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@check_in", dateTimePickerCheckIn.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@check_out", dateTimePickerCheckOut.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@days", days);
                        cmd.Parameters.AddWithValue("@price", numericUpDownTotalPrice.Value);
                        cmd.Parameters.AddWithValue("@deposit", numericUpDownDeposit.Value);
                        cmd.Parameters.AddWithValue("@status", GetStatusFromDisplay(comboBoxStatus.SelectedItem.ToString()));
                        cmd.Parameters.AddWithValue("@notes", textBoxNotes.Text);
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Изменения успешно сохранены", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            CalculateDays();
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            CalculateDays();
        }

        private void CalculateDays()
        {
            if (dateTimePickerCheckOut.Value > dateTimePickerCheckIn.Value)
            {
                int days = (dateTimePickerCheckOut.Value - dateTimePickerCheckIn.Value).Days;
                numericUpDownDays.Value = days;
            }
        }
    }
}