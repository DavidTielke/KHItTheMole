using System;
using System.Drawing;
using System.Linq;
using HitTheMole.Properties;

namespace HitTheMole
{
    public class Vulture : GameUnit
    {
        protected Point _rawPosition;

        public Vulture(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public Vulture(Point position, Size size)
            : base(position, size)
        {
            IsVisible = true;
            _spawntime = 10000;
            Image = Resources.Geier;
            ImageHit = Resources.Geier;
            RandomSpawner = new RandomSpawner(130, new Rectangle(0, 0, Game.Panel.Width, Game.Panel.Height / 2), RestrictedAreas);
            RestrictedAreas.Add(Game.LevelScene.Scoreboard.Rectangle);

            Movement = new Vector2D(180, 8);
        }

        private bool _wasSpawned = false;

        protected override void ReactOnSlap()
        {
            Game.Tries += 5;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        public override void Move(Point newPosition)
        {
            base.Move(newPosition);
            var angle = RandomSpawner.RandomPositionX.Next(-15, 15);
            Movement = new Vector2D(180 + angle, 8);

            _rawPosition = Position;
        }

        public override void Update()
        {
            base.Update();

            var isCollision = RestrictedAreas.Any(ra => ra.IntersectsWith(Rectangle));
            if (isCollision)
            {
                Movement = new Vector2D(0, Movement.Length);
            }

            if (WasHit)
            {
                Movement = new Vector2D(Movement.Angle + 2, Movement.Length + 0.7);
            }
            else
            {
                var y = Math.Sin(DateTime.Now.Millisecond / 100.0);
                Position = new Point(Position.X, _rawPosition.Y + (int)(y*30));
            }
        }
    }
}