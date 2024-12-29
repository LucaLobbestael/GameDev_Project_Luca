using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameComponents
{
    internal class FinishBlock : Block
    {
        public FinishBlock(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            BoundingBox = new Rectangle(x, y, 50, 50);
            Passable = false;
            Color = Color.Yellow;
            Texture = texture;
        }
    }
}
