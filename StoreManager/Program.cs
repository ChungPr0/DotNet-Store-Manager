using StoreManager.Utils;

namespace StoreManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                Application.Run(new MainForm());

                if (Session.IsLoggedIn)
                {
                    break;
                }
            }
        }
    }
}