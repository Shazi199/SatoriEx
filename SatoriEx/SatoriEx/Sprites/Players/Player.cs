using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SatoriEx.Sprites.Players.PlayerShoot;
using SatoriEx.Bullets;

namespace SatoriEx.Sprites.Players
{
    class Player : Sprite
    {
        private float collisionRadius=3f;
        private bool slow = false;
        private bool shoot = false;
        private int power = 0;
        private Texture2D otherTexture;
        private int time = 0;
        ShootManager shootManager;

        public Player(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, currentFrame, sheetSize, speed)
        {
            init();
        }
        public Player(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, currentFrame, sheetSize, speed, millisecondsPerFrame)
        {
            init();
        }
        public void init()
        {
            shootManager = new ShootManager();
        }
        public void loadOtherTexture(Texture2D otherTexture)
        {
            this.otherTexture = otherTexture;
        }
        public float getCollisionRadius()
        {
            return collisionRadius;
        }
        public Vector2 direction
        {
            get
            {
                slow = false;
                shoot = false;
                Vector2 inputDirection = Vector2.Zero;
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (keyboardState.IsKeyDown(Keys.Right))
                    inputDirection.X += 1;
                if (keyboardState.IsKeyDown(Keys.Up))
                    inputDirection.Y -= 1;
                if (keyboardState.IsKeyDown(Keys.Down))
                    inputDirection.Y += 1;
                if (keyboardState.IsKeyDown(Keys.Z))
                    shoot = true;
                if (keyboardState.IsKeyDown(Keys.LeftShift))
                {
                    inputDirection.X /= 2;
                    inputDirection.Y /= 2;
                    slow = true;
                }
                return inputDirection * speed;
            }
        }
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            ++time;
            position += direction;
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter))
                power++;
            if (position.X < 41)
                position.X = 41;
            if (position.Y < 49)
                position.Y = 49;
            if (position.X > 439 - frameSize.X)
            {
                position.X = 439 - frameSize.X;
            }
            if (position.Y > 497 - frameSize.Y)
            {
                position.Y = 497 - frameSize.Y;
            }
            if (direction.X == 0)
            {
                sheetSize = new Point(8, 1);
                currentDirectionFrame.X = 0;
                directionMove = false;
                millisecondsPerFrame = 66;
                base.Update(gameTime, clientBounds);
            }
            else
            {
                directionMove = true;
                millisecondsPerFrame = 50;
                if (direction.X < 0)
                {
                    sheetSize = new Point(8, 2);
                    currentDirectionFrame.Y = 1;
                    directionUpdate(gameTime, clientBounds);
                }
                if (direction.X > 0)
                {
                    sheetSize = new Point(8, 3);
                    currentDirectionFrame.Y = 2;
                    directionUpdate(gameTime, clientBounds);
                }
            }
            shootUpdate();
            shootManager.update();
        }
        public void directionUpdate(GameTime gameTime, Rectangle clientBounds)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentDirectionFrame.X;
                if (currentDirectionFrame.X >= sheetSize.X)
                    currentDirectionFrame.X = 3;
                return;
            }
        }
        public void shootUpdate()
        {
            if (shoot)
            {
                if (time % 4 == 0)
                {
                    PlayerBullet b = new PlayerBullet(position+new Vector2(-10,18), new Rectangle(0, 176, 63, 16),new Vector2(0,-25), new Rectangle(0, 0, 16, 64));
                    shootManager.getPlayerBulletList().Add(b);
                    b = new PlayerBullet(position + new Vector2(10, 18), new Rectangle(0, 176, 63, 16), new Vector2(0, -25), new Rectangle(0, 0, 16, 64));
                    shootManager.getPlayerBulletList().Add(b);
                    GameVariable.audioManager.play("se_plst00");
                }
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            childrenDraw(gameTime, spriteBatch,power/100);
            shootManager.draw(gameTime, spriteBatch);
            if (directionMove)
            {
                directionDraw(gameTime, spriteBatch);
                slowDraw(gameTime, spriteBatch);
                return;
            }
            base.Draw(gameTime, spriteBatch,0.5f);
            slowDraw(gameTime, spriteBatch);
        }
        public void directionDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage,
                position,
                new Rectangle(currentDirectionFrame.X * frameSize.X,
                              currentDirectionFrame.Y * frameSize.Y,
                              frameSize.X, frameSize.Y),
                Color.White,
                0,
                new Vector2(frameSize.X / 2, frameSize.Y / 2),
                1f,
                SpriteEffects.None,
                0);
        }
        public void slowDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (slow)
            {
                spriteBatch.Draw(otherTexture,
                    position,
                    new Rectangle(0, 16, 64, 64),
                    Color.White,
                    time / 25f,
                    new Vector2(32, 32),
                    1f,
                    SpriteEffects.None,
                    0.001f);
                spriteBatch.Draw(otherTexture,
                    position,
                    new Rectangle(0, 16, 64, 64),
                    Color.White,
                    -time / 25f,
                    new Vector2(32, 32),
                    1f,
                    SpriteEffects.None,
                    0.001f);
            }
        }
        public void childrenDraw(GameTime gameTime, SpriteBatch spriteBatch, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int distance = 60;
                if (slow)
                    distance = 25;
                spriteBatch.Draw(textureImage,
                    position + new Vector2((float)Math.Cos(time / 10f + MathHelper.Pi / amount * i * 2) * distance, (float)Math.Sin(time / 10f + MathHelper.Pi / amount * i * 2) * distance),
                    new Rectangle(0, 192, 32, 32),
                    Color.White,
                    -time / 10f,
                    new Vector2(16, 16),
                    1f,
                    SpriteEffects.None,
                    0.0001f);
                spriteBatch.Draw(textureImage,
                    position + new Vector2((float)Math.Cos(time / 10f + MathHelper.Pi / amount * i*2) * distance, (float)Math.Sin(time / 10f + MathHelper.Pi / amount * i*2) * distance),
                    new Rectangle(96, 144, 16, 16),
                    Color.White,
                    time / 10f,
                    new Vector2(8, 8),
                    1f,
                    SpriteEffects.None,
                    0.0001f);
            }
        }
    }
}
