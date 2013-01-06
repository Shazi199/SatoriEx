using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SatoriEx.Bullets
{
    class PlayerBullet : Bullet
    {
        private static Texture2D otherTexture;
        private Rectangle collisionRectangle;
        public PlayerBullet(Vector2 position, Rectangle drawRectangle, Vector2 direction, Rectangle collisionRectangle):
            base(position,drawRectangle,direction)
        {
            this.collisionRectangle = collisionRectangle;
        }
        public Rectangle getCollisionRectangle()
        {
            collisionRectangle.X = (int)(this.getPosition().X - collisionRectangle.Width / 2);
            collisionRectangle.Y = (int)(this.getPosition().Y - collisionRectangle.Height / 2);
            return collisionRectangle;
        }
        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(otherTexture,
                position,
                drawRectangle,
                Color.White,
                MathHelper.ToRadians(-90),
                new Vector2(drawRectangle.Width/2, drawRectangle.Height/2),
                1f,
                SpriteEffects.None,
                0.09f
                );
        }

        public static void loadOtherTexture(Texture2D otherTexture)
        {
            PlayerBullet.otherTexture = otherTexture;
        }
    }
}
