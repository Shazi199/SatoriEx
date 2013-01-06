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
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }
        Vector3 pos = new Vector3(0, -2.5f, 4);
        Vector3 tar = new Vector3(0, 0, 0);
        float move = 0f;
        float plus = 0.3f;
        public Viewport viewport { get; set; }

        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up, Viewport viewport)
            : base(game)
        {
            view = Matrix.CreateLookAt(pos, target, up);
            this.pos = pos;
            this.tar = target;
            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)viewport.Width /
                (float)viewport.Height,
                1, 100);

            this.viewport = viewport;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            targetUpdate();
            
            view = Matrix.CreateLookAt(pos, tar, Vector3.Up);

            base.Update(gameTime);
        }

        public void targetUpdate()
        {
            move += plus;
            tar.X=2.5f * (float)Math.Sin(MathHelper.ToRadians(move));
            float Y = 25 - tar.X * tar.X;
            tar.Y = -(float)Math.Sqrt(Y) + 5;
            if (move >= 90 || move <= -90)
                plus *= -1;
        }
    }
}
