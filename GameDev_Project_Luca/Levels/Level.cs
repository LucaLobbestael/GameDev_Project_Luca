using GameDev_Project_Luca.Factories;
using GameDev_Project_Luca.GameComponents;
using GameDev_Project_Luca.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameDev_Project_Luca.Levels
{
    internal class Level
    {
        public Hero hero;
        public bool IsFinished = false;
        public List<Block> blocks = new List<Block>();
        // 0 = air
        // 1 = grassblock
        // 2 = dirtblock
        // 3 = player
        // 4 = flying enemy
        // 5 = shy enemy
        // 6 = guarding enemy
        // 8 = finish
        // 9 = killzone
        public int[,] gameboard;

        public void CreateBlocks(Texture2D grass, Texture2D dirt)
        {
            for (int l = 0; l < gameboard.GetLength(1); l++)
            {
                for (int k = 0; k < gameboard.GetLength(0); k++)
                {
                    if (gameboard[k, l] != 3)
                    {
                        blocks.Add(BlockFactory.CreateBlock(l * 50, k * 50, gameboard[k, l], grass, dirt));
                    }
                    else
                    {
                        hero.position = new Vector2(l * 50, k * 50);
                    }
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
