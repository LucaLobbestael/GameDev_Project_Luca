using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_Project_Luca.GameComponents
{
    internal class VictoryScreen
    {
        public Texture2D Victory;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Victory, new Rectangle(0, 0, 1920, 1080), Color.White);
        }

        public bool Update()
        {
            bool retry = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                retry = true;
            }
            return retry;
        }
    }
}
