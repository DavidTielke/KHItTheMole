using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HitTheMole
{
    public abstract class GameLevelScene : Scenes.StaticScene
    {
        public Scoreboard Scoreboard { get; set; }
        public abstract string Name { get;}
        public abstract int ScoreToNextLevel { get; }

        public GameLevelScene()
        {
            Scoreboard = new Scoreboard(10, 0, 225, 230);

            Items.Add(Scoreboard);
        }

        public override void Update()
        {
            base.Update();

            if (Game.WhichKeyDown == Keys.Escape)
            {
                Game.ShowMainMenu();
            }

            if (Game.Score >= ScoreToNextLevel)
            {
                Game.NextLevel();
            }

            if (Game.Tries <= 0)
            {
                Game.GameOver();
            }
        }


    }
}