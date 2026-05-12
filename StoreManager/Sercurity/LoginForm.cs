using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)) return;

            try
            {
                string sql = "SELECT emp_ID, emp_name, emp_role FROM Employees WHERE emp_username = @u AND emp_password = @p";
                SqlParameter[] parameters = { new SqlParameter("@u", user), new SqlParameter("@p", pass) };
                DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    Session.LoggedInEmpID = Convert.ToInt32(dt.Rows[0]["emp_ID"]);
                    Session.LoggedInEmpName = dt.Rows[0]["emp_name"].ToString();
                    Session.UserRole = dt.Rows[0]["emp_role"].ToString();
                    Session.IsLoggedIn = true;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}