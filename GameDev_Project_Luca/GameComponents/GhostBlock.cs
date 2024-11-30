using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.GameComponents
{
    class GhostBlock:Block
    {
        public GhostBlock(int x, int y ):base (x,y)
        {
            Passable = true;
            Color = Color.Gray;
            BoundingBox = new Rectangle(x, y, 50, 50);
        }
        public void setTexture(Texture2D texture)
        {
            Texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Color);
        }
    }
}
