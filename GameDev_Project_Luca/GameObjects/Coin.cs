using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameObjects
{
    internal class Coin : IGameObject
    {
        public Texture2D CoinTexture;
        public Rectangle BoundingBox;
        public Animation.Animation RotatingAnimation;
        int scale = 2;
        public bool Collected = false;
        private Vector2 position;

        public Coin(Texture2D texture, int x, int y)
        {
            //set texture
            CoinTexture = texture;
            //init animations
            RotatingAnimation = new Animation.Animation();
            //flyinganimation
            RotatingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 16, 16)));
            RotatingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(16, 0, 16, 16)));
            RotatingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 16, 16)));
            //set position
            position = new Vector2(x+5, y+3);
            BoundingBox = new Rectangle((int)position.X, (int)position.Y, 20 * scale,20 * scale);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Collected)
            {
                spriteBatch.Draw(CoinTexture, position, RotatingAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        public void Update(GameTime gameTime)
        {

            RotatingAnimation.Update(gameTime);
        }
    }
}
