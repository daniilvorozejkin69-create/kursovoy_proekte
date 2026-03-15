using System;
using System.Configuration;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    /// <summary>
    /// Менеджер блокировки при бездействии - просто работает
    /// </summary>
    public static class InactivityManager
    {
        private static Timer timer;
        private static Form currentForm;
        private static int timeout = 30;

        /// <summary>
        /// Запустить отслеживание (вызови эту функцию в каждой форме)
        /// </summary>
        public static void Start(Form form)
        {
            currentForm = form;

            // Читаем время из конфига
            string t = ConfigurationManager.AppSettings["InactivityTimeout"];
            if (!string.IsNullOrEmpty(t))
                int.TryParse(t, out timeout);

            // Создаем таймер
            timer = new Timer();
            timer.Interval = timeout * 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Ловим все действия пользователя
            Application.AddMessageFilter(new ActivityFilter());

            // Подписываемся на закрытие формы
            form.FormClosing += (s, e) => timer?.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            // Показываем окно с вопросом
            var result = MessageBox.Show(
                $"Вы не работали {timeout} секунд.\n\nХотите остаться в системе?",
                "Блокировка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                timer.Start(); // Продолжаем работу
            }
            else
            {
                // Выходим в авторизацию
                Session.Clear();
                Form1 login = new Form1();
                login.Show();
                currentForm.Close();
            }
        }

        /// <summary>
        /// Сброс таймера при активности
        /// </summary>
        public static void Reset()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Start();
            }
        }

        /// <summary>
        /// Фильтр сообщений - ловит мышь и клавиатуру
        /// </summary>
        private class ActivityFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                // 0x200 = WM_MOUSEMOVE, 0x100 = WM_KEYDOWN
                if (m.Msg == 0x200 || m.Msg == 0x100 || m.Msg == 0x201 || m.Msg == 0x204)
                {
                    Reset();
                }
                return false;
            }
        }
    }
}
