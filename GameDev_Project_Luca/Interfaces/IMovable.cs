using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IMovable
    {
        public Vector2 position { get; set; }
        public Vector2 speed { get; set; }
        public IInputreader inputreader { get; set; }
    }
}
