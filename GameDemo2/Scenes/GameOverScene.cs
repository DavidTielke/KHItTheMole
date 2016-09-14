using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitTheMole.Scenes
{
    class GameOverScene : StaticScene
    {
        public GameOverScene()
        {
            BackgroundImage = Game.LevelScene.BackgroundImage;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            g.DrawString("Game Over", new Font("Segoe UI", 55), Brushes.Black, Middlepoint, format);
        }

        public override void Update()
        {
            base.Update();

            if (Game.WhichKeyDown == Keys.Escape)
            {
                Game.ShowMainMenu();
            }
        }
    }
}
