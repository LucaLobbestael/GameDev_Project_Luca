using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameObjects
{
    internal class ShyEnemy : Enemy, IGameObject
    {
        //textures & animation
        private Texture2D texture;
        private Animation.Animation flyingAnimation;
        private Animation.Animation deathAnimation;
        Animation.Animation animation;
        private SpriteEffects flipped = new SpriteEffects();
        //movement related
        private Hero target;
        private Vector2 speed = new Vector2(0.5f, 0.5f);
        Vector2 position = new Vector2(100, 100);
        Vector2 direction;

        public ShyEnemy(Texture2D texture, Hero hero, int x, int y)
        {
            //set texture
            this.texture = texture;
            //init animations
            flyingAnimation = new Animation.Animation();
            //flyinganimation
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));
            //set target
            target = hero;
            //set animation
            animation = flyingAnimation;
            //set position
            position = new Vector2(x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction.X < 0)
                flipped = SpriteEffects.FlipHorizontally;
            else
                flipped = SpriteEffects.None;
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1, flipped, 0f);
        }

        public void Update(GameTime gameTime)
        {
            if (target.position.X < this.position.X && target.flipped == SpriteEffects.FlipHorizontally || target.position.X > this.position.X && target.flipped == SpriteEffects.None)
            {
                if (target.boundingBox.X < this.position.X)
                {
                    direction.X = -1;
                }
                else if (target.boundingBox.X > this.position.X)
                {
                    direction.X = 1;
                }
                if (target.boundingBox.Y < this.position.Y)
                {
                    direction.Y = -1;
                }
                else if (target.boundingBox.Y > this.position.Y)
                {
                    direction.Y = 1;
                }
            }
            this.Move();
            animation.Update(gameTime);
        }

        public void Move()
        {
            position.X += (direction.X * speed.X);
            position.Y += (direction.Y * speed.Y);
        }
    }
}
