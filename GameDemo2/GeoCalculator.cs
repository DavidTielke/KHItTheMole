using System;
using System.Drawing;

namespace HitTheMole
{
    public static class GeoCalculator
    {
        public static double Distance(Point pt, GameUnit item)
        {
            return Distance(pt, item.Middlepoint);
        }

        public static double Distance(GameUnit item1, GameUnit item2)
        {
            return Distance(item1.Middlepoint, item2.Middlepoint);
        }

        public static double Distance(Point pt1, Point pt2)
        {
            int a = pt2.X - pt1.X;
            int b = pt1.Y - pt2.Y;
            double distance = Math.Sqrt((Math.Pow(a, 2) + Math.Pow(b, 2)));
            return distance;
        }
    }
}