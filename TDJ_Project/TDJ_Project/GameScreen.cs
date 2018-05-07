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
    public class GameScreen
    {
        protected ContentManager content;
        protected InputManager inputManager;

        public virtual void LoadContent(ContentManager Content, InputManager inputManager)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            inputManager = new InputManager();
            this.inputManager = inputManager;
        }
        public virtual void UnloadContent()
        {
            content.Unload();
            inputManager = null;
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
