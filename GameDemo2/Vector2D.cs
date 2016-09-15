using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitTheMole
{
    public struct Vector2D
    {
        public double Angle { get; set; }
        public double Length { get; set; }

        public bool IsNullVector
        {
            get { return Angle == 0 && Length == 0; }
        }

        public Vector2D(double angle, double length)
        {
            Length = length;
            Angle = angle;
        }

        public Point MovePoint(Point point)
        {
            var angle = Math.PI* (Angle+90) / 180.0;
            var x = (int)Math.Round(Length*Math.Sin(angle));
            var y = (int)Math.Round(Length*Math.Cos(angle));

            return new Point(point.X + x, point.Y + y);
        }
    }
}
