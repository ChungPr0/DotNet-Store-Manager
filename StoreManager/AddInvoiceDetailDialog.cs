using System.Data;
using StoreManager.Utils;

namespace StoreManager
{
    public class AddInvoiceDetailDialog : Form
    {
        private ComboBox cbProduct;
        private TextBox txtStock;
        private TextBox txtQuantity;
        private Button btnSearchProduct, btnAdd, btnCancel;

        public int SelectedProductID { get; private set; } = -1;
        public string SelectedProductName { get; private set; } = "";
        public int SelectedQty { get; private set; } = 0;

        private Dictionary<int, int> productStockMap = new Dictionary<int, int>();

        public AddInvoiceDetailDialog()
        {
            // Thiết lập UI
            this.Text = "Thêm Sản Phẩm";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label { Text = "CHỌN SẢN PHẨM", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = true, Location = new Point(20, 20) };

            Label lbl1 = new Label { Text = "Sản Phẩm:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 70) };
            cbProduct = new ComboBox { Location = new Point(20, 95), Size = new Size(330, 30), Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };
            btnSearchProduct = new Button { Text = "Tìm", Location = new Point(360, 94), Size = new Size(50, 32), BackColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnSearchProduct.FlatAppearance.BorderSize = 1;

            Label lbl2 = new Label { Text = "Tồn Kho Hiện Tại:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 140) };
            txtStock = new TextBox { Location = new Point(20, 165), Size = new Size(390, 30), Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };

            Label lbl3 = new Label { Text = "Số Lượng Mua:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 210) };
            txtQuantity = new TextBox { Text = "1", Location = new Point(20, 235), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };

            btnAdd = new Button { Text = "Xác Nhận", Location = new Point(90, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnCancel = new Button { Text = "Hủy Bỏ", Location = new Point(230, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lblTitle, lbl1, cbProduct, btnSearchProduct, lbl2, txtStock, lbl3, txtQuantity, btnAdd, btnCancel });
            this.AcceptButton = btnAdd;

            // Load Data & Events
            LoadProductData();

            cbProduct.SelectedIndexChanged += (s, e) => {
                if (cbProduct.SelectedValue != null && productStockMap.ContainsKey((int)cbProduct.SelectedValue))
                {
                    txtStock.Text = productStockMap[(int)cbProduct.SelectedValue].ToString();
                }
            };

            btnSearchProduct.Click += (s, e) => {
                SearchProductDialog searchDlg = new SearchProductDialog();
                if (searchDlg.ShowDialog() == DialogResult.OK)
                {
                    cbProduct.SelectedValue = searchDlg.SelectedProductID;
                }
            };

            txtQuantity.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += (s, e) => this.Close();

            if (cbProduct.Items.Count > 0) cbProduct.SelectedIndex = 0;
        }

        private void LoadProductData()
        {
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery("SELECT pro_ID, pro_name, pro_count FROM Products WHERE pro_count > 0 ORDER BY pro_name ASC");

            productStockMap.Clear();
            foreach (DataRow row in dt.Rows)
            {
                productStockMap.Add(Convert.ToInt32(row["pro_ID"]), Convert.ToInt32(row["pro_count"]));
            }

            cbProduct.DataSource = dt;
            cbProduct.DisplayMember = "pro_name";
            cbProduct.ValueMember = "pro_ID";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = int.Parse(txtQuantity.Text);
            if (qty <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbProduct.SelectedValue == null) return;

            int proID = (int)cbProduct.SelectedValue;
            int currentStock = productStockMap[proID];

            if (qty > currentStock)
            {
                MessageBox.Show($"Kho chỉ còn {currentStock}, không đủ hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectedProductID = proID;
            SelectedProductName = cbProduct.Text;
            SelectedQty = qty;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}