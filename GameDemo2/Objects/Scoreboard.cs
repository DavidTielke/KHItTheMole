using System.Drawing;
using HitTheMole.Properties;

namespace HitTheMole
{
    public class Scoreboard : StaticObject
    {
        public Scoreboard(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public Scoreboard(Point position, Size size) : base(position, size)
        {
        }

        public override void Draw(Graphics g)
        {
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Far;
            strFormat.LineAlignment = StringAlignment.Near;
            g.DrawImage(Resources.Schild, Rectangle);
            g.DrawString("Score: " + Game.Score, new Font("Impact", 20), Brushes.WhiteSmoke, Position.X+10, Position.Y+ 95);
            g.DrawString("Tries: " + Game.Tries, new Font("Impact", 20), Brushes.WhiteSmoke, Position.X + 10, Position.Y + 125);
            g.DrawString("Level: " + Game.LevelScene.Name, new Font("Impact", 20), Brushes.WhiteSmoke, Position.X + 10, Position.Y + 155);
        }

        public override void Update()
        {

        }

        public override void Reset()
        {

        }

        public override void Start()
        {

        }

        public override void Stop()
        {

        }
    }
}