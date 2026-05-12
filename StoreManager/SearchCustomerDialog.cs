using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class SearchCustomerDialog : Form
    {
        public int SelectedCustomerID { get; private set; } = -1;

        public SearchCustomerDialog()
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

            string sql = "SELECT cus_ID, cus_name + ' - ' + cus_phone AS display_text FROM Customers WHERE (cus_name LIKE @kw OR cus_phone LIKE @kw) AND cus_ID != 1";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@kw", "%" + keyword + "%") });

            listResults.DataSource = dt;
            listResults.DisplayMember = "display_text";
            listResults.ValueMember = "cus_ID";
            listResults.ClearSelected();
        }

        private void ConfirmSelection()
        {
            if (listResults.SelectedValue != null)
            {
                SelectedCustomerID = (int)listResults.SelectedValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}