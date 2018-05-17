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

    }
}
