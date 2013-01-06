using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SatoriEx.Bullets;
using SatoriEx.Bullets.BulletGenerators;

namespace SatoriEx.Sprites.Enemys
{
    class Enemy : Sprite
    {
        int part = 0;
        bool shooting = false;
        int hp = 10000;
        private Rectangle collisionRectangle = new Rectangle(0, 0, 32, 2);

        public Enemy(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, currentFrame, sheetSize, speed)
        {
        }
        public Enemy(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, currentFrame, sheetSize, speed, millisecondsPerFrame)
        {
        }
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            if (part == 0 && shooting == false)
            {
                shooting = true;
                ++part;
                //GameVariable.bulletManager.getBulletGenerator().Add(new SatoriTest());
            }
            base.Update(gameTime, clientBounds);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch,0.2f);
        }

        public Rectangle getCollisionRectangle()
        {
            collisionRectangle.X = (int)(this.position.X - collisionRectangle.Width / 2);
            collisionRectangle.Y = (int)(this.position.Y - collisionRectangle.Height / 2);
            return collisionRectangle;
        }
    }
}
