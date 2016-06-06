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

        Random r = new Random();
        static public int spawnTimer2 = 0;
        static public int spawnTime2 = 60 * 1;

        static public int waveTimer2 = 0;
        static public int waveTime2 = 600 * 1;

        static public int numberofGuys2 = 1;
        private int x = 0;

        public static int totalSpawned2 = 0;
        public static bool spawncheck2 = false;
        public int wavenumber = 1;



       
        public Spawning2(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "ClearBlock";
            alive = false;
            solid = false;
        }
        public override void move()
        {
            wave1();
        }
        public void Inc()
        {
            spawnTimer2++;
        }
        public void Incs()
        {
            waveTimer2++;
        }
        public void wave1()
        {
            Inc();
            if (spawnTimer2 >= spawnTime2)
            {
                spawnTimer2 = 0;
                foreach (Obj o in items.objList)
                {
                    if (o.GetType() == typeof(Enemy2) && !o.alive)
                    {
                        spawncheck2 = false;
                        if (Enemy.DogsKilled == Spawning.totalSpawned &&
                            Enemy2.FudKilled == totalSpawned2 &&
                            Enemy3.SnakesKilled == Spawning3.totalSpawned3)
                            
                        {
                            while (x <= numberofGuys2)
                            {
                                x++;
                                o.alive = true;
                                int newX = r.Next(-745, 745);
                                int newY = r.Next(-65, 745);
                                newX = r.Next(-745, 745);
                                newY = r.Next(65, 745);
                                float currentX = (MainPlayer.Player.position.X) + 32;
                                float currentY = (MainPlayer.Player.position.Y) + 32;
                                if (o.position.X > currentX && o.position.Y > currentY)
                                {
                                    o.position.X = newX;
                                    o.position.Y = newY;
                                }
                                else
                                {
                                    newX = r.Next(-745, 745);
                                    newY = r.Next(65, 745);
                                    o.position.X = newX;
                                    o.position.Y = newY;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            nextwave();
        }
        public void nextwave()
        {
            Incs();
            if (x == numberofGuys2 + 1)
            {
                spawncheck2 = true;
                {

                    // check if all have enimes have spawned already before making updates to the total spawned allowing the wave 
                    // to continiue to spawn once they are all dead will reset and add more enemies to spawn for the next wave
                    // and also make them faster
                    if (Spawning.spawncheck1 == true && spawncheck2 == true && Spawning3.spawncheck3 == true)
                    {
                        waveTimer2 = 0;
                        x = 0;
                        numberofGuys2 = numberofGuys2 + 2;
                        totalSpawned2 = (numberofGuys2 - 1) + totalSpawned2;
                        Enemy2.enemeyspd2 = Enemy2.enemeyspd2 + .002f;
                        
                   }
                }
            }
           
        }


    }
}
