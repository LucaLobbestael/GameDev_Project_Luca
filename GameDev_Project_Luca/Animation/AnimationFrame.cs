using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Animation
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
