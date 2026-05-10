namespace StoreManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnAccount = new Button();
            btnInvoice = new Button();
            btnProduct = new Button();
            btnCustomer = new Button();
            btnSupplier = new Button();
            btnEmployee = new Button();
            btnHome = new Button();
            panelBody = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(btnAccount);
            panelHeader.Controls.Add(btnInvoice);
            panelHeader.Controls.Add(btnProduct);
            panelHeader.Controls.Add(btnCustomer);
            panelHeader.Controls.Add(btnSupplier);
            panelHeader.Controls.Add(btnEmployee);
            panelHeader.Controls.Add(btnHome);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1182, 50);
            panelHeader.TabIndex = 0;
            // 
            // btnAccount
            // 
            btnAccount.Dock = DockStyle.Right;
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccount.ForeColor = Color.White;
            btnAccount.Location = new Point(1032, 0);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(150, 50);
            btnAccount.TabIndex = 6;
            btnAccount.Text = "TÀI KHOẢN";
            btnAccount.UseVisualStyleBackColor = true;
            btnAccount.Click += btnAccount_Click;
            // 
            // btnInvoice
            // 
            btnInvoice.Dock = DockStyle.Left;
            btnInvoice.FlatAppearance.BorderSize = 0;
            btnInvoice.FlatStyle = FlatStyle.Flat;
            btnInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInvoice.ForeColor = Color.White;
            btnInvoice.Location = new Point(750, 0);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(150, 50);
            btnInvoice.TabIndex = 5;
            btnInvoice.Text = "HOÁ ĐƠN";
            btnInvoice.UseVisualStyleBackColor = true;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // btnProduct
            // 
            btnProduct.Dock = DockStyle.Left;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProduct.ForeColor = Color.White;
            btnProduct.Location = new Point(600, 0);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(150, 50);
            btnProduct.TabIndex = 4;
            btnProduct.Text = "SẢN PHẨM";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Left;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCustomer.ForeColor = Color.White;
            btnCustomer.Location = new Point(450, 0);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(150, 50);
            btnCustomer.TabIndex = 3;
            btnCustomer.Text = "KHÁCH HÀNG";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Dock = DockStyle.Left;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSupplier.ForeColor = Color.White;
            btnSupplier.Location = new Point(300, 0);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(150, 50);
            btnSupplier.TabIndex = 2;
            btnSupplier.Text = "NHÀ CUNG CẤP";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.Dock = DockStyle.Left;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEmployee.ForeColor = Color.White;
            btnEmployee.Location = new Point(150, 0);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(150, 50);
            btnEmployee.TabIndex = 1;
            btnEmployee.Text = "NHÂN VIÊN";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Left;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(150, 50);
            btnHome.TabIndex = 0;
            btnHome.Text = "TRANG CHỦ";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panelBody
            // 
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 50);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1182, 603);
            panelBody.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 247);
            ClientSize = new Size(1182, 653);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Store Manager";
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Button btnInvoice;
        private Button btnProduct;
        private Button btnCustomer;
        private Button btnSupplier;
        private Button btnEmployee;
        private Button btnHome;
        private Panel panelBody;
        private Button btnAccount;
    }
}
