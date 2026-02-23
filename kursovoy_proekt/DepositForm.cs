using MySql.Data.MySqlClient;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class DepositForm : Form
    {
        private int bookingId;
        private decimal currentDeposit;
        private decimal bookingTotal;

        public DepositForm(int bookingId, decimal currentDeposit)
        {
            InitializeComponent();
            this.bookingId = bookingId;
            this.currentDeposit = currentDeposit;
            LoadBookingInfo();
        }

        private void LoadBookingInfo()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            b.total_price,
                            b.check_in_date,
                            c.FIO as client_name,
                            c.telephone_number,
                            h.name as house_name
                        FROM booking b
                        JOIN client c ON b.client_id = c.id
                        JOIN house h ON b.house_id = h.id
                        WHERE b.id = @booking_id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bookingTotal = Convert.ToDecimal(reader["total_price"]);

                                // Заполняем информацию
                                labelClientInfo.Text = reader["client_name"].ToString();
                                labelPhoneInfo.Text = reader["telephone_number"].ToString();
                                labelHouseInfo.Text = reader["house_name"].ToString();
                                labelCheckInInfo.Text = Convert.ToDateTime(reader["check_in_date"]).ToString("dd.MM.yyyy");
                            }
                        }
                    }
                }

                // Обновляем отображение сумм
                UpdateAmountsDisplay();

                // Устанавливаем максимальное значение
                numericUpDownDeposit.Maximum = bookingTotal;
                numericUpDownDeposit.Value = 0;

                // Настраиваем прогресс
                UpdateProgressBar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAmountsDisplay()
        {
            labelCurrentDeposit.Text = $"{currentDeposit:N2} ₽";
            labelBookingTotal.Text = $"{bookingTotal:N2} ₽";

            decimal remaining = bookingTotal - currentDeposit;
            labelRemaining.Text = $"{remaining:N2} ₽";

            // Процент внесенного депозита
            decimal depositPercentage = bookingTotal > 0 ? (currentDeposit / bookingTotal) * 100 : 0;
            labelDepositPercentage.Text = $"{depositPercentage:F1}%";
        }

        private void UpdateProgressBar()
        {
            decimal depositPercentage = bookingTotal > 0 ? (currentDeposit / bookingTotal) * 100 : 0;
            progressBarDeposit.Value = (int)Math.Min(depositPercentage, 100);
            labelProgress.Text = $"Внесено: {progressBarDeposit.Value}%";
        }

        private void buttonFullDeposit_Click(object sender, EventArgs e)
        {
            decimal remaining = bookingTotal - currentDeposit;
            numericUpDownDeposit.Value = remaining;
        }

        private void buttonHalfDeposit_Click(object sender, EventArgs e)
        {
            decimal remaining = bookingTotal - currentDeposit;
            numericUpDownDeposit.Value = remaining / 2;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal depositAmount = numericUpDownDeposit.Value;

                if (depositAmount <= 0)
                {
                    MessageBox.Show("Введите сумму депозита больше 0", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal remaining = bookingTotal - currentDeposit;
                if (depositAmount > remaining)
                {
                    MessageBox.Show("Сумма депозита не может превышать остаток к оплате", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подтверждение
                DialogResult result = MessageBox.Show(
                    $"Внести депозит в размере {depositAmount:N2} ₽?\n\n" +
                    $"Новый депозит: {currentDeposit + depositAmount:N2} ₽\n" +
                    $"Остаток к оплате: {remaining - depositAmount:N2} ₽",
                    "Подтверждение внесения депозита",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Сохранение в базе данных
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Обновляем депозит
                    string query = "UPDATE booking SET deposit_paid = deposit_paid + @deposit WHERE id = @booking_id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@deposit", depositAmount);
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Депозит успешно внесен!\nСумма: {depositAmount:N2} ₽", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения депозита: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownDeposit_ValueChanged(object sender, EventArgs e)
        {
            decimal depositAmount = numericUpDownDeposit.Value;
            decimal remaining = bookingTotal - currentDeposit;
            decimal newRemaining = remaining - depositAmount;

            labelNewRemaining.Text = $"{newRemaining:N2} ₽";
            labelNewDepositAmount.Text = $"{(currentDeposit + depositAmount):N2} ₽";

            // Активируем кнопку сохранения только если сумма больше 0
            buttonSave.Enabled = depositAmount > 0;
        }

        private void buttonPrintReceipt_Click(object sender, EventArgs e)
        {
            decimal depositAmount = numericUpDownDeposit.Value;
            if (depositAmount <= 0)
            {
                MessageBox.Show("Введите сумму для печати чека", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDepositReceipt(depositAmount);
        }

        private void PrintDepositReceipt(decimal amount)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument pd = new PrintDocument();
                printDialog.Document = pd;

                pd.PrintPage += PrintDocument_PrintPage;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                    MessageBox.Show("Чек отправлен на печать", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати чека: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Используем System.Drawing для рисования
            System.Drawing.Graphics g = e.Graphics;
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 8);

            float yPos = 50;
            float leftMargin = 50;

            // Заголовок
            g.DrawString("ЧЕК О ВНЕСЕНИИ ДЕПОЗИТА", titleFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Информация о бронировании
            g.DrawString($"Бронирование №: {bookingId}", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Клиент: {labelClientInfo.Text}", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Дом: {labelHouseInfo.Text}", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 20;

            // Суммы
            g.DrawString("=".PadRight(50, '='), normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Сумма депозита: {numericUpDownDeposit.Value:N2} ₽", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Подпись
            g.DrawString("_________________________", normalFont, System.Drawing.Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString("Подпись кассира", smallFont, System.Drawing.Brushes.Black, leftMargin + 30, yPos);
        }
    }
}