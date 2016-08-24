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
    class Enemy2 : Obj
    {

        
        int health;
        static public float enemeyspd2 = 0.5f;

        const int MaxHp = 5;
        private int damagedelt;

        static public int hitTimer2 = 0;
        static public int hitTime2 = 60;

        static public int FudKilled = 0;
        /**/
        /*
        MainPlayer : Obj

        NAME

                Enemy2 - A class that is in charge of when and were a Enemy2 object is created.

        SYNOPSIS
     
        health - the amount of health each Enemy2 object has
        enemeyspd2  - the speed of the Enemy2 object
        MaxHp - the health of the each Enemy2 object as it is created
        damagedelt - the amount of damage each Enemy2 object deals to the Mainplayer
        hitTimer2 - the total amount of seconds until the mainplayer can be hit again
        hitTime2 -the moment it takes for the Enemy2 object to be able to hit the Mainplayer after already hitting the mainplayer
        FudKilled - the total number of Enemy2 objects killed
     

        DESCRIPTION
            This class will attempt to create a Enemy2 object at a random location. The Enemy2
            is given the following attributes:
            position - the location it will be created on the canvas
            spriteName = "enemysprite" ( the Reference to the WindowsGame3Content picture) 
            solid - can be passed through
            alive - can be killed
            health - the current amount of health the sprite has 
            damagedelt -the amount of damage each Enemy2 object deals to the Mainplayer
    

        AUTHOR

                Thomas Wolski 

        DATE

               10:00pm 8/14/2016

        */
        /**/
        public Enemy2(Vector2 pos)
            : base(pos)
        {

            position = pos;
            spriteName = "enemysprite";
            solid = false;
            alive = true;
            health = 5;
            damagedelt = 5;
        }
        /**/
        /*
             move

        NAME

                move - A function called when the game has determined that game logic needs to be processed. 
                This includes change of the game state,  processing user input, updating of simulation data. 
                Overrided this method with game-specific logic.

        SYNOPSIS

        DESCRIPTION

                    When this function is called it updates the Enemy2. If there are no enemy2 objects alive
                    the program will then return, else it will increase the timer and call the Hitplayer function.
                    After it will check if the enemy2 health has gone less then or below zero. if so the kill counts 
                    will be increased. Also if the player is still alive in the end. The sprite rotation and direction will be updated 
        AUTHOR

                Thomas Wolski 

        DATE

                10:10pm 8/14/2016

        */
        /**/
        public override void Move()
        {
            if (!alive)
            {
                return;
            }
            hitTimer2++;
            Hitplayer();

            if (health <= 0)
            {
                Game1.Death2.Play();
                alive = false;
                // error need 2 reset hp for each enemy
                health = MaxHp;
                Game1.KillCount++;
                FudKilled++;
            }

            rotation = Direction(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y);
            speed = enemeyspd2;



            base.Move();
        }
        /**/
        /*
             Hitplayer

        NAME

                Hitplayer - A function called when an enemy2 comes in distance with the mainplayer

        SYNOPSIS   

        DESCRIPTION

                    When this Function is called it first checks if the main player's distance is less then 32 pixels ( the size of the main player)
                    away from then enemy2 object and also it is alive. If it is alive and the hit timer is greater then hit-time, the timer will be
                    reset and the Mainplayer will be dealt the specified damage. Also the enemy will receive 1 damage from the mainplayer.
         
                    
        AUTHOR

                Thomas Wolski 

        DATE

                10:00pm 8/14/2016

        */
        /**/
        private void Hitplayer()
        {
            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32)
            {


                if (hitTimer2 > hitTime2)
                {
                    hitTimer2 = 0;
                    MainPlayer.Player.Damage(damagedelt);
                    health = health - 1;
                }
            }
        }

        /**/
        /*
             Distance

        NAME

                Distance - A function called to determine how far away one object is to another object.

        SYNOPSIS   

        DESCRIPTION

                    When this Function is called it takes the x position from one object and the x position of another object
                    to form a new x^2 position and takes the y position from one object and the y position from 
                    another object to form a new y^2 position After then it takes the Sqrt of the two added together to get
                    the distance between the two objects. (Pythagorean theorem)
                   
                    
        AUTHOR

                Thomas Wolski 

        DATE

                9:45pm 8/14/2016

        */
        /**/
        private float Distance(float x1, float y1, float x2, float y2)
        {
            float xRectangle = (x1 - x2) * (x1 - x2);
            float yRectangle = (y1 - y2) * (y1 - y2);
            double zRectangle = xRectangle + yRectangle;
            float dist = (float)Math.Sqrt(zRectangle);
            return dist;

        }
        /**/
        /*
      Movement

        NAME

                Movement - moves the object with the specified arguments

        SYNOPSIS
            
            pix - the speed of the object
            dir - the rotation of the object
           

        DESCRIPTION
                This function moves the object by taking the pix value and increasing the x coordinate and y coordinate by that many pixels while multiplying
                by the x and y rotation to get the new positions for that spite.


        AUTHOR

                Thomas Wolski 

        DATE

               10:05pm 8/14/2016

        */
        /**/
        public override void Movement(float pix, float dir)
        {

            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            newX += pix;
            newY += pix;

            if (!Collision(new Vector2(newX, newY), new wall(Vector2.Zero)))
            {

                base.Movement(pix, dir);
            }
        }
        /**/
        /*
             Direction

        NAME

                Direction - the rotation of the character

        SYNOPSIS
                    x1 - x coordinate of the sprite on the canvas
                    y1 - y coordinate of the sprite on the canvas
                    x2 - the x coordinate of another sprite on the canvas
                    y1 -the y coordinate of another sprite on the canvas
        DESCRIPTION

                    When this function is called it will return rotation of the current object based on another object.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                10:10pm 8/14/2016

        */
        /**/
        private float Direction(float x1, float y1, float x2, float y2)
        {
            float difx = x1 - x2;
            float dify = y1 - y2;
            float adj = difx;
            float oop = dify;
            float tan = oop / adj;
            float rot = MathHelper.ToDegrees((float)Math.Atan2(oop, adj));
            rot = (rot - 180) % 360;
            if (rot < 0)
            {
                rot += 360;
            }

            return rot;
        }

        // When the enemy2 takes damage, it subtracts the specific damage 
        public void damage(int dmg)
        {
            health -= dmg;
        }


    }
}
