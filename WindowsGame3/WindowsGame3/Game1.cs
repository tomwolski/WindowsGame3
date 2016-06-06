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

        public static Song music;
        public static Song music2;

       static public SoundEffect Death1;
       static public SoundEffect Death2;
       static public SoundEffect Death3;
       static public SoundEffect PlayerDead;
       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MainMenu mainMenu;
        ControlVeiw controlVeiw;
        ScoreView scoreView;
        Texture2D background;
        
        public static Rectangle room;
        public static Rectangle screen;
        public static SpriteFont font;
        public static string game = "Menu";
        public static float timer;
        public static int KillCount = 0;
        Color color = new Color(255, 255, 255, 255);
        bool Paused = false;
        public static bool musicchange = false;
        public static bool musicchange2 = true;

        MainPlayer Player = new MainPlayer(new Vector2(50, 50));
        mousechange cursor = new mousechange(new Vector2(0, 0));
        static Camera camera = new Camera();
        static mousechange mousechange =new  mousechange (new Vector2(0,0));

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += Window_ClientSizeChanged;
            SoundEffect.MasterVolume = .01f;
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            screen.Height = GraphicsDevice.PresentationParameters.BackBufferHeight;
            screen.Width = GraphicsDevice.PresentationParameters.BackBufferWidth;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // the size of the screen
            room = new Rectangle(0, 0, graphics.PreferredBackBufferWidth*4, graphics.PreferredBackBufferHeight*4);
            screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); 
            items.Init();

            Content.RootDirectory = ("content");
            background = Content.Load<Texture2D>("grasstexter");
            Death1 = Content.Load<SoundEffect>("Dog Howling At Moon-SoundBible.com-1369876823");
            Death2 = Content.Load<SoundEffect>("Pig sound effect pig in a mood squeal sounds (online-audio-converter.com)");
            Death3 = Content.Load<SoundEffect>("Two Snake Hiss Sound Effects (online-audio-converter.com)");
            PlayerDead = Content.Load<SoundEffect>("Quack Quack-SoundBible.com-620056916");

            mainMenu = new MainMenu();
            controlVeiw = new ControlVeiw();
            scoreView = new ScoreView();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
          // Man.loadContent(this.Content, "duckfromabove");
           // cursor.loadContent(this.Content, "duckHair");

            music2 = Content.Load<Song>("Great music for gaming (2 hours)");
            music = Content.Load<Song>("KPM Music - Into The Fire");

            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = .01f;


            font = Content.Load<SpriteFont>("SpriteFont");

            mainMenu.LoadContent(Content);
            controlVeiw.LoadContent(Content);
            scoreView.LoadContent(Content);

            foreach (Obj o in items.objList)
            {
                o.loadContent(this.Content, o.spriteName);
            }

            cursor.loadContent(Content,"duckHair");
            camera.Update();
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || game == "Exit")
            this.Exit();

            KeyboardState keyState = Keyboard.GetState();
            string prevstate = game;

            


            if (game != "game"  && game != prevstate)
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
                   
                    if (musicchange == false)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(music2);
                        musicchange = true;
                    }
                    timer += gameTime.ElapsedGameTime.Milliseconds;
                    foreach (Obj o in items.objList)
                    {
                         o.move();
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
                            mainMenu.move(gameTime);
                            
                        }
                        break;

                case "Controls":
                        {

                            controlVeiw.move(gameTime);

                        }
                        break;

                case "Score":
                        {

                            scoreView.move(gameTime);

                        }
                        break;
            }
        


            camera.Update();
            cursor.move();

            mainMenu.move(gameTime);
            controlVeiw.move(gameTime);
            scoreView.move(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            switch (game)
            {
                case "game":
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform(graphics.GraphicsDevice));

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

                    foreach (Obj o in items.objList)
                    {
                        o.Draw(spriteBatch);
                    }



                    spriteBatch.End();
                    break;

                case "Menu":
                    {

                        spriteBatch.Begin();
                        spriteBatch.Draw(Content.Load<Texture2D>("duckBackGround"), new Rectangle(0, 0, screen.Width, screen.Height),Color.White );
                        spriteBatch.End();
                        MainMenu.isClickable = true;
                        ControlVeiw.isClickable2 = false;
                        ScoreView.isClickable3 = false;
                        mainMenu.Draw(spriteBatch);
                       
                    }
                    break;

                case "Controls":
                    {

                        spriteBatch.Begin();
                        
                        ControlVeiw.isClickable2 = true;
                        MainMenu.isClickable = false;
                        ScoreView.isClickable3 = false;
                        spriteBatch.End();
                        controlVeiw.Draw(spriteBatch);
                       

                    }
                    break;

                case "Score":
                    {

                        spriteBatch.Begin();

                        ControlVeiw.isClickable2 = false;
                        MainMenu.isClickable = false;
                        ScoreView.isClickable3 = true;
                        spriteBatch.End();
                        
                        scoreView.Draw(spriteBatch);


                    }
                    break;
            }
        
            spriteBatch.Begin();

            View.Draw(spriteBatch, gameTime);
            ControlVeiw.Draw(spriteBatch, gameTime);
            ScoreView.Draw(spriteBatch, gameTime);
            cursor.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public static Vector2 getCam()
        {
            return camera.Position;
        }

        public static Vector2 getMouse()
        {
            return mousechange.position;
        }
        public static void musicChecker()
        {
            if (game == "game" )
            {

                MediaPlayer.Play(music2);
                MediaPlayer.IsRepeating = true;
            }

            if (game == "Menu" || game == "Score" || game == "Controls")
            {

                MediaPlayer.Play(music);
                MediaPlayer.IsRepeating = true;
            }
        }

    }
}
