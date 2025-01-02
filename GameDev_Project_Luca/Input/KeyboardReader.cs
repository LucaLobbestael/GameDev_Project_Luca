using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace GameDev_Project_Luca.Input
{
    internal class KeyboardReader : IInputreader
    {
        public bool IsDestinationInput => true;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
                direction.X -= (float)1.5;
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                direction.X += (float)1.5;
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Z))
                direction.Y -= (float)1.5;
            return direction;
        }
    }
}
