using StoreManager.Utils;

namespace StoreManager
{
    partial class UCSupplier
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
            panel1 = new Panel();
            panel4 = new Panel();
            lstSupplier = new ListBox();
            panel3 = new Panel();
            txtSearch = new TextBox();
            btnSort = new Button();
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            txtName = new TextBox();
            label6 = new Label();
            label4 = new Label();
            dtpStartDate = new DateTimePicker();
            txtPhone = new TextBox();
            label8 = new Label();
            txtAddress = new TextBox();
            label9 = new Label();
            txtDescription = new TextBox();
            label10 = new Label();
            dgvProducts = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colSold = new DataGridViewTextBoxColumn();
            label2 = new Label();
            panel5 = new Panel();
            btnSave = new Custom3DButton();
            btnDelete = new Custom3DButton();
            btnAdd = new Custom3DButton();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            panel4.Controls.Add(lstSupplier);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 80);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(250, 523);
            panel4.TabIndex = 4;
            // 
            // lstSupplier
            // 
            lstSupplier.BackColor = Color.White;
            lstSupplier.BorderStyle = BorderStyle.FixedSingle;
            lstSupplier.Dock = DockStyle.Fill;
            lstSupplier.Font = new Font("Segoe UI", 11F);
            lstSupplier.ForeColor = Color.FromArgb(44, 62, 80);
            lstSupplier.FormattingEnabled = true;
            lstSupplier.Location = new Point(10, 10);
            lstSupplier.Name = "lstSupplier";
            lstSupplier.Size = new Size(230, 503);
            lstSupplier.TabIndex = 0;
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
            btnSort.Text = "A-Z";
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
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 1, 2);
            tableLayoutPanel1.Controls.Add(dtpStartDate, 0, 3);
            tableLayoutPanel1.Controls.Add(txtPhone, 1, 3);
            tableLayoutPanel1.Controls.Add(label8, 0, 4);
            tableLayoutPanel1.Controls.Add(txtAddress, 0, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(txtDescription, 0, 7);
            tableLayoutPanel1.Controls.Add(label10, 0, 8);
            tableLayoutPanel1.Controls.Add(dgvProducts, 0, 9);
            tableLayoutPanel1.Location = new Point(35, 90);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(860, 420);
            tableLayoutPanel1.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(160, 20);
            label3.TabIndex = 42;
            label3.Text = "TÊN NHÀ CUNG CẤP:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtName, 2);
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(3, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(854, 30);
            txtName.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(100, 116, 139);
            label6.Location = new Point(3, 70);
            label6.Name = "label6";
            label6.Size = new Size(194, 20);
            label6.TabIndex = 38;
            label6.Text = "NGÀY BẮT ĐẦU HỢP TÁC:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(100, 116, 139);
            label4.Location = new Point(445, 70);
            label4.Margin = new Padding(15, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 40;
            label4.Text = "SỐ ĐIỆN THOẠI:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(3, 98);
            dtpStartDate.Margin = new Padding(3, 3, 15, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(412, 30);
            dtpStartDate.TabIndex = 43;
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(445, 98);
            txtPhone.Margin = new Padding(15, 3, 3, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(412, 30);
            txtPhone.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label8, 2);
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(100, 116, 139);
            label8.Location = new Point(3, 140);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 36;
            label8.Text = "ĐỊA CHỈ:";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtAddress, 2);
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(3, 168);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(854, 30);
            txtAddress.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label9, 2);
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(3, 210);
            label9.Name = "label9";
            label9.Size = new Size(139, 20);
            label9.TabIndex = 32;
            label9.Text = "MÔ TẢ / GHI CHÚ:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtDescription, 2);
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(3, 238);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(854, 69);
            txtDescription.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label10, 2);
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(100, 116, 139);
            label10.Location = new Point(3, 310);
            label10.Name = "label10";
            label10.Size = new Size(202, 20);
            label10.TabIndex = 34;
            label10.Text = "CÁC SẢN PHẨM CUNG CẤP";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 244, 247);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colStock, colSold });
            tableLayoutPanel1.SetColumnSpan(dgvProducts, 2);
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.Location = new Point(3, 338);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(854, 79);
            dgvProducts.TabIndex = 48;
            // 
            // colId
            // 
            colId.DataPropertyName = "pro_ID";
            colId.HeaderText = "Mã SP";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 70;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "pro_name";
            colName.HeaderText = "Tên Sản Phẩm";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "pro_price";
            dataGridViewCellStyle2.Format = "N0";
            colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            colPrice.HeaderText = "Giá Bán";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 110;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "pro_count";
            colStock.HeaderText = "Tồn Kho";
            colStock.MinimumWidth = 6;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colStock.Width = 90;
            // 
            // colSold
            // 
            colSold.DataPropertyName = "sold_count";
            colSold.HeaderText = "Đã Bán";
            colSold.MinimumWidth = 6;
            colSold.Name = "colSold";
            colSold.ReadOnly = true;
            colSold.Width = 90;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(35, 30);
            label2.Name = "label2";
            label2.Size = new Size(423, 41);
            label2.TabIndex = 46;
            label2.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(btnSave);
            panel5.Controls.Add(btnDelete);
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
            btnSave.Location = new Point(502, 10);
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
            btnDelete.Location = new Point(642, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 60);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "XÓA";
            btnDelete.UseVisualStyleBackColor = false;
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
            btnAdd.Text = "THÊM";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // UCSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCSupplier";
            Size = new Size(1182, 603);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
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
        private ListBox lstSupplier;
        private Label label2;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private TextBox txtName;
        private Label label4;
        private TextBox txtPhone;
        private Label label6;
        private DateTimePicker dtpStartDate;
        private Label label8;
        private TextBox txtAddress;
        private Label label9;
        private TextBox txtDescription;
        private Label label10;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colSold;
        private Custom3DButton btnSave;
        private Custom3DButton btnDelete;
        private Custom3DButton btnAdd;
    }
}