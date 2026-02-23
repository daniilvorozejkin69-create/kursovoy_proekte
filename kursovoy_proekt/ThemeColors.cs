using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public static class ThemeColors
    {
        // Цветовая палитра базы отдыха
        public static Color PrimaryGreen = Color.FromArgb(106, 153, 85);    // Зеленый лесной
        public static Color PrimaryBlue = Color.FromArgb(76, 145, 195);     // Голубой озерный
        public static Color LightBackground = Color.FromArgb(240, 245, 235); // Светло-зеленый фон
        public static Color TableBackground = Color.FromArgb(249, 245, 235); // Кремовый фон таблицы
        public static Color BorderColor = Color.FromArgb(220, 235, 210);    // Светло-зеленая граница
        public static Color TextColor = Color.FromArgb(64, 64, 64);         // Темно-серый текст
        public static Color White = Color.White;

        // Методы для создания контролов в едином стиле
        public static Button CreateModernButton(string text, Color backgroundColor, int width = 130, int height = 35)
        {
            return new Button
            {
                Text = text,
                BackColor = backgroundColor,
                ForeColor = White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold),
                Size = new Size(width, height),
                FlatAppearance = {
                    BorderSize = 0,
                    MouseDownBackColor = DarkenColor(backgroundColor, 0.2f),
                    MouseOverBackColor = LightenColor(backgroundColor, 0.1f)
                }
            };
        }

        public static TextBox CreateModernTextBox(int width = 250)
        {
            return new TextBox
            {
                BackColor = White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11.25F),
                ForeColor = TextColor,
                Size = new Size(width, 27)
            };
        }

        public static ComboBox CreateModernComboBox(int width = 200)
        {
            return new ComboBox
            {
                BackColor = White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11.25F),
                ForeColor = TextColor,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new Size(width, 28)
            };
        }

        public static Label CreateModernLabel(string text, bool isHeader = false)
        {
            return new Label
            {
                Text = text,
                ForeColor = TextColor,
                Font = new Font("Segoe UI Semibold", isHeader ? 24F : 11.25F,
                              isHeader ? FontStyle.Regular : FontStyle.Bold),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }

        private static Color DarkenColor(Color color, float factor)
        {
            return Color.FromArgb(
                (int)(color.R * (1 - factor)),
                (int)(color.G * (1 - factor)),
                (int)(color.B * (1 - factor))
            );
        }

        private static Color LightenColor(Color color, float factor)
        {
            return Color.FromArgb(
                (int)(color.R + (255 - color.R) * factor),
                (int)(color.G + (255 - color.G) * factor),
                (int)(color.B + (255 - color.B) * factor)
            );
        }
    }
}