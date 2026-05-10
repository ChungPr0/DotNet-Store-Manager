using StoreManager.Utils;
using Microsoft.Data.SqlClient;

namespace StoreManager
{
    public partial class TypeEditorDialog : Form
    {
        private int typeID;
        private string currentName;
        public bool IsUpdated { get; private set; } = false;

        public TypeEditorDialog(int typeID, string currentName)
        {
            InitializeComponent();
            this.typeID = typeID;
            this.currentName = currentName;
            SetupDialog();
        }

        private void SetupDialog()
        {
            if (typeID == -1)
            {
                lblTitle.Text = "THÊM PHÂN LOẠI MỚI";
                btnAction.Text = "Thêm Mới";
                btnDelete.Visible = false; // Thêm mới thì ẩn nút Xóa
            }
            else
            {
                lblTitle.Text = "CHỈNH SỬA PHÂN LOẠI";
                btnAction.Text = "Lưu Thay Đổi";
                txtName.Text = currentName;
                btnDelete.Visible = true;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (typeID == -1) // INSERT
                {
                    string sql = "INSERT INTO ProductTypes (type_name) VALUES (@name)";
                    if (DatabaseHelper.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@name", newName) }) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công!");
                        IsUpdated = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else // UPDATE
                {
                    string sql = "UPDATE ProductTypes SET type_name = @name WHERE type_ID = @id";
                    if (DatabaseHelper.Instance.ExecuteNonQuery(sql, new[] {
                        new SqlParameter("@name", newName),
                        new SqlParameter("@id", typeID)
                    }) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        IsUpdated = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Bắt lỗi Duplicate nếu cột name setup Unique
                    MessageBox.Show("Loại sản phẩm này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Xóa loại: {currentName}?\n(Không thể xóa nếu đang có sản phẩm thuộc loại này)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM ProductTypes WHERE type_ID = @id";
                    if (DatabaseHelper.Instance.ExecuteNonQuery(sql, new[] { new SqlParameter("@id", typeID) }) > 0)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        IsUpdated = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_") || ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Không thể xóa vì đang có sản phẩm thuộc loại này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}