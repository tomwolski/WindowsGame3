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
  breakablewall :Obj

    NAME

            breakablewall - A class that is in charge of Determining the attributes of a breakablewall object.

    SYNOPSIS
     
       MaxHp - A constant integer to keep track of the maximum health a breakable wall can have
       health - A integer to keep track of how much health each individual box has while it is being attacked
     

    DESCRIPTION

     
            This class will attempt to represent the breakablewall object. Every time a breakablewall object it will be created using the
            attributes defined :
                    Solid(True) -cant be passed through by certain objects
                    position - pos (Will be a zero vector until created by the BoxSpawning class)
                    spritename - Image2 ( the Reference to the WindowsGame3Content picture)
                    health - the total health the breakablewall will be created with
     

    AUTHOR

            Thomas Wolski 

    DATE

            9:00pm 8/8/2016

    */
    /**/
    class breakablewall :Obj
    {
        const int MaxHp = 10;
        int health ;

                public breakablewall(Vector2 pos): base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "Image2";
            health = 10;

            
        }
                /**/
                /*
                     move

                NAME

                        move - A function called when the game has determined that game logic needs to be processed. 
                        This includes change of the game state,  processing user input, updating of simulation data. 
                        Overrided this method with game-specific logic.

                SYNOPSIS
     
                       Zero arguments passed
     

                DESCRIPTION

                            When this Function is called it will first check if breakablewall object attribute alive is true. if it is not it will be return 
                            saving time. Next it check if a breakablewall's health has gone to zero or past zero this will ensure it should no longer exist. When  
                            This is true it will make the breakablewall not alive and not solid, while reseting the hp of the box if it was to become alive and solid again.

                AUTHOR

                        Thomas Wolski 

                DATE

                        9:00pm 8/8/2016

                */
                /**/
                public override void Move()
                {
                    if (!alive)
                    {
                        return;
                    }

                    if (health <= 0)
                    {
                        alive = false;
                        solid = false;
                       health = MaxHp;
                       
                    }


                    base.Move();
                }
                // Subtracts the damage dealt from the breakablewall's health
                public void Damage(int dmg)
                {
                    health -= dmg;
                }




    }
}
