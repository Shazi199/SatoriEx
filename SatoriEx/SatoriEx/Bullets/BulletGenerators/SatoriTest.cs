using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SatoriEx.Bullets.BulletGenerators
{
    class SatoriTest : BulletGenerator
    {
        int time = 0;
        int plus = 0;
        int d = 30;
        public override void update(List<Bullet> bulletList)
        {
            ++time;

            if (time % 2 == 0)
            {
                plus += d;
                Bullet bullet;
                int p=(int)(Math.Sin(MathHelper.ToRadians(plus))*3);
                for (int i = 0; i < 8; ++i)
                {
                    bullet = new Bullet(GameVariable.enemy.getPosistion() + new Vector2(100 , 0), new Rectangle(96, 176, 16, 16), new Vector2(0f, 0f),3f);
                    bullet.setDirection(bullet.getPosition(), GameVariable.player.getPosistion(), -105 + i * 30 + p, 5);
                    bulletList.Add(bullet);
                    bullet = new Bullet(GameVariable.enemy.getPosistion() + new Vector2(-100, 0), new Rectangle(96, 176, 16, 16), new Vector2(0f, 0f),3f);
                    bullet.setDirection(bullet.getPosition(), GameVariable.player.getPosistion(), -105 + i * 30 + p, 5);
                    bulletList.Add(bullet);
                    bullet = new Bullet(GameVariable.enemy.getPosistion() + new Vector2(70, 40), new Rectangle(96, 176, 16, 16), new Vector2(0f, 0f), 3f);
                    bullet.setDirection(bullet.getPosition(), GameVariable.player.getPosistion(), -105 + i * 30 + p, 5);
                    bulletList.Add(bullet);
                    bullet = new Bullet(GameVariable.enemy.getPosistion() + new Vector2(-70, 40), new Rectangle(96, 176, 16, 16), new Vector2(0f, 0f), 3f);
                    bullet.setDirection(bullet.getPosition(), GameVariable.player.getPosistion(), -105 + i * 30 + p, 5);
                    bulletList.Add(bullet);
                }
                if (plus >= 90)
                    d = -30;
                if (plus <= -90)
                    d = 30;
            }
            if (time % 10 == 0)
            {
                Bullet bullet;
                for (int i = 0; i < 15; i++)
                {
                    bullet = new Bullet(GameVariable.enemy.getPosistion(), new Rectangle(16, 96, 16, 16), new Vector2(0f, 0f),2.5f);
                    bullet.setDirection(bullet.getPosition(), GameVariable.player.getPosistion(), -42 + i * 6, 2.5f);
                    bulletList.Add(bullet);
                }
            }
        }
    }
}
