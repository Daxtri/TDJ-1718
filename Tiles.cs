using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace TDJ_projects
{
    public class Tiles
    {
        public Texture2D texture;

        public Rectangle Rectangle { get; set; }
        public static ContentManager Content { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }
    }

    public class NotCollisionTiles : Tiles
    {
        public NotCollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }

    public class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }
}
