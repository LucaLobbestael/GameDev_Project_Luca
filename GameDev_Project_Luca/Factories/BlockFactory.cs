using GameDev_Project_Luca.GameComponents;
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
        public static Block CreateBlock(int x, int y, int type, Texture2D grass, Texture2D dirt)
        {
            string Type ="";
            switch(type)
            {
                case 0:
                    Type = "";
                    break;
                case 1:
                    Type = "NORMAL";
                    break;
                case 2:
                    Type = "DIRT";
                    break;
                default:
                    Type = "";
                    break;

            }
            Block newBlock = null;
            Type = Type.ToUpper();
            if (Type == "NORMAL")
            {
                newBlock = new Block(x, y, grass);
            }
            else if (Type == "DIRT")
            {
                newBlock = new Block(x,y, dirt);
            }
            else if (Type == "")
            {
                newBlock = new Block();
            }
            return newBlock;
        }
    }
}
