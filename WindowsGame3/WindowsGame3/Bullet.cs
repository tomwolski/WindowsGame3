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
  Bullet :Obj

    NAME

            Bullet - A class that is in charge of Determining the attributes of a Bullet object.

    SYNOPSIS
     
        ConstbulletDistance - A constant integer that always keeps the Basic Distance a Bullet can travel from the MainPlayer
          bulletDistance - A static integer that can be changed based on which gun object has been picked up that also represents the Basic Distance a Bullet can travel from the MainPlayer
          damagedelt - A private integer that sets the total amount of damage the specific Bullet object has.
          gundamage - A static integer that can be changed based on which gun object has been picked up, represents the amount of damage that each Bullet does.
          Constgundamage - A constant integer that always keeps the Basic damage a Bullet can do
        public static string Gunname = "yellowBall";
     

    DESCRIPTION

 
            This class will attempt to Represent the Bullet object. Every time a Bullet object it will be created using the
            attributes defined :
                    Solid  - True
                    position - pos (Will be a zero vector until the Bullet is created)
                    spritename - yellowBall ( the Reference to the WindowsGame3Content picture)
                    damagedelt - the total amount of damage the specific Bullet object has
            The bullet will then travel in the detection shot checking if there is a collision with another object specified in the game or has reached    
            its maximum distance traveled before making it self not alive anymore.
     

    AUTHOR

            Thomas Wolski 

    DATE

            7:00pm 8/9/2016

    */
    /**/
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
        // a Get and Set for the damage to be done by the bullet created
        public int damage
        {
            set {
                damagedelt = value;
            }
            get{
                return damagedelt;
            }
        }


 
        /**/
        /*
             move

        NAME

                move - A function called when the game has determined that game logic needs to be processed. 
                This includes change of the game state,  processing user input, updating of simulation data. 
                Overrided this method with game-specific logic.

        SYNOPSIS
     
               Zero arguments passed
     

        DESCRIPTION

                    When this Function is called it will first check if Bullet object attribute alive is true. if it is not it will be return 
                    saving time and increasing performance. Next it check if the Bullet object has come in connect with the side of a wall object. 
                    To ensure the bullet object becomes set to not alive faster when coming in contact with the wall it checks and see's if it has 
                    hit either side of the wall. If the Bullet does not come in contact with a wall it then will check next if the Bullet has come in contact 
                    with a breakablewall. If this is true then the bullet's alive attribute will be set to false, while the breakablewall object will get its
                    health reduced by that amount. Then the Bullet object will check if it collides with an enemy object. There are three different types of 
                    enemies in the game, this means that it checks one at a time checking for a collision, if a collision occurs between the Bullet object and 
                    any one of the enemies the Bullet attribute once again will be set to false while dealing that much damage to that specific enemy object.
                    Lastly it will check if the distance of the bullet and the MainPlayer. If position of the MainPlayer and the bullet is larger then the
                    max distance that Bullet can go it will then set the alive attribute to false, the distance will vary based on what gun type is being used.

        AUTHOR

                Thomas Wolski 

        DATE

                7:30pm 8/9/2016

        */
        /**/
        public override void Move()
        {
            
            if (!alive) 
            { 
                return; 
            }
            //hit wall
            if (Collision(new Vector2(-11, 0), new wall(new Vector2(0, 0))))
            {
                
                alive = false;
            }

            else if (Collision(new Vector2(11, 0), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }

            else if (Collision(new Vector2(0, 11), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }

            else if (Collision(new Vector2(0, -11), new wall(new Vector2(0, 0))))
            {

                alive = false;
            }
            // hits breakablewall

            if (Collision(new Vector2(0, 0), new breakablewall(new Vector2(0, 0))))
            {
                alive = false;
                Obj wa = Collision(new breakablewall(new Vector2(0, 0)));
                if (wa.GetType() == typeof(breakablewall))
                {
                    
                    breakablewall w = (breakablewall)wa;
                    w.Damage(gundamage);
                }
               
            }

            //hits enemy
            Obj o = Collision(new Enemy(new Vector2(0, 0)));
            if (o.GetType()== typeof(Enemy))
            {
                Enemy e = (Enemy)o;
                alive = false;

                e.Damage(gundamage);
            }

            //hits enemy2
            Obj o2 = Collision(new Enemy2(new Vector2(0, 0)));
            if (o2.GetType() == typeof(Enemy2))
            {
                Enemy2 e2 = (Enemy2)o2;
                alive = false;

                e2.damage(gundamage);
            }

            //hits enemy3
            Obj o3 = Collision(new Enemy3(new Vector2(0, 0)));
            if (o3.GetType() == typeof(Enemy3))
            {
                Enemy3 e3 = (Enemy3)o3;
                alive = false;

                e3.Damage(gundamage);
            }

            //del bullet if outside the set distance

            if (Vector2.Distance(position, MainPlayer.Player.position) > bulletDistance)
          
            {
                alive = false;
            }

            //give control to xna ,letting it know I am done with the update 
            base.Move();
        }
    }
}
