using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SatoriEx.Backgrounds.UI
{
    class Front
    {
        Texture2D textureImage;

        public Front(Texture2D textureImage)
        {
            this.textureImage = textureImage;
        }
        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, new Vector2(0, 0), new Rectangle(0, 0, 32, 480), Color.White,0,Vector2.Zero,1f,SpriteEffects.None,0f);
            spriteBatch.Draw(textureImage, new Vector2(32, 0), new Rectangle(0, 480, 384, 16), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(32, 464), new Rectangle(0, 496, 384, 16), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(416, 0), new Rectangle(32, 0, 224, 480), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(427, 46), new Rectangle(256, 0, 80, 18), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(427, 70), new Rectangle(256, 18, 80, 17), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(427, 101), new Rectangle(256, 35, 80, 21), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(427, 125), new Rectangle(256, 57, 80, 18), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(427, 150), new Rectangle(336, 0, 80, 18), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(487, 24), new Rectangle(256, 368, 80, 16), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            spriteBatch.Draw(textureImage, new Vector2(522, 102), new Rectangle(464, 0, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(534, 102), new Rectangle(480, 0, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(546, 102), new Rectangle(496, 0, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(558, 102), new Rectangle(464, 20, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(570, 102), new Rectangle(480, 20, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureImage, new Vector2(582, 102), new Rectangle(496, 20, 16, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
