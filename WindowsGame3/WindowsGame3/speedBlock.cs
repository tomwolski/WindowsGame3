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
    class speedBlock : Obj
{

        public speedBlock(Vector2 pos)
            : base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "speedBlock";
        }
    }
}
