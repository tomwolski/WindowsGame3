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
    /**/
    /*
  wall :Obj

    NAME

            wall - A class that is in charge of Determining the attributes of a wall.

    SYNOPSIS
     

    DESCRIPTION

     
            This class will attempt to Represent the wall object. Every time a breakablewall object it will be created using the
            attributes defined :
                solid - can not be passed though
                position - the location it will be created on the canvas
                spriteName - "Image1" ( the reference to the WindowsGame3Content picture)
            The Purpose of this class is to create an object that restricts the MainPlayer from leaving the area specified for the
            game to take place. It also helps maintain control of bullet object deletion when collided with.
     
        
     

    AUTHOR

            Thomas Wolski 

    DATE

            9:30pm 8/9/2016

    */
    /**/

    class wall :Obj
    {
        public wall(Vector2 pos): base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "Image1";
        }
    }
}
