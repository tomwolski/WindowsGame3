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
    class Enemy :Obj
    {

       // public static Enemy enemy;
        int health;
        static public float enemeyspd1 =1;

        const int MaxHp = 2;
        private int damagedelt;

        static public int hitTimer1 = 0;
        static public int hitTime1 = 60;

        static public int DogsKilled = 0;

        public Enemy(Vector2 pos)
            : base(pos)
        {
           
            position = pos;
            spriteName = "Realdoggy";
            solid = false;
            alive = true;
            health = 2;
            damagedelt = 10;
           
        }

        public override void move()
        {
            
            if (!alive)
            {
                return;
            }
            hitTimer1++;
            hitplayer();

            if (health <= 0)
            {
                alive = false;
                Game1.Death1.Play();
                // error need 2 reset hp for each enemy
                health = MaxHp;
                Game1.KillCount++;
                DogsKilled++;
            }

            rotation = direction(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y);
            speed = enemeyspd1;


            
            base.move();
        }

        private void hitplayer()
        {
            if (distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32)
            {
              
                  
                if (hitTimer1 > hitTime1)
                {
                    hitTimer1 = 0;
                    MainPlayer.Player.damage(damagedelt);
                    health = health - 1;
                }
            }
        }


        public float distance(float x1, float y1, float x2, float y2)
        {
            float xRectangle = (x1 - x2) * (x1 - x2);
            float yRectangle = (y1 - y2) * (y1 - y2);
            double zRectangle = xRectangle + yRectangle;
            float dist = (float)Math.Sqrt(zRectangle);
            return dist;

        }

        public  override void Movement(float pix, float dir)
        {
            
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            newX += pix;
            newY += pix;
            
                if (!collision(new Vector2(newX, newY), new wall(Vector2.Zero)))
                {

                    base.Movement(pix, dir);
                }
        }

        private float direction(float x1, float y1, float x2, float y2)
        {
            float difx = x1 - x2;
            float dify = y1 - y2;
            float adj = difx;
            float oop = dify;
            float tan = oop / adj;
            float res = MathHelper.ToDegrees((float)Math.Atan2(oop, adj));
            res = (res - 180) % 360;
            if (res < 0)
            {
                res += 360;
            }

            return res;
        }


        public void damage(int dmg)
        {
            health -= dmg;
        }


    }
}