using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace GameDev_Project_Luca.GameComponents
{
    internal class Menu
    {
        public Texture2D titleScreen;
        public Texture2D startSelected;
        public Texture2D ExitSelected;
        private bool selectedStart = true;
        public bool Update()
        {
            bool enter = false;
            if (selectedStart == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    selectedStart = false;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    selectedStart = true;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                enter = true;
            return enter;
        }

        public int PressedEnter()
        {
            //1 = start game, 9 = exit
            if (selectedStart == true)
                return 1;
            else
                return 9;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titleScreen, new Rectangle(0, 0, 1920, 1080), Color.White);
            if (selectedStart)
                spriteBatch.Draw(startSelected, new Rectangle(0, 0, 1920, 1080), Color.White);
            else
                spriteBatch.Draw(ExitSelected, new Rectangle(0, 0, 1920, 1080), Color.White);
        }
    }
}
