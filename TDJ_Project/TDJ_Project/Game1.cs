using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TDJ_Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D back;
        Player pl;
        Map map = new Map();
        Camera camera;
        int previousScroll;
        float zoomIncrement = 0.1f;

        Texture2D backgroundTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pl = new Player(new Texture2D(graphics.GraphicsDevice, 70, 70), new Rectangle(100, 500, 70, 70), new Vector2(1,1), new Vector2(1,1));
            Tiles.Content = Content;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pl.Texture =Content.Load<Texture2D>("sprite-test"); //change later
            back = Content.Load<Texture2D>("Paper_Mockup4");
            camera = new Camera(GraphicsDevice.Viewport, map.Width, map.Height, 1f);

            #region Map

            map.Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,22,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,15,16,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,16,0,4,5,5,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,15,15,16,0,0,0,0,0,12,9,13,0,0,0,0,0,0,0,0,0,0,0,30,0,0,0,0,0,0,0,0,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,26,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,19,0,0,1,2,2,2,3,0,0,0,0,0,0,0,0,0,17,0,0,28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,7,8,6,0,0,0,0,0,0,19,0,0,0,0,0,0,0},
                {0,0,0,0,0,23,23,0,22,4,5,5,5,6,21,0,0,0,0,0,0,0,0,0,0,0,24,24,0,0,0,0,0,0,0,0,0,0,0,0,27,0,0,0,0,4,5,5,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {2,2,2,2,2,2,2,2,7,8,5,5,5,10,11,2,2,2,3,0,0,1,2,2,2,2,2,2,2,2,2,3,0,0,2,0,2,0,1,2,2,2,2,2,7,8,5,5,5,10,11,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,0,0,4,5,5,5,5,5,5,5,5,5,6,0,0,5,0,5,0,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            }, 65);

            #endregion

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Estado to teclado
            KeyboardState keyboardState = Keyboard.GetState();
            
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                pl.Coll(tile.Rectangle);
            }

            pl.Move(keyboardState);
            pl.Update(gameTime);
            

            MouseState mouseStateCurrent = Mouse.GetState();


            if (mouseStateCurrent.ScrollWheelValue > previousScroll)
                camera.Zoom += zoomIncrement;
            else if (mouseStateCurrent.ScrollWheelValue < previousScroll)
                camera.Zoom -= zoomIncrement;

            previousScroll = mouseStateCurrent.ScrollWheelValue;

            // Move the camera when the arrow keys are pressed
            Vector2 movement = Vector2.Zero;
            Viewport vp = graphics.GraphicsDevice.Viewport;

            if (keyboardState.IsKeyDown(Keys.Left))
                movement.X--;
            if (keyboardState.IsKeyDown(Keys.Right))
                movement.X++;
            if (keyboardState.IsKeyDown(Keys.Up))
                movement.Y--;
            if (keyboardState.IsKeyDown(Keys.Down))
                movement.Y++;



            camera.Pos += movement * 20;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightYellow);

            spriteBatch.Begin();
            spriteBatch.Draw(back, Vector2.Zero, Color.LightGoldenrodYellow);
           

            /*spriteBatch.Begin(SpriteSortMode.BackToFront,
                     null, null, null, null, null,
                     camera.GetTransformation());

            spriteBatch.Draw(backgroundTexture,
               new Rectangle(0, 0, map.Width, map.Height),
               null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);*/

            map.Draw(spriteBatch);
            pl.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
