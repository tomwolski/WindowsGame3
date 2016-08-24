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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        bool paused = false;

        Texture2D pausedgame;
        Rectangle pausedshow;

        public static Song music;
        public static Song music2;

       static public SoundEffect Death1; // death sound for enemy object 1
       static public SoundEffect Death2;// death sound for enemy object 2
       static public SoundEffect Death3;// death sound for enemy object 3
       static public SoundEffect PlayerDead;// death sound for MainPLayer object  
       

        GraphicsDeviceManager graphics; // handles the graphics
        SpriteBatch spriteBatch; // objects to draw
        MainMenu mainMenu;  // used to determine the main menu page
        ControlVeiw controlVeiw; // used to determine the control page
        ScoreView scoreView; // used to determine the score page
        Texture2D background; // the background on the main page
        
        public static Rectangle room; // the size of the entire canvas
        public static Rectangle screen;// the size of the players view
        public static SpriteFont font; // the string font used to draw the strings
        public static string game = "Menu"; // describes the game state of the main menu
        public static float timer; // how long the game has been going for that round
        public static int KillCount = 0; //total number of enemies destroyed
        Color color = new Color(255, 255, 255, 255); // color white
      
        public static bool musicchange = false; // determines what music is going to be playing (game/playing music)
        public static bool musicchange2 = true; // determines what music is going to be playing (into music)

        MainPlayer Player = new MainPlayer(new Vector2(50, 50)); // the main player ( the duck)
        mousechange cursor = new mousechange(new Vector2(0, 0)); // the mouse
        static Camera camera = new Camera(); // initializing the camera from the Camera class
        static mousechange mousechange =new  mousechange (new Vector2(0,0)); // setting the mouse position

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); // handles the graphics that xna will be doing
            Content.RootDirectory = "Content";
            this.Window.AllowUserResizing = false;  // game can not be resized, will always be the size of the computers screen
            graphics.IsFullScreen = true; // makes the game full screen mode     
            SoundEffect.MasterVolume = .01f; // sets the initial volume of the music
        }

        public Microsoft.Xna.Framework.Game Game
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


 

        /**/
        /*
             Initialize

        NAME
            Initialize -  Sets any variables before starting

        SYNOPSIS
 
     

        DESCRIPTION
               Allows the game to perform any initialization it needs to before starting to run.
               This is where it can query for any required services and load any non-graphic
               related content.  Calling base.Initialize will enumerate through any components
               and initialize them as well. Here we initialize the all the games objects and views.
 

        AUTHOR

                Thomas Wolski 

        DATE

                7:00pm 8/15/2016

        */
        /**/
        protected override void Initialize()
        {
            // the size of the canvas and screen
            room = new Rectangle(0, 0, graphics.PreferredBackBufferWidth*4, graphics.PreferredBackBufferHeight*4);
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); 
            items.Init();

            Content.RootDirectory = ("content");
            background = Content.Load<Texture2D>("grasstexter");  // load the background sprite
            Death1 = Content.Load<SoundEffect>("DogSound"); // load the enemy1 object death sound
            Death2 = Content.Load<SoundEffect>("PigSound");  // load the enemy2 object death sound
            Death3 = Content.Load<SoundEffect>("Snakesound"); // load the enemy3 object death sound
            PlayerDead = Content.Load<SoundEffect>("DuckSound"); // load the Mainplayer object death sound

            // initialize the views
            mainMenu = new MainMenu();
            controlVeiw = new ControlVeiw();
            scoreView = new ScoreView();
            base.Initialize();
        }
 
        /**/
        /*
             LoadContent

        NAME
            LoadContent -  Loads all objects

        SYNOPSIS
     
             

        DESCRIPTION
         LoadContent will be called once per game and is the place to load
         all of the content. This function creates every object that has been initialized in the function Initialize.
 

        AUTHOR

                Thomas Wolski 

        DATE

                7:10pm 8/15/2016

        */
        /**/
        protected override void LoadContent()
        {
            // Create a new SpriteBatch,  to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
 

            music2 = Content.Load<Song>("Great music for gaming (2 hours)"); // load the second music song 
            music = Content.Load<Song>("KPM Music - Into The Fire"); // load the first music song

            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = .01f;


            font = Content.Load<SpriteFont>("SpriteFont"); // string display font

            mainMenu.LoadContent(Content);
            controlVeiw.LoadContent(Content);
            scoreView.LoadContent(Content);

            pausedgame = Content.Load<Texture2D>("PAUSEING");
            pausedshow = new Rectangle(-200, 200, (screen.Width), (screen.Height));
            foreach (Obj o in items.objList)
            {
                o.LoadContent(this.Content, o.spriteName);
            }

            cursor.LoadContent(Content,"duckHair");
            camera.Update();
           
        }
 


        /**/
        /*
             Update

        NAME
            Update -  Updates the game based on game logic

        SYNOPSIS
     
             gameTime - The amount of elapsed game time since the last update.

        DESCRIPTION
               
                This function is called every time there is a change in a game state,  processing user input, updating of simulation data. It is overloaded in other
                instances to allow the updating of game-specific logic such as updating the world, checking for collisions, gathering input, and playing audio. In 
                this instance the game state can never change to itself. If the game state is set to game the music will change and the previous game state will be recorded.
                if the game state is menu the view main-menu will be displayed allowing with the music to go with it. If the game state is set to control it will select then control
                screen. Lastly if score is the game-state the score screen will display. No two game states will display at the same time.
 

        AUTHOR

                Thomas Wolski 

        DATE

                7:15pm 8/15/2016

        */
        /**/
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || game == "Exit")
            this.Exit();

            KeyboardState keyState = Keyboard.GetState();
            string prevstate = game;
 
            if (game != "game" && game != prevstate)
                {

                    MediaPlayer.Stop();
                    MediaPlayer.Play(music);
                    MediaPlayer.IsRepeating = true;

                }
                else if (game != prevstate)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(music2);

                }

                switch (game)
                {
                    case "game":

            if (!paused)
            {


                if (keyState.IsKeyDown(Keys.P)) // pause the game and music and display the sprite at the correct location
                {

                    pausedshow = new Rectangle((int)(MainPlayer.Player.position).X -400, (int)(MainPlayer.Player.position).Y - 275, (screen.Width), (screen.Height));
                        paused = true;
                        MediaPlayer.Pause();
                         

                }

                        if (musicchange == false)
                        {
                            MediaPlayer.Stop();
                            MediaPlayer.Play(music2);
                            musicchange = true;
                        }
                        timer += gameTime.ElapsedGameTime.Milliseconds;
                        foreach (Obj o in items.objList)
                        {
                            o.Move();
                        }
            }
                        
            else if (paused)
            {
               
                if (keyState.IsKeyDown(Keys.R)) // resume the game and the music
                {
                    paused = false;
                    MediaPlayer.Resume();
 
                }
               
            }

                        break;

                    case "Menu":
                        {

                            if (musicchange2 == true)
                            {
                                MediaPlayer.Stop();
                                MediaPlayer.Play(music);
                                musicchange2 = false;
                            }
                            mainMenu.Move(gameTime);

                        }
                        break;

                    case "Controls":
                        {

                            controlVeiw.Move(gameTime);

                        }
                        break;

                    case "Score":
                        {

                            scoreView.Move(gameTime);

                        }
                        break;
                }



                camera.Update(); // update the camera
                cursor.Move(); // update the mouse
                // update the view
                mainMenu.Move(gameTime);
                controlVeiw.Move(gameTime);
                scoreView.Move(gameTime);

                base.Update(gameTime);
            


        }

        /**/
        /*
        Draw

        NAME

              Draw  is called when the game should draw itself.

        SYNOPSIS
            
                gameTime - The amount of elapsed game time since the last update.
         

        DESCRIPTION

                This function first clears the background of the canvas to green, setting the background for any part of the canvas if not initialized. After depending
                on what the game-state is it uses a switch statement to determine what view is going to be drawn for the user. if the game-state is set to game then the background will
                first be drawn onto the canvas after the camera get set. Depending on what attributes are set for the other objects they will also be drawn onto the screen. If the player
                clicks P the game will also display a message saying the game is paused. After if the game is set to Menu, a different set of buttons will be click-able by the user.
                While also displayed a different background. The same goes for score and controls; they each will have there own view and click-able buttons when being the game state.
                However because these two screens to not have a background set they will use the default background which is Green.
                
 
        AUTHOR

                Thomas Wolski 

        DATE

                7:25pm 8/15/2016

        */
        /**/

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            switch (game)
            {
                case "game":
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform(graphics.GraphicsDevice)); // Sets the camera

                    Vector2 backgrounddraw = camera.Position - new Vector2(screen.Width, screen.Height) / 2;
                    Vector2 backgrounddraw2 = camera.Position + new Vector2(screen.Width, screen.Height) / 2;
                    Vector2 startingpoint = backgrounddraw - new Vector2(screen.Width, screen.Height);
                    Vector2 endingpoint = backgrounddraw2 + new Vector2(screen.Width, screen.Height);

                    // background
                    for (int x = (int)(startingpoint.X / background.Width); x < (endingpoint.X / background.Width); x++)
                    {
                        for (int y = (int)(startingpoint.Y / background.Height); y < (endingpoint.Y / background.Height); y++)
                        {

                            spriteBatch.Draw(background, new Vector2 (x * background.Width, y * background.Height), null, Color.White, 0.0f ,  Vector2.Zero, 1,SpriteEffects.None, 0);
        
                        }

                    }

                    foreach (Obj o in items.objList) // draws all objects
                    {
                        o.Draw(spriteBatch);
                    }

                    if(paused) // shows sprite image if paused
                    {
                        spriteBatch.Draw(pausedgame, pausedshow, Color.White);
                    }


                    spriteBatch.End(); // ends the drawing
                    break;

                case "Menu":
                    {

                        spriteBatch.Begin();// begins the drawing
                        spriteBatch.Draw(Content.Load<Texture2D>("duckBackGround"), new Rectangle(0, 0, screen.Width, screen.Height),Color.White ); // sets background
                        spriteBatch.End();
                        MainMenu.isClickable = true; // sets these buttons to only be click-able from the view
                        ControlVeiw.isClickable2 = false;
                        ScoreView.isClickable3 = false;
                        mainMenu.Draw(spriteBatch);
                       
                    }
                    break;

                case "Controls":
                    {

                        spriteBatch.Begin();// begins the drawing
                        
                        ControlVeiw.isClickable2 = true; // sets these buttons to only be click-able from the view
                        MainMenu.isClickable = false;
                        ScoreView.isClickable3 = false;
                        spriteBatch.End(); // ends the drawing
                        controlVeiw.Draw(spriteBatch); // draws this screen
                       

                    }
                    break;

                case "Score":
                    {

                        spriteBatch.Begin();// begins the drawing

                        ControlVeiw.isClickable2 = false;
                        MainMenu.isClickable = false;
                        ScoreView.isClickable3 = true;// sets these buttons to only be click-able from the view
                        spriteBatch.End(); // ends the drawing

                        scoreView.Draw(spriteBatch);// draws this screen


                    }
                    break;
            }
        
            spriteBatch.Begin();
            // draws the specific view of the game-state
            View.Draw(spriteBatch, gameTime);
            ControlVeiw.Draw(spriteBatch, gameTime);
            ScoreView.Draw(spriteBatch, gameTime);
            cursor.Draw(spriteBatch); // draws the mouse
            spriteBatch.End(); // ends the drawing
            base.Draw(gameTime);
        }
        // updates the position of the camera
        public static Vector2 GetCam()
        {
            return camera.Position;
        }
 
 

    }
}
