using StoreManager.Utils;

namespace StoreManager
{
    partial class AddInvoiceDetailDialog
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lbl1 = new Label();
            cbProduct = new ComboBox();
            btnSearchProduct = new Button();
            lbl2 = new Label();
            txtStock = new TextBox();
            lbl3 = new Label();
            txtQuantity = new TextBox();
            btnAdd = new Custom3DButton();
            btnCancel = new Custom3DButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CHỌN SẢN PHẨM";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl1.ForeColor = Color.FromArgb(100, 116, 139);
            lbl1.Location = new Point(20, 70);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(82, 20);
            lbl1.TabIndex = 1;
            lbl1.Text = "Sản Phẩm:";
            // 
            // cbProduct
            // 
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduct.Font = new Font("Segoe UI", 10F);
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(20, 95);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(330, 31);
            cbProduct.TabIndex = 2;
            cbProduct.SelectedIndexChanged += cbProduct_SelectedIndexChanged;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.BackColor = Color.WhiteSmoke;
            btnSearchProduct.Cursor = Cursors.Hand;
            btnSearchProduct.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnSearchProduct.FlatStyle = FlatStyle.Flat;
            btnSearchProduct.Location = new Point(360, 94);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(50, 32);
            btnSearchProduct.TabIndex = 3;
            btnSearchProduct.Text = "Tìm";
            btnSearchProduct.UseVisualStyleBackColor = false;
            btnSearchProduct.Click += btnSearchProduct_Click;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl2.ForeColor = Color.FromArgb(100, 116, 139);
            lbl2.Location = new Point(20, 140);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(133, 20);
            lbl2.TabIndex = 4;
            lbl2.Text = "Tồn Kho Hiện Tại:";
            // 
            // txtStock
            // 
            txtStock.BackColor = Color.WhiteSmoke;
            txtStock.Font = new Font("Segoe UI", 10F);
            txtStock.Location = new Point(20, 165);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(390, 30);
            txtStock.TabIndex = 5;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl3.ForeColor = Color.FromArgb(100, 116, 139);
            lbl3.Location = new Point(20, 210);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(114, 20);
            lbl3.TabIndex = 6;
            lbl3.Text = "Số Lượng Mua:";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 10F);
            txtQuantity.Location = new Point(20, 235);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(390, 30);
            txtQuantity.TabIndex = 7;
            txtQuantity.Text = "1";
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(90, 310);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Xác Nhận";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(230, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Hủy Bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddInvoiceDetailDialog
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(432, 373);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtQuantity);
            Controls.Add(lbl3);
            Controls.Add(txtStock);
            Controls.Add(lbl2);
            Controls.Add(btnSearchProduct);
            Controls.Add(cbProduct);
            Controls.Add(lbl1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddInvoiceDetailDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Sản Phẩm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtQuantity;
        private Custom3DButton btnAdd;
        private Custom3DButton btnCancel;
    }
}