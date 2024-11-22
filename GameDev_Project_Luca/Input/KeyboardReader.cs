using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Input
{
    internal class KeyboardReader:IInputreader
    {
        public bool IsDestinationInput => true;
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
                direction.X -= 1;
            if (state.IsKeyDown(Keys.Right)||state.IsKeyDown(Keys.D))
                direction.X += 1;
            if (state.IsKeyDown(Keys.Up)||state.IsKeyDown(Keys.Z))
                direction.Y -= 1;
            return direction;
        }
    }
}
