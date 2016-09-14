using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HitTheMole.Properties;

namespace HitTheMole.Scenes
{
    class MainMenuScene : StaticScene
    {
        public GameButton StartButton { get; set; }
        public GameButton ShopButton { get; set; }
        public GameButton ExitButton { get; set; }

        public MainMenuScene()
        {
            var panelMiddlePoint = new Point(Game.Panel.Width / 2, Game.Panel.Height / 2);

            var x = panelMiddlePoint.X - 150;
            var y = panelMiddlePoint.Y - 85;

            StartButton = new GameButton(x, y, 300, 50);
            StartButton.Text = "Spiel starten";
            StartButton.Clicked += StartButtonClicked;
            Items.Add(StartButton);

            ShopButton = new GameButton(x,y+60, 300, 50);
            ShopButton.Text = "Shop";
            ShopButton.Clicked += ShopButtonClicked;
            Items.Add(ShopButton);

            ExitButton = new GameButton(x,y+120, 300, 50);
            ExitButton.Text = "Beenden";
            ExitButton.Clicked += ExitButtonClicked;
            Items.Add(ExitButton);

            BackgroundImage = Resources.Wüste2;
        }

        private void ExitButtonClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShopButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void StartButtonClicked(object sender, EventArgs e)
        {
            Game.StartGame();
        }
    }
}
