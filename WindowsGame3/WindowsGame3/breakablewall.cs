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
    class breakablewall :Obj
    {
        const int MaxHp = 10;
        int health ;

                public breakablewall(Vector2 pos): base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "Image2";
          // alive = false;
            health = 10;

            
        }
                public override void move()
                {
                    if (!alive)
                    {
                        return;
                    }

                    if (health <= 0)
                    {
                        alive = false;
                        solid = false;
                       health = MaxHp;
                       
                    }


                    base.move();
                }

                public void damage(int dmg)
                {
                    health -= dmg;
                }




    }
}
