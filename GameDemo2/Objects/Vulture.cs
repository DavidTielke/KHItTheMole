using System.Drawing;
using HitTheMole.Properties;

namespace HitTheMole
{
    public class Vulture : GameUnit
    {
        public Vulture(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public Vulture(Point position, Size size)
            : base(position, size)
        {
            IsVisible = true;
            _spawntime = 2000;
            Image = Resources.Geier;
            ImageHit = Resources.MaulwurfHit;
            RandomSpawner = new RandomSpawner(130, new Rectangle(0, 0, Game.Panel.Width, Game.Panel.Height / 2), RestrictedAreas);
            RestrictedAreas.Add(Game.LevelScene.Scoreboard.Rectangle);
        }

        private bool _wasSpawned = false;

        protected override void ReactOnSlap()
        {
            Game.Tries += 5;
        }
    }
}