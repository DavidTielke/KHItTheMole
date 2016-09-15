using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitTheMole.Objects
{
    class Car : GameUnit
    {
        public Car(int x, int y, int width, int height) 
            : this(new Point(x,y), new Size(width, height))
        {
        }

        public Car(Point position, Size size) : base(position, size)
        {
            RandomSpawner = new RandomSpawner(130, Game.Panel.DisplayRectangle, new List<Rectangle>());
            _spawntime = int.MaxValue;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, Rectangle);
        }

        public override void Update()
        {
            base.Update();
            switch (Game.WhichKeyDown)
            {
                case Keys.Up:
                    Movement = new Vector2D(Movement.Angle, Movement.Length+0.5);
                    break;
                case Keys.Down:
                    Movement = new Vector2D(Movement.Angle, Movement.Length - 0.5);
                    break;
                case Keys.Left:
                    Movement = new Vector2D(Movement.Angle +1, Movement.Length);
                    break;
                case Keys.Right:
                    Movement = new Vector2D(Movement.Angle-1, Movement.Length);
                    break;
            }
        }

        protected override void ReactOnSlap()
        {
            
        }
    }
}
