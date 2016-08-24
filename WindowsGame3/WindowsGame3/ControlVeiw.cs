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

    class ControlVeiw : View
    {

        int linePadding = 3;
        KeyboardState keyboard;
        KeyboardState prevKeyboard;

        MouseState mouse;
        MouseState prevMouse; 

        List<string> buttonList = new List<string>(); // list of the buttons
        Color color0 = new Color(255, 255, 0, 255); // button color
        Color color1 = new Color(255, 0, 255, 255);// button color
        Color color2 = new Color(0, 255, 0, 255);// button color
        Color color3 = new Color(255, 0, 0, 255);// button color

        SpriteFont font; // font of the text

        bool colorChanger = false; // determine if the color should be changed or not
        bool ishovered = false; // if the mouse is over the rectangle
        public static bool isClickable2 = false; // if you can click on the buttons

        public static int selected = 0; // default for the button selected
        /**/
        /*
        ControlVeiw

        NAME

                ControlVeiw - A function to Add the 3 different buttons to the current view.

        SYNOPSIS
       

        DESCRIPTION

     
                This function takes the initialized button list and adds the 3 different buttons along with the names associated with them.
     

        AUTHOR

                Thomas Wolski 

        DATE

                3:30pm 8/14/2016

        */
        public ControlVeiw()
        {
             
            buttonList.Add("Menu");
            buttonList.Add("Score");
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

     
                This function draws the view to display the controls to the player of the game if the game-state is set to Controls. Each display is placed based on 
                half the size of the screen displayed then moved left to compensate for the length of the text. Then is moved down a specific amount of line spaces
                followed by the color the font will be displayed. 
     

        AUTHOR

                Thomas Wolski 

        DATE

                3:30pm 8/14/2016

        */
        /**/
        public static void Draw(SpriteBatch spritebatch, GameTime gameTime)
        {
            string str = "w to move up";

            if (Game1.game == "Controls")
            {


                spritebatch.DrawString(Game1.font, str, new Vector2((int)((Game1.screen.Width / 2)) -70, Game1.font.LineSpacing * 2), Color.Red);
                spritebatch.DrawString(Game1.font, "S to move Down", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 3), Color.Blue);
                spritebatch.DrawString(Game1.font, "A to move Left", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 4), Color.Red);
                spritebatch.DrawString(Game1.font, "D to move Right", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 5), Color.Blue);
                spritebatch.DrawString(Game1.font, "Left Click to Shoot", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 8), Color.White);
                spritebatch.DrawString(Game1.font, "Move the Mouse to Aim", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 9), Color.Blue);
                spritebatch.DrawString(Game1.font, "P to Pause", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 10), Color.White);
                spritebatch.DrawString(Game1.font, "R to Resume", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 11), Color.Blue);
      


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
                currently being selected. There are two ways to select a bottom on the list. You can move the arrow keys up and down to pick your selection by increasing or decreasing the selector number
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

                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 4), 50, 30);
            Rectangle Recbutton1 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[1]).X / 2)),
                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 5), 100, 30);

            Rectangle Recbutton2 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[2]).X / 2)),
               (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 6), 50, 30);


            // use arrow key to move the selector up one

            if (CheckKey(Keys.Up))
            {
                if (selected > 0)
                {
                    selected--;
                }
            }
            // use arrow key to move the selector Down one
            if (CheckKey(Keys.Down))
            {
                if (selected < buttonList.Count - 1)
                {
                    selected++;
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


                selected = 0;
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
                selected = 1;
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
                selected = 2;
            }

            else if (color2.A < 255)
            {
                color2.A += 3;
                color2.R += 3;
                ishovered = false;
            }
 

            else if (color3.A < 255)
            {
                ishovered = false;
                color3.A += 3;
                color3.R += 3;
            }


            if (CheckKey(Keys.Enter) && isClickable2 || mouse.LeftButton == ButtonState.Pressed && ishovered && isClickable2)
            {
                switch (selected)
                {


                    case 0:
                        isClickable2 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Menu";
                        
                        break;

                    case 1:
                        isClickable2 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Score";
                        
                        break;

                    case 2:
                        Game1.game = "Exit";
                        break;
                }
            }

            prevMouse = mouse;
            prevKeyboard = keyboard;

        }
        // This will make sure that the key has been pressed and released before proceeding 
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

     
                This function is called it will display the 3 buttons who's color will be constantly changing. they will be displayed as Menu, score and Exit in that order. Each
                Will have the attributes described above. This will determine there locations on the canvas with by its x and y coordinates
                ( half the screen's Width - the buttons font and height - the buttons font Then times that many line spaces down), and the color being shown.
     
 
        AUTHOR

                Thomas Wolski 

        DATE

                2:35pm 8/13/2016

        */
        /**/
        public void Draw(SpriteBatch spritebatch)
        {



            spritebatch.Begin();



            spritebatch.DrawString(font, buttonList[0],
                    new Vector2((Game1.screen.Width / 2) -
                    (font.MeasureString(buttonList[0]).X / 2),
                    (Game1.screen.Height / 2) -
                    (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 4)), color0);

            spritebatch.DrawString(font, buttonList[1],
                   new Vector2((Game1.screen.Width / 2) -
                   (font.MeasureString(buttonList[1]).X / 2),
                   (Game1.screen.Height / 2) -
                   (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 5)), color1);

            spritebatch.DrawString(font, buttonList[2],
                   new Vector2((Game1.screen.Width / 2) -
                   (font.MeasureString(buttonList[2]).X / 2),
                   (Game1.screen.Height / 2) -
                   (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 6)), color2);



            spritebatch.End();
        }

        }
}
