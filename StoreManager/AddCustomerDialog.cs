using Microsoft.Data.SqlClient;
using StoreManager.Utils;
using System.Data;

namespace StoreManager
{
    public partial class AddCustomerDialog : Form
    {
        public int NewCustomerID { get; private set; } = -1;

        public AddCustomerDialog()
        {
            InitializeComponent();
        }

        // Chặn nhập chữ vào ô Số điện thoại
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Tên và SĐT là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO Customers (cus_name, cus_phone, cus_address) VALUES (@name, @phone, @address); SELECT SCOPE_IDENTITY();";
                DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, new[] {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim())
                });

                NewCustomerID = Convert.ToInt32(dt.Rows[0][0]);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}