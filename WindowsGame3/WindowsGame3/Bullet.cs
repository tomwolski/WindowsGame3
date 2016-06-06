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
    class Bullet :Obj
    {
        public const int ConstbulletDistance = 500;
        public static int bulletDistance = 500;
        private int damagedelt;
        public static int gundamage = 1;
        public const int Constgundamage = 1;
        public static string Gunname = "yellowBall";
        
        
        
       

        public Bullet(Vector2 pos, int damagedelt): base(pos)
        {
            
            position = pos;
            this.spriteName = Gunname;
            this.damagedelt = damagedelt;
            
        }
        
        public int damage
        {
            set {
                damagedelt = value;
            }
            get{
                return damagedelt;
            }
        }



        public override void move()
        {
            
            if (!alive) 
            { 
                return; 
            }
            //hit wall
            if (collision(new Vector2(-5, 0), new wall(new Vector2(0, 0))))
            {
                
                alive = false;
            }

            else if (collision(new Vector2(5, 0), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }

            else if (collision(new Vector2(0, 5), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }

            else if (collision(new Vector2(0, -5), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }
            // hits breakablewall
            
            if (collision(new Vector2(-11, 0), new breakablewall(new Vector2(0, 0))))
            {
                alive = false;
                Obj wa = collision(new breakablewall(new Vector2(0, 0)));
                if (wa.GetType() == typeof(breakablewall))
                {
                    
                    breakablewall w = (breakablewall)wa;
                    alive = false;
                    w.damage(gundamage);
                }
               
            }

            //hits enemy
            Obj o = collision ( new Enemy(new Vector2(0,0)));
            if (o.GetType()== typeof(Enemy))
            {
                Enemy e = (Enemy)o;
                alive = false;

                e.damage(gundamage);
            }

            //hits enemy2
            Obj o2 = collision(new Enemy2(new Vector2(0, 0)));
            if (o2.GetType() == typeof(Enemy2))
            {
                Enemy2 e2 = (Enemy2)o2;
                alive = false;

                e2.damage(gundamage);
            }

            //hits enemy3
            Obj o3 = collision(new Enemy3(new Vector2(0, 0)));
            if (o3.GetType() == typeof(Enemy3))
            {
                Enemy3 e3 = (Enemy3)o3;
                alive = false;

                e3.damage(gundamage);
            }

            //del bullet if outside the set distance

            if (Vector2.Distance(position, MainPlayer.Player.position) > bulletDistance)
          
            {
                alive = false;
            }
            base.move();
        }
    }
}
