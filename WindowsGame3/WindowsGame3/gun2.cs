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
    class gun2: Obj
    {
        /**/
        /*
      gun2 :Obj

        NAME

                gun2 - A class that is in charge of Determining the attributes of a gun2 object.

        SYNOPSIS
         

        DESCRIPTION

     
                This class will attempt to Represent the gun2 object. Every time a gun2 object it will be created using the
                attributes defined :
                        Solid(True) -cant be passed through by certain objects
                        position - pos (Will be a zero vector until created by the BoxSpawning class)
                        spritename - gun2 ( the Reference to the WindowsGame3Content picture)
             
     

        AUTHOR

                Thomas Wolski 

        DATE

                1:40pm 8/14/2016

        */
        /**/
        public gun2(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "gun2";
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
                    away from then gun2 object and also it is alive. If it is alive the gun attributes are reset to default, then changed based on
                    the gun2 attributes (fire rate, distance, shootfive and ammo change). Then sets the alive value to false making the gun2 object not displayed 
                    anymore
         
                    
        AUTHOR

                Thomas Wolski 

        DATE

                1:45pm 8/14/2016

        */
        /**/
        public override void Move()
        {

            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32 && alive == true)
            {
                MainPlayer.bspd = 12;
                MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
                MainPlayer.ammo = MainPlayer.Standeredammo;
                MainPlayer.rate = MainPlayer.Standeredrate;
                MainPlayer.fireTimer = MainPlayer.StanderedfireTimer;
                Bullet.bulletDistance = Bullet.ConstbulletDistance;
                Bullet.gundamage = Bullet.Constgundamage;

                MainPlayer.shoottwo = false;
                MainPlayer.shootthree = false;
                MainPlayer.shootfive = true;

                MainPlayer.rate = 0.9F; ;
                MainPlayer.ammo = 1000;
                Bullet.bulletDistance = 50;
                alive = false;

                ;
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

                1:50pm 8/14/2016

        */
        /**/
        private float Distance(float x1, float y1, float x2, float y2)
        {
            float xRectangle = (x1 - x2) * (x1 - x2);
            float yRectangle = (y1 - y2) * (y1 - y2);
            double zRectangle = xRectangle + yRectangle;
            float dist = (float)Math.Sqrt(zRectangle);
            return dist;

        }
    }
}

