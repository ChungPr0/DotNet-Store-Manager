using StoreManager.Utils;

namespace StoreManager
{
    partial class AccountPopupForm
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
            lblAvatar = new Label();
            lblName = new Label();
            lblRole = new Label();
            separator = new Panel();
            btnLogout = new Custom3DButton();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(52, 152, 219);
            lblAvatar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(20, 20);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(50, 50);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "U";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(80, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(97, 23);
            lblName.TabIndex = 1;
            lblName.Text = "User Name";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(100, 116, 139);
            lblRole.Location = new Point(80, 48);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(39, 20);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role";
            // 
            // separator
            // 
            separator.BackColor = Color.FromArgb(236, 240, 241);
            separator.Location = new Point(20, 90);
            separator.Name = "separator";
            separator.Size = new Size(220, 1);
            separator.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(20, 110);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 45);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // AccountPopupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(260, 180);
            Controls.Add(btnLogout);
            Controls.Add(separator);
            Controls.Add(lblRole);
            Controls.Add(lblName);
            Controls.Add(lblAvatar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AccountPopupForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "AccountPopupForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel separator;
        private Custom3DButton btnLogout;
    }
}