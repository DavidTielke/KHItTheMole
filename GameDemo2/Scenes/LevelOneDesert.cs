﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HitTheMole.Cursors;
using HitTheMole.Properties;

namespace HitTheMole.Scenes
{
    class LevelOneDesert : GameLevelScene
    {
        public Mole Mole { get; set; }
        public Vulture Vulture { get; set; }

        public override string Name
        {
            get { return "Desert"; }
        }

        public override int ScoreToNextLevel {
            get { return 1; } }

        public LevelOneDesert()
        {
            BackgroundImage = Resources.Wüste2;
            Cursor = new Crosshair(Color.Black, 100, 2);
        }

        public override void Initialize()
        {
            var width = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 12.8);
            var height = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 12.8);

            Mole = new Mole(-width, -height, width, height);
            Vulture = new Vulture(-width, -height, width, height);

            Items.Add(Mole);
            Items.Add(Vulture);
        }

    }
}
