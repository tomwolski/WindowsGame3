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
    class Spawning3 : Obj
    {
        /**/
        /*
        Spawning3 : Obj

        NAME

                Spawning3 - A class that is in charge of when and were a Enemy3 object will spawn/be created.

        SYNOPSIS
     
            spawnTimer1 - A counter to determine how long to wait before Spawning3 the Enemy3 (the Snake)
            spawnTime1 - The amount of time it should take for the next Enemy3 to spawn (about 5 seconds)
            waveTimer1 - A counter to determine the new position for the Enemy3 object to be created at on the canvas
            waveTime1  - The amount of time it should take for increasing/resetting the number of Enemy3 that can spawn (about 12 seconds)
            numberofGuys - The total number of Enemy3's that will be created on that iteration of the loop
            makeAlive -The Number of Enemy3 that going to become "alive" in the loop, in this case there will only be one alive on the canvas
            totalSpawned - a running total of all Enemy3 objects created during the current game
            spawncheck1 - checks if the number of Enemy3 objects are the same as the number destroyed 
            newX - Used for Generating the random X coordinates for the Enemy3 spawn
            newY- Used for Generating the random Y coordinates for the Enemy3 spawn
     

        DESCRIPTION

     
                This class will attempt to create a Enemy3 object at a random x and y coordinates using a Spawning3 object. This Spawning3 object
                uses the obj class to define its attributes. Where it is calling Move to update each time.
                Spawning3 has the following attributes:
                position - the location it will be created on the canvas
                spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
                alive(false) - can not be killed if not alive can not be damage by anything
                solid(false) - can be passed though by the Mainplayer and bullet objects
    

        AUTHOR

                Thomas Wolski 

        DATE

               11:00pm 8/10/2016

        */
        /**/
      
        static public int spawnTimer3 = 0;
        static public int spawnTime3 = 60 * 1;

        static public int waveTimer3 = 0;
        static public int waveTime3 = 600 * 1;

        static public int numberofGuys3 = 0;
        private int makeAlive = 0;

        public static int totalSpawned3 = 0;

        public static bool spawncheck3 = false;
        public static int wavenumber = 1;

        int newX;
        int newY;

        public Spawning3(Vector2 pos)
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
        // A simple spawnTimer3 incrementor increasing it by 1 every time called
        private void Inc()
        {
            spawnTimer3++;
        }
        // A simple waveTimer3 incrementor increasing it by 1 every time called
        private void Incs()
        {
            waveTimer3++;
        }

        /**/
        /*
        wave1

        NAME

                Wave1 - A function that is called every time the game updates. Used to determine when a Enemy3 will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each Enemy3 object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn time (about 5 seconds), 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of Enemy3 and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many Enemy3's to make alive and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the Enemy3 object to spawn in a different location. This function will only spawn the next round
                of Enemy3s when all enemies (enemy, enemy2,enemy3) have been destroyed (when there health <= 0 and alive = false)
    

        AUTHOR

                Thomas Wolski 

        DATE

                  11:10pm 8/10/2016

        */
        /**/
        private void Wave1()
        {
            Inc();
            if (spawnTimer3 >= spawnTime3)
            {
                spawnTimer3 = 0;
                foreach (Obj o in items.objList)
                {
                    if (o.GetType() == typeof(Enemy3) && !o.alive)
                    {
                       
                        spawncheck3 = false;
                        if (Enemy.DogsKilled == Spawning.totalSpawned &&
                            Enemy2.FudKilled == Spawning2.totalSpawned2 &&
                            Enemy3.SnakesKilled == totalSpawned3)
                        {
                            // if it randomly is chosen to spawn on the location of the character it will pick a new random location 
                            // the odds of getting the same location again as the character slim chance
                            while (makeAlive <= numberofGuys3)
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
            }
            Nextwave();
        }
        /**/
        /*
        wave1

        NAME

                nextwave - A function that is called every time the game updates. Used to determine when a Enemy3 creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are created in the class to determine the time it should take for each Enemy3 object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime (about 12 seconds), 
                The number of Enemy3 objects that are creating stays the same, also Nextwave resets the number of Enemy3 objects that will spawn the next time wave1 meets its
                requirements to create more Enemy3 objects. waveTimer will never be incremented until the next wave starts, allowing the game to have a constant of Enemy3 objects created.
                 
    

        AUTHOR

                Thomas Wolski 

        DATE

                11:15pm 8/10/2016

        */
        /**/
        private void Nextwave()
        {
            Incs();
            if (makeAlive == numberofGuys3 + 1) 
            { 
                spawncheck3 = true;
                // check if all have enemies have spawned already before making updates to the total spawned allowing the wave 
                // to continue to spawn once they are all dead will reset and add more enemies to spawn for the next wave
                // and also make them faster
                if (Spawning.spawncheck1 == true && Spawning2.spawncheck2 == true && spawncheck3 == true)
                {
                    waveTimer3 = 0;
                    makeAlive = 0;
                    numberofGuys3 = numberofGuys3 + 2;
                    totalSpawned3 = (numberofGuys3 - 1) + totalSpawned3;
                    Enemy3.enemeyspd3 = Enemy3.enemeyspd3 + .002f;
                    
                }
            }
           

        }


    }
}
