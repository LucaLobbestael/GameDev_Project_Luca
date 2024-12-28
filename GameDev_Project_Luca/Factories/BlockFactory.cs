using GameDev_Project_Luca.GameComponents;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.Factories
{
    class BlockFactory
    {
        public static Block CreateBlock(int x, int y, int type1, Texture2D grass, Texture2D dirt)
        {
            string type = "";
            switch (type1)
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
                case 8:
                    type = "FINISH";
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
                case "FINISH":
                    newBlock = new FinishBlock(x, y, grass);
                    break;
                case "KILL":
                    newBlock = new KillZone(x, y, dirt);
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
