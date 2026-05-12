namespace StoreManager.Utils
{
    public static class Session
    {
        public static int LoggedInEmpID { get; set; } = -1;
        public static string LoggedInEmpName { get; set; } = "";
        public static string UserRole { get; set; } = ""; // "Admin" hoặc "Employee"
        public static bool IsLoggedIn { get; set; } = false;

        public static void Clear()
        {
            LoggedInEmpID = -1;
            LoggedInEmpName = "";
            UserRole = "";
            IsLoggedIn = false;
        }

        // Kiểm tra quyền Admin
        public static bool IsAdmin() => string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase);

        // Các quyền cụ thể
        public static bool CanManageSystem() => IsAdmin(); // Quản lý nhân viên, Thống kê
        public static bool CanOperate() => true;           // Bán hàng, Quản lý kho, Khách hàng (Cả 2 đều làm được)
    }
}