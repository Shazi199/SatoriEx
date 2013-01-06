using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SatoriEx.Sprites
{
    abstract class Sprite
    {
        protected Texture2D textureImage;
        protected int timeSinceLastFrame = 0;
        protected int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;
        protected Point frameSize;
        protected Point currentFrame;
        protected Point currentDirectionFrame;
        protected bool directionMove;
        protected Point sheetSize;
        protected Vector2 speed;
        protected Vector2 position;

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed)
            : this(textureImage, position, frameSize, currentFrame, sheetSize, speed,defaultMillisecondsPerFrame)
        {
        }
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.currentDirectionFrame = new Point(0, 0);
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;
        }

        public Vector2 getPosistion()
        {
            return position;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch,float layerDepth)
        {            
            spriteBatch.Draw(textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X,
                              currentFrame.Y * frameSize.Y,
                              frameSize.X, frameSize.Y),
                Color.White, 
                0,
                new Vector2(frameSize.X / 2, frameSize.Y / 2),
                1f, 
                SpriteEffects.None, 
                layerDepth);
        }
    }
}
