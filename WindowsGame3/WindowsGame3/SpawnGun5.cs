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
    SpawnGun5 : Obj

    NAME

            SpawnGun5 - A class that is in charge of when and were a gun5 object will spawn/be created.

    SYNOPSIS
     
        spawnTimer - A counter to determine how long to wait before spawning the gun5
        spawnTime - The amount of time it should take for the next gun5 to spawn (about 5 seconds)
        waveTimer - A counter to determine the new position for the gun5 object to be created at on the canvas
        waveTime  - The amount of time it should take for increasing/resetting the number of gun5 that can spawn (about 12 seconds)
        numberofGuys - The total number of gun5's that will be created on that iteration of the loop
        MakeAlive -The Number of gun5 that going to become "alive" in the loop, in this case there will only be one alive on the canvas
        newX - Used for Generating the random X coordinates for the gun5 spawn
        newY- Used for Generating the random Y coordinates for the gun5 spawn
     

    DESCRIPTION

     
            This class will attempt to create a gun5 object at a random x and y coordinates using a SpawnGun5 object. This SpawnGun5 object
            uses the obj class to define its attributes. Where it is calling Move to update each time.
            SpawnGun5 has the following attributes:
            position - the location it will be created on the canvas
            spriteName = "ClearBlock" ( the reference to the WindowsGame3Content picture)
            alive(false) - can not be killed if not alive can not be damage by anything
            solid(false) - can be passed though by the Mainplayer and bullet objects
    

    AUTHOR

            Thomas Wolski 

    DATE

           9:10pm 8/10/2016

    */
    /**/

    class SpawnGun5 : Obj
    {

        private int spawnTimer = 0;
        private int spawnTime = 100 * 1;

        private int waveTimer = 0;
        private int waveTime = 500 * 1;

        private double numberofGuys = 1;
        private int MakeAlive = 0;


        public int wavenumber = 1;

        private int newX;
        private int newY;

        public SpawnGun5(Vector2 pos)
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

                Wave1 - A function that is called every time the game updates. Used to determine when a gun5 will spawn.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are creating in the class to determine the time it should take for each gun5 object to spawn/be created.
                Every time the game updates Wave1 is called, always increasing the SpawnTimer. When SpawnTimer becomes greater or equal to spawn time , 
                It will proceed to check the objects in the object list located in the items class for an object that has the type of gun5 and if is not alive.
                Once an object is found the program will move to the while loop were it determines how many gun5's to make alive ( in this case always 1) and make solid along with the
                a random x, and y coordinates located inside the game area will then be its spawn location. However if those random x and y coordinates are the same location as the MainPLayer
                then they will be randomly generated again for the gun5 object to spawn in a different location. Yes this Leaves a chance that the MainPlayer can have
                this gun5 object spawn on top of them, this makes the game more random and interesting. 
    

        AUTHOR

                Thomas Wolski 

        DATE

                9:10pm 8/10/2016

        */
        /**/
        public void Wave1()
        {

            Inc();

            if (spawnTimer >= spawnTime)
            {
                spawnTimer = 0;

                foreach (Obj o in items.objList)
                {


                    // if it randomly is chosen to spawn on the location of the character it will pick a new random location 
                    // the odds of getting the same location again as the character are slim but still can happen

                    if (o.GetType() == typeof(Gun4ShootThree) && !o.alive)
                    {
                        while (MakeAlive < numberofGuys)
                        {
                            MakeAlive++;
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

                nextwave - A function that is called every time the game updates. Used to determine when a gun4 creation number is increased.

        SYNOPSIS
     
                Zero arguments passed
     

        DESCRIPTION

                This function uses the arguments that are created in the class to determine the time it should take for each gun4 object to be created.
                Every time the game updates Wave1 is called,  increasing the waveTimer overtime. When waveTimer becomes greater or equal to waveTime (about 12 seconds), 
                The number of gun4 objects that are creating stays the same, also Nextwave resets the number of gun4 objects that will spawn the next time wave1 meets its
                requirements to create more gun4 objects (there will never be more then one gun4 spawned).
                 
    

        AUTHOR

                Thomas Wolski 

        DATE

                9:20pm 8/10/2016

        */
        /**/
        private void Nextwave()
        {
            Incs();

            if (waveTimer >= waveTime)
            {
                waveTimer = 0;
                MakeAlive = 0;


                foreach (Obj o in items.objList)
                {
                    if (o.GetType() == typeof(Gun4ShootThree) && o.alive)
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
