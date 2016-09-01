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
    /**/
    /*
         Camera

    NAME
        Camera -  This class controls the games view

    SYNOPSIS
     
           Zero arguments passed
     

    DESCRIPTION

            This class will attempt to represent the view of the game. Every time the MainPlayer moves on the canvas it makes sure to 
            follow the Mainplayer While keeping itself rotated and zoomed properly. 
            
            position- the position of the cameras view based on the room size.
            rotation -  a value needed in the matrix camera transformation even if a defaulted to have no rotation
            zoom - a value needed in the matrix camera transformation even if using a defaulted value of zoom
            m_transform - used to multiply the xna graphic device by the specified camera attributes

    AUTHOR

            Thomas Wolski 

    DATE

            7:30pm 8/9/2016

    */
    /**/

    class Camera : View
        {
            private Vector2 position;
            private float rotation;
            private float zoom;
            private Matrix m_transform;

            /**/
            /*
                 Camera

            NAME
                Camera -  This function controls the games view

            SYNOPSIS
     
                   Zero arguments passed
     

            DESCRIPTION

                      The Camera function will determine the ratio of the camera Height and Width based on the size of the entire canvas(room)
                      and the entire actual view (screen) specification comparing which will be the best for the display.

            AUTHOR

                    Thomas Wolski 

            DATE

                    7:30pm 8/9/2016

            */
            /**/
            public Camera()
            {
                position = new Vector2(Game1.room.Width / 2, Game1.room.Height / 2);
                rotation = 0.0f;
                zoom = 1.0f;

                float wRatio = (float)Game1.room.Width / (float)Game1.screen.Width;
                float hRatio = (float)Game1.room.Height / (float)Game1.screen.Height;
                bool lowesRatio = (wRatio < hRatio) ? true : false;

                float rLength = (lowesRatio) ? Game1.room.Width : Game1.room.Height;
                float sLength = (lowesRatio) ? Game1.screen.Width : Game1.screen.Height;
 
            }
            //Sets the Position of the camera based on the players location
            public Vector2 Position
            {
                get { return position; }
                set { position = value; }
            }
            // Will update every time the player moves changing the cameras position
            public void Update()
            {
                position = MainPlayer.Player.position;
            }
            // will determine how far the camera has to change based on how much the Mainplayer moves
            public void Move(Vector2 amount)
            {
                position += amount;
            }


            /**/
            /*
                 Transform

            NAME
                Transform -  This function transforms the GraphicsDevice graphics to display the camera as specified

            SYNOPSIS
     
                   Zero arguments passed
     

            DESCRIPTION

             this function is called is called every time the game state is set to "game" and then xna has to draw the sprite batch multiplying the graphics devices ViewPortWidth and
             ViewPortHeight  by the specified position, rotation, scale and zoom

            AUTHOR

                    Thomas Wolski 

            DATE

                    8:30pm 8/9/2016

            */
            /**/
            public Matrix Transform(GraphicsDevice graphics)
            {
                float ViewPortWidth = graphics.Viewport.Width;
                float ViewPortHeight = graphics.Viewport.Height;

                m_transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                    Matrix.CreateRotationZ(rotation) * Matrix.CreateScale(zoom) *
                    Matrix.CreateTranslation(new Vector3(ViewPortWidth * 0.5f, ViewPortHeight * 0.5f, 0));

                return m_transform;
            }
            

            /**/
            /*
                 XYFromMap

            NAME
                XYFromMap -  Translates different positions relative of the objects to the screen and canvas due the change of xna graphics devices ViewPortWidth and
             ViewPortHeight.

            SYNOPSIS
     
                   Zero arguments passed
     

            DESCRIPTION
                      Takes the Cameras location and subtracts half the screens width and half the height to fit the canvas (room)

            AUTHOR

                    Thomas Wolski 

            DATE

                   9:00pm 8/9/2016

            */
            /**/
            public static Vector2 XYFromMap(Vector2 pos)
            {
                pos -= (Game1.GetCam() - new Vector2(Game1.screen.Width / 2, Game1.screen.Height / 2));
                return pos;
            }
        }
    }
