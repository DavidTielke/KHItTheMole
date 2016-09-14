using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HitTheMole.Cursors;
using HitTheMole.Objects;
using HitTheMole.Properties;

namespace HitTheMole.Scenes
{
    class LevelTwoForrest : GameLevelScene
    {
        public override string Name
        {
            get { return "Forrest"; }
        }

        public override int ScoreToNextLevel
        {
            get { return 20; }
        }

        public LevelTwoForrest()
        {
            BackgroundImage = Resources.GodlikeLandschaft;
            Cursor = new Crosshair(Color.Yellow, 100, 2);

            var width = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 12.8);
            var height = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 12.8);
            var monster = new Monster(-150,-150,width, height);

            Items.Add(monster);
        }
    }
}
