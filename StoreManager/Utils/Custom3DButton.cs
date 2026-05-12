using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace StoreManager.Utils
{
    public class Custom3DButton : Button
    {
        private bool isHovered = false;
        private bool isPressed = false;

        // --- CÁC THUỘC TÍNH TÙY CHỈNH ---

        [Category("Appearance")]
        [DefaultValue(15)]
        public int BorderRadius { get; set; } = 15;

        [Category("Appearance")]
        [DefaultValue(4)]
        public int ShadowSize { get; set; } = 4;

        public Custom3DButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
        }

        // Hàm trộn màu giống y hệt mixColors() bên Java
        private Color MixColor(Color baseColor, Color mixColor, double ratio)
        {
            int r = (int)(mixColor.R * ratio + baseColor.R * (1 - ratio));
            int g = (int)(mixColor.G * ratio + baseColor.G * (1 - ratio));
            int b = (int)(mixColor.B * ratio + baseColor.B * (1 - ratio));
            return Color.FromArgb(r, g, b);
        }

        // Hàm vẽ bo góc (Tương đương RoundRectangle2D bên Java)
        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // VẼ LẠI GIAO DIỆN NÚT
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Khử răng cưa
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Xóa nền cũ
            g.Clear(this.Parent != null ? this.Parent.BackColor : Color.White);

            // DÙNG BACKCOLOR ĐỂ LẤY MÀU NÚT (Sẽ ăn theo màu bạn set trong Designer)
            Color baseColor = this.BackColor == Color.Transparent ? Color.FromArgb(46, 204, 113) : this.BackColor;

            // Tính toán màu sắc
            Color shadowColor = MixColor(baseColor, Color.Black, 0.35);
            Color hoverColor = MixColor(baseColor, Color.White, 0.15);
            Color currentColor = isHovered ? hoverColor : baseColor;

            // LẤY MARGIN ĐỂ TẠO KHOẢNG CÁCH (Giúp các nút không dính nhau khi dùng Dock)
            int mLeft = this.Margin.Left;
            int mTop = this.Margin.Top;
            int mRight = this.Margin.Right;
            int mBottom = this.Margin.Bottom;

            int width = this.Width - mLeft - mRight;
            int height = this.Height - mTop - mBottom;
            int yOffset = isPressed ? ShadowSize : 0;

            if (width <= 0 || height <= 0) return;

            // 3. VẼ NÚT DỰA TRÊN MARGIN VÀ MÀU ĐÃ TÍNH
            using (GraphicsPath shadowPath = GetRoundPath(new Rectangle(mLeft, mTop + ShadowSize, width - 1, height - ShadowSize - 1), BorderRadius))
            using (GraphicsPath mainPath = GetRoundPath(new Rectangle(mLeft, mTop + yOffset, width - 1, height - ShadowSize - 1), BorderRadius))
            using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
            using (SolidBrush mainBrush = new SolidBrush(currentColor))
            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                // Vẽ bóng đổ 
                if (!isPressed)
                {
                    g.FillPath(shadowBrush, shadowPath);
                }

                // Vẽ thân nút
                g.FillPath(mainBrush, mainPath);

                // Vẽ chữ căn giữa
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Rectangle textRect = new Rectangle(mLeft, mTop + yOffset, width, height - ShadowSize);
                g.DrawString(this.Text, this.Font, textBrush, textRect, sf);
            }
        }

        // --- XỬ LÝ SỰ KIỆN CHUỘT ---
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            this.Invalidate();
        }
    }
}