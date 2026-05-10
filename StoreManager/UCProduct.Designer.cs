namespace StoreManager
{
    partial class UCProduct
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
            panel1 = new Panel();
            panel4 = new Panel();
            lstProduct = new ListBox();
            panel3 = new Panel();
            txtSearch = new TextBox();
            btnSort = new Button();
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtPrice = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtCount = new TextBox();
            panelType = new Panel();
            cbType = new ComboBox();
            btnEditType = new Button();
            btnAddType = new Button();
            label8 = new Label();
            panelSup = new Panel();
            cbSupplier = new ComboBox();
            btnAddSupplier = new Button();
            label9 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            panel5 = new Panel();
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelType.SuspendLayout();
            panelSup.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();

            panel1.BackColor = Color.FromArgb(240, 244, 247);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 603);
            panel1.TabIndex = 0;

            panel4.Controls.Add(lstProduct);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 80);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(250, 523);
            panel4.TabIndex = 4;

            lstProduct.BackColor = Color.White;
            lstProduct.BorderStyle = BorderStyle.FixedSingle;
            lstProduct.Dock = DockStyle.Fill;
            lstProduct.Font = new Font("Segoe UI", 11F);
            lstProduct.ForeColor = Color.FromArgb(44, 62, 80);
            lstProduct.FormattingEnabled = true;
            lstProduct.ItemHeight = 25;
            lstProduct.Location = new Point(10, 10);
            lstProduct.Name = "lstProduct";
            lstProduct.Size = new Size(230, 503);
            lstProduct.TabIndex = 0;

            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnSort);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 80);
            panel3.TabIndex = 3;

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(14, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(168, 30);
            txtSearch.TabIndex = 0;

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

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(100, 116, 139);
            label1.Location = new Point(10, 12);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 1;
            label1.Text = "TÌM KIẾM";

            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(932, 603);
            panel2.TabIndex = 1;

            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 1, 0);
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(txtPrice, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 1, 2);
            tableLayoutPanel1.Controls.Add(txtCount, 0, 3);
            tableLayoutPanel1.Controls.Add(panelType, 1, 3);
            tableLayoutPanel1.Controls.Add(label8, 0, 4);
            tableLayoutPanel1.Controls.Add(panelSup, 0, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(txtDescription, 0, 7);
            tableLayoutPanel1.Location = new Point(35, 90);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(860, 320);
            tableLayoutPanel1.TabIndex = 47;

            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 42;
            label3.Text = "TÊN SẢN PHẨM:";

            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(100, 116, 139);
            label4.Location = new Point(445, 0);
            label4.Margin = new Padding(15, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 40;
            label4.Text = "GIÁ BÁN (VND):";

            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(0, 28);
            txtName.Margin = new Padding(0, 3, 15, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(415, 30);
            txtName.TabIndex = 45;

            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.Location = new Point(445, 28);
            txtPrice.Margin = new Padding(15, 3, 0, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(415, 30);
            txtPrice.TabIndex = 41;

            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(100, 116, 139);
            label6.Location = new Point(0, 70);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 38;
            label6.Text = "SỐ LƯỢNG TỒN:";

            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(100, 116, 139);
            label5.Location = new Point(445, 70);
            label5.Margin = new Padding(15, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 39;
            label5.Text = "PHÂN LOẠI:";

            txtCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCount.Font = new Font("Segoe UI", 10F);
            txtCount.Location = new Point(0, 98);
            txtCount.Margin = new Padding(0, 3, 15, 3);
            txtCount.Name = "txtCount";
            txtCount.Size = new Size(415, 30);
            txtCount.TabIndex = 43;

            // Panel bọc ComboBox Type và Nút
            panelType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelType.Controls.Add(cbType);
            panelType.Controls.Add(btnAddType);
            panelType.Controls.Add(btnEditType);
            panelType.Location = new Point(445, 98);
            panelType.Margin = new Padding(15, 3, 0, 3);
            panelType.Name = "panelType";
            panelType.Size = new Size(415, 31);
            panelType.TabIndex = 44;

            cbType.Dock = DockStyle.Fill;
            cbType.Font = new Font("Segoe UI", 10F);
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;

            btnAddType.Dock = DockStyle.Right;
            btnAddType.Width = 50;
            btnAddType.Text = "+";
            btnAddType.FlatStyle = FlatStyle.Flat;
            btnAddType.FlatAppearance.BorderSize = 1;
            btnAddType.BackColor = Color.WhiteSmoke;
            btnAddType.Cursor = Cursors.Hand;

            btnEditType.Dock = DockStyle.Right;
            btnEditType.Width = 50;
            btnEditType.Text = "Sửa";
            btnEditType.FlatStyle = FlatStyle.Flat;
            btnEditType.FlatAppearance.BorderSize = 1;
            btnEditType.BackColor = Color.WhiteSmoke;
            btnEditType.Cursor = Cursors.Hand;

            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(100, 116, 139);
            label8.Location = new Point(0, 140);
            label8.Name = "label8";
            label8.Size = new Size(127, 20);
            label8.TabIndex = 36;
            label8.Text = "NHÀ CUNG CẤP:";
            tableLayoutPanel1.SetColumnSpan(label8, 2);

            // Panel bọc ComboBox Supplier và Nút
            panelSup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSup.Controls.Add(cbSupplier);
            panelSup.Controls.Add(btnAddSupplier);
            panelSup.Location = new Point(0, 168);
            panelSup.Margin = new Padding(0, 3, 0, 3);
            panelSup.Name = "panelSup";
            panelSup.Size = new Size(860, 31);
            tableLayoutPanel1.SetColumnSpan(panelSup, 2);

            cbSupplier.Dock = DockStyle.Fill;
            cbSupplier.Font = new Font("Segoe UI", 10F);
            cbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            btnAddSupplier.Dock = DockStyle.Right;
            btnAddSupplier.Width = 50;
            btnAddSupplier.Text = "+";
            btnAddSupplier.FlatStyle = FlatStyle.Flat;
            btnAddSupplier.FlatAppearance.BorderSize = 1;
            btnAddSupplier.BackColor = Color.WhiteSmoke;
            btnAddSupplier.Cursor = Cursors.Hand;

            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(0, 210);
            label9.Name = "label9";
            label9.Size = new Size(137, 20);
            label9.TabIndex = 32;
            label9.Text = "MÔ TẢ / GHI CHÚ:";
            tableLayoutPanel1.SetColumnSpan(label9, 2);

            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(0, 238);
            txtDescription.Margin = new Padding(0, 3, 0, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(860, 79);
            txtDescription.TabIndex = 33;
            tableLayoutPanel1.SetColumnSpan(txtDescription, 2);

            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(35, 30);
            label2.Name = "label2";
            label2.Size = new Size(359, 41);
            label2.TabIndex = 46;
            label2.Text = "THÔNG TIN SẢN PHẨM";

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

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCProduct";
            Size = new Size(1182, 603);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelType.ResumeLayout(false);
            panelSup.ResumeLayout(false);
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
        private ListBox lstProduct;
        private Label label2;
        private Panel panel5;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtPrice;
        private Label label6;
        private TextBox txtCount;
        private Label label5;
        private Panel panelType;
        private ComboBox cbType;
        private Button btnEditType;
        private Button btnAddType;
        private Label label8;
        private Panel panelSup;
        private ComboBox cbSupplier;
        private Button btnAddSupplier;
        private Label label9;
        private TextBox txtDescription;
    }
}