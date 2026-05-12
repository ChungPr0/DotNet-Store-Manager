using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class UCEmployee : UserControl
    {
        // --- STATE VARIABLES ---
        private int currentSortIndex = 0;
        private readonly string[] sortModes = { "A-Z", "Z-A", "NEW", "OLD" };
        private int selectedEmpID = -1;
        private bool isDataLoading = false;

        public UCEmployee()
        {
            InitializeComponent();
            InitComboBoxData();
            LoadListData();
            SetupEvents();
            ClearForm();
        }

        // --- 1. INITIALIZATION ---
        private void InitComboBoxData()
        {
            // Thiết lập ComboBox Phân quyền
            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.Items.Add(new { Text = "Quản trị viên (Admin)", Value = "Admin" });
            cbRole.Items.Add(new { Text = "Nhân viên (Employee)", Value = "Employee" });
            cbRole.SelectedIndex = 1; // Mặc định là Employee

            EnableForm(false);
        }

        // --- 2. DATA LOADING ---
        private void LoadListData()
        {
            string keyword = txtSearch.Text.Trim();
            bool isSearching = !string.IsNullOrEmpty(keyword) && keyword != "Nhập tên nhân viên...";

            string sql = "SELECT emp_ID, emp_name FROM Employees";

            if (isSearching) sql += " WHERE emp_name LIKE @keyword OR emp_phone LIKE @keyword";

            switch (currentSortIndex)
            {
                case 1: sql += " ORDER BY emp_name DESC"; break;
                case 2: sql += " ORDER BY emp_start_date DESC"; break;
                case 3: sql += " ORDER BY emp_start_date ASC"; break;
                default: sql += " ORDER BY emp_name ASC"; break;
            }

            SqlParameter[] parameters = isSearching ? new[] { new SqlParameter("@keyword", "%" + keyword + "%") } : null;

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

            lstEmployee.DataSource = dt;
            lstEmployee.DisplayMember = "emp_name"; // Cột hiển thị ra màn hình
            lstEmployee.ValueMember = "emp_ID";     // Cột giá trị ngầm bên dưới

            lstEmployee.ClearSelected();
        }

        private void LoadDetail(int id)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Employees WHERE emp_ID = @id";
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", id) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                selectedEmpID = Convert.ToInt32(row["emp_ID"]);

                txtName.Text = row["emp_name"].ToString();
                txtPhone.Text = row["emp_phone"].ToString();
                txtAddress.Text = row["emp_address"].ToString();

                // Ép kiểu lương và bỏ phần thập phân
                txtSalary.Text = Convert.ToDecimal(row["emp_salary"]).ToString("0");

                txtUsername.Text = row["emp_username"].ToString();
                txtPassword.Text = row["emp_password"].ToString();

                // Gán ngày tháng cho DateTimePicker
                dtpDOB.Value = Convert.ToDateTime(row["emp_date_of_birth"]);
                dtpStartDate.Value = Convert.ToDateTime(row["emp_start_date"]);

                // Chọn đúng Role trong ComboBox
                string roleCode = row["emp_role"].ToString();
                cbRole.SelectedIndex = roleCode == "Admin" ? 0 : 1;

                EnableForm(true);
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
            }
            isDataLoading = false;
        }

        // --- 3. MAIN ACTIONS ---
        private void PrepareCreate()
        {
            lstEmployee.ClearSelected();
            selectedEmpID = -1;

            isDataLoading = true;
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            dtpDOB.Value = new DateTime(2000, 1, 1);
            dtpStartDate.Value = DateTime.Now;
            cbRole.SelectedIndex = 1;
            isDataLoading = false;

            EnableForm(true);
            txtName.Focus();

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void SaveEmployee()
        {
            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên và Lương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            if ((user == "" && pass != "") || (user != "" && pass == ""))
            {
                MessageBox.Show("Tài khoản và mật khẩu phải nhập đủ cả hai (hoặc cùng để trống)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy Value ẩn của ComboBox đang chọn
            string roleVal = (string)((dynamic)cbRole.SelectedItem).Value;

            if (selectedEmpID == -1) // Thêm Mới
            {
                string sql = @"INSERT INTO Employees (emp_name, emp_date_of_birth, emp_phone, emp_address, emp_salary, emp_start_date, emp_username, emp_password, emp_role) 
                       VALUES (@name, @dob, @phone, @address, @salary, @startDate, @user, @pass, @role); 
                       SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@dob", dtpDOB.Value.Date),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim()),
                    new SqlParameter("@salary", Convert.ToDecimal(txtSalary.Text.Trim())),
                    new SqlParameter("@startDate", dtpStartDate.Value.Date),
                    new SqlParameter("@user", user == "" ? (object)DBNull.Value : user),
                    new SqlParameter("@pass", pass == "" ? (object)DBNull.Value : pass),
                    new SqlParameter("@role", roleVal)
                };

                DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    int newID = Convert.ToInt32(dt.Rows[0][0]); // Bắt ID mới
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadListData();
                    lstEmployee.SelectedValue = newID; // Trỏ thẳng vào nhân viên vừa tạo
                }
            }
            else // Cập Nhật
            {
                string sql = @"UPDATE Employees 
                       SET emp_name=@name, emp_date_of_birth=@dob, emp_phone=@phone, emp_address=@address, 
                           emp_salary=@salary, emp_start_date=@startDate, emp_username=@user, emp_password=@pass, emp_role=@role 
                       WHERE emp_ID=@id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text.Trim()),
                    new SqlParameter("@dob", dtpDOB.Value.Date),
                    new SqlParameter("@phone", txtPhone.Text.Trim()),
                    new SqlParameter("@address", txtAddress.Text.Trim()),
                    new SqlParameter("@salary", Convert.ToDecimal(txtSalary.Text.Trim())),
                    new SqlParameter("@startDate", dtpStartDate.Value.Date),
                    new SqlParameter("@user", user == "" ? (object)DBNull.Value : user),
                    new SqlParameter("@pass", pass == "" ? (object)DBNull.Value : pass),
                    new SqlParameter("@role", roleVal),
                    new SqlParameter("@id", selectedEmpID)
                };

                if (DatabaseConnector.Instance.ExecuteNonQuery(sql, parameters) > 0)
                {
                    // 1. Cất giấu ID vào biến tạm
                    int tempID = selectedEmpID;

                    MessageBox.Show("Cập nhật thành công!");

                    // 2. Nạp lại list
                    LoadListData();

                    // 3. Phục hồi lại focus bằng biến đã giấu
                    lstEmployee.SelectedValue = tempID;
                }
            }
        }

        private void DeleteEmployee()
        {
            if (selectedEmpID == -1) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Employees WHERE emp_ID = @id";
                    DatabaseConnector.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", selectedEmpID) });
                    MessageBox.Show("Đã xóa!");
                    LoadListData();
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Không thể xóa: Nhân viên này đã lập hóa đơn!");
                    else
                        MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // --- 4. EVENTS & UTILITIES ---
        private void SetupEvents()
        {
            // Bắt sự kiện chọn item trong ListBox
            lstEmployee.SelectedIndexChanged += (s, e) =>
            {
                if (lstEmployee.SelectedValue != null && int.TryParse(lstEmployee.SelectedValue.ToString(), out int id))
                {
                    LoadDetail(id);
                }
            };

            // Sự kiện tìm kiếm (Tương đương DocumentListener của Java)
            txtSearch.TextChanged += (s, e) => LoadListData();
            btnSort.Click += (s, e) => {
                currentSortIndex = (currentSortIndex + 1) % sortModes.Length;
                btnSort.Text = sortModes[currentSortIndex];
                LoadListData();
            };

            // Chặn nhập chữ vào số điện thoại, lương
            KeyPressEventHandler digitOnly = (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
            txtPhone.KeyPress += digitOnly;
            txtSalary.KeyPress += digitOnly;

            // Hiện nút Lưu khi có bất kỳ thay đổi nào
            EventHandler dataChanged = (s, e) => {
                if (!isDataLoading) btnSave.Visible = true;
            };
            txtName.TextChanged += dataChanged;
            txtPhone.TextChanged += dataChanged;
            txtAddress.TextChanged += dataChanged;
            txtSalary.TextChanged += dataChanged;
            txtUsername.TextChanged += dataChanged;
            txtPassword.TextChanged += dataChanged;
            cbRole.SelectedIndexChanged += dataChanged;
            dtpDOB.ValueChanged += dataChanged;
            dtpStartDate.ValueChanged += dataChanged;

            btnAdd.Click += (s, e) => PrepareCreate();
            btnSave.Click += (s, e) => SaveEmployee();
            btnDelete.Click += (s, e) => DeleteEmployee();
        }

        private void EnableForm(bool enable)
        {
            txtName.Enabled = enable;
            txtPhone.Enabled = enable;
            txtAddress.Enabled = enable;
            txtSalary.Enabled = enable;
            txtUsername.Enabled = enable;
            txtPassword.Enabled = enable;
            cbRole.Enabled = enable;
            dtpDOB.Enabled = enable;
            dtpStartDate.Enabled = enable;
        }

        private void ClearForm()
        {
            selectedEmpID = -1;
            EnableForm(false);
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
}