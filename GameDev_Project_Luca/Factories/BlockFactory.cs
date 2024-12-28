using GameDev_Project_Luca.GameComponents;
using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Factories
{
    class BlockFactory
    {
        public static Block CreateBlock(int x, int y, int type1, Texture2D grass, Texture2D dirt)
        {
            string type ="";
            switch(type1)
            {
                case 0:
                    type = "";
                    break;
                case 1:
                    type = "NORMAL";
                    break;
                case 2:
                    type = "DIRT";
                    break;
                case 3:
                    type = "PLAYER";
                    break;
                case 4:
                    type = "FLYING";
                    break;
                case 5:
                    type = "SHY";
                    break;
                case 6:
                    type = "GUARDING";
                    break;
                case 9:
                    type = "KILL";
                    break;
                default:
                    type = "";
                    break;

            }
            Block newBlock = null;
            type = type.ToUpper();
            switch (type)
            {
                case "NORMAL":
                    newBlock = new Block(x, y, grass);
                    break;
                case "DIRT":
                    newBlock = new Block(x, y, dirt);
                    break;
                case "PLAYER":
                    newBlock = new Block();
                    break;
                case "FLYING":
                    newBlock = new Block();
                    break;
                case "SHY":
                    newBlock = new Block();
                    break;
                case "GUARDING":
                    newBlock = new Block();
                    break;
                case "KILL":
                    newBlock = new KillZone(x,y, dirt);
                    break;
                case "":
                    newBlock = new Block();
                    break;
                default:
                    newBlock = new Block();
                    break;
            }
            return newBlock;
        }
    }
}
