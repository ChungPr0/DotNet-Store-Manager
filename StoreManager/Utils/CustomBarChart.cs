using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace StoreManager.Utils
{
    public class CustomBarChart : Control
    {
        private List<string> labels = new List<string>();
        private List<double> values = new List<double>();
        private double maxValue = 0;

        [Category("Chart Settings")]
        [DefaultValue("BIỂU ĐỒ DOANH THU")]
        public string ChartTitle { get; set; } = "BIỂU ĐỒ DOANH THU";

        [Category("Chart Settings")]
        [DefaultValue(typeof(Color), "46, 204, 113")]
        public Color BarColor { get; set; } = Color.FromArgb(46, 204, 113);

        [Category("Chart Settings")]
        [DefaultValue(typeof(Color), "200, 200, 200")]
        public Color AxisColor { get; set; } = Color.FromArgb(200, 200, 200);

        [Category("Chart Settings")]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color TextColor { get; set; } = Color.DarkGray;

        public CustomBarChart()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10F);
        }

        // Hàm nạp dữ liệu thật khi chạy code
        public void LoadData(List<string> lbls, List<double> vals, string titleSuffix = "")
        {
            this.labels = lbls;
            this.values = vals;
            this.ChartTitle = "BIỂU ĐỒ DOANH THU " + titleSuffix.ToUpper();
            this.maxValue = vals.Count > 0 ? vals.Max() : 0;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Dữ liệu giả để hiển thị trong giao diện Designer
            List<string> drawLabels = this.DesignMode ? new List<string> { "01/05", "02/05", "03/05", "04/05", "05/05" } : labels;
            List<double> drawValues = this.DesignMode ? new List<double> { 1500000, 3200000, 800000, 4500000, 2100000 } : values;
            double drawMax = this.DesignMode ? 4500000 : maxValue;

            int width = this.Width;
            int height = this.Height;
            int paddingX = 50;
            int paddingY = 60;
            int graphHeight = height - paddingY * 2;

            // 1. Vẽ tiêu đề
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(44, 62, 80)))
            using (Font titleFont = new Font("Segoe UI", 14F, FontStyle.Bold))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString(ChartTitle, titleFont, textBrush, new RectangleF(0, 15, width, 30), sf);
            }

            // Nếu không có dữ liệu
            if (drawValues.Count == 0)
            {
                using (SolidBrush textBrush = new SolidBrush(TextColor))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("Chưa có dữ liệu cho khoảng thời gian này", this.Font, textBrush, new RectangleF(0, 0, width, height), sf);
                }
                return;
            }

            // 2. Vẽ trục tọa độ
            using (Pen axisPen = new Pen(AxisColor, 2))
            {
                g.DrawLine(axisPen, paddingX, height - paddingY, width - paddingX, height - paddingY); // Trục X
                g.DrawLine(axisPen, paddingX, height - paddingY, paddingX, paddingY); // Trục Y
            }

            // 3. Vẽ các cột
            int numberOfBars = drawValues.Count;
            int slotWidth = (width - 2 * paddingX) / numberOfBars;
            int barWidth = Math.Min(slotWidth - 20, 80);
            if (barWidth < 10) barWidth = 10;

            using (SolidBrush barBrush = new SolidBrush(BarColor))
            using (Pen barBorderPen = new Pen(ControlPaint.Dark(BarColor), 1))
            using (SolidBrush textBrush = new SolidBrush(TextColor))
            using (Font valueFont = new Font("Segoe UI", 10F, FontStyle.Bold))
            {
                for (int i = 0; i < numberOfBars; i++)
                {
                    double val = drawValues[i];
                    int barHeight = drawMax > 0 ? (int)((val / drawMax) * graphHeight * 0.8) : 0;
                    if (barHeight < 2 && val > 0) barHeight = 2;

                    int x = paddingX + (i * slotWidth) + (slotWidth - barWidth) / 2;
                    int y = height - paddingY - barHeight;

                    // Vẽ cột
                    g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                    g.DrawRectangle(barBorderPen, x, y, barWidth, barHeight);

                    // Chữ giá trị (Format tiền)
                    string priceStr = val >= 1000000 ? (val / 1000000.0).ToString("0.#") + " Tr" : (val / 1000.0).ToString("0") + " K";
                    SizeF valSize = g.MeasureString(priceStr, valueFont);
                    g.DrawString(priceStr, valueFont, textBrush, x + (barWidth - valSize.Width) / 2, y - 20);

                    // Chữ ngày tháng
                    string dateStr = drawLabels[i];
                    SizeF dateSize = g.MeasureString(dateStr, this.Font);
                    g.DrawString(dateStr, this.Font, textBrush, x + (barWidth - dateSize.Width) / 2, height - paddingY + 10);
                }
            }
        }
    }
}