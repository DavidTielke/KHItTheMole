using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitTheMole.Cursors;
using HitTheMole.Properties;

namespace HitTheMole.Scenes
{
    public abstract class StaticScene
    {
        public List<StaticObject> Items { get; set; }
        public Bitmap BackgroundImage { get; set; }
        public CursorBase Cursor { get; set; }

        public Point Middlepoint
        {
            get { return new Point(Game.Panel.Width/2, Game.Panel.Height/2); }
        }

        public StaticScene()
        {
            Items = new List<StaticObject>();
            Cursor = new CursorBase(Color.Red, 10);
        }

        public void Start()
        {
            foreach (var item in Items)
            {
                item.Start();
            }
        }

        public void Stop()
        {
            foreach (var item in Items)
            {
                item.Stop();
            }
        }

        public void Restart()
        {
            Start();
            Stop();
        }

        public virtual void Update()
        {
            foreach (var item in Items)
            {
                item.Update();
            }
        }

        public virtual void Draw(Graphics g)
        {
            if (BackgroundImage != null)
            {
                g.DrawImage(BackgroundImage, 0, 0, Game.Panel.Width, Game.Panel.Height);
            }

            foreach (var item in Items)
            {
                item.Draw(g);
            }

            Cursor.Draw(g);
        }

        public virtual void Initialize()
        {
            
        }
    }
}
