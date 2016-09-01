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
    class slowBlock : Obj
    {
        /**/
        /*
      speedBlock :Obj

        NAME

                speedBlock - A class that is in charge of Determining the attributes of a speedBlock.

        SYNOPSIS
     

        DESCRIPTION

     
                This class will attempt to represent the speedBlock object. Every time a speedBlock object is created using the
            attributes defined :
                        solid - can not be passed though by the Mainplayer and bullet objects
                        position - the location it will be created on the canvas
                        spriteName = "slowblock";( the Reference to the WindowsGame3Content picture)
                 
 
                The Purpose of this class is to create an object that does not help the MainPlayer move around the game area faster. This gives the
                slower enemies a chance to catch up and do some damage while providing an obstacle for the player.
     
        
     

        AUTHOR

                Thomas Wolski 

        DATE

                10:30pm 8/9/2016

        */
        /**/
        public slowBlock(Vector2 pos)
            : base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "slowblock";
        }
    }
}
