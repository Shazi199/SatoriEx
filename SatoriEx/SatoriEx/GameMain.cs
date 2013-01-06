using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SatoriEx.Sprites;
using SatoriEx.Backgrounds;
using SatoriEx.Audio;

namespace SatoriEx
{
    public class GameMain : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteManager spriteManager;
        Background bg;
        Camera camera;

        AudioManager audioManager;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
        }

        protected override void Initialize()
        {
            spriteManager = new SpriteManager(this);
            audioManager = new AudioManager();
            GameVariable.audioManager = audioManager;
            IsMouseVisible = true;
            Viewport vp = GraphicsDevice.Viewport;
            vp.Bounds = new Rectangle(32, 16, 384, 448);
            camera = new Camera(this, new Vector3(0, -2.5f, 4), Vector3.Zero, Vector3.Up, vp);
            bg = new Background(this, camera);
            Components.Add(camera);
            Components.Add(bg);
            Components.Add(spriteManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            audioManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);            
            base.Draw(gameTime);
        }
    }
}
