using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public class SearchCustomerDialog : Form
    {
        private TextBox txtSearch;
        private ListBox listResults;
        private Button btnConfirm, btnCancel;
        public int SelectedCustomerID { get; private set; } = -1;

        public SearchCustomerDialog()
        {
            // Thiết lập UI bằng code (Giống Java Swing)
            this.Text = "Tìm Kiếm Khách Hàng";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label { Text = "TÌM KIẾM KHÁCH HÀNG", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), AutoSize = true, Location = new Point(20, 20) };

            txtSearch = new TextBox { Location = new Point(20, 60), Size = new Size(390, 30), Font = new Font("Segoe UI", 10) };
            txtSearch.PlaceholderText = "Nhập tên hoặc SĐT...";
            txtSearch.TextChanged += (s, e) => Search();

            listResults = new ListBox { Location = new Point(20, 100), Size = new Size(390, 220), Font = new Font("Segoe UI", 11) };
            listResults.DoubleClick += (s, e) => ConfirmSelection();

            btnConfirm = new Button { Text = "Xác Nhận", Location = new Point(90, 340), Size = new Size(120, 40), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += (s, e) => ConfirmSelection();

            btnCancel = new Button { Text = "Hủy", Location = new Point(230, 340), Size = new Size(120, 40), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtSearch);
            this.Controls.Add(listResults);
            this.Controls.Add(btnConfirm);
            this.Controls.Add(btnCancel);
            this.AcceptButton = btnConfirm;
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