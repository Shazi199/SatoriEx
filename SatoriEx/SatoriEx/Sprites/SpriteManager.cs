using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SatoriEx.Sprites.Enemys;
using SatoriEx.Sprites.Players;
using SatoriEx.Backgrounds.UI;
using SatoriEx.Bullets;


namespace SatoriEx.Sprites
{
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Player player;
        Enemy enemy;
        BulletManager bulletManager;
        Front ft;

        public SpriteManager(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(Game.Content.Load<Texture2D>(@"Images/pl00"), new Vector2(228,374), new Point(32, 48), new Point(0, 0), new Point(8, 1),new Vector2(4.5f,4.5f),66);
            player.loadOtherTexture(Game.Content.Load<Texture2D>(@"Images/etama2"));
            enemy = new Enemy(Game.Content.Load<Texture2D>(@"Images/stg4enm"), new Vector2(228,150), new Point(48, 64), new Point(0, 0), new Point(4, 2), Vector2.Zero, 120);
            Bullet.loadTextureImage(Game.Content.Load<Texture2D>(@"Images/etama"));
            PlayerBullet.loadOtherTexture(Game.Content.Load<Texture2D>(@"Images/pl00"));
            ft=new Front(Game.Content.Load<Texture2D>(@"Images/front00"));
            bulletManager=new BulletManager();

            GameVariable.player = player;
            GameVariable.enemy = enemy;
            GameVariable.bulletManager = bulletManager;
            GameVariable.audioManager.playBGM("satoribgm");
        }

        public override void Update(GameTime gameTime)
        {
            enemy.Update(gameTime, Game.Window.ClientBounds);
            player.Update(gameTime, Game.Window.ClientBounds);
            bulletManager.update();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            enemy.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
            bulletManager.draw(gameTime, spriteBatch);
            ft.draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
