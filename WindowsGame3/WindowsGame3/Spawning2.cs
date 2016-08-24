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
    class Spawning2 : Obj
    {

        /**/
        /*
        Spawning2 : Obj

        NAME

                Spawning2 - A class that is in charge of when and were a Enemy2 object will spawn/be created.

        SYNOPSIS
     
            spawnTimer1 - A counter to determine how long to wait before Spawning2 the Enemy2 (the Pig)
            spawnTime1 - The amount of time it should take for the next Enemy2 to spawn (about 5 seconds)
            waveTimer1 - A counter to determine the new position for the Enemy2 object to be created at on the canvas
            waveTime1  - The amount of time it should take for increasing/resetting the number of Enemy2 that can spawn (about 12 seconds)
            numberofGuys - The total number of Enemy2's that will be created on that iteration of the loop
            makeAlive -The Number of Enemy2 that going to become "alive" in the loop, in this case there will only be one alive on the canvas
            totalSpawned - a running total of all Enemy2 objects created during the current game
            spawncheck1 - checks if the number of Enemy2 objects are the same as the number destroyed 
            newX - Used for Generating the random X coordinates for the Enemy2 spawn
            newY- Used for Generating the random Y coordinates for the Enemy2 spawn
     

        DESCRIPTION

     
                This class will attempt to create a Enemy2 object at a random x and y coordinates using a Spawning2 object. This Spawning2 object
                uses the obj class to define its attributes. Where it is calling Move to update each time.
                Spawning2 has the following attributes:
                position - the location it will be created on the canvas
                spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
                alive(false) - can not be killed if not alive can not be damage by anything
                solid(false) - can be passed though by the Mainplayer and bullet objects
    

        AUTHOR

                Thomas Wolski 

        DATE

               10:30pm 8/10/2016

        */
        /**/
        static public int spawnTimer2 = 0;
        static public int spawnTime2 = 60 * 1;

        static public int waveTimer2 = 0;
        static public int waveTime2 = 600 * 1;

        static public int numberofGuys2 = 1;
        private int makeAlive = 0;

        public static int totalSpawned2 = 0;
        public static bool spawncheck2 = false;
        public static int wavenumber = 1;

        private int newX;
        private int newY;

       
        public Spawning2(Vector2 pos)
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
        // A simple spawnTimer2 incrementor increasing it by 1 every time called
        private void Inc()
        {
            spawnTimer2++;
        }
        // A simple waveTimer2 incrementor increasing it by 1 every time called
        private void Incs()
        {
            waveTimer2++;
        }
        /**/
        /*
        wave1

        NAME

                Wave1 - A function that is called every time the game updates. Used to determine when a Enemy2 will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each Enemy2 object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn time (about 5 seconds), 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of Enemy2 and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many Enemy2's to make alive and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the Enemy2 object to spawn in a different location. This function will only spawn the next round
                of Enemy2s when all enemies (enemy, enemy2,enemy3) have been destroyed (when there health <= 0 and alive = false)
    

        AUTHOR

                Thomas Wolski 

        DATE

                  10:35pm 8/10/2016

        */
        /**/
        private void Wave1()
        {
            Inc();
            if (spawnTimer2 >= spawnTime2)
            {
                spawnTimer2 = 0;
                foreach (Obj o in items.objList)
                {

                    // if it randomly is chosen to spawn on the location of the character it will pick a new random location 
                    // the odds of getting the same location again as the character slim chance
                    if (o.GetType() == typeof(Enemy2) && !o.alive)
                    {
                        spawncheck2 = false;
                        if (Enemy.DogsKilled == Spawning.totalSpawned &&
                            Enemy2.FudKilled == totalSpawned2 &&
                            Enemy3.SnakesKilled == Spawning3.totalSpawned3)
                            
                        {
                            while (makeAlive <= numberofGuys2)
                            {
                                makeAlive++;
                                o.alive = true;
                                newX = StaticRandom.StaticRandomNumber.Rand(-745, 745);
                                newY = StaticRandom.StaticRandomNumber.Rand(95, 745);
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
                                    newY = StaticRandom.StaticRandomNumber.Rand(95, 745);
                                    o.position.X = newX;
                                    o.position.Y = newY;
                                }
                                break;
                            }
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

                nextwave - A function that is called every time the game updates. Used to determine when a Enemy2 creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are created in the class to determine the time it should take for each Enemy2 object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime (about 12 seconds), 
                The number of Enemy2 objects that are creating stays the same, also Nextwave resets the number of Enemy2 objects that will spawn the next time wave1 meets its
                requirements to create more Enemy2 objects. waveTimer will never be incremented until the next wave starts, allowing the game to have a constant of Enemy2 objects created.
                 
    

        AUTHOR

                Thomas Wolski 

        DATE

                10:40pm 8/10/2016

        */
        /**/
        private void Nextwave()
        {
            Incs();
            if (makeAlive == numberofGuys2 + 1)
            {
                spawncheck2 = true;
                {

                    // check if all have enemies have spawned already before making updates to the total spawned allowing the wave 
                    // to continue to spawn once they are all dead will reset and add more enemies to spawn for the next wave
                    // and also make them faster
                    if (Spawning.spawncheck1 == true && spawncheck2 == true && Spawning3.spawncheck3 == true)
                    {
                        waveTimer2 = 0;
                        makeAlive = 0;
                        numberofGuys2 = numberofGuys2 + 2;
                        totalSpawned2 = (numberofGuys2 - 1) + totalSpawned2;
                        Enemy2.enemeyspd2 = Enemy2.enemeyspd2 + .002f;
                        
                   }
                }
            }
           
        }


    }
}
