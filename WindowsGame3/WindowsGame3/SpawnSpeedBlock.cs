﻿using System;
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
    class SpawningSpeedBlock : Obj
    {

        /**/
        /*
        SpawningSpeedBlock : Obj

        NAME

                SpawningSpeedBlock - A class that is in charge of when and were a speedBlock object will spawn/be created.

        SYNOPSIS
     
            spawnTimer - A counter to determine how long to wait before spawning the speedBlock
            spawnTime - The amount of time it should take for the next speedBlock to spawn 
            waveTimer - A counter to determine the new position for the speedBlock object to be created at on the canvas
            waveTime  - The amount of time it should take for increasing/resetting the number of speedBlock that can spawn 
            numberofGuys - The total number of speedBlock's that will be created on that iteration of the loop
            makeAlive -The Number of speedBlock that going to become "alive" in the loop, in this case there will 3 alive on the canvas at a time
            newX - Used for Generating the random X coordinates for the speedBlock spawn
            newY- Used for Generating the random Y coordinates for the speedBlock spawn
     

        DESCRIPTION

     
                This class will attempt to create a speedBlock object at a random x and y coordinates using a SpawningSpeedBlock object. This SpawningSpeedBlock object
                uses the obj class to define its attributes. Where it is calling Move to update each time.
                SpawningSpeedBlock has the following attributes:
                position - the location it will be created on the canvas
                spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
                alive(false) - can not be killed if not alive can not be damage by anything can not be seen if not alive
                solid(false) - can be passed though by the Mainplayer and bullet objects
    

        AUTHOR

                Thomas Wolski 

        DATE

               7:30pm 8/11/2016

        */
        /**/
        private int spawnTimer = 0;
        private int spawnTime = 60 * 1;

        private int waveTimer = 0;
        private int waveTime = 600 * 1;

        private int numberofGuys = 3;
        private int makeAlive = 0;


        public int wavenumber = 1;

        int newX;
        int newY;

        public SpawningSpeedBlock(Vector2 pos)
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
            Wave1();

        }
        // A simple spawnTimer incrementor increasing it by 1 every time called
        private void Inc()
        {
            spawnTimer++;
        }
        // A simple waveTimer incrementor increasing it by 1 every time called
        private void Incs()
        {
            waveTimer++;
        }
        /**/
        /*
        wave1

        NAME

                Wave1 - A function that is called every time the game updates. Used to determine when a speedBlock will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each speedBlock object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn time, 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of speedBlock and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many speedBlock's to make alive and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the speedBlock object to spawn in a different location. Yes this Leaves a chance that the MainPlayer can have
                this speedBlock object spawn on top of them, this makes the game more random and interesting. 
    

        AUTHOR

                Thomas Wolski 

        DATE

                7:35pm 8/11/2016

        */
        /**/
        private void Wave1()
        {

            Inc();

            if (spawnTimer >= spawnTime)
            {
                spawnTimer = 0;

                foreach (Obj o in items.objList)
                {


                    if (o.GetType() == typeof(speedBlock) && !o.alive)
                    {
                        while (makeAlive < numberofGuys)
                        {
                            makeAlive++;
                              o.alive = true;
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
            Nextwave();
        }
        /**/
        /*
        wave1

        NAME

                    nextwave - A function that is called every time the game updates. Used to determine when a speedBlock creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are created in the class to determine the time it should take for each speedBlock object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime, 
                The number of speedBlock objects that are creating stays the same, also Nextwave resets the number of speedBlock objects that will spawn the next time wave1 meets its
                requirements to create more speedBlock objects (there will be 3 speedBlock spawned at a time) Each time it will despawn (Make alive false again) the speedBlock
                and re-spawn 3 different speedBlock objects continuing this cycle till the MainPlayer dies.
                 
    

        AUTHOR

                Thomas Wolski 

        DATE

                7:40pm 8/11/2016

        */
        /**/
        private void Nextwave()
        {
            Incs();

            if (waveTimer >= waveTime)
            {
                waveTimer = 0;
                makeAlive = 0;
                

                foreach (Obj o in items.objList)
                {
                    if (o.GetType() == typeof(speedBlock) && o.alive)
                    {
                        o.alive = false;
                        o.position.X = newX;
                        o.position.Y = newY;
                       
                    }
                }

            }
        }


    }
}
