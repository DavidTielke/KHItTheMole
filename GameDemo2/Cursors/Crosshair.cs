using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitTheMole.Cursors
{
    class Crosshair : CursorBase
    {
        private readonly int _thickness;

        public Crosshair(Color color, int size, int thickness) 
            : base(color, size)
        {
            _thickness = thickness;
        }

        public override void Draw(Graphics g)
        {
            var xHalf = Size/2 + Rectangle.X;
            var yHalf = Size/2 + Rectangle.Y;

            var pen = new Pen(Color, _thickness);

            g.DrawLine(pen, Rectangle.Left, yHalf, Rectangle.Right, yHalf);
            g.DrawLine(pen, xHalf, Rectangle.Top, xHalf, Rectangle.Bottom);

            var elipsRect =new Rectangle(Rectangle.Left + Size/4, Rectangle.Top + Size/4, Size/2, Size/2);
            g.DrawEllipse(pen, elipsRect);
        }
    }
}
