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
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public bool ismoving = false, isattacking = false;
        

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
            while (ismoving == true)
            {
                //correr loop animaçao
            }

            if (isattacking == true)
            {
                //correr loop animaçao
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
                Position = new Vector2(Position.X, -7);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position = new Vector2(-2, Position.Y);
                //ismoving = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position = new Vector2(2, Position.Y);
                //ismoving = true;
            }

            //gravidade -- mudar para colidir com as plataformas
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                //if (Position.Y <900)
                Position = new Vector2(Position.X, 3);
            }

            Rectangle = new Rectangle
                (Rectangle.X + (int)(Position.X * Velocity.X),
                Rectangle.Y + (int)(Position.Y * Velocity.Y),
                Rectangle.Width,Rectangle.Height);
        }

        public void Draw (SpriteBatch spriteBtach)
        {
            spriteBtach.Draw(Texture, Rectangle, Color.White);
        }
    }
}
