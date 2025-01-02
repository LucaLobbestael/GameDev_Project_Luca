using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameComponents
{
    class Block : Interfaces.IGameComponent
    {
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }

        public Block()
        {
            Passable = false;
            Color = Color.Red;
            BoundingBox = Rectangle.Empty;
        }
        public Block(int x, int y, Texture2D tileSet)
        {
            Passable = false;
            Color = Color.White;
            BoundingBox = new Rectangle(x, y, 50, 50);
            Texture = tileSet;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Texture == null)
            {

            }
            else
            {
                spriteBatch.Draw(Texture, BoundingBox, Color);
            }
        }

    }
}
