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
        /**/
        /*
      gun3 :Obj

        NAME

                gun3 - A class that is in charge of Determining the attributes of a gun3 object.

        SYNOPSIS
         

        DESCRIPTION

     
                This class will attempt to Represent the gun3 object. Every time a gun3 object it will be created using the
                attributes defined :
                        Solid(True) -cant be passed through by certain objects
                        position - pos (Will be a zero vector until created by the BoxSpawning class)
                        spritename - gun3 ( the Reference to the WindowsGame3Content picture)
             
     

        AUTHOR

                Thomas Wolski 

        DATE

                2:00pm 8/14/2016

        */
        /**/
        public gun3(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "gun3";
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
                    away from then gun2 object and also it is alive. If this object is alive then the main players ammo will be changed to 100 if it is
                    currently under or equal to 50, and the damage of any gun that is currently being used has its damage doubled, if the main player
                    is within 32 pixels of the object which then the object will be set to false. 
         
                    
        AUTHOR

                Thomas Wolski 

        DATE

                 2:10pm 8/14/2016

        */
        /**/
        public override void Move()
        {

            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32 && alive == true)
            {
               
                if (MainPlayer.ammo <= 50)
                {
                    MainPlayer.ammo = 100;
                }
                MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
               
                Bullet.gundamage = Bullet.gundamage *2;
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

                2:15pm 8/14/2016

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

 