namespace StoreManager
{
    partial class UCSupplier
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
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
            panel5 = new Panel();
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();

            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label6 = new Label();
            dtpStartDate = new DateTimePicker();
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

            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            lstSupplier.ItemHeight = 25;
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
            btnSort.Size = new Size(50, 31);
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
            label1.Size = new Size(76, 20);
            label1.TabIndex = 1;
            label1.Text = "TÌM KIẾM";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dgvProducts);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtDescription);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(dtpStartDate);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 603);
            panel2.TabIndex = 1;
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
            // label2 (Tiêu đề)
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(35, 30);
            label2.Name = "label2";
            label2.Size = new Size(405, 41);
            label2.TabIndex = 46;
            label2.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // label3 (Tên)
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(40, 90);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 42;
            label3.Text = "TÊN NHÀ CUNG CẤP:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(40, 115);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 30);
            txtName.TabIndex = 45;
            // 
            // label4 (SĐT)
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(100, 116, 139);
            label4.Location = new Point(350, 90);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 40;
            label4.Text = "SỐ ĐIỆN THOẠI:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(350, 115);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(280, 30);
            txtPhone.TabIndex = 41;
            // 
            // label6 (Ngày hợp tác)
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(100, 116, 139);
            label6.Location = new Point(40, 165);
            label6.Name = "label6";
            label6.Size = new Size(191, 20);
            label6.TabIndex = 38;
            label6.Text = "NGÀY BẮT ĐẦU HỢP TÁC:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(40, 190);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(280, 30);
            dtpStartDate.TabIndex = 43;
            // 
            // label8 (Địa chỉ)
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(100, 116, 139);
            label8.Location = new Point(40, 240);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 36;
            label8.Text = "ĐỊA CHỈ:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(40, 265);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(590, 30);
            txtAddress.TabIndex = 37;
            // 
            // label9 (Mô tả)
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(40, 315);
            label9.Name = "label9";
            label9.Size = new Size(137, 20);
            label9.TabIndex = 32;
            label9.Text = "MÔ TẢ / GHI CHÚ:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(40, 340);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(590, 55);
            txtDescription.TabIndex = 33;
            // 
            // label10 (Bảng Sản Phẩm)
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(100, 116, 139);
            label10.Location = new Point(40, 410);
            label10.Name = "label10";
            label10.Size = new Size(198, 20);
            label10.TabIndex = 34;
            label10.Text = "CÁC SẢN PHẨM CUNG CẤP";
            // 
            // dgvProducts
            // 
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.FixedSingle;

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 244, 247);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.EnableHeadersVisualStyles = false;

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colStock, colSold });
            dgvProducts.Location = new Point(40, 435);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.Size = new Size(700, 75); // Chiều cao vừa khít phía trên footer
            dgvProducts.TabIndex = 47;
            // 
            // colId
            // 
            colId.DataPropertyName = "pro_ID";
            colId.HeaderText = "Mã SP";
            colId.Width = 70;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "pro_name";
            colName.HeaderText = "Tên Sản Phẩm";
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "pro_price";
            dataGridViewCellStyle2.Format = "N0";
            colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            colPrice.HeaderText = "Giá Bán";
            colPrice.Width = 110;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "pro_count";
            colStock.HeaderText = "Tồn Kho";
            colStock.Width = 90;
            // 
            // colSold
            // 
            colSold.DataPropertyName = "sold_count";
            colSold.HeaderText = "Đã Bán";
            colSold.Width = 90;
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
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
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
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;

        // Khai báo biến
        private Label label3;
        private TextBox txtName;
        private Label label6;
        private DateTimePicker dtpStartDate;
        private Label label4;
        private TextBox txtPhone;
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
    }
}
