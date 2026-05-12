using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class UCSupplier : UserControl
    {
        // --- STATE VARIABLES ---
        private int currentSortIndex = 0;
        private readonly string[] sortModes = { "A-Z", "Z-A", "NEW", "OLD" };
        private int selectedSupID = -1;
        private bool isDataLoading = false;

        public UCSupplier()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupEvents();
            LoadListData();
            ClearForm();
        }

        // --- 1. SETUP UI ---
        private void SetupDataGridView()
        {
            // Tắt tự động tạo cột
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.RowTemplate.Height = 35;
        }

        // --- 2. DATA LOADING ---
        private void LoadListData()
        {
            string keyword = txtSearch.Text.Trim();
            bool isSearching = !string.IsNullOrEmpty(keyword) && keyword != "Nhập tên nhà cung cấp...";

            string sql = "SELECT sup_ID, sup_name FROM Suppliers";

            if (isSearching) sql += " WHERE sup_name LIKE @keyword";

            switch (currentSortIndex)
            {
                case 1: sql += " ORDER BY sup_name DESC"; break;
                case 2: sql += " ORDER BY sup_start_date DESC"; break;
                case 3: sql += " ORDER BY sup_start_date ASC"; break;
                default: sql += " ORDER BY sup_name ASC"; break;
            }

            SqlParameter[] parameters = isSearching ? new[] { new SqlParameter("@keyword", "%" + keyword + "%") } : null;

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

            lstSupplier.DataSource = dt;
            lstSupplier.DisplayMember = "sup_name";
            lstSupplier.ValueMember = "sup_ID";

            lstSupplier.ClearSelected();
        }

        private void LoadDetail(int id)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Suppliers WHERE sup_ID = @id";
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", id) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                selectedSupID = Convert.ToInt32(row["sup_ID"]);

                txtName.Text = row["sup_name"].ToString();
                txtPhone.Text = row["sup_phone"].ToString();
                txtAddress.Text = row["sup_address"].ToString();
                txtDescription.Text = row["sup_description"].ToString();

                // Gán ngày tháng
                if (row["sup_start_date"] != DBNull.Value)
                {
                    dtpStartDate.Value = Convert.ToDateTime(row["sup_start_date"]);
                }

                EnableForm(true);
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

                // Load danh sách sản phẩm của Nhà Cung Cấp này
                LoadSupplierProducts(selectedSupID);
            }
            isDataLoading = false;
        }

        private void LoadSupplierProducts(int supID)
        {
            // Sử dụng LEFT JOIN để đếm số lượng đã bán từ bảng Chi tiết hóa đơn
            string sql = @"
                SELECT p.pro_ID, p.pro_name, p.pro_price, p.pro_count, 
                       COALESCE(SUM(d.ind_count), 0) AS sold_count
                FROM Products p
                LEFT JOIN Invoice_details d ON p.pro_ID = d.pro_ID
                WHERE p.sup_ID = @id
                GROUP BY p.pro_ID, p.pro_name, p.pro_price, p.pro_count";

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", supID) });
            dgvProducts.DataSource = dt;
        }

        // --- 3. MAIN ACTIONS ---
        public void PrepareCreate()
        {
            lstSupplier.ClearSelected();
            selectedSupID = -1;

            isDataLoading = true;
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            dtpStartDate.Value = DateTime.Now;
            dgvProducts.DataSource = null; // Thêm mới thì chưa có sản phẩm
            isDataLoading = false;

            EnableForm(true);
            txtName.Focus();

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void SaveSupplier()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Tên và SĐT là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSupID == -1) // Thêm mới
            {
                string sql = @"INSERT INTO Suppliers (sup_name, sup_phone, sup_address, sup_start_date, sup_description) 
                       VALUES (@name, @phone, @address, @date, @desc); 
                       SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim()),
                    new SqlParameter("@date", dtpStartDate.Value.Date),
                    new SqlParameter("@desc", txtDescription.Text.Trim())
                };

                DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    int newID = Convert.ToInt32(dt.Rows[0][0]); // Bắt ID mới

                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    LoadListData();
                    lstSupplier.SelectedValue = newID;
                    btnSave.Visible = false; // Ẩn nút lưu
                }
            }
            else // Cập nhật
            {
                string sql = @"UPDATE Suppliers 
                       SET sup_name=@name, sup_phone=@phone, sup_address=@address, sup_start_date=@date, sup_description=@desc 
                       WHERE sup_ID=@id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim()),
                    new SqlParameter("@date", dtpStartDate.Value.Date),
                    new SqlParameter("@desc", txtDescription.Text.Trim()),
                    new SqlParameter("@id", selectedSupID)
                };

                if (DatabaseConnector.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    int tempID = selectedSupID;

                    MessageBox.Show("Cập nhật thành công!");
                    LoadListData();
                    lstSupplier.SelectedValue = tempID;
                    btnSave.Visible = false; // Ẩn nút lưu
                }
            }
        }

        private void DeleteSupplier()
        {
            if (selectedSupID == -1) return;

            if (MessageBox.Show("Xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Suppliers WHERE sup_ID = @id";
                    DatabaseConnector.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", selectedSupID) });
                    MessageBox.Show("Đã xóa!");
                    LoadListData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Không thể xóa: Nhà cung cấp này đang cung cấp sản phẩm trong kho!");
                    else
                        MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // --- 4. EVENTS & UTILITIES ---
        private void SetupEvents()
        {
            lstSupplier.SelectedIndexChanged += (s, e) =>
            {
                if (lstSupplier.SelectedValue != null && int.TryParse(lstSupplier.SelectedValue.ToString(), out int id))
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

            dgvProducts.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DataRowView rowView = (DataRowView)dgvProducts.Rows[e.RowIndex].DataBoundItem;
                    int proID = Convert.ToInt32(rowView["pro_ID"]);

                    MainForm mainForm = this.FindForm() as MainForm;
                    if (mainForm != null)
                    {
                        mainForm.NavigateToProductAndSelect(proID);
                    }
                }
            };

            EventHandler dataChanged = (s, e) => {
                if (!isDataLoading) btnSave.Visible = true;
            };
            txtName.TextChanged += dataChanged;
            txtPhone.TextChanged += dataChanged;
            txtAddress.TextChanged += dataChanged;
            txtDescription.TextChanged += dataChanged;
            dtpStartDate.ValueChanged += dataChanged;

            btnAdd.Click += (s, e) => PrepareCreate();
            btnSave.Click += (s, e) => SaveSupplier();
            btnDelete.Click += (s, e) => DeleteSupplier();
        }

        private void EnableForm(bool enable)
        {
            txtName.Enabled = enable;
            txtPhone.Enabled = enable;
            txtAddress.Enabled = enable;
            txtDescription.Enabled = enable;
            dtpStartDate.Enabled = enable;
        }

        private void ClearForm()
        {
            selectedSupID = -1;
            EnableForm(false);
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            dgvProducts.DataSource = null;

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
}