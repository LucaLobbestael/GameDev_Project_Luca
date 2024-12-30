using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.States
{
    internal class Gamestate
    {
        private string state = "MENU";

        public void changeState(int newstate)
        {
            switch (newstate)
            {
                case 0:
                    state = "MENU";
                    break;
                case 1:
                    state = "GAME";
                    break;
                case 2:
                    state = "VICTORY";
                    break;
                default:
                    state = "MENU";
                    break;
            }
        }

        public int CheckState()
        {
            // 0 = Menu
            // 1 = Game
            // 2 = Victory
            int stateInt = 0;
            
            switch (state)
            {
                case "MENU":
                    stateInt = 0;
                    break;
                case "GAME":
                    stateInt = 1;
                    break;
                case "VICTORY":
                    stateInt = 2;
                    break;
                default:
                    stateInt = 0;
                    break;
            }
            return stateInt;
        }
    }
}
