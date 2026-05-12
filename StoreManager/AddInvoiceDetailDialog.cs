using System.Data;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class AddInvoiceDetailDialog : Form
    {
        public int SelectedProductID { get; private set; } = -1;
        public string SelectedProductName { get; private set; } = "";
        public int SelectedQty { get; private set; } = 0;

        private Dictionary<int, int> productStockMap = new Dictionary<int, int>();

        public AddInvoiceDetailDialog()
        {
            InitializeComponent();

            // Load dữ liệu và chọn item đầu tiên sau khi UI được vẽ
            LoadProductData();
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

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedValue != null && productStockMap.ContainsKey((int)cbProduct.SelectedValue))
            {
                txtStock.Text = productStockMap[(int)cbProduct.SelectedValue].ToString();
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            SearchProductDialog searchDlg = new SearchProductDialog();
            if (searchDlg.ShowDialog() == DialogResult.OK)
            {
                cbProduct.SelectedValue = searchDlg.SelectedProductID;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}