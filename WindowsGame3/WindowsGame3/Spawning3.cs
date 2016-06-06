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

        Random r = new Random();
        static public int spawnTimer3 = 0;
        static public int spawnTime3 = 60 * 1;

        static public int waveTimer3 = 0;
        static public int waveTime3 = 600 * 1;

        static public int numberofGuys3 = 1;
        private int x = 0;

        public static int totalSpawned3 = 0;

        public static bool spawncheck3 = false;
        public int wavenumber = 1;



        public Spawning3(Vector2 pos)
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
            spawnTimer3++;
        }
        public void Incs()
        {
            waveTimer3++;
        }
        public void wave1()
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
                           
                            while (x <= numberofGuys3)
                            {
                                x++;
                                o.alive = true;
                                int newX = r.Next(-745, 745);
                                int newY = r.Next(45, 745);
                                newX = r.Next(-745, 745);
                                newY = r.Next(45, 745);
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
                                    newY = r.Next(45, 745);
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
            if (x == numberofGuys3 + 1) 
            { 
                spawncheck3 = true;
                if (Spawning.spawncheck1 == true && Spawning2.spawncheck2 == true && spawncheck3 == true)
                {
                    waveTimer3 = 0;
                    x = 0;
                    numberofGuys3 = numberofGuys3 + 2;
                    totalSpawned3 = (numberofGuys3 - 1) + totalSpawned3;
                    Enemy3.enemeyspd3 = Enemy3.enemeyspd3 + .002f;
                    
                }
            }
           

        }


    }
}
