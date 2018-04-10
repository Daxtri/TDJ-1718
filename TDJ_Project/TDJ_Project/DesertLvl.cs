using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    class DesertLvl
    {
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public DesertLvl(Texture2D texture, Rectangle collision)
        {
            Texture = texture;
            Rectangle = collision;
        }

        public void Initialize()
        {
            //plat coord
        }

        public void Draw (SpriteBatch spriteBatch)
        {

        }
    }
}
