﻿using System;
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
    class ScoreView
    {
        

        int linePadding = 3;
        KeyboardState keyboard;
        KeyboardState prevKeyboard;

        MouseState mouse;
        MouseState prevMouse;

        List<string> buttonList = new List<string>();
        Color color0 = new Color(255, 255, 0, 255);
        Color color1 = new Color(255, 0, 255, 255);
        Color color2 = new Color(0, 255, 0, 255);
        Color color3 = new Color(255, 0, 0, 255);

        SpriteFont font;

        bool colorChanger = false;
        bool ishovered = false;
        public static bool isClickable3 = false;
        public static int score1 ;

        //int selected = 0;

        public ScoreView()
        {
            buttonList.Add("play");
            buttonList.Add("Menu");
            buttonList.Add("Controls");
            buttonList.Add("Exit");
        }

        public void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("SpriteFont");
        }

        public static void Draw(SpriteBatch spritebatch, GameTime gameTime)
        {


            if (Game1.game == "Score")
            {
                

                spritebatch.DrawString(Game1.font, "Good Luck!", new Vector2((int)((Game1.screen.Width / 2)) - 70, Game1.font.LineSpacing * 2), Color.White);
                spritebatch.DrawString(Game1.font, "Score:" + score1, new Vector2(0, Game1.font.LineSpacing), Color.White);
            }
        }

        public void move(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            Rectangle mouserectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);


            Rectangle Recbutton0 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[0]).X / 2)),
                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 6), 50, 30);

            Rectangle Recbutton1 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[1]).X / 2)),
                (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 7), 100, 30);

            Rectangle Recbutton2 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[2]).X / 2)),
               (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 8), 50, 30);

            Rectangle Recbutton3 = new Rectangle((int)((Game1.screen.Width / 2) - (font.MeasureString(buttonList[3]).X / 2)),
               (int)(Game1.screen.Height / 2) - (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 9), 50, 30);


            if (checkKey(Keys.Up))
            {
                if (ControlVeiw.selected > 0)
                {
                    ControlVeiw.selected--;
                }
            }
            if (checkKey(Keys.Down))
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

            if (mouserectangle.Intersects(Recbutton3))
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
                ControlVeiw.selected = 3;
            }

            else if (color3.A < 255)
            {
                ishovered = false;
                color3.A += 3;
                color3.R += 3;
            }


            if (checkKey(Keys.Enter) && isClickable3 || mouse.LeftButton == ButtonState.Pressed && ishovered && isClickable3)
            {
                switch (ControlVeiw.selected)
                {
                    case 0:
                        isClickable3 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "game";
                        
                        break;

                    case 1:
                        isClickable3 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Menu";
                        
                        break;

                    case 2:
                        isClickable3 = false;
                        ControlVeiw.selected = 0;
                        Game1.game = "Controls";
                       
                        break;

                    case 3:
                        Game1.game = "Exit";
                        break;
                }
            }

            prevMouse = mouse;
            prevKeyboard = keyboard;

        }

        public bool checkKey(Keys Key)
        {
            return (keyboard.IsKeyDown(Key) && !prevKeyboard.IsKeyDown(Key));

        }

        public bool CheckMouse()
        {
            return (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released);

        }

        public void Draw(SpriteBatch spritebatch)
        {



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

            spritebatch.DrawString(font, buttonList[3],
                   new Vector2((Game1.screen.Width / 2) -
                   (font.MeasureString(buttonList[3]).X / 2),
                   (Game1.screen.Height / 2) -
                   (font.LineSpacing * buttonList.Count / 2) + ((font.LineSpacing + linePadding) * 9)), color3);


            spritebatch.End();
        }

        }
}
