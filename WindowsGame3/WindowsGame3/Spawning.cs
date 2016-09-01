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
    Spawning : Obj

    NAME

            Spawning - A class that is in charge of when and were an Enemy object will spawn/be created.

    SYNOPSIS
     
        spawnTimer1 - A counter to determine how long to wait before spawning the Enemy (the Dogs)
        spawnTime1 - The amount of time it should take for the next Enemy to spawn  
        waveTimer1 - A counter to determine the new position for the Enemy object to be created at on the canvas
        waveTime1  - The amount of time it should take for increasing/resetting the number of Enemy that can spawn 
        numberofGuys - The total number of Enemy's that will be created on that iteration of the loop
        makeAlive -The Number of Enemy that going to become "alive" in the loop, in this case there will only be one alive on the canvas
        totalSpawned - a running total of all enemy objects created during the current game
        spawncheck1 - checks if the number of enemy objects are the same as the number destroyed 
        newX - Used for Generating the random X coordinates for the Enemy spawn
        newY- Used for Generating the random Y coordinates for the Enemy spawn
     

    DESCRIPTION

     
            This class will attempt to create a Enemy object at a random x and y coordinates using a Spawning object. This Spawning object
            uses the obj class to define its attributes. Where it is calling Move to update each time.
            Spawning has the following attributes:
            position - the location it will be created on the canvas
            spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
            alive(false) - can not be killed if not alive can not be damage by anything
            solid(false) - can be passed though by the Mainplayer and bullet objects
    

    AUTHOR

            Thomas Wolski 

    DATE

           10:00pm 8/10/2016

    */
    /**/

    class Spawning : Obj
    {

 
        static public int spawnTimer1 = 0;
        static public int spawnTime1 = 60 * 1;

        static public int waveTimer1 = 0;
        static public int waveTime1 = 600 * 1;

        static public int numberofGuys = 1;
        private int makeAlive = 0;
        public static int totalSpawned = 0;
        public static bool spawncheck1 = false;

    

        private int newX = 0;
        private int newY = 0;

        public Spawning(Vector2 pos)
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
            spawnTimer1++;
        }
        // A simple waveTimer1 incrementor increasing it by 1 every time called
        private void Incs()
        {
            waveTimer1++;
        }
        /**/
        /*
        wave1

        NAME

                Wave1 - A function that is called every time the game updates. Used to determine when a Enemy will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each Enemy object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn time, 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of Enemy and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many Enemy's to make alive and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the Enemy object to spawn in a different location. This function will only spawn the next round
                of enemies when all enemies (enemy, enemy2,enemy3) have been destroyed (when there health <= 0 and alive = false)
    

        AUTHOR

                Thomas Wolski 

        DATE

                  10:10pm 8/10/2016

        */
        /**/
        private void Wave1()
        {

            Inc();

            if (spawnTimer1 >= spawnTime1)
            {
                spawnTimer1 = 0;

                foreach (Obj o in items.objList)
                {

                    // if it randomly is chosen to spawn on the location of the character it will pick a new random location 
                    // the odds of getting the same location again as the character slim chance
                    if (o.GetType() == typeof(Enemy) && !o.alive)
                    {
                        spawncheck1 = false;
                        if (Enemy.DogsKilled == totalSpawned &&
                            Enemy2.FudKilled == Spawning2.totalSpawned2 &&
                            Enemy3.SnakesKilled == Spawning3.totalSpawned3)
                        {


                            while (makeAlive <= numberofGuys)
                            {
                                makeAlive++;

                                o.alive = true;
                                newX = StaticRandom.StaticRandomNumber.Rand(-745, 745);
                                newY = StaticRandom.StaticRandomNumber.Rand(65, 745);
                                float currentX = (MainPlayer.Player.position.X);
                                float currentY = (MainPlayer.Player.position.Y);

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

                nextwave - A function that is called every time the game updates. Used to determine when a Enemy creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are created in the class to determine the time it should take for each Enemy object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime , 
                The number of Enemy objects that are creating stays the same, also Nextwave resets the number of Enemy objects that will spawn the next time wave1 meets its
                requirements to create more Enemy objects. waveTimer will never be incremented until the next wave starts, allowing the game to have a constant of objects created.
                 
    

        AUTHOR

                Thomas Wolski 

        DATE

                10:20pm 8/10/2016

        */
        /**/
        private void Nextwave()
        {
            Incs();
            if (makeAlive == numberofGuys + 1)
            {
                spawncheck1 = true;
                {
                    // check if all have enemies have spawned already before making updates to the total spawned allowing the wave 
                    // to continue to spawn once they are all dead will reset and add more enemies to spawn for the next wave
                    // and also make them faster
                    if (spawncheck1 == true && Spawning2.spawncheck2 == true && Spawning3.spawncheck3 == true)
                    {
                        waveTimer1 = 0;
                        makeAlive = 0;
                        numberofGuys = numberofGuys + 2;
                        totalSpawned = (numberofGuys - 1) + totalSpawned;
                        Enemy.enemeyspd1 = Enemy.enemeyspd1 + .002f;
                        
                    }
                }
            }
            
        }


    }
}