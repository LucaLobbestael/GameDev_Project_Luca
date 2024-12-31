using GameDev_Project_Luca.Factories;
using GameDev_Project_Luca.GameComponents;
using GameDev_Project_Luca.GameObjects;
using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameDev_Project_Luca.Levels
{
    internal class Level
    {
        public Hero hero;
        public Texture2D FlyingEnemy;
        public Texture2D GuardingEnemy;
        public Texture2D ShyEnemy;
        public Texture2D CoinTexture;

        public bool IsFinished = false;
        public List<Block> blocks = new List<Block>();
        public List<IEnemy> enemies = new List<IEnemy>();
        public List<Coin> Coins = new List<Coin>();
        public int levelNr = 1;
        // 0 = air
        // 1 = grassblock
        // 2 = dirtblock
        // 3 = player
        // 4 = flying enemy
        // 5 = shy enemy
        // 6 = guarding enemy
        // 7 = coins
        // 8 = finish
        // 9 = killzone
        public int[,] gameboard;

        public void CreateBlocks(Texture2D grass, Texture2D dirt)
        {
            IsFinished = false;
            for (int l = 0; l < gameboard.GetLength(1); l++)
            {
                for (int k = 0; k < gameboard.GetLength(0); k++)
                {
                    if (gameboard[k, l] != 3 && gameboard[k, l] != 4 && gameboard[k, l] != 5 && gameboard[k, l] != 6 && gameboard[k, l] != 7)
                    {
                        blocks.Add(BlockFactory.CreateBlock(l * 50, k * 50, gameboard[k, l], grass, dirt));
                    }
                    else if (gameboard[k, l] == 3)
                    {
                        hero.position = new Vector2(l * 50, k * 50);
                    }
                    else if (gameboard[k, l] == 4)
                    {
                        enemies.Add(new FlyingEnemy(FlyingEnemy, hero, l * 50, k * 50));
                    }
                    else if (gameboard[k, l] == 5)
                    {
                        enemies.Add(new ShyEnemy(ShyEnemy, hero, l * 50, k * 50));
                    }
                    else if (gameboard[k, l] == 6)
                    {
                        enemies.Add(new GuardingEnemy(GuardingEnemy, l * 50, k * 50));
                    }
                    else if (gameboard[k,l] == 7)
                    {
                        Coins.Add(new Coin(CoinTexture, l * 50, k * 50));
                    }
                }
            }
            hero.Enemies = enemies;
            hero.Coins = Coins;
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

            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            foreach (var coin in Coins)
            {
                coin.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (var coin in Coins)
            {
                coin.Update(gameTime);
            }
        }

        public bool CheckLevelStatus()
        {
            return IsFinished;
        }

        public int SwitchLevel()
        {
            levelNr += 1;
            blocks.Clear();
            enemies.Clear();
            Debug.WriteLine(levelNr);
            return levelNr;
        }
    }
}
