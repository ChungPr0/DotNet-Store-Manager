using StoreManager.Utils;
using System.Data;
using Microsoft.Data.SqlClient;

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
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery("SELECT type_ID, type_name FROM ProductTypes ORDER BY type_name ASC");
            cbType.DataSource = dt;
            cbType.DisplayMember = "type_name";
            cbType.ValueMember = "type_ID";
            isDataLoading = false;
        }

        private void LoadSupplierData()
        {
            isDataLoading = true;
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery("SELECT sup_ID, sup_name FROM Suppliers ORDER BY sup_name ASC");
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

            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, parameters);
            lstProduct.DataSource = dt;
            lstProduct.DisplayMember = "pro_name";
            lstProduct.ValueMember = "pro_ID";
            lstProduct.ClearSelected();
        }

        private void LoadDetail(int id)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Products WHERE pro_ID = @id";
            DataTable dt = DatabaseHelper.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", id) });

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
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnSave.Text = "LƯU";
                btnSave.Visible = false;
            }
            isDataLoading = false;
        }

        public void PrepareCreate()
        {
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
            btnSave.Text = "LƯU MỚI";
            btnSave.Visible = true;
        }

        private void SaveProduct()
        {
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

            if (selectedProductID == -1) // Insert
            {
                string sql = @"INSERT INTO Products (pro_name, pro_price, pro_count, type_ID, sup_ID, pro_description) 
                               VALUES (@name, @price, @count, @type, @sup, @desc)";

                if (DatabaseHelper.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadListData();
                    ClearForm();
                }
            }
            else // Update
            {
                string sql = @"UPDATE Products 
                               SET pro_name=@name, pro_price=@price, pro_count=@count, type_ID=@type, sup_ID=@sup, pro_description=@desc 
                               WHERE pro_ID=@id";

                if (DatabaseHelper.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadListData();
                }
            }
        }

        private void DeleteProduct()
        {
            if (selectedProductID == -1) return;

            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Products WHERE pro_ID = @id";
                    DatabaseHelper.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", selectedProductID) });
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

            btnSort.Click += (s, e) => {
                currentSortIndex = (currentSortIndex + 1) % sortModes.Length;
                btnSort.Text = sortModes[currentSortIndex];
                LoadListData();
            };

            txtPrice.KeyPress += NumberOnly_KeyPress;
            txtCount.KeyPress += NumberOnly_KeyPress;

            EventHandler dataChanged = (s, e) => {
                if (!isDataLoading) btnSave.Visible = true;
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

            // Quản lý Phân Loại MỚI
            btnAddType.Click += (s, e) => {
                TypeEditorDialog dialog = new TypeEditorDialog(-1, "");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTypeData();
                    cbType.SelectedIndex = cbType.Items.Count - 1; // Chọn cái cuối cùng
                }
            };

            // Quản lý Phân Loại SỬA
            btnEditType.Click += (s, e) => {
                if (cbType.SelectedValue == null) return;
                int currentId = (int)cbType.SelectedValue;
                string currentName = cbType.Text;

                TypeEditorDialog dialog = new TypeEditorDialog(currentId, currentName);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTypeData();
                    cbType.SelectedValue = currentId; // Chọn lại item vừa sửa
                }
            };

            // Quản lý Thêm Nhà Cung Cấp (Chuyển nhanh sang tab UCSupplier)
            btnAddSupplier.Click += (s, e) => {
                MainForm mainForm = this.FindForm() as MainForm;
                if (mainForm != null)
                {
                    UCSupplier ucSupplier = new UCSupplier();
                    ucSupplier.PrepareCreate();
                    mainForm.AddUserControl(ucSupplier);
                }
            };
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void EnableForm(bool enable)
        {
            txtName.Enabled = enable;
            txtPrice.Enabled = enable;
            txtCount.Enabled = enable;
            txtDescription.Enabled = enable;
            cbType.Enabled = enable;
            cbSupplier.Enabled = enable;

            btnEditType.Visible = enable;
            btnAddType.Visible = enable;
            btnAddSupplier.Visible = enable;
        }

        private void ClearForm()
        {
            selectedProductID = -1;
            EnableForm(false);
            txtName.Text = "";
            txtPrice.Text = "";
            txtCount.Text = "";
            txtDescription.Text = "";

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
}