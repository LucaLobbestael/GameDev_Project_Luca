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
        public static Block CreateBlock(int x, int y, int type)
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
                    Type = "GHOST";
                    break;

            }
            Block newBlock = null;
            Type = Type.ToUpper();
            if (Type == "NORMAL")
            {
                newBlock = new Block(x, y);
            }
            else if (Type == "GHOST")
            {
                newBlock = new GhostBlock(x,y);
            }
            return newBlock;
        }
    }
}
