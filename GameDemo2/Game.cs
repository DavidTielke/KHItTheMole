using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HitTheMole.Scenes;

namespace HitTheMole
{
    public static class Game
    {
        public static bool DebugMode { get; } = false;
        public static StaticScene CurrentScene { get; private set; }

        public static GameLevelScene LevelScene
        {
            get
            {
                return CurrentScene as GameLevelScene;
            }
        }

        public static Panel Panel { get; set; }
        public static Timer Timer { get; set; }
        public static bool IsGameOver { get; set; }
        public static Point MousePosition { get; set; }
        public static bool IsMouseDown { get; set; }
        public static List<StaticScene> Levels { get; set; }
        public static int Score { get; set; }
        public static int Tries { get; set; }

        public static void ChangeScene(StaticScene scene)
        {
            CurrentScene = scene;
            CurrentScene.Initialize();
        }

        public static void Initialize(Panel panel)
        {
            Panel = panel;
            Timer = new Timer();
            Timer.Interval = 20;
            Timer.Tick += Update;
            
            CurrentScene = new MainMenuScene();
            
            IsGameOver = false;

            Levels = new List<StaticScene>();
            Levels.Add(new LevelOneDesert());
            Levels.Add(new LevelTwoForrest());
        }

        public static void Start()
        {
            CurrentScene.Start();
            Timer.Enabled = true;
        }

        public static void Stop()
        {
            CurrentScene.Stop();
        }

        public static void Draw(Graphics g)
        {
            CurrentScene.Draw(g);
        }

        public static void Restart()
        {
            CurrentScene.Restart();
        }

        private static void Update(object sender, EventArgs e)
        {
            CurrentScene.Update();
            IsMouseUp = false;
            WhichKeyDown = Keys.None;
        }

        public static void MouseDown(Point point)
        {
            IsMouseDown = true;
            IsMouseUp = false;
        }

        public static bool IsMouseUp { get; set; }


        public static void MouseMove(int x, int y)
        {
            MousePosition = new Point(x,y);
        }
        
        public static void MouseUp(int x, int y)
        {
            IsMouseDown = false;
            IsMouseUp = true;
        }

        public static void NextLevel()
        {
            var gameFinished = Levels.Last() == CurrentScene;
            if (gameFinished)
            {
                GameFinished();
            }
            else
            {
                var currentIndex = Levels.IndexOf(CurrentScene);
                var nextLevel = Levels[currentIndex + 1];
                ChangeScene(nextLevel);
            }
        }

        public static void StartGame()
        {
            Score = 0;
            Tries = 5;
            ChangeScene(Levels.First());
        }

        private static void GameFinished()
        {
            CurrentScene = new GameFinishedScene();
        }

        public static void GameOver()
        {
            CurrentScene = new GameOverScene();
        }

        public static void ShowMainMenu()
        {
            CurrentScene = new MainMenuScene();
        }

        public static void KeyDown(Keys keyCode)
        {
            WhichKeyDown = keyCode;
        }

        public static Keys WhichKeyDown { get; set; }
    }
}