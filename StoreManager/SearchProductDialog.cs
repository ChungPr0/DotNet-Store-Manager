using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class SearchProductDialog : Form
    {
        public int SelectedProductID { get; private set; } = -1;
        public string SelectedProductName { get; private set; } = "";

        public SearchProductDialog()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void listResults_DoubleClick(object sender, EventArgs e)
        {
            ConfirmSelection();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                listResults.DataSource = null;
                return;
            }

            string sql = "SELECT pro_ID, pro_name, pro_name + ' (Tồn: ' + CAST(pro_count AS VARCHAR) + ')' AS display_text FROM Products WHERE pro_name LIKE @kw AND pro_count > 0";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@kw", "%" + keyword + "%") });

            listResults.DataSource = dt;
            listResults.DisplayMember = "display_text";
            listResults.ValueMember = "pro_ID";
            listResults.ClearSelected();
        }

        private void ConfirmSelection()
        {
            if (listResults.SelectedValue != null)
            {
                SelectedProductID = (int)listResults.SelectedValue;

                DataRowView row = (DataRowView)listResults.SelectedItem;
                SelectedProductName = row["pro_name"].ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}