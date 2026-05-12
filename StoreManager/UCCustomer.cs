using StoreManager.Utils;
using System.Data;
using Microsoft.Data.SqlClient;

namespace StoreManager
{
    public partial class UCCustomer : UserControl
    {
        private int currentSortIndex = 0;
        private readonly string[] sortModes = { "A-Z", "Z-A", "NEW", "OLD" };
        private int selectedCusID = -1;
        private bool isDataLoading = false;

        public UCCustomer()
        {
            InitializeComponent();
            SetupEvents();
            LoadListData();
            ClearForm();
        }

        private void LoadListData()
        {
            string keyword = txtSearch.Text.Trim();
            bool isSearching = !string.IsNullOrEmpty(keyword) && keyword != "Nhập tên hoặc SĐT...";

            string sql = "SELECT cus_ID, cus_name FROM Customers WHERE cus_ID != 1";

            if (isSearching) sql += " AND (cus_name LIKE @keyword OR cus_phone LIKE @keyword)";

            switch (currentSortIndex)
            {
                case 1: sql += " ORDER BY cus_name DESC"; break;
                case 2: sql += " ORDER BY cus_ID DESC"; break;
                case 3: sql += " ORDER BY cus_ID ASC"; break;
                default: sql += " ORDER BY cus_name ASC"; break;
            }

            SqlParameter[] parameters = isSearching ? new[] { new SqlParameter("@keyword", "%" + keyword + "%") } : null;

            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, parameters);

            lstCustomer.DataSource = dt;
            lstCustomer.DisplayMember = "cus_name";
            lstCustomer.ValueMember = "cus_ID";

            lstCustomer.ClearSelected();
        }

        private void LoadDetail(int id)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Customers WHERE cus_ID = @id";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", id) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                selectedCusID = Convert.ToInt32(row["cus_ID"]); 

                txtName.Text = row["cus_name"].ToString();
                txtPhone.Text = row["cus_phone"].ToString();
                txtAddress.Text = row["cus_address"].ToString();

                EnableForm(true);
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
            }
            isDataLoading = false;
        }

        private void PrepareCreate()
        {
            lstCustomer.ClearSelected();
            selectedCusID = -1;

            isDataLoading = true;
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            isDataLoading = false;

            EnableForm(true);
            txtName.Focus();

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void SaveCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Tên và SĐT là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedCusID == -1) // Thêm mới
            {
                // Dùng ExecuteQuery và SCOPE_IDENTITY() để lấy ID vừa sinh ra từ DB
                string sql = "INSERT INTO Customers (cus_name, cus_phone, cus_address) VALUES (@name, @phone, @address); SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim())
                };

                DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    int newID = Convert.ToInt32(dt.Rows[0][0]); // Bắt lấy cái ID mới

                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadListData();
                    lstCustomer.SelectedValue = newID;
                }
            }
            else // Cập nhật
            {
                string sql = "UPDATE Customers SET cus_name=@name, cus_phone=@phone, cus_address=@address WHERE cus_ID=@id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim()),
                    new SqlParameter("@id", selectedCusID)
                };

                if (DatabaseHelper.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    int tempId = selectedCusID; // Lưu tạm ID trước khi reload
                    MessageBox.Show("Cập nhật thành công!");
                    LoadListData();
                    lstCustomer.SelectedValue = tempId;
                }
            }
        }

        private void DeleteCustomer()
        {
            if (selectedCusID == -1 || selectedCusID == 1) return;

            if (MessageBox.Show("Xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Customers WHERE cus_ID = @id";
                    DatabaseHelper.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", selectedCusID) });
                    MessageBox.Show("Đã xóa!");
                    LoadListData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Không thể xóa: Khách hàng này đã có hóa đơn mua hàng!");
                    else
                        MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void SetupEvents()
        {
            lstCustomer.SelectedIndexChanged += (s, e) =>
            {
                if (lstCustomer.SelectedValue != null && int.TryParse(lstCustomer.SelectedValue.ToString(), out int id))
                {
                    LoadDetail(id);
                }
            };

            txtSearch.TextChanged += (s, e) => LoadListData();

            btnSort.Click += (s, e) => {
                currentSortIndex = (currentSortIndex + 1) % sortModes.Length;
                btnSort.Text = sortModes[currentSortIndex];
                LoadListData();
            };

            txtPhone.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            EventHandler dataChanged = (s, e) => {
                if (!isDataLoading) btnSave.Visible = true;
            };

            txtName.TextChanged += dataChanged;
            txtPhone.TextChanged += dataChanged;
            txtAddress.TextChanged += dataChanged;

            btnAdd.Click += (s, e) => PrepareCreate();
            btnSave.Click += (s, e) => SaveCustomer();
            btnDelete.Click += (s, e) => DeleteCustomer();
        }

        private void EnableForm(bool enable)
        {
            txtName.Enabled = enable;
            txtPhone.Enabled = enable;
            txtAddress.Enabled = enable;
        }

        private void ClearForm()
        {
            selectedCusID = -1;
            EnableForm(false);
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
}