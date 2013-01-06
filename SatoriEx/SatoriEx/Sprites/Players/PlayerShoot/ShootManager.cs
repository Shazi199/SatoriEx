using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SatoriEx.Bullets;
using SatoriEx.Bullets.Utility;

namespace SatoriEx.Sprites.Players.PlayerShoot
{
    class ShootManager
    {
        List<PlayerBullet> bulletList = new List<PlayerBullet>();

        public void update()
        {
            foreach (PlayerBullet b in bulletList)
            {
                b.Update();
                if (CollisionCheck.playerBulletToEnemy(b, GameVariable.enemy))
                    b.live = false;
                Vector2 position = b.getPosition();
                if (position.Y < -10)
                    b.live = false;
            }
            for (int i = bulletList.Count - 1; i >= 0; --i)
            {
                if (bulletList[i].live == false)
                    bulletList.RemoveAt(i);
            }
        }
        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (PlayerBullet b in bulletList)
            {
                b.draw(gameTime, spriteBatch);
            }
        }

        public List<PlayerBullet> getPlayerBulletList()
        {
            return bulletList;
        }
    }
}
