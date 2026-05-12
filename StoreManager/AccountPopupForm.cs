using StoreManager.Utils;

namespace StoreManager
{
    public partial class AccountPopupForm : Form
    {
        private bool isLoggingOut = false;

        public AccountPopupForm()
        {
            InitializeComponent();
            SetupCustomUI();
        }

        private void SetupCustomUI()
        {
            string name = Session.LoggedInEmpName;
            lblName.Text = string.IsNullOrEmpty(name) ? "Unknown" : name;
            lblRole.Text = Session.UserRole == "Admin" ? "Quản trị viên" : "Nhân viên";

            lblAvatar.Text = string.IsNullOrEmpty(name) ? "U" : name.Substring(0, 1).ToUpper();

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(0, 0, lblAvatar.Width, lblAvatar.Height);
                lblAvatar.Region = new Region(path);
            }

            this.Deactivate += (s, e) =>
            {
                if (!isLoggingOut)
                {
                    this.Close();
                }
            };
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLoggingOut = true;

            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.Clear();

                if (this.Owner != null)
                {
                    this.Owner.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 224, 228), 1), 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}