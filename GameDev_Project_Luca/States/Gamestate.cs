using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.States
{
    internal class Gamestate
    {
        // 0 = menu
        // 1 = game
        // 2 = victory
        private int state = 0;

        public void changeState(int newstate)
        {
            state = newstate;
        }

        public int CheckState()
        {
            // 0 = Menu
            // 1 = Game
            // 2 = Victory
            return state;
        }
    }
}
