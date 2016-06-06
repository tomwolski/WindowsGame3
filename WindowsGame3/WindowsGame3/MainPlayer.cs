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
    class MainPlayer :Obj
    {
       
        KeyboardState prevkeyboard;
        MouseState prevousmouse;

        float spd;
        public static float bspd = 20;
        public static  int maxAmmo = 50;
        public static int ammo = 10;
        public static float rate = 10;
        public static int fireTimer = 0;


        public const float Standeredbspd = 20;
        public const int StanderedmaxAmmo = 500;
        public const int Standeredammo = 10;
        public const float Standeredrate = 10;
        public const int StanderedfireTimer = 0;

        public const int maxhp = 100;
        public float hp;

        public static bool shoottwo = false;
        public static bool shootthree = false;
        public static bool shootfive = false;

        public static MainPlayer Player;

        public MainPlayer(Vector2 pos) : base (pos)
        {
            position = new Vector2(150, 400);
            spd = 2f;
            spriteName = "duckfromabove";
            Player = this;
            hp = 100;
        }

        public override void move()
        {
            Player = this;
            if (!alive) {
                return; 
            }
            
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !collision(new Vector2(0, -spd), new wall(new Vector2(0, 0))) && !collision(new Vector2(0, -spd), new breakablewall(new Vector2(0, 0))))
            {

                if (collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.Y -= spd;

                }

                else if (collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
                {
                    spd = 3f;
                    position.Y -= spd;

                }
                else
                {
                    spd = 2f;
                    position.Y -= spd;
                }
      
            }
            if (keyState.IsKeyDown(Keys.A) && !collision(new Vector2(-spd, 0), new wall(new Vector2(0, 0))) && !collision(new Vector2(-spd, 0), new breakablewall(new Vector2(0, 0))))
            {

                if (collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.X -= spd;

                }
                else if (collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
                {
                    spd = 3f;
                    position.X -= spd;

                }
                else
                {
                    spd = 2f;
                    position.X -= spd;
                }
               
            }
            if (keyState.IsKeyDown(Keys.S) && !collision(new Vector2(0, spd), new wall(new Vector2(0, 0))) && !collision(new Vector2(0, spd), new breakablewall(new Vector2(0, 0))))
            {
                if (collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.Y += spd;

                }
                else if (collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
                {
                    spd = 3f;
                    position.Y += spd;

                }

                else
                {
                    spd = 2f;
                    position.Y += spd;
                }    
            }
            if (keyState.IsKeyDown(Keys.D) && !collision(new Vector2(spd, 0), new wall(new Vector2(0, 0))) && !collision(new Vector2(spd, 0), new breakablewall(new Vector2(0, 0))))
            {
                if (collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.X += spd;

                }
                else if (collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
                {
                    spd = 3f;
                    position.X += spd;

                }

                else
                {
                    spd = 2f;
                    position.X += spd;
                }
            }



            if (ammo <= 0)
            {

              MainPlayer.bspd =  Standeredbspd;
              MainPlayer.maxAmmo =   StanderedmaxAmmo ;
              MainPlayer.ammo =  Standeredammo; 
              MainPlayer.rate =  Standeredrate ;
              MainPlayer.fireTimer = StanderedfireTimer;
              Bullet.bulletDistance = Bullet.ConstbulletDistance;
              Bullet.gundamage = Bullet.Constgundamage;
              MainPlayer.shoottwo = false;
              MainPlayer.shootthree = false;
              MainPlayer.shootfive = false;
        
            }
            

            fireTimer++;
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                ShootType();
            }


            if (hp <= 0)
            {
               
                Game1.PlayerDead.Play();
                Game1.game = "Menu";
                Game1.musicchange2 = true;
                items.Reset();
                items.Restart();
                
            }

            rotation = direction(Camera.XYFromMap(position).X, Camera.XYFromMap(position).Y, mouse.X, mouse.Y);


            prevkeyboard = keyState;
            prevousmouse = mouse;
            base.move();
            }



      

        public void ShootType()
        {
           
            if (fireTimer >rate)
            {
                fireTimer = 0;
                if (!shoottwo && !shootthree && !shootfive)
                {
                    shoot();
                }

                if (shoottwo)
                {
                    shootMulti(5);
                    shootMulti(-5);
                 
                }

                if (shootthree)
                {
                    shootMulti(0);
                    shootMulti(-30);
                    shootMulti(30);
                }
                if (shootfive)
                {
                    shootMulti(0);
                    shootMulti(-10);
                    shootMulti(10);
                    shootMulti(-20);
                    shootMulti(20);
                }

            }
        }

        private void shoot()
        {
            ammo --;
            foreach( Obj o in items.objList )
            {
                 if(o.GetType()== typeof (Bullet) && !o.alive)
                 {
                     Bullet b = (Bullet)o;
                     b.position.X = position.X + 12;
                     b.position.Y = position.Y + 12;
                     b.rotation = rotation;

                     if (rotation >= 180)
                     {
                         b.position.X = position.X ;
                         b.position.Y = position.Y + 12;
                     }
                     if (rotation < 180)
                     {
                         b.position.X = position.X;
                         b.position.Y = position.Y + 12;
                     }
                     if (rotation < 90)
                     {
                         b.position.X = position.X + 12;
                         b.position.Y = position.Y ;
                     }
                     if (rotation > 250)
                     {
                         b.position.X = position.X -12;
                         b.position.Y = position.Y ;
                     }
                     if (rotation > 320)
                     {
                         b.position.X = position.X ;
                         b.position.Y = position.Y - 12;
                     }

                     if (rotation < 30)
                     {
                         b.position.X = position.X ;
                         b.position.Y = position.Y - 12;
                     } 

                     b.UpdateArea();
                     b.speed = bspd;
                     b.alive = true;
                     b.damage = Bullet.gundamage;
                     break;
                 }

            }
        }


        private void shootMulti(int angle)
        {
            ammo--;
            foreach (Obj o in items.objList)
            {
                if (o.GetType() == typeof(Bullet) && !o.alive)
                {
                    Bullet b = (Bullet)o;
                    b.position.X = position.X + 12;
                    b.position.Y = position.Y + 12;
                    b.rotation = rotation + angle;

                    if (rotation >= 180)
                    {
                        b.position.X = position.X;
                       b.position.Y = position.Y + 12;
                    }
                    if (rotation < 180)
                    {
                        b.position.X = position.X;
                        b.position.Y = position.Y + 12;
                    }
                    if (rotation < 90)
                    {
                       b.position.X = position.X + 12;
                        b.position.Y = position.Y;
                   }
                    if (rotation > 250)
                    {
                        b.position.X = position.X - 12;
                        b.position.Y = position.Y;
                    }
                    if (rotation > 320)
                    {
                        b.position.X = position.X;
                        b.position.Y = position.Y - 12;
                    }

                    if (rotation < 30)
                    {
                        b.position.X = position.X;
                       b.position.Y = position.Y - 12;
                    }

                    b.UpdateArea();
                    b.speed = bspd;
                    b.alive = true;
                    b.damage = Bullet.gundamage;
                    break;
                }

            }
        }



    private float direction(float x1, float y1 ,float x2 ,float y2)
    {
        float difx =   x1 - x2;
        float dify = y1 - y2;
        float adj = difx;
        float oop = dify;
        float tan = oop / adj;
        float res = MathHelper.ToDegrees((float)Math.Atan2(oop ,adj));
        res = (res - 180)% 360;
        if (res < 0) 
        { 
        res += 360;
        }
        

        return res;
    }

    public void damage(int damagedelt)
    {
        hp -= damagedelt;
    }


    public static float distance(float x1, float y1, float x2, float y2)
    {
        float xRectangle = (x1 - x2) * (x1 - x2);
        float yRectangle = (y1 - y2) * (y1 - y2);
        double zRectangle = xRectangle + yRectangle;
        float dist = (float)Math.Sqrt(zRectangle);
        return dist;

    }

    }

}
