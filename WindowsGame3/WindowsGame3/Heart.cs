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
    
        public Heart(Vector2 pos)
            : base(pos)
        {
            
            position = pos;
            spriteName = "Heart";
            alive = true;
            solid = false;
          

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

                    When this Function is called it first checks if the main player's distance is less then 25 pixels ( the size of the main player)
                    away from then Heart object and also it is alive. if the heart object is alive the mainPlayers health will be increased by 10 while the
                    heart changes to not alive.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                 2:55pm 8/14/2016

        */
        /**/
        public override void Move()
        {
            if (!alive)
            {
                return;
            }


            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 25 && alive == true)
            {
                MainPlayer.Player.hp += 10;
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
