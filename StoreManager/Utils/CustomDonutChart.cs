using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace StoreManager.Utils
{
    public class CustomDonutChart : Control
    {
        public class Slice
        {
            public string Name { get; set; }
            public double Value { get; set; }
            public Color Color { get; set; }
            public GraphicsPath Path { get; set; }
        }

        private List<Slice> slices = new List<Slice>();

        private readonly Color[] defaultColors = {
            Color.FromArgb(46, 204, 113), Color.FromArgb(52, 152, 219), Color.FromArgb(155, 89, 182),
            Color.FromArgb(241, 196, 15), Color.FromArgb(230, 126, 34), Color.FromArgb(231, 76, 60)
        };

        [Category("Chart Settings")]
        [DefaultValue("TỈ LỆ BÁN THEO DANH MỤC")]
        public string ChartTitle { get; set; } = "TỈ LỆ BÁN THEO DANH MỤC";

        [Category("Chart Settings")]
        [DefaultValue(50)]
        public int DonutHoleSize { get; set; } = 50; // Kích thước lỗ hổng ở giữa (Tỉ lệ %)

        // Sự kiện khi click vào 1 miếng bánh
        public event EventHandler<string> SliceClicked;

        public CustomDonutChart()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 11F);
            this.Cursor = Cursors.Hand;
        }

        // Nạp dữ liệu thật
        public void LoadData(Dictionary<string, double> data)
        {
            slices.Clear();
            int colorIndex = 0;
            foreach (var item in data)
            {
                slices.Add(new Slice { Name = item.Key, Value = item.Value, Color = defaultColors[colorIndex % defaultColors.Length] });
                colorIndex++;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Dữ liệu giả cho Designer
            List<Slice> drawSlices = this.DesignMode ? new List<Slice> {
                new Slice { Name = "Đồ điện tử", Value = 45, Color = defaultColors[0] },
                new Slice { Name = "Gia dụng", Value = 25, Color = defaultColors[1] },
                new Slice { Name = "Thời trang", Value = 30, Color = defaultColors[2] }
            } : slices;

            int width = this.Width;
            int height = this.Height;

            // 1. Vẽ Title
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(44, 62, 80)))
            using (Font titleFont = new Font("Segoe UI", 14F, FontStyle.Bold))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString(ChartTitle, titleFont, textBrush, new RectangleF(0, 15, width, 30), sf);
            }

            if (drawSlices.Count == 0)
            {
                g.DrawString("Không có dữ liệu", this.Font, Brushes.Gray, width / 2 - 40, height / 2);
                return;
            }

            // 2. Tính toán không gian vẽ Biểu đồ (Trái) và Chú thích (Phải)
            int chartAreaWidth = (int)(width * 0.6); // Chart chiếm 60% chiều rộng
            int minDim = Math.Min(chartAreaWidth, height - 60);
            int size = minDim - 20;
            int x = (chartAreaWidth - size) / 2;
            int y = (height - size) / 2 + 10;

            double totalValue = drawSlices.Sum(s => s.Value);
            float startAngle = -90f; // Bắt đầu từ góc 12 giờ

            // 3. Vẽ các miếng bánh
            foreach (var s in drawSlices)
            {
                float sweepAngle = (float)((s.Value / totalValue) * 360f);

                // Khởi tạo path để bắt click
                s.Path = new GraphicsPath();
                s.Path.AddPie(x, y, size, size, startAngle, sweepAngle);

                using (SolidBrush brush = new SolidBrush(s.Color))
                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.FillPath(brush, s.Path);
                    g.DrawPath(pen, s.Path);
                }
                startAngle += sweepAngle;
            }

            // 4. Vẽ lỗ tròn ở giữa tạo thành Donut
            int innerSize = (int)(size * (DonutHoleSize / 100.0));
            int innerX = x + (size - innerSize) / 2;
            int innerY = y + (size - innerSize) / 2;
            using (SolidBrush bgBrush = new SolidBrush(this.BackColor))
            {
                g.FillEllipse(bgBrush, innerX, innerY, innerSize, innerSize);
            }

            // 5. Vẽ Bảng chú thích (Legend) bên phải
            int legendX = chartAreaWidth;
            int legendY = y + 20;
            using (SolidBrush textBrush = new SolidBrush(Color.DarkGray))
            {
                foreach (var s in drawSlices)
                {
                    using (SolidBrush colorBrush = new SolidBrush(s.Color))
                    {
                        g.FillRectangle(colorBrush, legendX, legendY, 15, 15);
                    }
                    g.DrawString($"{s.Name} ({Math.Round((s.Value / totalValue) * 100)}%)", this.Font, textBrush, legendX + 25, legendY - 2);
                    legendY += 30;
                }
            }
        }

        // Bắt sự kiện Click vào miếng bánh
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (this.DesignMode) return;

            foreach (var s in slices)
            {
                if (s.Path != null && s.Path.IsVisible(e.Location))
                {
                    SliceClicked?.Invoke(this, s.Name);
                    return;
                }
            }
            SliceClicked?.Invoke(this, "ALL"); // Bấm ra ngoài là reset
        }
    }
}