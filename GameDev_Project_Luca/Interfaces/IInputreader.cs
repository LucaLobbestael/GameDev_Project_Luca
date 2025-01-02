using System.Numerics;

namespace GameDev_Project_Luca.Interfaces
{
    public interface IInputreader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
