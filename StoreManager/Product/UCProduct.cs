using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class UCProduct : UserControl
    {
        private int currentSortIndex = 0;
        private readonly string[] sortModes = { "A-Z", "Z-A", "PUP", "PDW", "NEW", "OLD" };
        private int selectedProductID = -1;
        private bool isDataLoading = false;

        public UCProduct()
        {
            InitializeComponent();
            SetupEvents();
            LoadTypeData();
            LoadSupplierData();
            LoadListData();
            ClearForm();
        }

        private void LoadTypeData()
        {
            isDataLoading = true;
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery("SELECT type_ID, type_name FROM ProductTypes ORDER BY type_name ASC");
            cbType.DataSource = dt;
            cbType.DisplayMember = "type_name";
            cbType.ValueMember = "type_ID";
            isDataLoading = false;
        }

        private void LoadSupplierData()
        {
            isDataLoading = true;
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery("SELECT sup_ID, sup_name FROM Suppliers ORDER BY sup_name ASC");
            cbSupplier.DataSource = dt;
            cbSupplier.DisplayMember = "sup_name";
            cbSupplier.ValueMember = "sup_ID";
            isDataLoading = false;
        }

        private void LoadListData()
        {
            string keyword = txtSearch.Text.Trim();
            bool isSearching = !string.IsNullOrEmpty(keyword) && keyword != "Nhập tên sản phẩm...";

            string sql = "SELECT pro_ID, pro_name FROM Products";

            if (isSearching) sql += " WHERE pro_name LIKE @keyword";

            switch (currentSortIndex)
            {
                case 1: sql += " ORDER BY pro_name DESC"; break;
                case 2: sql += " ORDER BY pro_price ASC"; break;
                case 3: sql += " ORDER BY pro_price DESC"; break;
                case 4: sql += " ORDER BY pro_ID DESC"; break;
                case 5: sql += " ORDER BY pro_ID ASC"; break;
                default: sql += " ORDER BY pro_name ASC"; break;
            }

            SqlParameter[] parameters = isSearching ? new[] { new SqlParameter("@keyword", "%" + keyword + "%") } : null;

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);
            lstProduct.DataSource = dt;
            lstProduct.DisplayMember = "pro_name";
            lstProduct.ValueMember = "pro_ID";
            lstProduct.ClearSelected();
        }

        private void LoadDetail(int id)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Products WHERE pro_ID = @id";
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", id) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                selectedProductID = Convert.ToInt32(row["pro_ID"]);

                txtName.Text = row["pro_name"].ToString();
                txtPrice.Text = string.Format("{0:0}", row["pro_price"]);
                txtCount.Text = row["pro_count"].ToString();
                txtDescription.Text = row["pro_description"].ToString();

                cbType.SelectedValue = row["type_ID"];
                cbSupplier.SelectedValue = row["sup_ID"];

                EnableForm(true);

                btnAdd.Visible = Session.IsAdmin();
                btnDelete.Visible = Session.IsAdmin();
                btnSave.Visible = false;
            }
            isDataLoading = false;
        }

        public void PrepareCreate()
        {
            if (!Session.IsAdmin()) return;

            lstProduct.ClearSelected();
            selectedProductID = -1;

            isDataLoading = true;
            txtName.Text = "";
            txtPrice.Text = "";
            txtCount.Text = "";
            txtDescription.Text = "";
            if (cbType.Items.Count > 0) cbType.SelectedIndex = 0;
            if (cbSupplier.Items.Count > 0) cbSupplier.SelectedIndex = 0;
            isDataLoading = false;

            EnableForm(true);
            txtName.Focus();

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void SaveProduct()
        {
            if (!Session.IsAdmin()) return;

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Tên và Giá bán là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbType.SelectedValue == null || cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại và Nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = string.IsNullOrWhiteSpace(txtCount.Text) ? 0 : int.Parse(txtCount.Text);

            if (selectedProductID == -1) // Thêm mới
            {
                string sql = @"INSERT INTO Products (pro_name, pro_price, pro_count, type_ID, sup_ID, pro_description) 
                               VALUES (@name, @price, @count, @type, @sup, @desc); 
                               SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@price", double.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@count", count),
                    new SqlParameter("@type", cbType.SelectedValue),
                    new SqlParameter("@sup", cbSupplier.SelectedValue),
                    new SqlParameter("@desc", txtDescription.Text.Trim())
                };

                DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    int newID = Convert.ToInt32(dt.Rows[0][0]);

                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadListData();
                    lstProduct.SelectedValue = newID;
                    btnSave.Visible = false; // Ẩn nút lưu
                }
            }
            else // Cập nhật
            {
                string sql = @"UPDATE Products 
                               SET pro_name=@name, pro_price=@price, pro_count=@count, type_ID=@type, sup_ID=@sup, pro_description=@desc 
                               WHERE pro_ID=@id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@price", double.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@count", count),
                    new SqlParameter("@type", cbType.SelectedValue),
                    new SqlParameter("@sup", cbSupplier.SelectedValue),
                    new SqlParameter("@desc", txtDescription.Text.Trim()),
                    new SqlParameter("@id", selectedProductID)
                };

                if (DatabaseConnector.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    int tempID = selectedProductID;

                    MessageBox.Show("Cập nhật thành công!");
                    LoadListData();
                    lstProduct.SelectedValue = tempID;
                    btnSave.Visible = false; // Ẩn nút lưu
                }
            }
        }

        private void DeleteProduct()
        {
            if (!Session.IsAdmin()) return;

            if (selectedProductID == -1) return;

            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Products WHERE pro_ID = @id";
                    DatabaseConnector.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", selectedProductID) });
                    MessageBox.Show("Đã xóa!");
                    LoadListData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Không thể xóa: Sản phẩm này đã có trong hóa đơn!");
                    else
                        MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public void SelectProduct(int proID)
        {
            lstProduct.SelectedValue = proID;
        }

        private void SetupEvents()
        {
            lstProduct.SelectedIndexChanged += (s, e) =>
            {
                if (lstProduct.SelectedValue != null && int.TryParse(lstProduct.SelectedValue.ToString(), out int id))
                {
                    LoadDetail(id);
                }
            };

            txtSearch.TextChanged += (s, e) => LoadListData();

            btnSort.Click += (s, e) =>
            {
                currentSortIndex = (currentSortIndex + 1) % sortModes.Length;
                btnSort.Text = sortModes[currentSortIndex];
                LoadListData();
            };

            txtPrice.KeyPress += NumberOnly_KeyPress;
            txtCount.KeyPress += NumberOnly_KeyPress;

            EventHandler dataChanged = (s, e) => {
                if (!isDataLoading && Session.IsAdmin())
                {
                    btnSave.Visible = true;
                }
            };

            txtName.TextChanged += dataChanged;
            txtPrice.TextChanged += dataChanged;
            txtCount.TextChanged += dataChanged;
            txtDescription.TextChanged += dataChanged;
            cbType.SelectedIndexChanged += dataChanged;
            cbSupplier.SelectedIndexChanged += dataChanged;

            btnAdd.Click += (s, e) => PrepareCreate();
            btnSave.Click += (s, e) => SaveProduct();
            btnDelete.Click += (s, e) => DeleteProduct();

            // Quản lý Phân Loại
            btnAddType.Click += (s, e) => {
                if (!Session.IsAdmin()) return;
                TypeEditorDialog dialog = new TypeEditorDialog(-1, "");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTypeData();
                    cbType.SelectedIndex = cbType.Items.Count - 1;
                }
            };

            // Quản lý Phân Loại SỬA
            btnEditType.Click += (s, e) => {
                if (!Session.IsAdmin()) return;
                if (cbType.SelectedValue == null) return;
                int currentId = (int)cbType.SelectedValue;
                string currentName = cbType.Text;

                TypeEditorDialog dialog = new TypeEditorDialog(currentId, currentName);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTypeData();
                    cbType.SelectedValue = currentId;
                }
            };

            // Quản lý Thêm Nhà Cung Cấp
            btnAddSupplier.Click += (s, e) => {
                if (!Session.IsAdmin()) return;
                MainForm mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    mainForm.NavigateToSupplierAndCreate();
                }
            };
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void EnableForm(bool enable)
        {
            bool actualEnable = enable && Session.IsAdmin();

            txtName.Enabled = actualEnable;
            txtPrice.Enabled = actualEnable;
            txtCount.Enabled = actualEnable;
            txtDescription.Enabled = actualEnable;
            cbType.Enabled = actualEnable;
            cbSupplier.Enabled = actualEnable;

            btnEditType.Visible = actualEnable;
            btnAddType.Visible = actualEnable;
            btnAddSupplier.Visible = actualEnable;
        }

        private void ClearForm()
        {
            selectedProductID = -1;
            EnableForm(false);
            txtName.Text = "";
            txtPrice.Text = "";
            txtCount.Text = "";
            txtDescription.Text = "";

            // Chỉ Admin mới thấy nút Thêm mới
            btnAdd.Visible = Session.IsAdmin();
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
}