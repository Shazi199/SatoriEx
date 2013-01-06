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


namespace SatoriEx.Backgrounds
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Background : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Camera camera;
        VertexPositionTexture[] verts;
        VertexBuffer vertexBuffer;
        BasicEffect effect;
        Texture2D textureA;
        Texture2D textureB;
        SpriteFont font;

        public Background(Game game,Camera camera)
            : base(game)
        {
            this.camera = camera;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            verts = new VertexPositionTexture[4];
            verts[0] = new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0));
            verts[1] = new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 0));
            verts[2] = new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(0, 1));
            verts[3] = new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, 1));
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionTexture), verts.Length, BufferUsage.None);
            effect = new BasicEffect(GraphicsDevice);
            textureA = Game.Content.Load<Texture2D>(@"Images/stage04a");
            textureB = Game.Content.Load<Texture2D>(@"Images/stage04b");
            font = Game.Content.Load<SpriteFont>(@"Images/Font");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Viewport vp = GraphicsDevice.Viewport;
            GraphicsDevice.Viewport = camera.viewport;
            
            effect.World = Matrix.CreateTranslation(new Vector3(3, -16, 0)) * Matrix.CreateFromYawPitchRoll(0, 0, MathHelper.Pi);
            effect.View = camera.view;
            effect.Projection = camera.projection;
            effect.Texture = textureB;
            effect.TextureEnabled = true;
            for (int i = 0; i < 2; ++i)
            {
                effect.World *= Matrix.CreateTranslation(new Vector3(2, 0, 0));
                for (int j = 0; j < 16; ++j)
                {
                    effect.World *= Matrix.CreateTranslation(new Vector3(0, -2, 0));
                    foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, verts, 0, 2);
                    }
                }
                effect.World *= Matrix.CreateTranslation(new Vector3(0, 32, 0));
            }
            effect.Texture = textureA;
            effect.World = Matrix.CreateTranslation(new Vector3(-1f, -16, 0)) * Matrix.CreateFromYawPitchRoll(0, 0, MathHelper.Pi);
            for (int i = 0; i < 4; ++i)
            {
                effect.World *= Matrix.CreateTranslation(new Vector3(2, 0, 0));
                for (int j = 0; j < 16; ++j)
                {
                    effect.World *= Matrix.CreateTranslation(new Vector3(0, -2, 0));
                    foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, verts, 0, 2);
                    }
                }
                effect.World *= Matrix.CreateTranslation(new Vector3(0, 32, 0));
            }
            effect.World = Matrix.CreateTranslation(new Vector3(11f, -16, 0)) * Matrix.CreateFromYawPitchRoll(0, 0, MathHelper.Pi);
            for (int i = 0; i < 4; ++i)
            {
                effect.World *= Matrix.CreateTranslation(new Vector3(2, 0, 0));
                for (int j = 0; j < 16; ++j)
                {
                    effect.World *= Matrix.CreateTranslation(new Vector3(0, -2, 0));
                    foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, verts, 0, 2);
                    }
                }
                effect.World *= Matrix.CreateTranslation(new Vector3(0, 32, 0));
            }
            GraphicsDevice.Viewport = vp;

            base.Draw(gameTime);
        }
    }
}
