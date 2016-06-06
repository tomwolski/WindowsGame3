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
    class gun3: Obj
    {
       // public static gun1 Gun1;
        public gun3(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "gun3";
            alive = true;
            //Gun1 = this;
        }
        
        public override void move()
        {

            if (distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32 && alive == true)
            {
                //Player.bspd = Player.Standeredbspd;
                if (MainPlayer.ammo <= 10)
                {
                    MainPlayer.ammo = 100;
                }
                MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
               
                Bullet.gundamage = Bullet.gundamage *2;
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

 