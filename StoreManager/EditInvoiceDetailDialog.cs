namespace StoreManager
{
    public class EditInvoiceDetailDialog : Form
    {
        private TextBox txtQuantity;
        private Button btnSave, btnCancel;

        public int NewQuantity { get; private set; } = 0;
        private int limit;

        public EditInvoiceDetailDialog(string productName, int currentQty, int limit)
        {
            this.limit = limit;

            // Thiết lập UI
            this.Text = "Chỉnh Sửa Số Lượng";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label { Text = "SỬA SỐ LƯỢNG", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = true, Location = new Point(20, 20) };

            Label lbl1 = new Label { Text = "Sản phẩm:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 70) };
            TextBox txtName = new TextBox { Text = productName, Location = new Point(20, 95), Size = new Size(390, 30), Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };

            Label lbl2 = new Label { Text = "Tối đa có thể nhập:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 140) };
            TextBox txtLimit = new TextBox { Text = limit.ToString(), Location = new Point(20, 165), Size = new Size(390, 30), Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };

            Label lbl3 = new Label { Text = "Số Lượng Mới:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 210) };
            txtQuantity = new TextBox { Text = currentQty.ToString(), Location = new Point(20, 235), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };

            btnSave = new Button { Text = "Xác Nhận", Location = new Point(90, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnSave.FlatAppearance.BorderSize = 0;
            btnCancel = new Button { Text = "Hủy Bỏ", Location = new Point(230, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lblTitle, lbl1, txtName, lbl2, txtLimit, lbl3, txtQuantity, btnSave, btnCancel });
            this.AcceptButton = btnSave;

            txtQuantity.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text)) return;

            int qty = int.Parse(txtQuantity.Text);
            if (qty <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qty > limit)
            {
                MessageBox.Show($"Kho không đủ hàng!\nBạn chỉ có thể nhập tối đa: {limit}\n(Do trong kho và đơn hàng cộng lại chỉ có bấy nhiêu)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewQuantity = qty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}