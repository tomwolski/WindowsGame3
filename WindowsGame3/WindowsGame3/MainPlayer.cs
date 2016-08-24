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
        public const int StanderedmaxAmmo = 10;
        public const int Standeredammo = 10;
        public const float Standeredrate = 10;
        public const int StanderedfireTimer = 0;

        public const int maxhp = 100;
        public float hp;

        public static bool shoottwo = false;
        public static bool shootthree = false;
        public static bool shootfive = false;

        public static MainPlayer Player;
        /**/
        /*
        MainPlayer : Obj

        NAME

                MainPlayer - A class that is in charge of when and were a MainPlayer object.

        SYNOPSIS
     
        spd - the speed of the mainplayer
        bspd - The speed of the bullet
        maxAmmo - the max amount of ammo for the default gun
        ammo - the amount of bullets shot 
        rate - how fast the bullets shoot one after the other
        fireTimer -puts a delay between each shot
        Standeredbspd - a constant bullet speed
        StanderedmaxAmmo - a constant to keep the max ammo
        Standeredammo = a constant to keep how many shots fired before reseting
        Standeredrate - a constant to keep the default fire rate
        StanderedfireTimer - a constant to keep the fire rate between bullets
        maxhp - a constant for the total health for reseting 
        hp - the current amount of health the sprite has 
        shoottwo - a bool to decide if two bullets should be shot
        shootthree - a bool to decide if three bullets should be shot
        shootfive - a bool to decide if five bullets should be shot
     

        DESCRIPTION
                This class will attempt to create a MainPlayer object at the starting location 150,400. The Mainplayer
                is given the following attributes:
                position - the location it will be created on the canvas
                spd - how fast the MainPlayer object can move
                spriteName = "duckfromabove" ( the reference to the WindowsGame3Content picture)           
                Player - the one specific sprite to be referenced 
                hp - the current amount of health the sprite has 
 
    

        AUTHOR

                Thomas Wolski 

        DATE

               8:00pm 8/14/2016

        */
        /**/
        public MainPlayer(Vector2 pos) : base (pos)
        {
            position = new Vector2(150, 400);
            spd = 2f;
            spriteName = "duckfromabove";
            Player = this;
            hp = 100;
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

                    When this function is called it updates the mainplayer. If a key is pressed that corresponds to
                    w,a,s or d then the mainPlayer will move in that direction depending if there is no collision 
                    with a wall or a breakablewall. After checking if there is no collision it will then check if the 
                    Mainplayer has a collision with a speedblock or a slowblock this will decrease or increase the speed
                    that the mainCharacter is moving. Then it will check if the ammo count has become less then or equal 
                    to zero. If it has all the guns attributes will be reset to the default. Then a check to call 
                    the type of shoot will be set for the gun. After it will lastly check if the Mainplayers health has
                    become less then or equal to zero. If so the game will change back to the menu and reset the game,
                    setting everything that was alive to dead. Lastly the music will change back to the menu music.
                    Also if the player is still alive in the end. The sprite rotation and direction will be updated.
        AUTHOR

                Thomas Wolski 

        DATE

                9:00pm 8/14/2016

        */
        /**/
        public override void Move()
        {
            Player = this;
            if (!alive) {
                return; 
            }
            
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !Collision(new Vector2(0, -spd), new wall(new Vector2(0, 0))) && !Collision(new Vector2(0, -spd), new breakablewall(new Vector2(0, 0))))
            {

                if (Collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.Y -= spd;

                }

                else if (Collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
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
            if (keyState.IsKeyDown(Keys.A) && !Collision(new Vector2(-spd, 0), new wall(new Vector2(0, 0))) && !Collision(new Vector2(-spd, 0), new breakablewall(new Vector2(0, 0))))
            {

                if (Collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.X -= spd;

                }
                else if (Collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
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
            if (keyState.IsKeyDown(Keys.S) && !Collision(new Vector2(0, spd), new wall(new Vector2(0, 0))) && !Collision(new Vector2(0, spd), new breakablewall(new Vector2(0, 0))))
            {
                if (Collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.Y += spd;

                }
                else if (Collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
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
            if (keyState.IsKeyDown(Keys.D) && !Collision(new Vector2(spd, 0), new wall(new Vector2(0, 0))) && !Collision(new Vector2(spd, 0), new breakablewall(new Vector2(0, 0))))
            {
                if (Collision(new Vector2(0, 0), new slowBlock(new Vector2(0, 0))))
                {
                    spd = 1f;
                    position.X += spd;

                }
                else if (Collision(new Vector2(0, 0), new speedBlock(new Vector2(0, 0))))
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
                MainMenu.LoadingTime();
                Game1.musicchange2 = true;
                items.Reset();
                items.Restart();
                
            }

            rotation = Direction(Camera.XYFromMap(position).X, Camera.XYFromMap(position).Y, mouse.X, mouse.Y);


            prevkeyboard = keyState;
            prevousmouse = mouse;
            base.Move();
            }




        /**/
        /*
             ShootType

        NAME

                ShootType - determines the number of bullets to be shot.

        SYNOPSIS

        DESCRIPTION

                    When this function is called  it determines how many bullets are going to be shot based on 
                    the bool values that are set. Each time the fire time has become greater then the rate,
                    the fire-time is reset back to zero. After it then selects which shoot function is to be called.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                9:10pm 8/14/2016

        */
        /**/
        public void ShootType()
        {
           
            if (fireTimer >rate)
            {
                fireTimer = 0;
                if (!shoottwo && !shootthree && !shootfive)
                {
                    Shoot();
                }

                if (shoottwo)
                {
                    ShootMulti(5);
                    ShootMulti(-5);
                 
                }

                if (shootthree)
                {
                    ShootMulti(0);
                    ShootMulti(-30);
                    ShootMulti(30);
                }
                if (shootfive)
                {
                    ShootMulti(0);
                    ShootMulti(-10);
                    ShootMulti(10);
                    ShootMulti(-20);
                    ShootMulti(20);
                }

            }
        }
        /**/
        /*
             Shoot

        NAME

                Shoot - determines the number of bullets to be shot.

        SYNOPSIS

        DESCRIPTION

                    When this function is called it first subtracts a bullet from the ammo. After 
                    it then creates a bullet at the main players location and rotation.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                9:00pm 8/14/2016

        */
        /**/
        private void Shoot()
        {
            ammo --;
            foreach( Obj o in items.objList )
            {
                 if(o.GetType()== typeof (Bullet) && !o.alive)
                 {
                     Bullet b = (Bullet)o;
                     b.position.X = position.X ;
                     b.position.Y = position.Y ;
                     b.rotation = rotation;


                     b.UpdateArea();
                     b.speed = bspd;
                     b.alive = true;
                     b.damage = Bullet.gundamage;
                     break;
                 }

            }
        }

        /**/
        /*
             Shoot

        NAME

                angle - The angle that offsets the bullets rotation on creation.

        SYNOPSIS

        DESCRIPTION

                    When this function is called it first subtracts a bullet from the ammo. After 
                    it then creates a bullet at the main players location and rotation plus the given angle.
                    
        AUTHOR

                Thomas Wolski 

        DATE

                9:20pm 8/14/2016

        */
        /**/
        private void ShootMulti(int angle)
        {
            ammo--;
            foreach (Obj o in items.objList)
            {
                if (o.GetType() == typeof(Bullet) && !o.alive)
                {
                    Bullet b = (Bullet)o;
                    b.position.X = position.X ;
                    b.position.Y = position.Y ;
                    b.rotation = rotation + angle;

 

                    b.UpdateArea();
                    b.speed = bspd;
                    b.alive = true;
                    b.damage = Bullet.gundamage;
                    break;
                }

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

                9:25pm 8/14/2016

        */
        /**/
    private float Direction(float x1, float y1 ,float x2 ,float y2)
    {
        float difx =   x1 - x2;
        float dify = y1 - y2;
        float adj = difx;
        float oop = dify;
        float tan = oop / adj;
        float rot = MathHelper.ToDegrees((float)Math.Atan2(oop ,adj));
        rot = (rot - 180) % 360;
        if (rot < 0) 
        {
            rot += 360;
        }


        return rot;
    }
     // When the player takes damage, it subtracts the specific damage dealt to the mainplayer
    public void Damage(int damagedelt)
    {
        hp -= damagedelt;
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

            9:35pm 8/14/2016

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

    }

}
