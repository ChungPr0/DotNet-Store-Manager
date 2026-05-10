using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using StoreManager.Utils;

namespace StoreManager
{
    public class AddCustomerDialog : Form
    {
        private TextBox txtName, txtPhone, txtAddress;
        private Button btnSave, btnCancel;
        public int NewCustomerID { get; private set; } = -1;

        public AddCustomerDialog()
        {
            this.Text = "Thêm Khách Hàng Nhanh";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label { Text = "THÊM KHÁCH HÀNG", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = true, Location = new Point(20, 20) };

            Label lbl1 = new Label { Text = "Họ và Tên:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 70) };
            txtName = new TextBox { Location = new Point(20, 95), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };

            Label lbl2 = new Label { Text = "Số Điện Thoại:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 140) };
            txtPhone = new TextBox { Location = new Point(20, 165), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };
            txtPhone.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };

            Label lbl3 = new Label { Text = "Địa Chỉ:", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, Location = new Point(20, 210) };
            txtAddress = new TextBox { Location = new Point(20, 235), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };

            btnSave = new Button { Text = "Xác Nhận", Location = new Point(90, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnSave.FlatAppearance.BorderSize = 0;
            btnCancel = new Button { Text = "Hủy Bỏ", Location = new Point(230, 310), Size = new Size(120, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lblTitle, lbl1, txtName, lbl2, txtPhone, lbl3, txtAddress, btnSave, btnCancel });
            this.AcceptButton = btnSave;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
    }
}