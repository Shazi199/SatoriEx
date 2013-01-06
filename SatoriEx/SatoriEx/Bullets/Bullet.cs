using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SatoriEx.Bullets.BulletControllers;

namespace SatoriEx.Bullets
{
    class Bullet
    {
        private static Texture2D textureImage;
        protected Vector2 position;
        protected Vector2 direction;
        protected Rectangle drawRectangle;
        private float collisionRadius;
        public int bulletTypeID = 0;
        public int time = 0;
        public int part = 0;
        public bool live = true;

        public Bullet(Vector2 position, Rectangle drawRectangle, Vector2 direction)
        {
            this.position = position;
            this.drawRectangle = drawRectangle;
            this.direction = direction;
        }
        public Bullet(Vector2 position, Rectangle drawRectangle,Vector2 direction,float collisionRadius)
        {
            this.position = position;
            this.drawRectangle = drawRectangle;
            this.direction = direction;
            this.collisionRadius = collisionRadius;
        }
        public static void loadTextureImage(Texture2D textureImage)
        {
            Bullet.textureImage = textureImage;
        }
        public Vector2 getPosition()
        {
            return position;
        }
        public Vector2 getDirection()
        {
            return direction;
        }
        public float getCollisionRadius()
        {
            return collisionRadius;
        }
        public void setDirection(Vector2 direction)
        {
            this.direction = direction;
        }
        public void setDirection(float angle, float speed)
        {
            angle = MathHelper.ToRadians(angle);
            direction = new Vector2((float)Math.Sin(angle)*speed, (float)Math.Cos(angle)*speed);
        }
        public void setDirection(Vector2 origin, Vector2 destination, float speed)
        {
            direction = (destination - origin) / (destination - origin).Length() * speed;
        }
        public void setDirection(Vector2 origin, Vector2 destination, float offsetAngle, float speed)
        {
            setDirection(origin, destination, speed);
            setDirection(MathHelper.ToDegrees((float)Math.Atan2(direction.X, direction.Y)) + offsetAngle, speed);
        }
        public void Update()
        {
            ++time;
            position += direction;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage,
                position,
                drawRectangle,
                Color.White,
                (float)Math.Atan2(-direction.X, direction.Y),
                new Vector2(drawRectangle.Width/2, drawRectangle.Height/2),
                1f,
                SpriteEffects.None,
                0.1f);
        }
    }
}
