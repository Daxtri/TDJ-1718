using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TDJ_Project
{
    public class Enemy
    {
        private float deltaTime = 0f;
        
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Direction { get; set; }
        public bool Visible { get; set; }
        

        public Enemy(Texture2D texture, Rectangle rect, Vector2 velocity, Vector2 direction, bool visible)
        {
            Texture = texture;
            Rectangle = rect;
            Velocity = velocity;
            Direction = direction;
            Visible = visible;

        }

        public void Move(GameTime gameTime)
        {
            Random random = new Random();

            GameTime game = gameTime;

            int width = 800;
            int height = 800;
            Vector2 deadDirection;
            Vector2 deadVelocity;
            Rectangle deadRectangle;

            deadDirection = Direction;
            deadVelocity = Velocity;
            deadRectangle = Rectangle;
            //int myRandom = random.Next(0, 2);

            deltaTime += (float)game.ElapsedGameTime.TotalSeconds;


            if (deltaTime < 5)
            {
                deadDirection.X = 1;
            }
            if(deltaTime > 5)
            {
                deadDirection.X = -1;
                if(deltaTime > 10)
                {
                    deltaTime = 0f;
                }
            }


            deadRectangle = new Rectangle(deadRectangle.X + (int)(deadDirection.X * deadVelocity.X), Rectangle.Y + (int)(deadDirection.Y * deadVelocity.Y), deadRectangle.Width, deadRectangle.Height);

            System.Diagnostics.Debug.WriteLine("GameTime: " + (float)game.ElapsedGameTime.TotalSeconds);
            System.Diagnostics.Debug.WriteLine("DeltaTime: " + deltaTime);
            //System.Diagnostics.Debug.WriteLine("Random. " + myRandom);

            /* 
            if (deltaTime < 4)
            {



                    if (deadRectangle.X <= 0)
                    {
                        deadDirection.X = 1;
                    }
                    if (deadRectangle.X >= width - deadRectangle.Width)
                    {
                        deadDirection.X = -1;
                    }
                    if (deadRectangle.Y <= 0)
                    {
                        deadDirection.Y = 1;
                    }
                    if (deadRectangle.Y >= height - deadRectangle.Height)
                    {
                        deadDirection.Y = -1;
                    }
                    deadRectangle.X += (int)deadDirection.X * (int)deadVelocity.X;
                    deadRectangle.Y += (int)deadDirection.Y * (int)deadVelocity.Y;

                    //Direction = Vector2.One;


                Rectangle = new Rectangle(
                    (int)deadDirection.X * (int)deadVelocity.X,
                    (int)deadDirection.Y * (int)deadVelocity.Y,
                    Rectangle.Width,
                    Rectangle.Height
                );
            }
            */


            

            Rectangle = deadRectangle;



        }
    }
}
        