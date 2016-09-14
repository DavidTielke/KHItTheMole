using System.Drawing;
using HitTheMole.Properties;

namespace HitTheMole
{
    public class Mole : GameUnit
    {
        public Mole(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public Mole(Point position, Size size)
            : base(position, size)
        {
            IsVisible = true;
            Image = Resources.MaulwurdNormal;
            ImageHit = Resources.MaulwurfHit;
            _spawntime = 1800;
            RandomSpawner = new RandomSpawner(130, new Rectangle(0, Game.Panel.Height / 3 * 2, Game.Panel.Width, Game.Panel.Height / 3 * 1), RestrictedAreas);
        }

        protected override void ReactOnSlap()
        {
            Game.Score++;
        }

        protected override void ReactOnMiss()
        {
            Game.Tries--;
        }
    }
}