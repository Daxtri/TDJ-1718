using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ_Project
{
    public class Player
    {

        // acessors
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }
        private Vector2 Position;
        private Vector2 Velocity ;
        public int HP = 100;
        public bool ismoving = false, isattacking = false, backwards = false, die = false;
        Animation animation;

        public Player ( Texture2D texture,Rectangle rec, Vector2 pos, Vector2 vel)
        {
            Texture = texture;
            Rectangle = rec;
            Position = pos;
            Velocity = vel;
        }

        public void Update (GameTime gametime)
        {
            // atualizar com hitboxes e animaçao
            //gravidade -- mudar para colidir com as plataformas

            animation = new Animation();
            animation.FX(this.Position, gametime);
            animation.Anim(this.Position, gametime);
            if (HP <= 0) die = true;
        }

        public void Coll(Rectangle newtiles)
        {
            if (this.Rectangle.CollisionCheck(newtiles)==true)
            {
                Position.Y = newtiles.Y - newtiles.Height - 1;
                Velocity.Y = 0;
            }
        }

        public void Move(KeyboardState keyboardState)
        {
            //inicializar posição
            Position = Vector2.Zero;

            //alterar posiçao com input
            // force a timer on space so u can't spam jump
            // create timer class for jumps/attacks
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Position.Y = -3;
                Velocity.Y = 3f;
                ismoving = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position.X = -3;
                Velocity.X = 1f;
                ismoving = true;
                backwards = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.X = 3 ;
                Velocity.X = 1f;
                ismoving = true;
                backwards = false;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                
                Position.Y = 3f;
                Velocity.Y = 1f;
                ismoving = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                isattacking = true;
            }
            else isattacking = false;

            Rectangle = new Rectangle
               (Rectangle.X + (int)(Position.X * Velocity.X),
               Rectangle.Y + (int)(Position.Y * Velocity.Y),
               Rectangle.Width, Rectangle.Height);

        }

        public void Draw (SpriteBatch spriteBtach)
        {
            spriteBtach.Draw(Texture, animation.source, Color.White);
        }
    }
}
