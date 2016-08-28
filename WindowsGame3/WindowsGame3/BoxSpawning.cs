﻿
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
    class BoxSpawning : Obj
    {
        /**/
        /*
        BoxSpawning : Obj

        NAME

                BoxSpawning - A class that is in charge of when and were a breakablewall object will spawn/be created.

        SYNOPSIS
     
            spawnTimer - A counter to determine how long to wait before spawning the breakablewall
            spawnTime - The amount of time it should take for the next breakablewall to spawn 
            waveTimer - A counter to determine the new position for the breakablewall object to be created at on the canvas
            waveTime  - The amount of time it should take for increasing/reseting the number of breakablewall that can spawn 
            numberofGuys - The total number of breakablewall's that will be created on that iteration of the loop
            MakeAlive -The Number of breakablewall that going to become "alive" in the loop, in this case there will only be one alive on the canvas
            newX - Used for Generating the random X coordinates for the breakablewall spawn
            newY- Used for Generating the random Y coordinates for the breakablewall spawn
     

        DESCRIPTION

     
                This class will attempt to create a gun2 object at a random x and y coordinates using a BoxSpawning object. This BoxSpawning object
                uses the obj class to define its attributes. Where it is calling Move to update each time.
                BoxSpawning has the following attributes:
                position - the location it will be created on the canvas
                spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
                alive(false) - can not be killed if not alive can not be damage by anything
                solid(false) - can be passed though by the Mainplayer and bullet objects
    

        AUTHOR

                Thomas Wolski 

        DATE

               8:00pm 8/10/2016

        */
        /**/ 
       
        private int spawnTimer = 0;
        private int spawnTime = 60 * 1;

        private int waveTimer = 0;
        private int waveTime = 800 * 1;

        public static int numberofGuys = 1;
        private int makeAlive = 0;

        private int newX;
        private int newY;

        public int wavenumber = 1;



        public BoxSpawning(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "ClearBlock";
            alive = false;
            solid = false;

        }
        // called every time the game updates
        public override void Move()
        {
            wave1();

        }
        // A simple SpawnTimer incrementor increasing it by 1 every time called
        public void Inc()
        {
            spawnTimer++;
        }
        // A simple waveTimer incrementor increasing it by 1 every time called
        public void Incs()
        {
            waveTimer++;
        }
        /**/
        /*
        wave1

        NAME

                wave1 - A function that is called every time the game updates. Used to determine when a breakablewall will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each breakablewall object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn-time , 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of breakablewall and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many breakablewall's to make alive and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the breakablewall object to spawn in a different location. Yes this Leaves a chance that the MainPlayer can have
                this breakablewall object spawn on top of them, this makes the game more random and interesting. 
    

        AUTHOR

                Thomas Wolski 

        DATE

                12:00pm 8/28/2016

        */
        /**/
        public void wave1()
        {

            Inc();

            if (spawnTimer >= spawnTime)
            {
                spawnTimer = 0;

                foreach (Obj o in items.objList)
                {

                    // if it randomly is chosen to spawn on the location of the character it will pick a new random location 
                    // the odds of getting the same location again as the character are slim but still can happen
                    if (o.GetType() == typeof(breakablewall) && !o.alive)
                    {
                        while (makeAlive < numberofGuys)
                        {
                            makeAlive++;
                            o.alive = true;
                            o.solid = true;

                            newX = StaticRandom.StaticRandomNumber.Rand(-745, 745);
                            newY = StaticRandom.StaticRandomNumber.Rand(65, 745);

                            float currentX = (MainPlayer.Player.position.X) + 32;
                            float currentY = (MainPlayer.Player.position.Y) + 32;

                            if (o.position.X > currentX && o.position.Y > currentY)
                            {
                                o.position.X = newX;
                                o.position.Y = newY;
                            }
                            else
                            {
                                newX = StaticRandom.StaticRandomNumber.Rand(-745, 745);
                                newY = StaticRandom.StaticRandomNumber.Rand(65, 745);

                                o.position.X = newX;
                                o.position.Y = newY;
                            }

                            break;
                        }
                    }
                }
            }
            nextwave();
        }
        /**/
        /*
        wave1

        NAME

                nextwave - A function that is called every time the game updates. Used to determine when a breakablewall creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION


                This function uses the arguments that are created in the class to determine the time it should take for each breakablewall object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime, 
                The number of breakablewall objects that are creating stays the same, also Nextwave resets the number of breakablewall objects that will spawn the next time wave1 meets its
                requirements to create more breakablewall objects.
    

        AUTHOR

                Thomas Wolski 

        DATE

                7:15pm 8/10/2016

        */
        /**/
        public void nextwave()
        {
            Incs();
            if (waveTimer >= waveTime)
            {
                waveTimer = 0;
                makeAlive = 0;
                numberofGuys = numberofGuys + 1;

            }
        }


    }
}