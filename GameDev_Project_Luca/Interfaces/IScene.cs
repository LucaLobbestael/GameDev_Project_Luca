using GameDev_Project_Luca.GameComponents;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IScene
    {


        public List<Block> blocks { get; set; }
        public int[,] gameboard { get; set; }

        public void CreateBlocks(Texture2D grass, Texture2D dirt);

        public void Draw(SpriteBatch spriteBatch);

    }
}
