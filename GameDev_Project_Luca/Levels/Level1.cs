using GameDev_Project_Luca.Factories;
using GameDev_Project_Luca.GameComponents;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Levels
{
    class Level1
    {
        public List<Block> blocks = new List<Block>();
    int[,] gameboard = new int[,]
    {
        { 0,1,1,1,1,1,1,1 },
        { 0,0,1,1,0,1,1,1 },
        { 1,0,0,0,0,0,0,1 },
        { 1,1,1,1,1,1,0,1 },
        { 1,0,0,0,0,0,0,2 },
        { 1,0,1,1,1,1,1,2 },
        { 1,0,0,0,0,0,0,0 },
        { 1,1,1,1,1,1,1,1 }
    };

        public void CreateBlocks()
        {
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    blocks.Add(BlockFactory.CreateBlock(l*50, k*50, gameboard[l, k]));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.Draw(spriteBatch);
                }
            }
        }

    }
}
