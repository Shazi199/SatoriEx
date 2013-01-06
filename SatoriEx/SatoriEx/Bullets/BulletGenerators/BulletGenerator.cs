using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoriEx.Bullets.BulletGenerators
{
    abstract class BulletGenerator
    {
        public abstract void update(List<Bullet> bulletList);
    }
}
