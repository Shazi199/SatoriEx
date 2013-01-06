using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SatoriEx.Bullets.BulletGenerators;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SatoriEx.Bullets.Utility;

namespace SatoriEx.Bullets
{
    class BulletManager
    {
        List<Bullet> bulletList = new List<Bullet>();
        List<BulletGenerator> bulletGeneratorList = new List<BulletGenerator>();

        public void update()
        {
            foreach (Bullet b in bulletList)
            {
                b.Update();
                if (CollisionCheck.enemyBulletToPlayer(b, GameVariable.player))
                {
                    b.live = false;
                    GameVariable.audioManager.play("se_pldead00");
                }
                Vector2 position = b.getPosition();
                if (position.X < -20 || position.Y < -20 || position.X > 500 || position.Y > 500)
                    b.live = false;
            }
            foreach (BulletGenerator bg in bulletGeneratorList)
            {
                bg.update(bulletList);
            }
            for (int i = bulletList.Count - 1; i >= 0; --i)
            {
                if (bulletList[i].live == false)
                    bulletList.RemoveAt(i);
            }
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Bullet b in bulletList)
            {
                b.Draw(gameTime, spriteBatch);
            }
        }

        public List<Bullet> getBulletList()
        {
            return bulletList;
        }

        public List<BulletGenerator> getBulletGenerator()
        {
            return bulletGeneratorList;
        }
    }
}
