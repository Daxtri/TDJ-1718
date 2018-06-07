using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    public static class Collider
    {
        public static bool CollisionCheck(this Rectangle rec1, Rectangle rec2)
        {
            if (rec1.Intersects(rec2)) { return true; }
            else return false;
        }

        public static bool SidesCheck(this Rectangle rec1, Rectangle rec2)
        {
            if (rec1.Right >= rec2.Left - 1 || rec1.Left <= rec2.Right + 1 ||
                rec1.Bottom >= rec2.Top - 1|| rec1.Top <= rec2.Bottom + 1)
                return true;
            else return false;
        }

        public static int SidesColl(this Rectangle rec1, Rectangle rec2)
        {
            if (rec1.Right >= rec2.Left - 1) return rec1.X = rec2.X - 1 -rec1.Width;
            if (rec1.Left <= rec2.Right) return rec1.X = rec2.X + rec2.Width+1;
            if (rec1.Bottom >= rec2.Top) return rec1.Y = rec2.Y - 1;
            if (rec1.Top <= rec2.Bottom) return rec1.Y = rec2.Y + rec2.Height + 1;
            else return 0;


        }
    }
}
