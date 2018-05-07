﻿using System;
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
    public class ScreenManager
    {
        #region Variaveis
        private static ScreenManager instance;
        GameScreen currentScreen;
        GameScreen newScreen;

        ContentManager content;

        //Quais os ecrãs que abrem/fechem e a que ordem
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        Vector2 dimensions;

        bool transition;

        FadeAnimation fade = new FadeAnimation();

        Texture2D fadeTexture;

        InputManager inputManager;

        #endregion

        #region Propiedades

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Metodos

        public void AddScreen(GameScreen screen, InputManager inputManager)
        {
            transition = true;
            newScreen = screen;
            fade.IsActive = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
            this.inputManager = inputManager;
        }

        public void Initialize()
        {
            currentScreen = new SplashScreen();
            fade = new FadeAnimation();
            inputManager = new InputManager();

        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content, inputManager);

            fadeTexture = content.Load<Texture2D>("blyat");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.X;
        }
        public void Update(GameTime gameTime)
        {
            if (!transition)
                currentScreen.Update(gameTime);
            else
                Transition(gameTime);

            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);

            if (transition)
                fade.Draw(spriteBatch);
        }

        #endregion

        private void Transition(GameTime gameTime)
        {
            fade.Update(gameTime);
            if(fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f)
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content, this.inputManager);
            }
            else if( fade.Alpha == 0.0f)
            {
                transition = false;
                fade.IsActive = false;
            }
        }

    }
}
