namespace StoreManager
{
    public partial class EditInvoiceDetailDialog : Form
    {
        public int NewQuantity { get; private set; } = 0;
        private int limit;

        // Constructor nhận dữ liệu từ form gọi nó
        public EditInvoiceDetailDialog(string productName, int currentQty, int limit)
        {
            InitializeComponent();

            // Gán dữ liệu vào các control sau khi giao diện đã được vẽ
            this.limit = limit;
            txtName.Text = productName;
            txtLimit.Text = limit.ToString();
            txtQuantity.Text = currentQty.ToString();
        }

        // Chặn nhập chữ cái, chỉ cho phép nhập số
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}