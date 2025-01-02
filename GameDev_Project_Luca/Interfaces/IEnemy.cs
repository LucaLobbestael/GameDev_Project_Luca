using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IEnemy
    {
        Rectangle BoundingBox
        {
            get;
            set;
        }
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
