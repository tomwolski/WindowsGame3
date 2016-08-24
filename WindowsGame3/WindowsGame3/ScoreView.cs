using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame3
{
    class ScoreView : View
    {


        int linePadding = 3;
        KeyboardState keyboard;
        KeyboardState prevKeyboard;

        MouseState mouse;
        MouseState prevMouse;

        List<string> buttonList = new List<string>(); // list for the buttons 
        Color color0 = new Color(255, 255, 0, 255); // button color
        Color color1 = new Color(255, 0, 255, 255);// button color
        Color color2 = new Color(0, 255, 0, 255);// button color
        Color color3 = new Color(255, 0, 0, 255);// button color 

        SpriteFont font; // font for the text displayed

        private bool colorChanger = false; // if the button color will be changed
       private bool ishovered = false;// if the mouse intersects the rectangle
        public static bool isClickable3 = false; // if the buttons are click-able

        // top 10 scores
        public static int score1;
        public static int score2;
        public static int score3;
        public static int score4;
        public static int score5;
        public static int score6;
        public static int score7;
        public static int score8;
        public static int score9;
        public static int score10;

        
        /**/
        /*
        ScoreView

        NAME

                ScoreView - A function to Add the 3 different buttons to the current view.

        SYNOPSIS
       

        DESCRIPTION

     
                This function takes the initialized button list and adds the 3 different buttons along with the names associated with them.
     

        AUTHOR

                Thomas Wolski 

        DATE

                2:00pm 8/13/2016

        */
        /**/
        public ScoreView()
        {

            buttonList.Add("Menu");
            buttonList.Add("Controls");
            buttonList.Add("Exit");
        }
        //This will initialize the font that is to be displayed, on the canvas
        public void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("SpriteFont");
        }
        /**/
        /*
        Draw

        NAME

                Draw

        SYNOPSIS
                spritebatch - the group of elements that are going to drawn
                gameTime - The amount of elapsed game time since the last update.
         

        DESCRIPTION

     
                This function draws the view of the top 10 high-scores between each play through, when the game state has been changed to "scores" (This is done when the  
                Player selects to the score button) The first 5 scores will be Displayed on the left side starting from the top of the screen and moving down the   
                number of line spaces specified. The next 5 will be displayed a little right of the middle of the screen's width and spaced vertically by the line space 
                that is specified. (always 2 apart).
     

        AUTHOR

                Thomas Wolski 

        DATE

                2:15pm 8/13/2016

        */
        /**/
        public static void Draw(SpriteBatch spritebatch, GameTime gameTime)
        {


            if (Game1.game == "Score")
            {


                spritebatch.DrawString(Game1.font, "Good Luck!", new Vector2((int)((Game1.screen.Width / 2)) - 60, Game1.font.LineSpacing * 14), Color.White);


                spritebatch.DrawString(Game1.font, "First  :" + score1, new Vector2(20, Game1.font.LineSpacing * 2), Color.Yellow);
                spritebatch.DrawString(Game1.font, "Second :" + score2, new Vector2(20, Game1.font.LineSpacing * 4), Color.Blue);
                spritebatch.DrawString(Game1.font, "Third  :" + score3, new Vector2(20, Game1.font.LineSpacing * 6), Color.Red);
                spritebatch.DrawString(Game1.font, "Forth :" + score4, new Vector2(20, Game1.font.LineSpacing * 8), Color.White);
                spritebatch.DrawString(Game1.font, "Fifth   :" + score5, new Vector2(20, Game1.font.LineSpacing * 10), Color.Purple);
                spritebatch.DrawString(Game1.font, "Sixth  :" + score6, new Vector2((int)((Game1.screen.Width / 2)) + 50, Game1.font.LineSpacing * 2), Color.Blue);
                spritebatch.DrawString(Game1.font, "Seventh:" + score7, new Vector2((int)((Game1.screen.Width / 2)) + 50, Game1.font.LineSpacing * 4), Color.White);
                spritebatch.DrawString(Game1.font, "Eighth   :" + score8, new Vector2((int)((Game1.screen.Width / 2)) + 50, Game1.font.LineSpacing * 6), Color.Purple);
                spritebatch.DrawString(Game1.font, "Ninth  :" + score9, new Vector2((int)((Game1.screen.Width / 2)) + 50, Game1.font.LineSpacing * 8), Color.White);
                spritebatch.DrawString(Game1.font, "LAST!  :" + score10, new Vector2((int)((Game1.screen.Width / 2)) + 50, Game1.font.LineSpacing * 10), Color.Red);

            }
        }

        /**/
        /*
        Move

        NAME

                Move

        SYNOPSIS
               
                gameTime - The amount of elapsed game time since the last update.
         

        DESCRIPTION

     
                This function updates the color and location of the 3 buttons. Recbutton0 ,Recbutton1 ,Recbutton2 represent the size of the buttons in the button list declared earlier. 
                These buttons are located in the center of the screen while always subtracting half the length of the button characters to ensure they are all in the middle
                After initializing the X and Y coordinate locations the rectangles representing the buttons are then moved down by a specified amount of line spacings. Each button
                is then given a height and with, In this case the numbers corresponding to how long the buttons text is. When pressing the up arrow it will change which button on the list is
                currently being selected. There are two ways to select a button on the list. You can move the arrow keys up and down to pick your selection by increasing or decreasing the selector number
                or use the mouse to click onto the button of your choice. When using the mouse, when the mouse intersects with one of the button rectangles it will then begin to change the color 
                of the A value and R value in RGBA. When the R value reaches its maximum value of 255 it will then begin to lower the R and A value's back down till zero, This keeps the buttons color  
                constantly changing. When any of these buttons are Clicked on with the mouse or used enter to select the button choice it will then proceeded to change the game state while
                also making these buttons not click-able on another game-state window even if they are not drawn onto the canvas. Then will reset the selector to zero.
     

        AUTHOR

                Thomas Wolski 

        DATE

                2:25pm 8/13/2016

        */
        /**/
        public void Move(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            // location of the mouse
            Rectangle mouserectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);


            Rectangle Recbutton0 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[0]).X / 2)),
                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 6), 50, 30);

            Rectangle Recbutton1 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[1]).X / 2)),
                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 7), 100, 30);

            Rectangle Recbutton2 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[2]).X / 2)),
               (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 8), 50, 30);


            // use arrow key to move the selector up one
            if (CheckKey(Keys.Up))
            {
                if (ControlVeiw.selected > 0)
                {
                    ControlVeiw.selected--;
                }
            }
            // use arrow key to move the selector down one
            if (CheckKey(Keys.Down))
            {
                if (ControlVeiw.selected < buttonList.Count - 1)
                {
                    ControlVeiw.selected++;
                }
            }

            if (mouserectangle.Intersects(Recbutton0))
            {
                if (color0.A == 255)
                {
                    colorChanger = false;
                }
                if (color0.A == 0)
                {
                    colorChanger = true;
                }
                if (colorChanger)
                {
                    color0.A += 3;
                    color0.R += 3;
                }
                else
                {
                    color0.A -= 3;
                    color0.R -= 3;
                }


                ControlVeiw.selected = 0;
                ishovered = true;

            }

            else if (color0.A < 255)
            {
                color0.A += 3;
                color0.R += 3;
                ishovered = false;
            }

            if (mouserectangle.Intersects(Recbutton1))
            {
                if (color1.A == 255)
                {
                    colorChanger = false;
                }
                if (color1.A == 0)
                {
                    colorChanger = true;
                }
                if (colorChanger)
                {
                    color1.A += 3;
                    color1.R += 3;
                }
                else
                {
                    color1.A -= 3;
                    color1.R -= 3;
                }

                ishovered = true;
                ControlVeiw.selected = 1;
            }

            else if (color1.A < 255)
            {
                color1.A += 3;
                color1.R += 3;
                ishovered = false;
            }


            if (mouserectangle.Intersects(Recbutton2))
            {
                if (color2.A == 255)
                {
                    colorChanger = false;
                }
                if (color2.A == 0)
                {
                    colorChanger = true;
                }
                if (colorChanger)
                {
                    color2.A += 3;
                    color2.R += 3;
                }
                else
                {
                    color2.A -= 3;
                    color2.R -= 3;
                }
                ishovered = true;
                ControlVeiw.selected = 2;
            }

            else if (color2.A < 255)
            {
                color2.A += 3;
                color2.R += 3;
                ishovered = false;
            }

            if (mouserectangle.Intersects(Recbutton0))
            {
                if (color3.A == 255)
                {
                    colorChanger = false;
                }
                if (color3.A == 0)
                {
                    colorChanger = true;
                }
                if (colorChanger)
                {
                    color3.A += 3;
                    color3.R += 3;
                }
                else
                {
                    color3.A -= 3;
                    color3.R -= 3;
                }
                ishovered = true;
                ControlVeiw.selected = 0;
            }

            else if (color3.A < 255)
            {
                ishovered = false;
                color3.A += 3;
                color3.R += 3;
            }


            if (CheckKey(Keys.Enter) && isClickable3 || mouse.LeftButton == ButtonState.Pressed && ishovered && isClickable3)
            {
                switch (ControlVeiw.selected)
                {

                    case 0:
                        isClickable3 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Menu";

                        break;

                    case 1:
                        isClickable3 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Controls";

                        break;

                    case 2:
                        Game1.game = "Exit";
                        break;
                }
            }

            prevMouse = mouse;
            prevKeyboard = keyboard;

        }
        // This will make sure that the key has been pressed and released  before proceeding 
       
        private bool CheckKey(Keys Key)
        {
            return (keyboard.IsKeyDown(Key) && !prevKeyboard.IsKeyDown(Key));

        }


        /**/
        /*
      Draw

        NAME

                Draw - A static class that will display to the MainPlayer some basic attributes.

        SYNOPSIS
             spritebatch - Enables a group of sprites to be drawn the screen
             gameTime - the amount of time the game as been running for

        DESCRIPTION

     
                This function is called it will display the 3 buttons who's color will be constantly changing. they will be displayed as Menu, Controls and Exit in that order. Each
                Will have the attributes described above. This will determine there locations on the canvas with by its x and y coordinates
                ( half the screen's Width - the buttons font and height - the buttons font Then times that many line spaces down), and the color being shown.
     
 
        AUTHOR

                Thomas Wolski 

        DATE

                3:00pm 8/11/2016

        */
        /**/
        public void Draw(SpriteBatch spritebatch)
        {


            // tell xna to begin draw
            spritebatch.Begin();



            spritebatch.DrawString(font, buttonList[0],
                    new Vector2((Game1.screen.Width / 2) -
                    (font.MeasureString(buttonList[0]).X / 2),
                    (Game1.screen.Height / 2) -
                    (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 6)), color0);

            spritebatch.DrawString(font, buttonList[1],
                   new Vector2((Game1.screen.Width / 2) -
                   (font.MeasureString(buttonList[1]).X / 2),
                   (Game1.screen.Height / 2) -
                   (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 7)), color1);

            spritebatch.DrawString(font, buttonList[2],
                   new Vector2((Game1.screen.Width / 2) -
                   (font.MeasureString(buttonList[2]).X / 2),
                   (Game1.screen.Height / 2) -
                   (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 8)), color2);



            // tell xna to End draw
            spritebatch.End();
        }

    }
}

