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
    class Obj
    {
        public Vector2 position;
        public float rotation;
        public Texture2D spriteIndex;
        public string spriteName = "";
        public float speed = 0.0f;
        public float scale = 1.0f;
        public bool alive = true;
        public Rectangle area;
        public bool solid = false;
        public Color color = new Color(255, 255, 255, 255);
        private Rectangle roomsize = new Rectangle(0, 0, Game1.screen.Width, Game1.screen.Height);
        // Constructor for the object class that takes a vector used to define the position of the object and its rotation. 
        public Obj(Vector2 pos)
        {
            position = pos;
            rotation = 0.0f;
             

        }
        // Constructor for the object class that takes zero arguments 
        public Obj()
        {

        }
 
        /**/
        /*
         Move

        NAME

                Move - a function that controls the updating done by xna 

        SYNOPSIS
     
 
     

        DESCRIPTION
                This function is called ever time there is a change in a game state,  processing user input, updating of simulation data. It is overloaded in other
                instances to allow the updating of game-specific logic. If the object that is being updated and not alive it will automatically return otherwise
                the sprites area will be updated along with were the sprite should move to.
                 

        AUTHOR

                Thomas Wolski 

        DATE

              3:30pm 8/13/2016

        */
        /**/
        public virtual void Move()
        {

            if (!alive) 
            { 
                return;
            }
 
            // Updates the area of the sprites
            UpdateArea();

            // Updates movement of the sprites
            Movement(speed, rotation);


        }

        /**/
        /*
         Move

        NAME

                Move - a function that controls the updating done by xna 

        SYNOPSIS
        
                ContentManager content - Loads the objects that are specified after the initialization of the game.
                sprName- the Name that all objects are associated with telling xna what sprite should be drawn for the specific object.
     

        DESCRIPTION
                This function is called after the game initialized or if something has to be reinitialized. Each sprite name is passed into this function as an argument 
                for each object. After a sprite name is passed in, a spriteIndex will be created as a 2 denominational texture. After the 2 denominational texture has been declared
                The area of the sprite is represented by the width and height of the sprite image itself, located in the WindowsGameContect.
                 

        AUTHOR

                Thomas Wolski 

        DATE

              3:30pm 8/13/2016

        */
        /**/
        public virtual void LoadContent(ContentManager content, string sprName)
        {
            spriteName = sprName;

            spriteIndex = content.Load<Texture2D>(this.spriteName);

            area = new Rectangle(0, 0, spriteIndex.Width, spriteIndex.Height);                     
        }

 


        /**/
        /*
      Draw

        NAME

                Draw - A virtual function that will display the objects specified by the spriteindex

        SYNOPSIS
             spritebatch - Enables a group of sprites to be drawn th screen
           

        DESCRIPTION
                
                This function is called when a sprite is to be drawn on the canvas. Each spriteindex's center is defined by taking the width/2 and height/2, This is used
                in order to draw the image correctly with spritebatch.draw. First it checks if the object is alive if it is not there is no point in drawing the object.
                next it takes the spriteindex, position, a source rectangle, color, rotation, center, scale, sprite effects (flip horizontal, flip vertical or none, and 
                the depth layer of the object on the canvas.
     
     
 
        AUTHOR

                Thomas Wolski 

        DATE

               3:40pm 8/13/2016

        */
        /**/
        public virtual void Draw(SpriteBatch spritebatch)
        {
         if (!alive) 
         { 
             return; 
         
         }
       
         
         Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);
            //texture, position , rectangle , color, rotation, origin,scale ,effect, layer
         spritebatch.Draw(spriteIndex, position, null, color, MathHelper.ToRadians(rotation), center, scale, SpriteEffects.None, 0);
      

        }


        /**/
        /*
      Draw

        NAME

                Collision - a bool function to check if an object has collided with another object

        SYNOPSIS
             pos -  the position of the object on the canvas.
             obj -  the current object that is being checked with another object on the canvas.
           

        DESCRIPTION
                
                This function is called to check if one object will collided with another. It takes the area of the sprite object and then creates a new area
                with a future area's position. Then for each object in the object list that is solid "Intersects" the new area, then a collision has been created returning
                true, if not then it will return false

        AUTHOR

                Thomas Wolski 

        DATE

               3:50pm 8/13/2016

        */
        /**/
        public bool Collision(Vector2 pos, Obj obj)
        {

            Rectangle newarea = new Rectangle(area.X, area.Y, area.Width, area.Height);
            newarea.X += (int)pos.X;
            newarea.Y += (int)pos.Y;

            foreach (Obj o in items.objList)
            {
                if (o.GetType() == obj.GetType() && o.solid)
                {
                    if (o.area.Intersects(newarea))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /**/
        /*
      Draw

        NAME

                Collision - a bool function to check if an object has collided with another object

        SYNOPSIS
            
             obj -  the current object that is being checked with another object on the canvas.
           

        DESCRIPTION
                This function is called to check if one object collided with another.  Then for each object in the object list that is solid "Intersects" 
                the area, then a collision has been created returning true, if not then it will return false


        AUTHOR

                Thomas Wolski 

        DATE

               4:00pm 8/13/2016

        */
        /**/
        public Obj Collision(Obj obj)
        {

            foreach (Obj o in items.objList)
            {
                if (o.GetType() == obj.GetType() && o.alive )
                {
                    if (o.area.Intersects(area))
                    {
                        return o;
                    }
                }
            }
            return new Obj();
        }


        /**/
        /*
      Draw

        NAME

                UpdateArea - Updates the area of the Sprite object

        SYNOPSIS
            
            
           

        DESCRIPTION
                This function is called to update the sprites area. This takes the sprite objects x and y coordinate and subtracts half the width or height from the position depending 
                on if it is the X or Y coordinate to get the sprites new position.


        AUTHOR

                Thomas Wolski 

        DATE

               4:10pm 8/13/2016

        */
        /**/

        public void UpdateArea()
        {   // setting the x and y  to the new x and y
            // so the area of the bullet changes every time shot
            // was getting stuck because area did not update
            area.X = (int)position.X - (spriteIndex.Width / 2);
            area.Y = (int)position.Y - (spriteIndex.Height / 2);
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

               4:15pm 8/13/2016

        */
        /**/
        public virtual void Movement(float pix, float dir)
        {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
            
        }
     }
 }
