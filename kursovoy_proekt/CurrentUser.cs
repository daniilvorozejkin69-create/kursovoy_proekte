namespace kursovoy_proekt
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string FIO { get; set; }
        public static int RoleId { get; set; }
        public static string RoleName { get; set; }

        public static void SetUser(int id, string login, string fio, int roleId, string roleName)
        {
            Id = id;
            Login = login;
            FIO = fio;
            RoleId = roleId;
            RoleName = roleName;
        }
    }
}