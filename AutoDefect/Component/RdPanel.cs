using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Component
{
    public class RdPanel : Panel
    {
        private int cornerRadius = 15;
        private Color borderColor = Color.Black;
        private int borderSize = 1;

        public RdPanel()
        {
            this.DoubleBuffered = true;
            this.Resize += (s, e) => this.Invalidate();
        }

        [Category("Appearance"), Description("Radius of the corners.")]

        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Border color of the panel.")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate(); // Redraw the panel when the property changes
            }
        }

        [Category("Appearance"), Description("Border size of the panel.")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate(); // Redraw the panel when the property changes
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (cornerRadius > 2) // Rounded panel
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, cornerRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, cornerRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Panel surface
                    this.Region = new Region(pathSurface);
                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Panel border                    
                    if (borderSize >= 1)
                    {
                        // Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else // Normal panel
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                // Panel surface
                this.Region = new Region(rectSurface);
                // Panel border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
