using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace HitTheMole
{
    public abstract class GameUnit : StaticObject
    {
        public bool WasHit { get; private set; }
        private DateTime LastSpawnTime { get; set; }
        public List<Rectangle> RestrictedAreas { get; set; }

        public Bitmap Image { get; set; }
        public Bitmap ImageHit { get; set; }

        public Vector2D Movement { get; set; }

        protected int _spawntime = 1800;
        protected int _amountSpawns = 0;

        public GameUnit(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        public GameUnit(Point position, Size size) : base(position, size)
        {
            WasHit = false;
            IsVisible = true;

            Movement = new Vector2D(0,0);

            RestrictedAreas = new List<Rectangle>();

            RandomSpawner = new RandomSpawner(130, new Rectangle(0, Game.Panel.Height / 2, Game.Panel.Width, Game.Panel.Height / 2), RestrictedAreas);
        }

        public virtual void Move(Point newPosition)
        {
            Position = newPosition;
            WasHit = false;
            _amountSpawns++;
        }

        protected abstract void ReactOnSlap();
        protected virtual void ReactOnMiss() { }

        public override void Draw(Graphics g)
        {
            if (!IsVisible)
            {
                return;
            }

            if (Game.DebugMode)
            {
                DrawDebugInformation(g);
            }


            if (!WasHit)
            {
                Draw(g, Image);
            }
            else
            {
                Draw(g, ImageHit);
            }
        }



        private void DrawDebugInformation(Graphics g)
        {
            // Metainfos objekte
            g.DrawString("WasHit: " + WasHit, new Font("Arial", 12), Brushes.Black,
                new PointF(this.Position.X + this.Size.Width, this.Position.Y));

            // RestrictedAreas
            var color = Color.FromArgb(50, 0, 255, 0);
            if (RestrictedAreas.Count > 0)
            {
                g.FillRectangles(new SolidBrush(color), RestrictedAreas.ToArray());
            }

            // Spawnareas
            if (RandomSpawner != null)
            {
                g.DrawRectangle(Pens.Red, RandomSpawner.SpawnArea);
            }
        }

        public override void Update()
        {
            base.Update();

            if (!Movement.IsNullVector)
            {
                Position = Movement.MovePoint(Position);
            }

            if (IsMouseBottonDown && !WasHit)
            {
                WasHit = true;
                ReactOnSlap();
            }

            if (LastSpawnTime.AddMilliseconds(_spawntime) < DateTime.Now)
            {
                var moleWasMissed = !WasHit && _amountSpawns > 0;
                if (moleWasMissed)
                {
                    ReactOnMiss();
                }

                WasHit = false;
                RandomSpawner.Move(this);

                LastSpawnTime = DateTime.Now;
            }
        }

        public RandomSpawner RandomSpawner { get; set; }

        public override void Reset()
        {
            WasHit = false;
            IsVisible = false;
        }

        public override void Start()
        {
            WasHit = false;
            IsVisible = true;
            LastSpawnTime = DateTime.MinValue;
        }

        public override void Stop()
        {
            WasHit = false;
            IsVisible = false;
        }
    }
}