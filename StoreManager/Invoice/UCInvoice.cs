using StoreManager.Utils;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;

namespace StoreManager
{
    public partial class UCInvoice : UserControl
    {
        private int currentSortIndex = 0;
        private readonly string[] sortModes = { "NEW", "OLD", "PUP", "PDW" };
        private int selectedInvID = -1;
        private bool isDataLoading = false;

        public UCInvoice()
        {
            InitializeComponent();
            SetupEvents();
            LoadComboBoxData();
            LoadListData();
            ClearForm();
        }

        private void LoadComboBoxData()
        {
            isDataLoading = true;
            DataTable dtCus = DatabaseConnector.Instance.ExecuteQuery("SELECT cus_ID, cus_name FROM Customers ORDER BY cus_ID ASC");
            cbCustomer.DataSource = dtCus;
            cbCustomer.DisplayMember = "cus_name";
            cbCustomer.ValueMember = "cus_ID";

            DataTable dtEmp = DatabaseConnector.Instance.ExecuteQuery("SELECT emp_ID, emp_name FROM Employees");
            cbStaff.DataSource = dtEmp;
            cbStaff.DisplayMember = "emp_name";
            cbStaff.ValueMember = "emp_ID";
            isDataLoading = false;
        }

        private void LoadListData()
        {
            string keyword = txtSearch.Text.Trim();
            bool isSearching = !string.IsNullOrEmpty(keyword) && keyword != "Nhập mã HĐ, tên KH...";

            string sql = @"SELECT i.inv_ID, i.inv_price, c.cus_name 
                           FROM Invoices i 
                           LEFT JOIN Customers c ON i.cus_ID = c.cus_ID";

            if (isSearching) sql += " WHERE i.inv_ID LIKE @kw OR c.cus_name LIKE @kw";

            switch (currentSortIndex)
            {
                case 1: sql += " ORDER BY i.inv_ID ASC"; break;
                case 2: sql += " ORDER BY i.inv_price ASC"; break;
                case 3: sql += " ORDER BY i.inv_price DESC"; break;
                default: sql += " ORDER BY i.inv_ID DESC"; break;
            }

            SqlParameter[] parameters = isSearching ? new[] { new SqlParameter("@kw", "%" + keyword + "%") } : null;

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, parameters);

            DataTable displayTable = new DataTable();
            displayTable.Columns.Add("inv_ID", typeof(int));
            displayTable.Columns.Add("display_text", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                string cName = row["cus_name"] == DBNull.Value ? "Khách vãng lai" : row["cus_name"].ToString();
                displayTable.Rows.Add(row["inv_ID"], $"HĐ #{row["inv_ID"]} - {cName}");
            }

            lstInvoice.DataSource = displayTable;
            lstInvoice.DisplayMember = "display_text";
            lstInvoice.ValueMember = "inv_ID";
            lstInvoice.ClearSelected();
        }

        private void LoadDetail(int invID)
        {
            isDataLoading = true;
            string sql = "SELECT * FROM Invoices WHERE inv_ID = @id";
            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql, new[] { new SqlParameter("@id", invID) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                selectedInvID = invID;
                txtID.Text = "#" + selectedInvID;
                cbCustomer.SelectedValue = row["cus_ID"];
                cbStaff.SelectedValue = row["emp_ID"];
                txtDate.Text = row["inv_date"].ToString();

                EnableForm(true); // Gọi EnableForm, nó sẽ tự động ẩn các nút thao tác chi tiết nếu là nhân viên

                btnAdd.Visible = true;
                btnSave.Visible = false; // Luôn ẩn khi mới load chi tiết
                btnDelete.Visible = Session.IsAdmin(); // CHỈ ADMIN MỚI THẤY NÚT XÓA HÓA ĐƠN
                btnPrint.Visible = true;
            }

            dgvDetails.Rows.Clear();
            string sqlDetail = @"SELECT p.pro_ID, p.pro_name, d.unit_price, p.pro_price, d.ind_count 
                                 FROM Invoice_details d 
                                 JOIN Products p ON d.pro_ID = p.pro_ID 
                                 WHERE d.inv_ID = @id";
            DataTable dtDetail = DatabaseConnector.Instance.ExecuteQuery(sqlDetail, new[] { new SqlParameter("@id", invID) });

            foreach (DataRow dr in dtDetail.Rows)
            {
                double histPrice = Convert.ToDouble(dr["unit_price"]);
                double currPrice = Convert.ToDouble(dr["pro_price"]);
                double finalPrice = histPrice > 0 ? histPrice : currPrice;
                int count = Convert.ToInt32(dr["ind_count"]);

                dgvDetails.Rows.Add(
                    dr["pro_ID"],
                    dr["pro_name"],
                    finalPrice,
                    count,
                    finalPrice * count
                );
            }
            CalculateUITotal();
            isDataLoading = false;
        }

        private void CalculateUITotal()
        {
            double totalBill = 0;
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    totalBill += Convert.ToDouble(row.Cells[4].Value);
                }
            }
            lblFinalTotal.Text = totalBill.ToString("N0") + " VND";
        }

        private void PrepareCreate()
        {
            lstInvoice.ClearSelected();
            selectedInvID = -1;

            isDataLoading = true;
            txtID.Text = "[Tự động]";
            txtDate.Text = "[Tự động]";
            if (cbCustomer.Items.Count > 0) cbCustomer.SelectedIndex = 0;
            dgvDetails.Rows.Clear();
            CalculateUITotal();

            // --- PHÂN QUYỀN: AUTO ĐIỀN TÊN NHÂN VIÊN ---
            if (Session.IsAdmin())
            {
                if (cbStaff.Items.Count > 0) cbStaff.SelectedIndex = 0;
            }
            else
            {
                // Ép cứng chọn đúng ID của nhân viên đang đăng nhập
                cbStaff.SelectedValue = Session.LoggedInEmpID;
            }

            isDataLoading = false;

            EnableForm(true);

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnPrint.Visible = false;
            btnSave.Visible = true; // Hiện nút Lưu để tạo hóa đơn mới
        }

        private void SaveInvoice()
        {
            // BẢO MẬT: Nếu là nhân viên và đang cố lưu hóa đơn cũ -> CHẶN NGAY!
            if (selectedInvID != -1 && !Session.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền cập nhật hóa đơn cũ!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvDetails.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedInvID == -1) // Thêm Mới
                {
                    string sqlInv = "INSERT INTO Invoices (cus_ID, emp_ID, inv_price) VALUES (@cus, @emp, @price); SELECT SCOPE_IDENTITY();";
                    double total = Convert.ToDouble(lblFinalTotal.Text.Replace(" VND", "").Replace(",", ""));

                    DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sqlInv, new[] {
                        new SqlParameter("@cus", cbCustomer.SelectedValue),
                        new SqlParameter("@emp", cbStaff.SelectedValue),
                        new SqlParameter("@price", total)
                    });

                    int newInvID = Convert.ToInt32(dt.Rows[0][0]);

                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        int proID = Convert.ToInt32(row.Cells[0].Value);
                        int qty = Convert.ToInt32(row.Cells[3].Value);
                        double price = Convert.ToDouble(row.Cells[2].Value);

                        DatabaseConnector.Instance.ExecuteNonQuery("INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES (@i, @p, @q, @up)",
                            new[] { new SqlParameter("@i", newInvID), new SqlParameter("@p", proID), new SqlParameter("@q", qty), new SqlParameter("@up", price) });

                        DatabaseConnector.Instance.ExecuteNonQuery("UPDATE Products SET pro_count = pro_count - @q WHERE pro_ID = @p",
                            new[] { new SqlParameter("@q", qty), new SqlParameter("@p", proID) });
                    }

                    MessageBox.Show("Tạo hóa đơn thành công!");

                    LoadListData();
                    lstInvoice.SelectedValue = newInvID;
                    btnSave.Visible = false;
                }
                else // Cập Nhật
                {
                    DataTable dtOld = DatabaseConnector.Instance.ExecuteQuery("SELECT pro_ID, ind_count FROM Invoice_details WHERE inv_ID = @id", new[] { new SqlParameter("@id", selectedInvID) });
                    foreach (DataRow row in dtOld.Rows)
                    {
                        DatabaseConnector.Instance.ExecuteNonQuery("UPDATE Products SET pro_count = pro_count + @q WHERE pro_ID = @p",
                            new[] { new SqlParameter("@q", row["ind_count"]), new SqlParameter("@p", row["pro_ID"]) });
                    }

                    DatabaseConnector.Instance.ExecuteNonQuery("DELETE FROM Invoice_details WHERE inv_ID = @id", new[] { new SqlParameter("@id", selectedInvID) });

                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        int proID = Convert.ToInt32(row.Cells[0].Value);
                        int qty = Convert.ToInt32(row.Cells[3].Value);
                        double price = Convert.ToDouble(row.Cells[2].Value);

                        DatabaseConnector.Instance.ExecuteNonQuery("INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES (@i, @p, @q, @up)",
                            new[] { new SqlParameter("@i", selectedInvID), new SqlParameter("@p", proID), new SqlParameter("@q", qty), new SqlParameter("@up", price) });

                        DatabaseConnector.Instance.ExecuteNonQuery("UPDATE Products SET pro_count = pro_count - @q WHERE pro_ID = @p",
                            new[] { new SqlParameter("@q", qty), new SqlParameter("@p", proID) });
                    }

                    double total = Convert.ToDouble(lblFinalTotal.Text.Replace(" VND", "").Replace(",", ""));
                    string sqlUpdateHead = "UPDATE Invoices SET cus_ID=@cus, emp_ID=@emp, inv_price=@price WHERE inv_ID=@id";

                    DatabaseConnector.Instance.ExecuteNonQuery(sqlUpdateHead, new[] {
                        new SqlParameter("@cus", cbCustomer.SelectedValue),
                        new SqlParameter("@emp", cbStaff.SelectedValue),
                        new SqlParameter("@price", total),
                        new SqlParameter("@id", selectedInvID)
                    });

                    int tempID = selectedInvID;

                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    LoadListData();
                    lstInvoice.SelectedValue = tempID;
                    btnSave.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteInvoice()
        {
            if (!Session.IsAdmin()) return;

            if (selectedInvID == -1) return;

            if (MessageBox.Show("Xóa hóa đơn #" + selectedInvID + "? Hàng sẽ được hoàn kho.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DataTable dt = DatabaseConnector.Instance.ExecuteQuery("SELECT pro_ID, ind_count FROM Invoice_details WHERE inv_ID = @id", new[] { new SqlParameter("@id", selectedInvID) });
                    foreach (DataRow row in dt.Rows)
                    {
                        DatabaseConnector.Instance.ExecuteNonQuery("UPDATE Products SET pro_count = pro_count + @q WHERE pro_ID = @p",
                            new[] { new SqlParameter("@q", row["ind_count"]), new SqlParameter("@p", row["pro_ID"]) });
                    }

                    DatabaseConnector.Instance.ExecuteNonQuery("DELETE FROM Invoice_details WHERE inv_ID = @id", new[] { new SqlParameter("@id", selectedInvID) });
                    DatabaseConnector.Instance.ExecuteNonQuery("DELETE FROM Invoices WHERE inv_ID = @id", new[] { new SqlParameter("@id", selectedInvID) });

                    MessageBox.Show("Đã xóa và hoàn kho!");
                    LoadListData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetupEvents()
        {
            lstInvoice.SelectedIndexChanged += (s, e) => {
                if (lstInvoice.SelectedValue != null && int.TryParse(lstInvoice.SelectedValue.ToString(), out int id))
                    LoadDetail(id);
            };

            txtSearch.TextChanged += (s, e) => LoadListData();
            btnSort.Click += (s, e) => {
                currentSortIndex = (currentSortIndex + 1) % sortModes.Length;
                btnSort.Text = sortModes[currentSortIndex];
                LoadListData();
            };

            btnAdd.Click += (s, e) => PrepareCreate();
            btnSave.Click += (s, e) => SaveInvoice();
            btnDelete.Click += (s, e) => DeleteInvoice();

            // SỰ KIỆN THEO DÕI THAY ĐỔI
            EventHandler markAsChanged = (s, e) => {
                if (!isDataLoading)
                {
                    // Chỉ hiện nút Save nếu đang tạo hóa đơn mới HOẶC nếu là Admin sửa hóa đơn cũ
                    if (selectedInvID == -1 || Session.IsAdmin())
                    {
                        btnSave.Visible = true;
                    }
                }
            };

            cbCustomer.SelectedIndexChanged += markAsChanged;
            cbStaff.SelectedIndexChanged += markAsChanged;

            btnSearchCustomer.Click += (s, e) => {
                SearchCustomerDialog dialog = new SearchCustomerDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    cbCustomer.SelectedValue = dialog.SelectedCustomerID;
                }
            };

            btnQuickAddCustomer.Click += (s, e) => {
                AddCustomerDialog dialog = new AddCustomerDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadComboBoxData();
                    cbCustomer.SelectedValue = dialog.NewCustomerID;
                }
            };

            btnAddDetail.Click += (s, e) => {
                if (selectedInvID != -1 && !Session.IsAdmin()) return; // Bắt lụi

                AddInvoiceDetailDialog dialog = new AddInvoiceDetailDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int proID = dialog.SelectedProductID;
                    string name = dialog.SelectedProductName;
                    int qtyInput = dialog.SelectedQty;

                    int rowExist = -1;
                    int currentQtyInTable = 0;
                    for (int i = 0; i < dgvDetails.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgvDetails.Rows[i].Cells[0].Value) == proID)
                        {
                            rowExist = i;
                            currentQtyInTable = Convert.ToInt32(dgvDetails.Rows[i].Cells[3].Value);
                            break;
                        }
                    }

                    int stockDB = 0;
                    double price = 0;
                    DataTable dt = DatabaseConnector.Instance.ExecuteQuery("SELECT pro_count, pro_price FROM Products WHERE pro_ID = @id", new[] { new SqlParameter("@id", proID) });
                    if (dt.Rows.Count > 0)
                    {
                        stockDB = Convert.ToInt32(dt.Rows[0]["pro_count"]);
                        price = Convert.ToDouble(dt.Rows[0]["pro_price"]);
                    }

                    if (currentQtyInTable + qtyInput > stockDB)
                    {
                        MessageBox.Show("Vượt quá tồn kho (" + stockDB + ")!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (rowExist != -1)
                    {
                        int newTotal = currentQtyInTable + qtyInput;
                        dgvDetails.Rows[rowExist].Cells[3].Value = newTotal;
                        dgvDetails.Rows[rowExist].Cells[4].Value = newTotal * price;
                    }
                    else
                    {
                        dgvDetails.Rows.Add(proID, name, price, qtyInput, price * qtyInput);
                    }
                    CalculateUITotal();
                    btnSave.Visible = true;
                }
            };

            btnEditDetail.Click += (s, e) => {
                if (selectedInvID != -1 && !Session.IsAdmin()) return;

                if (dgvDetails.CurrentRow == null || dgvDetails.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Chọn 1 sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow row = dgvDetails.CurrentRow;
                int proID = Convert.ToInt32(row.Cells[0].Value);
                string name = row.Cells[1].Value.ToString();
                int currentQtyUI = Convert.ToInt32(row.Cells[3].Value);
                double price = Convert.ToDouble(row.Cells[2].Value);

                int stockInDB = 0;
                int qtySavedInDB = 0;

                DataTable dtProd = DatabaseConnector.Instance.ExecuteQuery("SELECT pro_count FROM Products WHERE pro_ID = @id", new[] { new SqlParameter("@id", proID) });
                if (dtProd.Rows.Count > 0) stockInDB = Convert.ToInt32(dtProd.Rows[0]["pro_count"]);

                if (selectedInvID != -1)
                {
                    DataTable dtInv = DatabaseConnector.Instance.ExecuteQuery("SELECT ind_count FROM Invoice_details WHERE inv_ID=@inv AND pro_ID=@pro",
                        new[] { new SqlParameter("@inv", selectedInvID), new SqlParameter("@pro", proID) });
                    if (dtInv.Rows.Count > 0) qtySavedInDB = Convert.ToInt32(dtInv.Rows[0]["ind_count"]);
                }

                int maxLimit = stockInDB + qtySavedInDB;

                EditInvoiceDetailDialog dialog = new EditInvoiceDetailDialog(name, currentQtyUI, maxLimit);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int newQty = dialog.NewQuantity;
                    row.Cells[3].Value = newQty;
                    row.Cells[4].Value = price * newQty;
                    CalculateUITotal();
                    btnSave.Visible = true;
                }
            };

            btnDelDetail.Click += (s, e) => {
                if (selectedInvID != -1 && !Session.IsAdmin()) return;

                if (dgvDetails.CurrentRow != null)
                {
                    dgvDetails.Rows.Remove(dgvDetails.CurrentRow);
                    CalculateUITotal();
                    btnSave.Visible = true;
                }
            };

            btnPrint.Click += (s, e) => PrintInvoice();
        }

        private void EnableForm(bool enable)
        {
            bool canEdit = enable && (selectedInvID == -1 || Session.IsAdmin());

            cbCustomer.Enabled = canEdit;
            btnSearchCustomer.Visible = canEdit;
            btnQuickAddCustomer.Visible = canEdit;

            cbStaff.Enabled = enable && Session.IsAdmin();

            btnAddDetail.Visible = canEdit;
            btnEditDetail.Visible = canEdit;
            btnDelDetail.Visible = canEdit;
        }

        private void ClearForm()
        {
            selectedInvID = -1;
            EnableForm(false);
            txtID.Text = "[Tự động]";
            txtDate.Text = "[Tự động]";
            dgvDetails.Rows.Clear();
            CalculateUITotal();

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = false;
            btnPrint.Visible = false;
        }

        private void PrintInvoice()
        {
            if (selectedInvID == -1)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 600;
            previewDialog.Height = 800;
            previewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Courier New", 18, FontStyle.Bold);
            Font regularFont = new Font("Courier New", 11, FontStyle.Regular);
            Font boldFont = new Font("Courier New", 11, FontStyle.Bold);
            Font italicFont = new Font("Courier New", 11, FontStyle.Italic);
            Brush brush = Brushes.Black;

            int startX = 20; // Lề trái
            int startY = 30; // Lề trên
            int offset = 25; // Khoảng cách các dòng

            // --- Header ---
            g.DrawString("HÓA ĐƠN BÁN HÀNG", titleFont, brush, startX + 100, startY);
            startY += 40;
            g.DrawString("Mã số: #" + selectedInvID, regularFont, brush, startX + 160, startY);
            startY += offset;
            g.DrawString("Ngày: " + txtDate.Text, regularFont, brush, startX + 110, startY);
            startY += offset;

            g.DrawString(new string('-', 55), regularFont, brush, startX, startY);
            startY += offset;

            // --- Thông tin chung ---
            g.DrawString("Khách hàng: " + cbCustomer.Text, regularFont, brush, startX, startY);
            startY += offset;
            g.DrawString("Nhân viên : " + cbStaff.Text, regularFont, brush, startX, startY);
            startY += offset;

            g.DrawString(new string('-', 55), regularFont, brush, startX, startY);
            startY += offset;

            // --- Bảng sản phẩm ---
            g.DrawString("Sản phẩm", boldFont, brush, startX, startY);
            g.DrawString("SL", boldFont, brush, startX + 220, startY);
            g.DrawString("Đ.Giá", boldFont, brush, startX + 270, startY);
            g.DrawString("T.Tiền", boldFont, brush, startX + 370, startY);
            startY += offset;

            g.DrawString(new string('-', 55), regularFont, brush, startX, startY);
            startY += offset;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                string name = row.Cells[1].Value.ToString();
                if (name.Length > 20) name = name.Substring(0, 20) + "...";

                string qty = row.Cells[3].Value.ToString();
                string price = Convert.ToDouble(row.Cells[2].Value).ToString("N0");
                string total = Convert.ToDouble(row.Cells[4].Value).ToString("N0");

                g.DrawString(name, regularFont, brush, startX, startY);
                g.DrawString(qty, regularFont, brush, startX + 220, startY);
                g.DrawString(price, regularFont, brush, startX + 270, startY);
                g.DrawString(total, regularFont, brush, startX + 370, startY);
                startY += offset;
            }

            g.DrawString(new string('-', 55), regularFont, brush, startX, startY);
            startY += offset;

            // --- Tổng kết ---
            g.DrawString("TỔNG CỘNG:", titleFont, brush, startX + 100, startY);
            g.DrawString(lblFinalTotal.Text, titleFont, brush, startX + 250, startY);
            startY += 60;

            g.DrawString("Cảm ơn quý khách và hẹn gặp lại!", italicFont, brush, startX + 80, startY);
        }
    }
}