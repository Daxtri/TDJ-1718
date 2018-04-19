using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    class Camera
    {
        public Vector2 pos;
        Player pl;
        Matrix transform;

        public void Update()
        {
            this.pos = pl.Position;
        }

        public void Draw()
        {
            
        }
    }
}
