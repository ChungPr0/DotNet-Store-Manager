namespace StoreManager
{
    partial class UCDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnRefresh = new StoreManager.Utils.Custom3DButton();
            cbPeriod = new ComboBox();
            lblTitle = new Label();
            pnlCards = new TableLayoutPanel();
            card1 = new Panel();
            card2 = new Panel();
            card3 = new Panel();
            card4 = new Panel();
            lblRevenue = new Label();
            lblItemsSold = new Label();
            lblActiveCustomers = new Label();
            lblOrders = new Label();
            pnlCharts = new TableLayoutPanel();
            barChartRevenue = new StoreManager.Utils.CustomBarChart();
            donutChartCategory = new StoreManager.Utils.CustomDonutChart();
            pnlHeader.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCharts.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(cbPeriod);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1182, 70);
            pnlHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.Gray;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1060, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 40);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Làm Mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cbPeriod
            // 
            cbPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeriod.Items.AddRange(new object[] { "Hôm nay", "7 ngày qua", "Tháng này", "Năm nay" });
            cbPeriod.Location = new Point(890, 21);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(150, 28);
            cbPeriod.TabIndex = 1;
            cbPeriod.SelectedIndexChanged += cbPeriod_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(325, 37);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "TỔNG QUAN HỆ THỐNG";
            // 
            // pnlCards
            // 
            pnlCards.ColumnCount = 4;
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.Controls.Add(card1, 0, 0);
            pnlCards.Controls.Add(card2, 1, 0);
            pnlCards.Controls.Add(card3, 2, 0);
            pnlCards.Controls.Add(card4, 3, 0);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 70);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(10, 0, 10, 0);
            pnlCards.RowCount = 1;
            pnlCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlCards.Size = new Size(1182, 130);
            pnlCards.TabIndex = 1;
            // 
            // card1
            // 
            card1.Dock = DockStyle.Fill;
            card1.Location = new Point(13, 3);
            card1.Name = "card1";
            card1.Size = new Size(284, 124);
            card1.TabIndex = 0;
            // 
            // card2
            // 
            card2.Dock = DockStyle.Fill;
            card2.Location = new Point(303, 3);
            card2.Name = "card2";
            card2.Size = new Size(284, 124);
            card2.TabIndex = 1;
            // 
            // card3
            // 
            card3.Dock = DockStyle.Fill;
            card3.Location = new Point(593, 3);
            card3.Name = "card3";
            card3.Size = new Size(284, 124);
            card3.TabIndex = 2;
            // 
            // card4
            // 
            card4.Dock = DockStyle.Fill;
            card4.Location = new Point(883, 3);
            card4.Name = "card4";
            card4.Size = new Size(286, 124);
            card4.TabIndex = 3;
            // 
            // lblRevenue
            // 
            lblRevenue.Location = new Point(0, 0);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(100, 23);
            lblRevenue.TabIndex = 0;
            // 
            // lblItemsSold
            // 
            lblItemsSold.Location = new Point(0, 0);
            lblItemsSold.Name = "lblItemsSold";
            lblItemsSold.Size = new Size(100, 23);
            lblItemsSold.TabIndex = 0;
            // 
            // lblActiveCustomers
            // 
            lblActiveCustomers.Location = new Point(0, 0);
            lblActiveCustomers.Name = "lblActiveCustomers";
            lblActiveCustomers.Size = new Size(100, 23);
            lblActiveCustomers.TabIndex = 0;
            // 
            // lblOrders
            // 
            lblOrders.Location = new Point(0, 0);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(100, 23);
            lblOrders.TabIndex = 0;
            // 
            // pnlCharts
            // 
            pnlCharts.ColumnCount = 2;
            pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlCharts.Controls.Add(barChartRevenue, 0, 0);
            pnlCharts.Controls.Add(donutChartCategory, 1, 0);
            pnlCharts.Dock = DockStyle.Fill;
            pnlCharts.Location = new Point(0, 200);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Padding = new Padding(10);
            pnlCharts.RowCount = 1;
            pnlCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlCharts.Size = new Size(1182, 403);
            pnlCharts.TabIndex = 2;
            // 
            // barChartRevenue
            // 
            barChartRevenue.AxisColor = Color.FromArgb(200, 200, 200);
            barChartRevenue.BackColor = Color.White;
            barChartRevenue.Dock = DockStyle.Fill;
            barChartRevenue.Font = new Font("Segoe UI", 10F);
            barChartRevenue.Location = new Point(20, 20);
            barChartRevenue.Margin = new Padding(10);
            barChartRevenue.Name = "barChartRevenue";
            barChartRevenue.Size = new Size(561, 363);
            barChartRevenue.TabIndex = 0;
            // 
            // donutChartCategory
            // 
            donutChartCategory.BackColor = Color.White;
            donutChartCategory.Dock = DockStyle.Fill;
            donutChartCategory.Font = new Font("Segoe UI", 11F);
            donutChartCategory.Location = new Point(601, 20);
            donutChartCategory.Margin = new Padding(10);
            donutChartCategory.Name = "donutChartCategory";
            donutChartCategory.Size = new Size(561, 363);
            donutChartCategory.TabIndex = 1;
            // 
            // UCDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            Controls.Add(pnlCharts);
            Controls.Add(pnlCards);
            Controls.Add(pnlHeader);
            Name = "UCDashboard";
            Size = new Size(1182, 603);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCards.ResumeLayout(false);
            pnlCharts.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupCard(System.Windows.Forms.Panel card, System.Windows.Forms.Label lblVal, string title, System.Drawing.Color color)
        {
            card.Controls.Clear();
            card.BackColor = color;
            card.Margin = new System.Windows.Forms.Padding(10);
            card.Dock = System.Windows.Forms.DockStyle.Fill;

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(15, 15);
            lblTitle.AutoSize = true;

            lblVal.ForeColor = System.Drawing.Color.White;
            lblVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblVal.Location = new System.Drawing.Point(10, 45);
            lblVal.AutoSize = true;
            lblVal.Text = "0";

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblVal);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbPeriod;
        private StoreManager.Utils.Custom3DButton btnRefresh;
        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private System.Windows.Forms.Panel card1, card2, card3, card4;
        private System.Windows.Forms.Label lblRevenue, lblItemsSold, lblActiveCustomers, lblOrders;
        private System.Windows.Forms.TableLayoutPanel pnlCharts;
        private StoreManager.Utils.CustomBarChart barChartRevenue;
        private StoreManager.Utils.CustomDonutChart donutChartCategory;
    }
}