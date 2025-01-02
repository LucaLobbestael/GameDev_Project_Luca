using Microsoft.Xna.Framework;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IMovable
    {
        public Vector2 position { get; set; }
        public Vector2 speed { get; set; }
        public IInputreader inputreader { get; set; }
    }
}
