using System.Diagnostics;
using System.Drawing;

namespace HitTheMole
{
    public abstract class StaticObject
    {
        public StaticObject(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public StaticObject(Point position, Size size)
        {
            Size = size;
            Position = position;
        }
        
        public Size Size { get; protected set; }
        public Point Position { get; protected set; }
        public bool IsMouseOver { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Position.X, Position.Y, Size.Width, Size.Height); }
        }

        public Point Middlepoint
        {
            get { return new Point(Position.X + Size.Width/2, Position.Y + Size.Height/2); }
        }

        public bool IsVisible { get; set; }
        public bool IsMouseLeave { get; set; }
        public bool IsMouseEnter { get; set; }

        public bool IsMouseBottonDown
        {
            get { return Game.IsMouseDown && IsMouseOver; }
        }

        public bool IsMouseButtonUp
        {
            get { return Game.IsMouseUp && IsMouseOver; }
        }

        public abstract void Draw(Graphics g);

        protected void Draw(Graphics g, Bitmap image)
        {
            g.DrawImage(image, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            var isNowMouseOver = Rectangle.Contains(Game.MousePosition);
            IsMouseEnter = !IsMouseOver && isNowMouseOver;
            IsMouseLeave = IsMouseOver && !isNowMouseOver;
            IsMouseOver = isNowMouseOver;
        }
        public virtual void Reset() { }
        public virtual void Start() { }
        public virtual void Stop() { }

        //public virtual void IsMouseDown(Point point)
        //{
        //    if (IsMouseOver)
        //    {
        //        IsMouseBottonDown = true;
        //    }
        //}

        //public virtual void MouseMove(Point point)
        //{
        //    var isMouseOver = Rectangle.Contains(point);

        //    if (isMouseOver)
        //    {
        //        Debug.WriteLine("Over " + ToString());
        //    }

        //    IsMouseEnter = !IsMouseOver && isMouseOver;
        //    IsMouseLeave = IsMouseOver && !isMouseOver;
        //    IsMouseOver = isMouseOver;
        //}

        //public virtual void MouseUp(Point point)
        //{
        //    if (IsMouseOver)
        //    {
        //        IsMouseBottonDown = false;
        //    }
        //}
    }
}