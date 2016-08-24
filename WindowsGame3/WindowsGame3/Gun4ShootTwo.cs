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
    class Gun4ShootTwo: Obj
    {
        /**/
        /*
      Gun4ShootTwo :Obj

        NAME

                Gun4ShootTwo - A class that is in charge of determining the attributes of a Gun4ShootTwo object.

        SYNOPSIS
         

        DESCRIPTION

     
                This class will attempt to Represent the Gun4ShootTwo object. Every time a Gun4ShootTwo object it will be created using the
                attributes defined :
                         
                        position - pos (Will be a zero vector until created by the BoxSpawning class)
                        spritename - 2shot ( the Reference to the WindowsGame3Content picture)
             
     

        AUTHOR

                Thomas Wolski 

        DATE

                2:55pm 8/14/2016

        */
        /**/
        public Gun4ShootTwo(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "2shot";
            alive = true;
          
        }
        /**/
        /*
             move

        NAME

                move - A function called when the game has determined that game logic needs to be processed. 
                This includes change of the game state,  processing user input, updating of simulation data. 
                Overrided this method with game-specific logic.

        SYNOPSIS   

        DESCRIPTION

                    When this Function is called it first checks if the main player's distance is less then 32 pixels ( the size of the main player)
                    away from then Gun4ShootTwo object and also it is alive. If it is alive the gun attributes are reset to default, then changed based on
                    the Gun4ShootTwo attributes (fire rate, shootthree, distance damage). Then sets the alive value to false making the Gun4ShootTwo object not displayed anymore
                    shootwo, shootthree,shootfive will never have more then 1 true at a time.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                 2:55pm 8/14/2016

        */
        /**/
        public override void Move()
        {

            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32 && alive == true)
            {
                MainPlayer.bspd = MainPlayer.Standeredbspd;
                MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
                MainPlayer.ammo = MainPlayer.Standeredammo;
                MainPlayer.rate = MainPlayer.Standeredrate;
                MainPlayer.fireTimer = MainPlayer.StanderedfireTimer;
                Bullet.bulletDistance = Bullet.ConstbulletDistance;
                Bullet.gundamage = Bullet.Constgundamage;
                MainPlayer.shoottwo = true;
                MainPlayer.shootthree = false;
                MainPlayer.shootfive = false;

                MainPlayer.ammo = 400;
                alive = false;
            }

            base.Move();
        }
        /**/
        /*
             Distance

        NAME

                Distance - A function called to determine how far away one object is to another object.

        SYNOPSIS   

        DESCRIPTION

                    When this Function is called it takes the x position from one object and the x position of another object
                    to form a new x^2 position and takes the y position from one object and the y position from 
                    another object to form a new y^2 position After then it takes the Sqrt of the two added together to get
                    the distance between the two objects. (Pythagorean theorem)
                   
                    
        AUTHOR

                Thomas Wolski 

        DATE

                2:55pm 8/14/2016

        */
        /**/
        public float Distance(float x1, float y1, float x2, float y2)
        {
            float xRectangle = (x1 - x2) * (x1 - x2);
            float yRectangle = (y1 - y2) * (y1 - y2);
            double zRectangle = xRectangle + yRectangle;
            float dist = (float)Math.Sqrt(zRectangle);
            return dist;

        }
    }
}
