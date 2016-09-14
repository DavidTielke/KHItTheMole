using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HitTheMole
{
    class GameButton : StaticObject
    {
        public string Text { get; set; }
        private Color BackgroundColor { get; set; }

        public event EventHandler Clicked;

        public GameButton(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public GameButton(Point position, Size size) : base(position, size)
        {
            IsVisible = true;
        }

        public override void Draw(Graphics g)
        {
            if (!IsVisible)
            {
                return;
            }

            g.FillRectangle(new SolidBrush(BackgroundColor), Rectangle);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            g.DrawString(Text, new Font("Segoe UI", 20), Brushes.Black, Middlepoint, format);
            g.DrawRectangle(new Pen(Color.Black, 3f), Rectangle);
        }

        private bool _isClicked = false;

        public override void Update()
        {
            base.Update();

            if (IsMouseOver)
            {
                if (IsMouseBottonDown)
                {
                    BackgroundColor = Color.LightSkyBlue;
                }
                else
                {
                    BackgroundColor = Color.FromArgb(255, 0xff, 0x99, 0x00);
                }

                if (IsMouseButtonUp)
                {
                    if (!_isClicked)
                    {
                        OnClicked();
                    }
                }
            }
            else
            {
                BackgroundColor = Color.FromArgb(150, 0xff, 0x99, 0x00);
            }
        }

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}