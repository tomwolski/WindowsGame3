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
    class Enemy3 : Obj
    {

       
        private int health;
        static public float enemeyspd3 = 1.5f;

        private const  int MaxHp = 1;
        private int damagedelt;

        static public int hitTimer3 = 0;
        static public int hitTime3 = 60;

        static public int SnakesKilled = 0;
        /**/
        /*
        MainPlayer : Obj

        NAME

                Enemy3 - A class that is in charge of when and were a Enemy3 object is created.

        SYNOPSIS
     
        health - the amount of health each Enemy3 object has
        enemeyspd1  - the speed of the Enemy3 object
        MaxHp - the health of the each Enemy3 object as it is created
        damagedelt - the amount of damage each Enemy3 object deals to the Mainplayer
        hitTimer3 - the total amount of seconds until the mainplayer can be hit again
        hitTime3 -the moment it takes for the Enemy3 object to be able to hit the Mainplayer after already hitting the mainplayer
        DogsKilled - the total number of Enemy3 objects killed
     

        DESCRIPTION
            This class will attempt to create a Enemy3 object at a random location. The Enemy3
            is given the following attributes:
            position - the location it will be created on the canvas
            spriteName = "Snake" ( the Reference to the WindowsGame3Content picture) 
            solid - can be passed through
            alive - can be killed
            health - the current amount of health the sprite has 
            damagedelt -the amount of damage each Enemy3 object deals to the Mainplayer
    

        AUTHOR

                Thomas Wolski 

        DATE

               10:30pm 8/14/2016

        */
        /**/
        public Enemy3(Vector2 pos)
            : base(pos)
        {

            position = pos;
            spriteName = "Snake";
            solid = false;
            alive = true;
            health = 1;
            damagedelt = 30;
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

                    When this function is called it updates the Enemy3. If there are no Enemy3 objects alive
                    the program will then return, else it will increase the timer and call the Hitplayer function.
                    After it will check if the Enemy3 health has gone less then or below zero. if so the kill counts 
                    will be increased. Also if the player is still alive in the end. The sprite rotation and direction will be updated 
        AUTHOR

                Thomas Wolski 

        DATE

                10:35pm 8/14/2016

        */
        /**/
        public override void Move()
        {
            if (!alive)
            {
                return;
            }
            hitTimer3++;
            Hitplayer();

            if (health <= 0)
            {
                Game1.Death3.Play();
                alive = false;
                // error need 2 reset hp for each Enemy3
                health = MaxHp;
                Game1.KillCount++;
                SnakesKilled++;

            }

            rotation = Direction(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y);
            speed = enemeyspd3;



            base.Move();
        }
        /**/
        /*
             Hitplayer

        NAME

                Hitplayer - A function called when an Enemy3 comes in distance with the mainplayer

        SYNOPSIS   

        DESCRIPTION

                    When this Function is called it first checks if the main player's distance is less then 32 pixels ( the size of the main player)
                    away from then Enemy3 object and also it is alive. If it is alive and the hit timer is greater then hit-time, the timer will be
                    reset and the Mainplayer will be dealt the specified damage. Also the enemy will receive 1 damage from the mainplayer.
         
                    
        AUTHOR

                Thomas Wolski 

        DATE

                10:40pm 8/14/2016

        */
        /**/
        private void Hitplayer()
        {
            if (Distance(position.X, position.Y, MainPlayer.Player.position.X, MainPlayer.Player.position.Y) < 32)
            {


                if (hitTimer3 > hitTime3)
                {
                    hitTimer3 = 0;
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

               10:50pm 8/14/2016

        */
        /**/
        public float Distance(float x1, float y1, float x2, float y2)
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

               10:50pm 8/14/2016

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

               10:55pm 8/14/2016

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

        // When the enemy3 takes damage, it subtracts the specific damage 
        public void Damage(int dmg)
        {
            health -= dmg;
        }


    }
}
