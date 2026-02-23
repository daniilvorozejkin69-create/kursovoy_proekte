using System;

namespace kursovoy_proekt
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string UserLogin { get; set; }
        public static string UserName { get; set; }
        public static int RoleId { get; set; }
        public static string RoleName { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static DateTime LoginTime { get; set; }

        public static void Clear()
        {
            UserId = 0;
            UserLogin = string.Empty;
            UserName = string.Empty;
            RoleId = 0;
            RoleName = string.Empty;
            IsLoggedIn = false;
            LoginTime = DateTime.MinValue;
        }
    }
}