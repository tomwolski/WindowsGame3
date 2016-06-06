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
    class Gun4ShootFive: Obj
    {
       // public static gun1 Gun1;
        public Gun4ShootFive(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "5shot";
            alive = true;
            //Gun1 = this;
        }
        
        public override void move()
        {

            if (distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32 && alive == true)
            {
                MainPlayer.bspd = MainPlayer.Standeredbspd;
                MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
                MainPlayer.ammo = MainPlayer.Standeredammo;
                MainPlayer.rate = 20;
                MainPlayer.fireTimer = MainPlayer.StanderedfireTimer;
                Bullet.bulletDistance = 100;
                Bullet.gundamage = 3;
                MainPlayer.shoottwo = false;
                MainPlayer.shootthree = false;
                MainPlayer.shootfive = true;


                MainPlayer.ammo = 500;
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
