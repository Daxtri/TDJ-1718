using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    public class HUD
    {
        Player pl;
        Camera cam;
        public Texture2D HBar { get; set; }
        public Texture2D HBarpos { get; set; }
        //public Texture2D HBarneg { get; set; }
        Vector2 Position;

        int HP = 100;



        public HUD(Texture2D hbase, Texture2D hpos, Vector2 pos)
        {
            HBar = hbase;
            HBarpos = hpos;
           // HBarneg = hneg;
            Position = pos;
        }

        // load content on main

        public void Update(GameTime gameTime)
        {
            /*HBar back
              h bar pos overlay
              if (hp < 30)
              h bar neg overlay
             */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(HBar, new Rectangle( (int)cam.Pos.X +50 , (int)cam.Pos.Y + 50, 200, 20), Color.White);
            spriteBatch.Draw(HBarpos, new Rectangle((int)cam.Pos.X + 50, (int)cam.Pos.Y + 50, pl.HP *2, 20), Color.White); //* Player HP
            
            // spriteBatch.Draw(HBarneg, new Rectangle(50, 50, pl.HP, 20), Color.White);

        }

    }
}
