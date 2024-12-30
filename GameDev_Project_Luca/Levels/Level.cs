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
        public List<Enemy> enemies = new List<Enemy>();
        int levelNr = 1;
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
                    if (gameboard[k, l] != 3 && gameboard[k, l] != 4 && gameboard[k, l] != 5 && gameboard[k, l] != 6)
                    {
                        blocks.Add(BlockFactory.CreateBlock(l * 50, k * 50, gameboard[k, l], grass, dirt));
                    }
                    else if (gameboard[k, l] == 3 )
                    {
                        hero.position = new Vector2(l * 50, k * 50);
                    }
                    else if (gameboard[k, l] == 4)
                    {
                        
                    }
                    else if (gameboard[k, l] == 5)
                    {
                        
                    }
                    else if (gameboard[k, l] == 6)
                    {
                        
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

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            /*foreach (var enemy in enemies)
            {
                enemy.Update(gameTime)
            }*/
        }

        public bool CheckLevelStatus()
        {
            return IsFinished;
        }

        public int SwitchLevel()
        {
            levelNr++;
            IsFinished = false;
            blocks.Clear();
            enemies.Clear();

            switch (levelNr)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                default:
                    return 4;
            }
        }
    }
}
