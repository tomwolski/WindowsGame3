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
    class items : Obj
    {
 
        public static List<Obj> objList = new List<Obj>(); // list of all the objects for items


        /**/
        /*
             Init

        NAME
            Init -  initialize all the game variables before the game runs

        SYNOPSIS
 
     

        DESCRIPTION
               Allows the game to perform any initialization it needs to before starting to run.
               This is where it can query for any required services and load any non-graphic
               related content.  Calling base.Initialize will enumerate through any components
               and initialize them as well. Here we initialize the all the games objects and that 
               are going to be used throughout the game. Depending on which object is created first
               thats how they are going to be layered on the screen when overlapping.
 

        AUTHOR

                Thomas Wolski 

        DATE

                8:00pm 8/15/2016

        */
        /**/
        public static void Init()
        {

            objList.Clear();
            // --- top wall

            objList.Add(new wall(new Vector2(-800, 32)));
            objList.Add(new wall(new Vector2(-768, 32)));
            objList.Add(new wall(new Vector2(-736, 32)));
            objList.Add(new wall(new Vector2(-704, 32)));
            objList.Add(new wall(new Vector2(-672, 32)));
            objList.Add(new wall(new Vector2(-640, 32)));
            objList.Add(new wall(new Vector2(-608, 32)));
            objList.Add(new wall(new Vector2(-576, 32)));
            objList.Add(new wall(new Vector2(-544, 32)));
            objList.Add(new wall(new Vector2(-512, 32)));
            objList.Add(new wall(new Vector2(-480, 32)));
            objList.Add(new wall(new Vector2(-448, 32)));
            objList.Add(new wall(new Vector2(-416, 32)));
            objList.Add(new wall(new Vector2(-384, 32)));
            objList.Add(new wall(new Vector2(-352, 32)));
            objList.Add(new wall(new Vector2(-320, 32)));
            objList.Add(new wall(new Vector2(-288, 32)));
            objList.Add(new wall(new Vector2(-256, 32)));
            objList.Add(new wall(new Vector2(-224, 32)));
            objList.Add(new wall(new Vector2(-192, 32)));
            objList.Add(new wall(new Vector2(-160, 32)));
            objList.Add(new wall(new Vector2(-128, 32)));
            objList.Add(new wall(new Vector2(-96, 32)));
            objList.Add(new wall(new Vector2(-64, 32)));
            objList.Add(new wall(new Vector2(-32, 32)));

            objList.Add(new wall(new Vector2(0, 32)));

            objList.Add(new wall(new Vector2(768, 32)));
            objList.Add(new wall(new Vector2(736, 32)));
            objList.Add(new wall(new Vector2(704, 32)));
            objList.Add(new wall(new Vector2(672, 32)));
            objList.Add(new wall(new Vector2(640, 32)));
            objList.Add(new wall(new Vector2(608, 32)));
            objList.Add(new wall(new Vector2(576, 32)));
            objList.Add(new wall(new Vector2(544, 32)));
            objList.Add(new wall(new Vector2(512, 32)));
            objList.Add(new wall(new Vector2(480, 32)));
            objList.Add(new wall(new Vector2(448, 32)));
            objList.Add(new wall(new Vector2(416, 32)));
            objList.Add(new wall(new Vector2(384, 32)));
            objList.Add(new wall(new Vector2(352, 32)));
            objList.Add(new wall(new Vector2(320, 32)));
            objList.Add(new wall(new Vector2(288, 32)));
            objList.Add(new wall(new Vector2(256, 32)));
            objList.Add(new wall(new Vector2(224, 32)));
            objList.Add(new wall(new Vector2(192, 32)));
            objList.Add(new wall(new Vector2(160, 32)));
            objList.Add(new wall(new Vector2(128, 32)));
            objList.Add(new wall(new Vector2(96, 32)));
            objList.Add(new wall(new Vector2(64, 32)));
            objList.Add(new wall(new Vector2(32, 32)));

            //----------left wall

            objList.Add(new wall(new Vector2(-800, 800)));
            objList.Add(new wall(new Vector2(-800, 768)));
            objList.Add(new wall(new Vector2(-800, 736)));
            objList.Add(new wall(new Vector2(-800, 704)));
            objList.Add(new wall(new Vector2(-800, 672)));
            objList.Add(new wall(new Vector2(-800, 640)));
            objList.Add(new wall(new Vector2(-800, 608)));
            objList.Add(new wall(new Vector2(-800, 576)));
            objList.Add(new wall(new Vector2(-800, 544)));
            objList.Add(new wall(new Vector2(-800, 512)));
            objList.Add(new wall(new Vector2(-800, 480)));
            objList.Add(new wall(new Vector2(-800, 448)));
            objList.Add(new wall(new Vector2(-800, 416)));
            objList.Add(new wall(new Vector2(-800, 384)));
            objList.Add(new wall(new Vector2(-800, 352)));
            objList.Add(new wall(new Vector2(-800, 320)));
            objList.Add(new wall(new Vector2(-800, 288)));
            objList.Add(new wall(new Vector2(-800, 256)));
            objList.Add(new wall(new Vector2(-800, 224)));
            objList.Add(new wall(new Vector2(-800, 192)));
            objList.Add(new wall(new Vector2(-800, 160)));
            objList.Add(new wall(new Vector2(-800, 128)));
            objList.Add(new wall(new Vector2(-800, 96)));
            objList.Add(new wall(new Vector2(-800, 64)));
 

            //--- Right wall


            objList.Add(new wall(new Vector2(800, 800)));
            objList.Add(new wall(new Vector2(800, 768)));
            objList.Add(new wall(new Vector2(800, 736)));
            objList.Add(new wall(new Vector2(800, 704)));
            objList.Add(new wall(new Vector2(800, 672)));
            objList.Add(new wall(new Vector2(800, 640)));
            objList.Add(new wall(new Vector2(800, 608)));
            objList.Add(new wall(new Vector2(800, 576)));
            objList.Add(new wall(new Vector2(800, 544)));
            objList.Add(new wall(new Vector2(800, 512)));
            objList.Add(new wall(new Vector2(800, 480)));
            objList.Add(new wall(new Vector2(800, 448)));
            objList.Add(new wall(new Vector2(800, 416)));
            objList.Add(new wall(new Vector2(800, 384)));
            objList.Add(new wall(new Vector2(800, 352)));
            objList.Add(new wall(new Vector2(800, 320)));
            objList.Add(new wall(new Vector2(800, 288)));
            objList.Add(new wall(new Vector2(800, 256)));
            objList.Add(new wall(new Vector2(800, 224)));
            objList.Add(new wall(new Vector2(800, 192)));
            objList.Add(new wall(new Vector2(800, 160)));
            objList.Add(new wall(new Vector2(800, 128)));
            objList.Add(new wall(new Vector2(800, 96)));
            objList.Add(new wall(new Vector2(800, 64)));
            objList.Add(new wall(new Vector2(800, 32)));


//-- bottom wall
            objList.Add(new wall(new Vector2(-768, 800)));
            objList.Add(new wall(new Vector2(-736, 800)));
            objList.Add(new wall(new Vector2(-704, 800)));
            objList.Add(new wall(new Vector2(-672, 800)));
            objList.Add(new wall(new Vector2(-640, 800)));
            objList.Add(new wall(new Vector2(-608, 800)));
            objList.Add(new wall(new Vector2(-576, 800)));
            objList.Add(new wall(new Vector2(-544, 800)));
            objList.Add(new wall(new Vector2(-512, 800)));
            objList.Add(new wall(new Vector2(-480, 800)));
            objList.Add(new wall(new Vector2(-448, 800)));
            objList.Add(new wall(new Vector2(-416, 800)));
            objList.Add(new wall(new Vector2(-384, 800)));
            objList.Add(new wall(new Vector2(-352, 800)));
            objList.Add(new wall(new Vector2(-320, 800)));
            objList.Add(new wall(new Vector2(-288, 800)));
            objList.Add(new wall(new Vector2(-256, 800)));
            objList.Add(new wall(new Vector2(-224, 800)));
            objList.Add(new wall(new Vector2(-192, 800)));
            objList.Add(new wall(new Vector2(-160, 800)));
            objList.Add(new wall(new Vector2(-128, 800)));
            objList.Add(new wall(new Vector2(-96, 800)));
            objList.Add(new wall(new Vector2(-64, 800)));
            objList.Add(new wall(new Vector2(-32, 800)));

            objList.Add(new wall(new Vector2(768, 800)));
            objList.Add(new wall(new Vector2(736, 800)));
            objList.Add(new wall(new Vector2(704, 800)));
            objList.Add(new wall(new Vector2(672, 800)));
            objList.Add(new wall(new Vector2(640, 800)));
            objList.Add(new wall(new Vector2(608, 800)));
            objList.Add(new wall(new Vector2(576, 800)));
            objList.Add(new wall(new Vector2(544, 800)));
            objList.Add(new wall(new Vector2(512, 800)));
            objList.Add(new wall(new Vector2(480, 800)));
            objList.Add(new wall(new Vector2(448, 800)));
            objList.Add(new wall(new Vector2(416, 800)));
            objList.Add(new wall(new Vector2(384, 800)));
            objList.Add(new wall(new Vector2(352, 800)));
            objList.Add(new wall(new Vector2(320, 800)));
            objList.Add(new wall(new Vector2(288, 800)));
            objList.Add(new wall(new Vector2(256, 800)));
            objList.Add(new wall(new Vector2(224, 800)));
            objList.Add(new wall(new Vector2(192, 800)));
            objList.Add(new wall(new Vector2(160, 800)));
            objList.Add(new wall(new Vector2(128, 800)));
            objList.Add(new wall(new Vector2(96, 800)));
            objList.Add(new wall(new Vector2(64, 800)));
            objList.Add(new wall(new Vector2(32, 800)));
            objList.Add(new wall(new Vector2(0, 800)));

 
            for (int i = 0; i < 100; i++)
            {
               
                Obj o = new Bullet(new Vector2(0,0), 0);
                o.alive = false;
                objList.Add(o);
            }

            // declares the spawning objects that spawn the other objects
            objList.Add(new Spawning(new Vector2(0, 0)));
            objList.Add(new Spawning2(new Vector2(0, 0)));
            objList.Add(new Spawning3(new Vector2(0, 0)));
            objList.Add(new BoxSpawning(new Vector2(0, 0)));
            objList.Add(new SpawnHeart(new Vector2(0, 0)));
            objList.Add(new SpawningSpeedBlock(new Vector2(0, 0)));
            objList.Add(new SpawnSlowBlock(new Vector2(0, 0)));
            objList.Add(new SpawnGun1(new Vector2(0, 0)));
            objList.Add(new SpawnGun2(new Vector2(0, 0)));
            objList.Add(new SpawnGun3(new Vector2(0, 0)));
            objList.Add(new SpawnGun4(new Vector2(0, 0)));
            objList.Add(new SpawnGun5(new Vector2(0, 0)));
            objList.Add(new SpawnGun6(new Vector2(0, 0)));

            // adds the specific amount of objects to the object list
            for (int i = 0; i < 10; i++)
            {

                speedBlock sp = new speedBlock(new Vector2(0, 0));
                sp.alive = false;
                objList.Add(sp);
            }
            for (int i = 0; i < 1; i++)
            {

                Gun4ShootFive g6 = new Gun4ShootFive(new Vector2(0, 0));
                g6.alive = false;
                objList.Add(g6);
            }
            for (int i = 0; i < 1; i++)
            {

                Gun4ShootThree g5 = new Gun4ShootThree(new Vector2(0, 0));
                g5.alive = false;
                objList.Add(g5);
            }

            for (int i = 0; i < 1; i++)
            {

                Gun4ShootTwo g4 = new Gun4ShootTwo(new Vector2(0, 0));
                g4.alive = false;
                objList.Add(g4);
            }

            for (int i = 0; i < 1; i++)
            {

                gun3 g3 = new gun3(new Vector2(0, 0));
                g3.alive = false;
                objList.Add(g3);
            }

            for (int i = 0; i < 1; i++)
            {

                gun2 g2 = new gun2(new Vector2(0, 0));
                g2.alive = false;
                objList.Add(g2);
            }

            for (int i = 0; i < 1; i++)
            {

                gun1 g1 = new gun1(new Vector2(0, 0));
                g1.alive = false;
                objList.Add(g1);
            }




            for (int i = 0; i < 20; i++)
            {

                slowBlock sl = new slowBlock(new Vector2(0, 0));
                sl.alive = false;
                objList.Add(sl);
            }
            for (int i = 0; i < 300; i++)
            {

              Enemy e = new Enemy(new Vector2(0, 0));
                e.alive = false;
                objList.Add(e);
            }

            for (int i = 0; i < 300; i++)
            {

                Enemy2 e2 = new Enemy2(new Vector2(0, 0));
                e2.alive = false;
                objList.Add(e2);
            }

            for (int i = 0; i < 300; i++)
            {

                Enemy3 e3 = new Enemy3(new Vector2(0, 0));
                e3.alive = false;
                objList.Add(e3);
            }

            for (int i = 0; i < 1000; i++)
            {

                breakablewall b = new breakablewall(new Vector2(0, 0));
                b.alive = false;
                
                objList.Add(b);
            }

            for (int i = 0; i < 500; i++)
            {
                Heart H = new Heart(new Vector2(0, 0));
                H.alive = false;
                objList.Add(H);
            }



            objList.Add(new MainPlayer(new Vector2(100, 100)));


        }
 

        
        // forced to make stuff static public for reset

        /**/
        /*
        wave1

        NAME

                Reset - A function that is called to reset all necessary variables in order for the game to be played again.

        SYNOPSIS
 

        DESCRIPTION

                This function uses the arguments that are creating though out the entire project to determine what has to be set back to default before
                changing the game-state to game. It takes every object created in the object list and restores there default values based on how they were declared
                After this function is used to set the score of the top 10 scores after the game come to an end making sure they are in the scores are in the correct order.
    

        AUTHOR

                Thomas Wolski 

        DATE

                8:10pm 8/10/2016

        */
        /**/

        public static void Reset()
        {
            
            foreach (Obj o in objList)
            {
                
                if (o.GetType() == typeof(Enemy) && o.alive)
                {
                    o.alive = false;
                   
                    Enemy.enemeyspd1 = 1;
                    Enemy.hitTime1 = 60;
                    Enemy.hitTimer1 = 0;
                  
                    Spawning.numberofGuys = 1;
                    Spawning.spawnTime1 = 60 * 1;
                    Spawning.spawnTimer1 = 0;
                    Spawning.waveTime1 = 600 * 1;
                    Spawning.waveTimer1 = 0;

                    Spawning.totalSpawned = 0;
                    Spawning.spawncheck1 = false;
                   
              
                }

                if (o.GetType() == typeof(Enemy2) && o.alive)
                {

                    o.alive = false;
                    
                    Enemy2.enemeyspd2 = 0.5f;
                    Enemy2.hitTime2 = 60;
                    Enemy2.hitTimer2 = 0;

                    Spawning2.numberofGuys2 = 1;
                    Spawning2.spawnTime2 = 60 * 1;
                    Spawning2.spawnTimer2 = 0;
                    Spawning2.waveTime2 = 600 * 1;
                    Spawning2.waveTimer2 = 0;

                    Spawning2.totalSpawned2 = 0;
                    Spawning2.spawncheck2 = false;
                   

                }

                if (o.GetType() == typeof(Enemy3) && o.alive)
                {
                    o.alive = false;
                   
                    Enemy3.enemeyspd3 = 1.5f;
                    Enemy3.hitTime3 = 60;
                    Enemy3.hitTimer3 = 0;

                    Spawning3.numberofGuys3 = 0;
                    Spawning3.spawnTime3 = 60 * 1;
                    Spawning3.spawnTimer3 = 0;
                    Spawning3.waveTime3 = 600 * 1;
                    Spawning3.waveTimer3 = 0;

                    Spawning3.totalSpawned3 = 0;
                    Spawning3.spawncheck3 = false;
                     
                    

                }
                if (o.GetType() == typeof(Heart) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(breakablewall) && o.alive)
                {
                    o.solid = false;
                    o.alive = false;
                    
                }
                if (o.GetType() == typeof(slowBlock) && o.alive)
                {
                    o.alive = false;
                }
                if (o.GetType() == typeof(speedBlock) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(Bullet) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(gun1) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(gun2) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(gun3) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(Gun4ShootFive) && o.alive)
                {
                    o.alive = false;
                }

                if (o.GetType() == typeof(Gun4ShootThree) && o.alive)
                {
                    o.alive = false;
                }
                if (o.GetType() == typeof(Gun4ShootTwo) && o.alive)
                {
                    o.alive = false;
                }
                // set the high score
            }
            if (ScoreView.score1 < Game1.KillCount) // first place
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = ScoreView.score5;
                ScoreView.score5 = ScoreView.score4;
                ScoreView.score4 = ScoreView.score3;
                ScoreView.score3 = ScoreView.score2;
                ScoreView.score2 = ScoreView.score1;
                ScoreView.score1 = Game1.KillCount;
                
            }

            else if (ScoreView.score2 < Game1.KillCount) // 2nd
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = ScoreView.score5;
                ScoreView.score5 = ScoreView.score4;
                ScoreView.score4 = ScoreView.score3;
                ScoreView.score3 = ScoreView.score2;
                ScoreView.score2 = Game1.KillCount;
            }
            else if (ScoreView.score3 < Game1.KillCount)//3rd
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = ScoreView.score5;
                ScoreView.score5 = ScoreView.score4;
                ScoreView.score4 = ScoreView.score3;
                ScoreView.score3 = Game1.KillCount;
            }
            else if (ScoreView.score4 < Game1.KillCount)//4th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = ScoreView.score5;
                ScoreView.score5 = ScoreView.score4;
                ScoreView.score4 = Game1.KillCount;
            }

            else if (ScoreView.score5 < Game1.KillCount)//5th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = ScoreView.score5;
                ScoreView.score5 = Game1.KillCount;
            }

            else if (ScoreView.score6 < Game1.KillCount) //6th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = ScoreView.score6;
                ScoreView.score6 = Game1.KillCount;
            }

            else if (ScoreView.score7 < Game1.KillCount) // 7th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = ScoreView.score7;
                ScoreView.score7 = Game1.KillCount;
            }
            else if (ScoreView.score8 < Game1.KillCount)// 8th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = ScoreView.score8;
                ScoreView.score8 = Game1.KillCount;
            }

            else if (ScoreView.score9 < Game1.KillCount)//9th
            {

                ScoreView.score10 = ScoreView.score9;
                ScoreView.score9 = Game1.KillCount;
            }
            else if (ScoreView.score10 < Game1.KillCount)// last
            {
                ScoreView.score10 = Game1.KillCount;
            }

            Game1.KillCount = 0;
            Game1.timer = 0;

            Enemy.DogsKilled =  0;
            Enemy2.FudKilled =  0;
            Enemy3.SnakesKilled = 0;

            BoxSpawning.numberofGuys = 1;

            MainPlayer.Player.alive = true;
            MainPlayer.bspd = MainPlayer.Standeredbspd;
            MainPlayer.maxAmmo = MainPlayer.StanderedmaxAmmo;
            MainPlayer.ammo = MainPlayer.Standeredammo;
            MainPlayer.rate = MainPlayer.Standeredrate;
            MainPlayer.fireTimer = MainPlayer.StanderedfireTimer;
            Bullet.bulletDistance = Bullet.ConstbulletDistance;
            Bullet.gundamage = Bullet.Constgundamage;
            MainPlayer.shoottwo = false;
            MainPlayer.shootthree = false;
            MainPlayer.shootfive = false;
            MainPlayer.Player.position = new Vector2(150, 400);
        }
        // Resets the main players max health after he dies
        public static void Restart()
        {

            MainPlayer.Player.hp = MainPlayer.maxhp;
             
            
        }

    }
}
