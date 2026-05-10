namespace StoreManager
{
    partial class UCEmployee
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
            panel1 = new Panel();
            panel4 = new Panel();
            lstEmployee = new ListBox();
            panel3 = new Panel();
            txtSearch = new TextBox();
            btnSort = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtSalary = new TextBox();
            label11 = new Label();
            label12 = new Label();
            dtpStartDate = new DateTimePicker();
            label9 = new Label();
            txtPassword = new TextBox();
            label10 = new Label();
            txtUsername = new TextBox();
            label8 = new Label();
            txtAddress = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            dtpDOB = new DateTimePicker();
            cbRole = new ComboBox();
            txtName = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
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
            panel4.Controls.Add(lstEmployee);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 80);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(250, 523);
            panel4.TabIndex = 4;
            // 
            // lstEmployee
            // 
            lstEmployee.BackColor = Color.White;
            lstEmployee.BorderStyle = BorderStyle.FixedSingle;
            lstEmployee.Dock = DockStyle.Fill;
            lstEmployee.Font = new Font("Segoe UI", 11F);
            lstEmployee.ForeColor = Color.FromArgb(44, 62, 80);
            lstEmployee.FormattingEnabled = true;
            lstEmployee.ItemHeight = 25;
            lstEmployee.Location = new Point(10, 10);
            lstEmployee.Name = "lstEmployee";
            lstEmployee.Size = new Size(230, 503);
            lstEmployee.TabIndex = 0;
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
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(txtSalary);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dtpStartDate);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpDOB);
            panel2.Controls.Add(cbRole);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(label2);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(35, 30);
            label2.Name = "label2";
            label2.Size = new Size(365, 41);
            label2.TabIndex = 46;
            label2.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // label3 (Tên)
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(40, 90);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 42;
            label3.Text = "HỌ VÀ TÊN:";
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
            // label6 (Ngày sinh)
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(100, 116, 139);
            label6.Location = new Point(40, 165);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 38;
            label6.Text = "NGÀY SINH:";
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "dd/MM/yyyy";
            dtpDOB.Font = new Font("Segoe UI", 10F);
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.Location = new Point(40, 190);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(280, 30);
            dtpDOB.TabIndex = 43;
            // 
            // label5 (Vai trò)
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(100, 116, 139);
            label5.Location = new Point(350, 165);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 39;
            label5.Text = "VAI TRÒ:";
            // 
            // cbRole
            // 
            cbRole.Font = new Font("Segoe UI", 10F);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(350, 190);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(280, 31);
            cbRole.TabIndex = 44;
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
            // label11 (Ngày vào làm)
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(100, 116, 139);
            label11.Location = new Point(40, 315);
            label11.Name = "label11";
            label11.Size = new Size(127, 20);
            label11.TabIndex = 29;
            label11.Text = "NGÀY VÀO LÀM:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(40, 340);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(280, 30);
            dtpStartDate.TabIndex = 31;
            // 
            // label12 (Lương)
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(100, 116, 139);
            label12.Location = new Point(350, 315);
            label12.Name = "label12";
            label12.Size = new Size(179, 20);
            label12.TabIndex = 30;
            label12.Text = "LƯƠNG CƠ BẢN (VNĐ):";
            // 
            // txtSalary
            // 
            txtSalary.Font = new Font("Segoe UI", 10F);
            txtSalary.Location = new Point(350, 340);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(280, 30);
            txtSalary.TabIndex = 28;
            // 
            // label10 (Tài khoản)
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(100, 116, 139);
            label10.Location = new Point(40, 390);
            label10.Name = "label10";
            label10.Size = new Size(96, 20);
            label10.TabIndex = 34;
            label10.Text = "TÀI KHOẢN:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(40, 415);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 30);
            txtUsername.TabIndex = 35;
            // 
            // label9 (Mật khẩu)
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(350, 390);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 32;
            label9.Text = "MẬT KHẨU:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(350, 415);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 30);
            txtPassword.TabIndex = 33;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // UCEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCEmployee";
            Size = new Size(1182, 603);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private ListBox lstEmployee;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDOB;
        private ComboBox cbRole;
        private TextBox txtName;
        private TextBox txtSalary;
        private Label label11;
        private Label label12;
        private DateTimePicker dtpStartDate;
        private Label label9;
        private TextBox txtPassword;
        private Label label10;
        private TextBox txtUsername;
        private Label label8;
        private TextBox txtAddress;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtPhone;
        private Panel panel5;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
    }
}
