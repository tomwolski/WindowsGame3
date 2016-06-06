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

namespace WindowsGame3
{

    class View
    {
         static Song music2;

        public static void Draw(SpriteBatch spritebatch,GameTime gameTime)
        {

            if (Game1.game == "game")
            {



                spritebatch.DrawString(Game1.font, "Bullets shot:" + MainPlayer.ammo, Vector2.Zero, Color.White);
                spritebatch.DrawString(Game1.font, "Fire rate:" + MainPlayer.rate, new Vector2(0, Game1.font.LineSpacing), Color.White);
                spritebatch.DrawString(Game1.font, "health:" + MainPlayer.Player.hp + "/" + MainPlayer.maxhp, new Vector2(0, Game1.font.LineSpacing * 2), Color.White);
                spritebatch.DrawString(Game1.font, "time:" + (Game1.timer) * .001, new Vector2(0, Game1.font.LineSpacing * 3), Color.White);
                spritebatch.DrawString(Game1.font, "KillCount:" + Game1.KillCount, new Vector2(0, Game1.font.LineSpacing * 4), Color.White);

                spritebatch.DrawString(Game1.font, "Roration:" + MainPlayer.Player.rotation, new Vector2(0, Game1.font.LineSpacing * 5), Color.White);
                spritebatch.DrawString(Game1.font, "Damage:" + Bullet.gundamage, new Vector2(0, Game1.font.LineSpacing * 6), Color.White);


            }
        }

    }
}
