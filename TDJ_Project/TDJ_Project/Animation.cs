using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    class Animation
    {
        public Rectangle source;
        Player pl ;

        public int maxCols = 6;
        public int maxRows = 3;
        public int currentCol = 0;
        public int currentRow = 0;
        public int frameWidth = 100;
        public int frameHeight = 100;
        // attack
        public int flameWidth = 560;
        public int flameHeight = 145;

        public void Anim(Vector2 pos,GameTime gameTime)
        {
            this.source = new Rectangle(currentCol * frameWidth, currentRow * frameHeight, frameWidth, frameHeight);
           

            if (pl.ismoving == false && pl.backwards == false)
            {
                currentCol = 0;
                currentRow = 0;
            }

            if (pl.ismoving == false && pl.backwards == true)
            {
                currentCol = 1;
                currentRow = 0;
            }

            if (pl.ismoving == true && pl.backwards==false)
            {
                currentRow = 1;
                currentCol++;
                if(currentCol == maxCols)
                {
                    currentCol = 0;
                }
            }else if(pl.ismoving==true && pl.backwards == true)
            {
                currentRow = 2;
                currentCol++;
                if (currentCol == maxCols)
                {
                    currentCol = 0;
                }
            }
        }

        public void FX (Vector2 pos, GameTime gameTime)
        {
            this.source = new Rectangle(currentCol * flameWidth, currentRow * flameHeight, flameWidth, flameHeight);

            if (pl.isattacking == true && pl.backwards == false)
            {
                currentRow = 0;
                while (currentCol < 8)
                {
                    currentCol++;
                    pos.X++;
                }
            }
            else if (pl.isattacking == true && pl.backwards == true)
            {
                currentRow = 1;
                while (currentCol < 8) { 
                    currentCol++;
                    pos.X--;
                }
            }
        }

    }
}
