using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameComponents
{
    internal class KillZone : Block
    {
        public KillZone(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            BoundingBox = new Rectangle(x, y, 50, 50);
            Passable = false;
            Color = Color.Transparent;
            Texture = texture;
        }
    }
}
