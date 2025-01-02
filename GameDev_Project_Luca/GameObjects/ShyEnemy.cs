using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameObjects
{
    internal class ShyEnemy : IEnemy, IGameObject
    {
        //textures & animation
        private Texture2D texture;
        private Animation.Animation flyingAnimation;
        Animation.Animation animation;
        private SpriteEffects flipped = new SpriteEffects();
        int scale = 2;
        //movement related
        private Hero target;
        private Vector2 speed = new Vector2(0.5f, 0.5f);
        Vector2 position = new Vector2(100, 100);
        Vector2 direction;
        private Rectangle boundingBox;

        public Rectangle BoundingBox { get => boundingBox; set => boundingBox = value; }

        public ShyEnemy(Texture2D texture, Hero hero, int x, int y)
        {
            //set texture
            this.texture = texture;
            //init animations
            flyingAnimation = new Animation.Animation();
            //flyinganimation
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 96, 32, 32))); //(127/127)
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 96, 32, 32)));
            //set target
            target = hero;
            //set animation
            animation = flyingAnimation;
            //set position
            position = new Vector2(x, y);
            boundingBox = new Rectangle(x + 8, y + 18, 14 * scale, 12 * scale);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction.X < 0)
                flipped = SpriteEffects.FlipHorizontally;
            else
                flipped = SpriteEffects.None;
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, flipped, 0f);
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
            else
            {
                direction = new Vector2(0, 0);
            }
            this.Move();
            animation.Update(gameTime);
        }

        public void Move()
        {
            position.X += (direction.X * speed.X);
            position.Y += (direction.Y * speed.Y);
            boundingBox.X = (int)position.X;
            boundingBox.Y = (int)position.Y;
        }
    }
}
