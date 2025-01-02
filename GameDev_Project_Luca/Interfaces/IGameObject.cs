using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IGameObject
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
