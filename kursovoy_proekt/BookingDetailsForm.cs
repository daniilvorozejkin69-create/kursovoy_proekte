using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class BookingDetailsForm : Form
    {
        private MySqlDataReader bookingData;

        public BookingDetailsForm(MySqlDataReader reader)
        {
            InitializeComponent();
            this.bookingData = reader;
            LoadBookingDetails(reader);
        }

        private void LoadBookingDetails(MySqlDataReader reader)
        {
            try
            {
                // Основная информация
                labelBookingId.Text = $"№ {reader["id"]}";
                labelClientName.Text = reader["client_name"].ToString();
                labelPassport.Text = reader["passport_series_number"].ToString();
                labelPhone.Text = reader["telephone_number"].ToString();
                labelEmail.Text = reader["email"].ToString();

                // Информация о доме
                labelHouseName.Text = reader["house_name"].ToString();
                labelHouseClass.Text = reader["house_class"].ToString();
                labelCapacity.Text = reader["capacity"].ToString();
                textBoxHouseDescription.Text = reader["house_description"].ToString();

                // Даты
                DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                labelDates.Text = $"{checkIn:dd.MM.yyyy} - {checkOut:dd.MM.yyyy}";
                labelDaysCount.Text = reader["days_count"].ToString();

                // Стоимость
                decimal totalPrice = Convert.ToDecimal(reader["total_price"]);
                decimal deposit = reader["deposit_paid"] != DBNull.Value ? Convert.ToDecimal(reader["deposit_paid"]) : 0;
                labelTotalPrice.Text = $"{totalPrice:N2} ₽";
                labelDeposit.Text = $"{deposit:N2} ₽";
                labelBalance.Text = $"{(totalPrice - deposit):N2} ₽";

                // Статус
                string status = reader["status"].ToString();
                labelStatus.Text = GetStatusDisplay(status);
                SetStatusColor(labelStatus, status);

                // Дополнительная информация
                labelCreatedBy.Text = reader["created_by_name"].ToString();
                labelCreatedDate.Text = Convert.ToDateTime(reader["booking_date"]).ToString("dd.MM.yyyy HH:mm");
                textBoxNotes.Text = reader["notes"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusDisplay(string status)
        {
            if (status == "pending")
                return "Ожидание подтверждения";
            else if (status == "confirmed")
                return "Подтверждено";
            else if (status == "cancelled")
                return "Отменено";
            else if (status == "completed")
                return "Завершено (преобразовано в заселение)";
            else if (status == "expired")
                return "Истекло";
            else
                return status;
        }

        private void SetStatusColor(Label label, string status)
        {
            Color color;

            if (status == "pending")
                color = Color.Orange;
            else if (status == "confirmed")
                color = Color.Green;
            else if (status == "cancelled")
                color = Color.Red;
            else if (status == "completed")
                color = Color.Blue;
            else if (status == "expired")
                color = Color.Gray;
            else
                color = Color.Black;

            label.ForeColor = color;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintDocument_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                    MessageBox.Show("Документ отправлен на печать", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);

            float yPos = 50;
            float leftMargin = 50;

            // Заголовок
            g.DrawString("ДЕТАЛИ БРОНИРОВАНИЯ", titleFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Информация
            g.DrawString($"Номер бронирования: {labelBookingId.Text.Replace("№ ", "")}",
                headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            g.DrawString($"Клиент: {labelClientName.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Паспорт: {labelPassport.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Телефон: {labelPhone.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Email: {labelEmail.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            g.DrawString($"Дом: {labelHouseName.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Класс: {labelHouseClass.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Вместимость: {labelCapacity.Text} чел.", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            g.DrawString($"Даты: {labelDates.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Дней: {labelDaysCount.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            g.DrawString($"Стоимость: {labelTotalPrice.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Депозит: {labelDeposit.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Остаток: {labelBalance.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            g.DrawString($"Статус: {labelStatus.Text}", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            g.DrawString($"Создал(а): {labelCreatedBy.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Дата: {labelCreatedDate.Text}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            g.DrawString("_________________________", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString("Подпись", new Font("Arial", 8), Brushes.Black, leftMargin + 30, yPos);
        }
    }
}