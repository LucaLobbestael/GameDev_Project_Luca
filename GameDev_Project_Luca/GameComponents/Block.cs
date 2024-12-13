using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void setTexture(Texture2D texture)
        {
            Texture = texture;
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
