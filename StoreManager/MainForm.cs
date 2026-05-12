using StoreManager.Utils;

namespace StoreManager
{
    public partial class MainForm : Form
    {
        // Biến lưu trữ nút đang được click (Active)
        private Button currentBtn;
        private UCDashboard ucDashboard;
        private UCEmployee ucEmployee;
        private UCSupplier ucSupplier;
        private UCCustomer ucCustomer;
        private UCProduct ucProduct;
        private UCInvoice ucInvoice;

        public MainForm()
        {
            InitializeComponent();
        }

        // --- HÀM XỬ LÝ CHUYỂN MÀN HÌNH (TỐI ƯU LAZY LOADING) ---
        public void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;

            if (!panelBody.Controls.Contains(userControl))
            {
                panelBody.Controls.Add(userControl);
            }

            // Đẩy Tab này lên trên cùng để che các Tab khác lại (Giữ nguyên State của các tab dưới)
            userControl.BringToFront();
        }

        // --- HÀM XỬ LÝ ĐỔI MÀU NÚT (ACTIVE STATE) ---
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtn != (Button)btnSender)
                {
                    ResetButtonColors(); 

                    currentBtn = (Button)btnSender;
                    currentBtn.BackColor = Color.FromArgb(52, 152, 219); // Màu xanh dương (Active)
                }
            }
        }

        // --- HÀM TRẢ CÁC NÚT VỀ MÀU NỀN MẶC ĐỊNH ---
        private void ResetButtonColors()
        {
            foreach (Control previousBtn in panelHeader.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(44, 62, 80);
                }
            }
        }

        // --- SỰ KIỆN CLICK CỦA CÁC NÚT TRÊN MENU ---

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (ucDashboard == null)
            {
                ucDashboard = new UCDashboard();
            }
            AddUserControl(ucDashboard);
            ucDashboard.RefreshDashboard();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (ucEmployee == null)
            {
                ucEmployee = new UCEmployee();
            }
            AddUserControl(ucEmployee);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (ucSupplier == null)
            {
                ucSupplier = new UCSupplier();
            }
            AddUserControl(ucSupplier);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (ucCustomer == null)
            {
                ucCustomer = new UCCustomer();
            }
            AddUserControl(ucCustomer);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (ucProduct == null)
            {
                ucProduct = new UCProduct();
            }
            AddUserControl(ucProduct);
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (ucInvoice == null)
            {
                ucInvoice = new UCInvoice();
            }
            AddUserControl(ucInvoice);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Color originalBackColor = btnAccount.BackColor;
            Color originalForeColor = btnAccount.ForeColor;

            btnAccount.BackColor = Color.FromArgb(52, 152, 219);
            btnAccount.ForeColor = Color.White;

            AccountPopupForm popup = new AccountPopupForm();

            Point pt = this.PointToScreen(btnAccount.Location);
            int xPos = pt.X - popup.Width + btnAccount.Width;
            int yPos = pt.Y + btnAccount.Height + 5;

            popup.Location = new Point(xPos, yPos);

            popup.FormClosed += (s, args) =>
            {
                btnAccount.BackColor = originalBackColor;
                btnAccount.ForeColor = originalForeColor;
            };

            // Show(this) để popup hiểu MainForm là form cha
            popup.Show(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Session.IsAdmin())
            {
                btnHome.Visible = false;
                btnSupplier.Visible = false;
                btnEmployee.Visible = false;

                btnInvoice.PerformClick();
            }
            else 
            {
                btnHome.PerformClick();
            }
        }

        public void NavigateToSupplierAndCreate()
        {
             btnSupplier.PerformClick();

            if (ucSupplier != null)
            {
                ucSupplier.PrepareCreate();
            }
        }

        public void NavigateToProductAndSelect(int proID)
        {
            btnProduct.PerformClick();

            if (ucProduct != null)
            {
                ucProduct.SelectProduct(proID);
            }
        }
    }
}