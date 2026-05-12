namespace StoreManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Bật form đăng nhập lên trước
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng nhập thành công thì mới mở MainForm
                Application.Run(new MainForm());
            }
            else
            {
                // Nếu tắt form đăng nhập thì thoát ứng dụng luôn
                Application.Exit();
            }
        }
    }
}