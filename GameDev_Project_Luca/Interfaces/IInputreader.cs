using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Interfaces
{
    public interface IInputreader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
