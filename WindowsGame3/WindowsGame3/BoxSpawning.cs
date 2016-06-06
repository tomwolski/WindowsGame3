
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

        Random r = new Random();
        private int spawnTimer = 0;
        private int spawnTime = 60 * 1;

        private int waveTimer = 0;
        private int waveTime = 800 * 1;

        private int numberofGuys = 1;
        private int x = 0;


        public int wavenumber = 1;



        public BoxSpawning(Vector2 pos)
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
            spawnTimer++;
        }
        public void Incs()
        {
            waveTimer++;
        }

        public void wave1()
        {

            Inc();

            if (spawnTimer >= spawnTime)
            {
                spawnTimer = 0;

                foreach (Obj o in items.objList)
                {


                    if (o.GetType() == typeof(breakablewall) && !o.alive)
                    {
                        while (x < numberofGuys)
                        {
                            x++;
                            o.alive = true;
                            o.solid = true;
                            int newX = r.Next(-745, 745);
                            int newY = r.Next(65, 745);
                            newX = r.Next(-745, 745);
                            newY = r.Next(65, 760);
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
            nextwave();
        }

        public void nextwave()
        {
            Incs();
            if (waveTimer >= waveTime)
            {
                waveTimer = 0;
                x = 0;
                numberofGuys = numberofGuys + 1;

            }
        }


    }
}