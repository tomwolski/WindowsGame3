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
    class mousechange :Obj
    {
        /**/
        /*
        mousechange : Obj

        NAME

                mousechange - A class that is in charge of updating the mouse.

        SYNOPSIS
                pos - position of the mouse on the canvas
     

        DESCRIPTION

     
                This class will attempt create a sprite at the position of you mouse keeping it updated.
                position - the location it will be created on the canvas
                spriteName = "duckHair" ( the reference to the WindowsGame3Content picture)
 
    

        AUTHOR

                Thomas Wolski 

        DATE

               1:00pm 8/14/2016

        */
        /**/
            MouseState mouse;

            public mousechange(Vector2 pos)
                : base(pos)
            {
                position = pos;
                spriteName = "duckHair";
            }

            /**/
            /*
            Move  

            NAME

                    Move - Updates the current position of the mouse

            SYNOPSIS
             
     

            DESCRIPTION

     
                    The function is called every time the game updates. It is used to keep the mouse sprite image displaying in the correct location.
 
    

            AUTHOR

                    Thomas Wolski 

            DATE

                   1:00pm 8/14/2016

            */
            /**/
            public override void Move()
            {
                mouse = Mouse.GetState();
                position = new Vector2(mouse.X, mouse.Y);
                base.Move();            
            
        }
    }
}
