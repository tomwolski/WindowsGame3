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

        public Rectangle roomsize = new Rectangle(0, 0, Game1.screen.Width, Game1.screen.Height);
        public Obj(Vector2 pos)
        {
            position = pos;
            rotation = 0.0f;
            color = color;

        }

        public Obj()
        {

        }

        public virtual void move()
        {

            if (!alive) 
            { 
                return;
            }

            // want the corner of the sprite rectangle
            UpdateArea();


            Movement(speed, rotation);


        }


        public virtual void loadContent(ContentManager content, string sprName)
        {
            spriteName = sprName;

            spriteIndex = content.Load<Texture2D>(this.spriteName);

            area = new Rectangle(0, 0, spriteIndex.Width, spriteIndex.Height);
        }
        
        public virtual void Draw(SpriteBatch spritebatch)
        {
         if (!alive) 
         { 
             return; 
         
         }
       
         
         Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);

         spritebatch.Draw(spriteIndex, position, null, color, MathHelper.ToRadians(rotation), center, scale, SpriteEffects.None, 0);
      

}
        // takes in a offset and obj
        // offset - for prediction for movement
        // specify what object to check colition for
        public bool collision(Vector2 pos, Obj obj)
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


        public Obj collision( Obj obj)
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

        // setting the x and y  to the new x and y
        // so the area of the bullet changes everytime shot
        // was gettig stuck because area ddint update
        public void UpdateArea()
        {
            area.X = (int)position.X - (spriteIndex.Width / 2);
            area.Y = (int)position.Y - (spriteIndex.Height / 2);
        }

        public virtual void Movement(float pix, float dir)
        {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
            
        }
     }
 }
