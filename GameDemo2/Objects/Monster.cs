using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitTheMole.Properties;

namespace HitTheMole.Objects
{
    class Monster : GameUnit
    {
        public Monster(int x, int y, int width, int height)
            : this(new Point(x,y), new Size(width, height) )
        {
        }

        public Monster(Point position, Size size) : base(position, size)
        {
            Image = Resources.GodlikeMonster;
            ImageHit = Resources.GodlikeMonsterHit;
            _spawntime = 1000;
        }

        protected override void ReactOnSlap()
        {
            Game.Score += 5;
        }

        protected override void ReactOnMiss()
        {
            Game.Tries--;
        }
    }
}
