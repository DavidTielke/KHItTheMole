using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitTheMole.Cursors
{
    public class CursorBase
    {
        public Point Position
        {
            get { return Game.MousePosition; }
        }
        
        public Color Color { get; set; }
        public int Size { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                var radius = Size/2;
                var x = Position.X - radius;
                var y = Position.Y - radius;
                return new Rectangle(x,y,Size,Size);
            }
        }

        public CursorBase(Color color, int size)
        {
            Color = color;
            Size = size;
        }

        public virtual void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color), Rectangle);
        }
    }
}
