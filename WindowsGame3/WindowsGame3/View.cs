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
        /**/
        /*
      Draw

        NAME

                Draw - A static function that will display to the MainPlayer some basic attributes.

        SYNOPSIS
             spritebatch - Enables a group of sprites to be drawn the screen
             gameTime - the amount of time the game as been running for

        DESCRIPTION

     
                This function is called when a player starts the game changing the game state to "game", otherwise it will not be displayed.
                It takes the font that has been specified in game1 and displays the given string followed by the item that we want to display
                on the screen. Each different string is placed at the top left of the screen and is then lowered down by one line spacing every time.
                in this case we will see the display as:
                Bullets shot: XXX
                Fire rate: XXX
                health: XXX / XXX
                time: XXX
                KillCount: XXX
                Damage: XXX
                Of course the XXX will be represented by a different number. Each different display will also have a color associated with it changing
                the font color.
     

        AUTHOR

                Thomas Wolski 

        DATE

                9:50pm 8/9/2016

        */
        /**/

        public static void Draw(SpriteBatch spritebatch,GameTime gameTime)
        {

            if (Game1.game == "game")
            {

                spritebatch.DrawString(Game1.font, "Bullets shot:" + MainPlayer.ammo, Vector2.Zero, Color.Black);
                spritebatch.DrawString(Game1.font, "Fire rate:" + MainPlayer.rate, new Vector2(0, Game1.font.LineSpacing), Color.Black);
                spritebatch.DrawString(Game1.font, "health:" + MainPlayer.Player.hp + "/" + MainPlayer.maxhp, new Vector2(0, Game1.font.LineSpacing * 2), Color.Red);
                spritebatch.DrawString(Game1.font, "time:" + (Game1.timer) * .001, new Vector2(0, Game1.font.LineSpacing * 3), Color.Blue);
                spritebatch.DrawString(Game1.font, "KillCount:" + Game1.KillCount, new Vector2(0, Game1.font.LineSpacing * 4), Color.Yellow);
                spritebatch.DrawString(Game1.font, "Damage:" + Bullet.gundamage, new Vector2(0, Game1.font.LineSpacing * 5), Color.Red);


            }
        }

    }
}
