using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SatoriEx.Sprites.Players;
using SatoriEx.Sprites.Enemys;

namespace SatoriEx.Bullets.Utility
{
    class CollisionCheck
    {
        public static bool enemyBulletToPlayer(Bullet bullet, Player player)
        {
            float distance = (bullet.getPosition() - player.getPosistion()).Length();
            if (distance < (bullet.getCollisionRadius() + player.getCollisionRadius()))
            {
                return true;
            }
            return false;
        }

        public static bool playerBulletToEnemy(PlayerBullet playerBullet, Enemy enemy)
        {
            return playerBullet.getCollisionRectangle().Intersects(enemy.getCollisionRectangle());
        }
    }
}
