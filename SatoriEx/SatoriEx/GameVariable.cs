using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SatoriEx.Sprites.Players;
using SatoriEx.Sprites.Enemys;
using SatoriEx.Bullets;
using SatoriEx.Audio;

namespace SatoriEx
{
    class GameVariable
    {
        public static Player player;
        public static Enemy enemy;
        public static BulletManager bulletManager;
        public static AudioManager audioManager;
    }
}
