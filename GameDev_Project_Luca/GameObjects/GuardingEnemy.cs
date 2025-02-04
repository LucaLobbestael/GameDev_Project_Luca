﻿using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_Project_Luca.GameObjects
{
    internal class GuardingEnemy : IEnemy, IGameObject
    {
        //textures & animation
        private Texture2D texture;
        private Animation.Animation walkingAnimation;
        Animation.Animation animation;
        int scale = 2;
        private SpriteEffects flipped = new SpriteEffects();
        //movement related
        private float boundary = 45f;
        private Vector2 speed = new Vector2(0.75f, 0.75f);
        Vector2 position;
        Vector2 startingPosition;
        Vector2 direction;
        bool hasFlipped = false;
        private Rectangle boundingBox;

        public Rectangle BoundingBox { get => boundingBox; set => boundingBox = value; }

        public GuardingEnemy(Texture2D texture, int x, int y)
        {
            //set texture
            this.texture = texture;
            //init animations
            walkingAnimation = new Animation.Animation();
            //flyinganimation
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 64, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 64, 32, 32))); //(32x32), 20x15
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 64, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 64, 32, 32)));
            //set animation
            animation = walkingAnimation;
            //set position
            startingPosition = new Vector2(x, y - 15);
            position = startingPosition;
            boundingBox = new Rectangle(x + 6, y + 2, 20 * scale, 15 * scale);
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
            if (hasFlipped == false)
            {
                if (position.X != startingPosition.X + boundary)
                {
                    direction.X = 1;
                }
                else
                    hasFlipped = true;
            }
            else
            {
                if (position.X != startingPosition.X - boundary)
                {
                    direction.X = -1;
                }
                else
                    hasFlipped = false;
            }
            this.Move();
            animation.Update(gameTime);
        }

        public void Move()
        {
            position.X += (direction.X * speed.X);
            boundingBox.X = (int)position.X;
        }
    }
}
