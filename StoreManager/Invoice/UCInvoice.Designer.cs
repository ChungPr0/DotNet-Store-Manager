using StoreManager.Utils;

namespace StoreManager
{
    partial class UCInvoice
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel4 = new Panel();
            lstInvoice = new ListBox();
            panel3 = new Panel();
            txtSearch = new TextBox();
            btnSort = new Button();
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            txtID = new TextBox();
            txtDate = new TextBox();
            label6 = new Label();
            label5 = new Label();
            panelCus = new Panel();
            cbCustomer = new ComboBox();
            btnQuickAddCustomer = new Button();
            btnSearchCustomer = new Button();
            cbStaff = new ComboBox();
            label10 = new Label();
            dgvDetails = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            panelActions = new Panel();
            btnDelDetail = new Custom3DButton();
            btnEditDetail = new Custom3DButton();
            btnAddDetail = new Custom3DButton();
            lblFinalTotal = new Label();
            labelTitleTotal = new Label();
            label2 = new Label();
            panel5 = new Panel();
            btnSave = new Custom3DButton();
            btnDelete = new Custom3DButton();
            btnPrint = new Custom3DButton();
            btnAdd = new Custom3DButton();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelCus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            panelActions.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(240, 244, 247);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 603);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(lstInvoice);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 80);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(250, 523);
            panel4.TabIndex = 4;
            // 
            // lstInvoice
            // 
            lstInvoice.BackColor = Color.White;
            lstInvoice.BorderStyle = BorderStyle.FixedSingle;
            lstInvoice.Dock = DockStyle.Fill;
            lstInvoice.Font = new Font("Segoe UI", 11F);
            lstInvoice.ForeColor = Color.FromArgb(44, 62, 80);
            lstInvoice.FormattingEnabled = true;
            lstInvoice.Location = new Point(10, 10);
            lstInvoice.Name = "lstInvoice";
            lstInvoice.Size = new Size(230, 503);
            lstInvoice.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnSort);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 80);
            panel3.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(14, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(168, 30);
            txtSearch.TabIndex = 0;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.FromArgb(149, 165, 166);
            btnSort.Cursor = Cursors.Hand;
            btnSort.FlatAppearance.BorderSize = 0;
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(188, 34);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(53, 31);
            btnSort.TabIndex = 2;
            btnSort.Text = "NEW";
            btnSort.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(100, 116, 139);
            label1.Location = new Point(10, 12);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "TÌM KIẾM";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 603);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 1, 0);
            tableLayoutPanel1.Controls.Add(txtID, 0, 1);
            tableLayoutPanel1.Controls.Add(txtDate, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 1, 2);
            tableLayoutPanel1.Controls.Add(panelCus, 0, 3);
            tableLayoutPanel1.Controls.Add(cbStaff, 1, 3);
            tableLayoutPanel1.Controls.Add(label10, 0, 4);
            tableLayoutPanel1.Controls.Add(dgvDetails, 0, 5);
            tableLayoutPanel1.Controls.Add(panelActions, 0, 6);
            tableLayoutPanel1.Controls.Add(lblFinalTotal, 1, 7);
            tableLayoutPanel1.Controls.Add(labelTitleTotal, 0, 7);
            tableLayoutPanel1.Location = new Point(35, 90);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(860, 420);
            tableLayoutPanel1.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 42;
            label3.Text = "MÃ HÓA ĐƠN:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(100, 116, 139);
            label4.Location = new Point(445, 0);
            label4.Margin = new Padding(15, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 40;
            label4.Text = "NGÀY LẬP ĐƠN:";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtID.Enabled = false;
            txtID.Font = new Font("Segoe UI", 10F);
            txtID.Location = new Point(0, 28);
            txtID.Margin = new Padding(0, 3, 15, 3);
            txtID.Name = "txtID";
            txtID.Size = new Size(415, 30);
            txtID.TabIndex = 45;
            // 
            // txtDate
            // 
            txtDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDate.Enabled = false;
            txtDate.Font = new Font("Segoe UI", 10F);
            txtDate.Location = new Point(445, 28);
            txtDate.Margin = new Padding(15, 3, 0, 3);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(415, 30);
            txtDate.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(100, 116, 139);
            label6.Location = new Point(3, 70);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 38;
            label6.Text = "KHÁCH HÀNG:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(100, 116, 139);
            label5.Location = new Point(445, 70);
            label5.Margin = new Padding(15, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 39;
            label5.Text = "NHÂN VIÊN BÁN:";
            // 
            // panelCus
            // 
            panelCus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCus.Controls.Add(cbCustomer);
            panelCus.Controls.Add(btnQuickAddCustomer);
            panelCus.Controls.Add(btnSearchCustomer);
            panelCus.Location = new Point(0, 98);
            panelCus.Margin = new Padding(0, 3, 15, 3);
            panelCus.Name = "panelCus";
            panelCus.Size = new Size(415, 31);
            panelCus.TabIndex = 44;
            // 
            // cbCustomer
            // 
            cbCustomer.Dock = DockStyle.Fill;
            cbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomer.Font = new Font("Segoe UI", 10F);
            cbCustomer.Location = new Point(0, 0);
            cbCustomer.Name = "cbCustomer";
            cbCustomer.Size = new Size(315, 31);
            cbCustomer.TabIndex = 0;
            // 
            // btnQuickAddCustomer
            // 
            btnQuickAddCustomer.BackColor = Color.WhiteSmoke;
            btnQuickAddCustomer.Cursor = Cursors.Hand;
            btnQuickAddCustomer.Dock = DockStyle.Right;
            btnQuickAddCustomer.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnQuickAddCustomer.FlatStyle = FlatStyle.Flat;
            btnQuickAddCustomer.Location = new Point(315, 0);
            btnQuickAddCustomer.Name = "btnQuickAddCustomer";
            btnQuickAddCustomer.Size = new Size(50, 31);
            btnQuickAddCustomer.TabIndex = 1;
            btnQuickAddCustomer.Text = "+";
            btnQuickAddCustomer.UseVisualStyleBackColor = false;
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.BackColor = Color.WhiteSmoke;
            btnSearchCustomer.Cursor = Cursors.Hand;
            btnSearchCustomer.Dock = DockStyle.Right;
            btnSearchCustomer.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnSearchCustomer.FlatStyle = FlatStyle.Flat;
            btnSearchCustomer.Location = new Point(365, 0);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(50, 31);
            btnSearchCustomer.TabIndex = 2;
            btnSearchCustomer.Text = "Tìm";
            btnSearchCustomer.UseVisualStyleBackColor = false;
            // 
            // cbStaff
            // 
            cbStaff.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStaff.Font = new Font("Segoe UI", 10F);
            cbStaff.Location = new Point(445, 98);
            cbStaff.Margin = new Padding(15, 3, 0, 3);
            cbStaff.Name = "cbStaff";
            cbStaff.Size = new Size(415, 31);
            cbStaff.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label10, 2);
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(100, 116, 139);
            label10.Location = new Point(3, 140);
            label10.Name = "label10";
            label10.Size = new Size(181, 20);
            label10.TabIndex = 34;
            label10.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 244, 247);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(44, 62, 80);
            dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colQty, colTotal });
            tableLayoutPanel1.SetColumnSpan(dgvDetails, 2);
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.Location = new Point(0, 168);
            dgvDetails.Margin = new Padding(0, 3, 0, 3);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.Size = new Size(860, 164);
            dgvDetails.TabIndex = 48;
            // 
            // colId
            // 
            colId.HeaderText = "Mã SP";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Tên Sản Phẩm";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPrice
            // 
            dataGridViewCellStyle2.Format = "N0";
            colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            colPrice.HeaderText = "Đơn Giá";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 130;
            // 
            // colQty
            // 
            colQty.HeaderText = "Số Lượng";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            colQty.Width = 90;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Format = "N0";
            colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            colTotal.HeaderText = "Thành Tiền";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 150;
            // 
            // panelActions
            // 
            panelActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(panelActions, 2);
            panelActions.Controls.Add(btnDelDetail);
            panelActions.Controls.Add(btnEditDetail);
            panelActions.Controls.Add(btnAddDetail);
            panelActions.Location = new Point(560, 338);
            panelActions.Margin = new Padding(0, 3, 0, 3);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(300, 39);
            panelActions.TabIndex = 49;
            // 
            // btnDelDetail
            // 
            btnDelDetail.BackColor = Color.Transparent;
            btnDelDetail.Dock = DockStyle.Right;
            btnDelDetail.FlatStyle = FlatStyle.Flat;
            btnDelDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelDetail.ForeColor = Color.White;
            btnDelDetail.Location = new Point(30, 0);
            btnDelDetail.Name = "btnDelDetail";
            btnDelDetail.Size = new Size(90, 39);
            btnDelDetail.TabIndex = 0;
            btnDelDetail.Text = "Xóa SP";
            btnDelDetail.UseVisualStyleBackColor = false;
            // 
            // btnEditDetail
            // 
            btnEditDetail.BackColor = Color.Transparent;
            btnEditDetail.Dock = DockStyle.Right;
            btnEditDetail.FlatStyle = FlatStyle.Flat;
            btnEditDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditDetail.ForeColor = Color.White;
            btnEditDetail.Location = new Point(120, 0);
            btnEditDetail.Name = "btnEditDetail";
            btnEditDetail.Size = new Size(90, 39);
            btnEditDetail.TabIndex = 1;
            btnEditDetail.Text = "Sửa SL";
            btnEditDetail.UseVisualStyleBackColor = false;
            // 
            // btnAddDetail
            // 
            btnAddDetail.BackColor = Color.Transparent;
            btnAddDetail.Dock = DockStyle.Right;
            btnAddDetail.FlatStyle = FlatStyle.Flat;
            btnAddDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddDetail.ForeColor = Color.White;
            btnAddDetail.Location = new Point(210, 0);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(90, 39);
            btnAddDetail.TabIndex = 2;
            btnAddDetail.Text = "Thêm SP";
            btnAddDetail.UseVisualStyleBackColor = false;
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.AutoSize = true;
            lblFinalTotal.Dock = DockStyle.Left;
            lblFinalTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFinalTotal.ForeColor = Color.FromArgb(231, 76, 60);
            lblFinalTotal.Location = new Point(433, 380);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Size = new Size(99, 40);
            lblFinalTotal.TabIndex = 51;
            lblFinalTotal.Text = "0 VND";
            lblFinalTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTitleTotal
            // 
            labelTitleTotal.AutoSize = true;
            labelTitleTotal.Dock = DockStyle.Right;
            labelTitleTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitleTotal.Location = new Point(248, 380);
            labelTitleTotal.Name = "labelTitleTotal";
            labelTitleTotal.Size = new Size(179, 40);
            labelTitleTotal.TabIndex = 50;
            labelTitleTotal.Text = "KHÁCH CẦN TRẢ:";
            labelTitleTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(35, 30);
            label2.Name = "label2";
            label2.Size = new Size(339, 41);
            label2.TabIndex = 46;
            label2.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(btnSave);
            panel5.Controls.Add(btnDelete);
            panel5.Controls.Add(btnPrint);
            panel5.Controls.Add(btnAdd);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 523);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(932, 80);
            panel5.TabIndex = 27;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(362, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 60);
            btnSave.TabIndex = 2;
            btnSave.Text = "LƯU";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Dock = DockStyle.Right;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(502, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 60);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "XÓA";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(155, 89, 182);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Dock = DockStyle.Right;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(642, 10);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(140, 60);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "IN HÓA ĐƠN";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Right;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(782, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 60);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "TẠO MỚI";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // UCInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCInvoice";
            Size = new Size(1182, 603);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelCus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            panelActions.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtSearch;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Button btnSort;
        private ListBox lstInvoice;
        private Label label2;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private TextBox txtID;
        private TextBox txtDate;
        private Label label6;
        private Label label5;
        private Panel panelCus;
        private ComboBox cbCustomer;
        private Button btnQuickAddCustomer;
        private Button btnSearchCustomer;
        private ComboBox cbStaff;
        private Label label10;
        private DataGridView dgvDetails;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colTotal;
        private Panel panelActions;
        private Label labelTitleTotal;
        private Label lblFinalTotal;
        private Custom3DButton btnSave;
        private Custom3DButton btnDelete;
        private Custom3DButton btnPrint;
        private Custom3DButton btnAdd;
        private Custom3DButton btnDelDetail;
        private Custom3DButton btnEditDetail;
        private Custom3DButton btnAddDetail;
    }
}