using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HitTheMole
{
    public class RandomSpawner
    {
        private static int _fu = 1000;

        public Random RandomPositionX { get; private set; }
        public Random RandomPositionY { get; private set; }
        private int MinDistance { get; set; }
        public Rectangle SpawnArea { get; private set; }
        public List<Rectangle> RestrictedAreas { get; set; }

        public RandomSpawner(int minDistance, Rectangle spawnArea, List<Rectangle> restrictedAreas)
        {
            RandomPositionX = new Random(1245 * _fu);
            RandomPositionY = new Random(13 * _fu);
            _fu += 1337;
            MinDistance = minDistance;
            SpawnArea = spawnArea;
            RestrictedAreas = restrictedAreas;
        }

        public void Move(GameUnit item)
        {
            Point newPoint;
            double distance;
            bool isInvalidSpawn;

            do
            {
                var newX = RandomPositionX.Next(0, SpawnArea.Width - item.Size.Width) + SpawnArea.X;
                var newY = RandomPositionY.Next(0, SpawnArea.Height - item.Size.Height) + SpawnArea.Y;
                newPoint = new Point(newX, newY);

                distance = GeoCalculator.Distance(newPoint, item);

                var inRestrictedArea = false;
                var newRectange = new Rectangle(newX, newY, item.Size.Width, item.Size.Height);
                foreach (var restrictedArea in RestrictedAreas)
                {
                    if (restrictedArea.IntersectsWith(newRectange))
                    {
                        inRestrictedArea = true;
                        break;
                    }
                }
                isInvalidSpawn = distance < MinDistance || inRestrictedArea;
            } while (isInvalidSpawn);

            item.Move(newPoint);
        }
    }
}