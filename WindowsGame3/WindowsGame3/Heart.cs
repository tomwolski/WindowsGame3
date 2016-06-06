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
    class Heart:Obj
    {
        //public static Heart heart;
        public Heart(Vector2 pos)
            : base(pos)
        {
            
            position = pos;
            spriteName = "Heart";
            alive = true;
            solid = false;
            //heart = this;

        }

        public override void move()
        {
            if (!alive)
            {
                return;
            }


            if (distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 25 && alive == true)
            {
                MainPlayer.Player.hp += 10;
                alive = false;
            }

            base.move();
        }

        public static float distance(float x1, float y1, float x2, float y2)
        {
            float xRectangle = (x1 - x2) * (x1 - x2);
            float yRectangle = (y1 - y2) * (y1 - y2);
            double zRectangle = xRectangle + yRectangle;
            float dist = (float)Math.Sqrt(zRectangle);
            return dist;

        }

    
    }

}
