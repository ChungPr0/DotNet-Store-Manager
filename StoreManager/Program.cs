using StoreManager.Utils;

namespace StoreManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ==========================================
            // 1. KIỂM TRA DATABASE TRƯỚC KHI KHỞI ĐỘNG
            // ==========================================
            if (!CheckDatabaseConnection())
            {
                return;
            }

            // ==========================================
            // 2. CHẠY VÒNG LẶP ĐĂNG NHẬP CỦA BRO
            // ==========================================
            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break; // Bấm [X] tắt form đăng nhập -> Thoát app
                    }
                }

                Application.Run(new MainForm());

                if (Session.IsLoggedIn)
                {
                    break;
                }
            }
        }

        private static bool CheckDatabaseConnection()
        {
            bool isConnected = DatabaseConnector.Instance.TestConnection(out string errorMsg);

            if (!isConnected)
            {
                MessageBox.Show(
                    "Hệ thống không tìm thấy Cơ sở dữ liệu",
                    "Lỗi Khởi Động Hệ Thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }
    }
}