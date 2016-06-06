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
    class Spawning : Obj
    {

        Random r = new Random();
        static public int spawnTimer1 = 0;
        static public int spawnTime1 = 60 * 1;

        static public int waveTimer1 = 0;
        static public int waveTime1 = 600 * 1;

        static public int numberofGuys = 1;
        private int x = 0;
        public static int totalSpawned = 0;
        public static bool spawncheck1 = false;

        public int wavenumber = 1;



        public Spawning(Vector2 pos)
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
            spawnTimer1++;
        }
        public void Incs()
        {
            waveTimer1++;
        }

        public void wave1()
        {

            Inc();

            if (spawnTimer1 >= spawnTime1)
            {
                spawnTimer1 = 0;

                foreach (Obj o in items.objList)
                {


                    if (o.GetType() == typeof(Enemy) && !o.alive)
                    {
                        spawncheck1 = false;
                        if (Enemy.DogsKilled == totalSpawned &&
                            Enemy2.FudKilled == Spawning2.totalSpawned2 &&
                            Enemy3.SnakesKilled == Spawning3.totalSpawned3)
                        {

                            
                            while (x <= numberofGuys)
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
            if (x == numberofGuys + 1)
            {
                spawncheck1 = true;
                {
                    if (spawncheck1 == true && Spawning2.spawncheck2 == true && Spawning3.spawncheck3 == true)
                    {
                        waveTimer1 = 0;
                        x = 0;
                        numberofGuys = numberofGuys + 2;
                        totalSpawned = (numberofGuys - 1) + totalSpawned;
                        Enemy.enemeyspd1 = Enemy.enemeyspd1 + .002f;
                        
                    }
                }
            }
            
        }


    }
}