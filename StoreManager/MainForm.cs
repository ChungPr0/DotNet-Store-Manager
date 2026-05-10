using System;
using System.Drawing;
using System.Windows.Forms;

namespace StoreManager
{
    public partial class MainForm : Form
    {
        // Biến lưu trữ nút đang được click (Active)
        private Button currentBtn;

        // Biến lưu trữ UserControl đang được hiển thị trên panelBody
        private UserControl currentControl;

        public MainForm()
        {
            InitializeComponent();

            btnHome.PerformClick();
        }

        // --- HÀM XỬ LÝ CHUYỂN MÀN HÌNH (USER CONTROL) ---
        private void AddUserControl(UserControl userControl)
        {
            // 1. Dọn dẹp màn hình cũ nếu có để giải phóng bộ nhớ
            if (currentControl != null)
            {
                panelBody.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            // 2. Gán màn hình mới và ép nó giãn đầy panel
            currentControl = userControl;
            userControl.Dock = DockStyle.Fill;

            // 3. Đẩy lên panelBody 
            panelBody.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // --- HÀM XỬ LÝ ĐỔI MÀU NÚT (ACTIVE STATE) ---
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                // Nếu nút vừa click KHÁC với nút đang sáng màu
                if (currentBtn != (Button)btnSender)
                {
                    ResetButtonColors(); // Reset màu tất cả các nút về mặc định trước

                    // Gán nút hiện tại thành nút vừa click và đổi màu sáng
                    currentBtn = (Button)btnSender;
                    currentBtn.BackColor = Color.FromArgb(52, 152, 219); // Màu xanh dương (Active)
                }
            }
        }

        // --- HÀM TRẢ CÁC NÚT VỀ MÀU NỀN MẶC ĐỊNH ---
        private void ResetButtonColors()
        {
            // Duyệt qua tất cả các control nằm trong panelHeader
            foreach (Control previousBtn in panelHeader.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    // Trả về màu xám đen mặc định của thanh Header
                    previousBtn.BackColor = Color.FromArgb(44, 62, 80);
                }
            }
        }

        // --- SỰ KIỆN CLICK CỦA CÁC NÚT TRÊN MENU ---

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Gọi màn hình Trang Chủ (UCDashboard)
            //AddUserControl(new UCDashboard());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            AddUserControl(new UCEmployee());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            AddUserControl(new UCSupplier());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // AddUserControl(new UCCustomer()); // Bỏ comment (//) sau khi tạo xong UCCustomer
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // AddUserControl(new UCProduct()); // Bỏ comment (//) sau khi tạo xong UCProduct
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // AddUserControl(new UCInvoice()); // Bỏ comment (//) sau khi tạo xong UCInvoice
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // AddUserControl(new UCAccount()); // Bỏ comment (//) sau khi tạo xong UCAccount
        }
    }
}