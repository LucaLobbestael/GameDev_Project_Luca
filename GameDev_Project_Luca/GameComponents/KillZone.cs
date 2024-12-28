using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.GameComponents
{
    internal class KillZone : Block
    {
        Rectangle zone;
        Texture2D texture;
        Color color = Color.Transparent;

        public KillZone(int x, int y, Texture2D texture)
        {
            zone = new Rectangle(x, y, 50, 50);
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, zone, color);
        }
    }
}
