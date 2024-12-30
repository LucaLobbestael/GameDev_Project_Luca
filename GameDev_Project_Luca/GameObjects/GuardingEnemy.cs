using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.GameObjects
{
    internal class GuardingEnemy : Enemy, IGameObject
    {
        //textures & animation
        private Texture2D texture;
        private Animation.Animation walkingAnimation;
        Animation.Animation animation;
        private SpriteEffects flipped = new SpriteEffects();
        //movement related
        private float boundary = 45f;
        private Vector2 speed = new Vector2(0.75f, 0.75f);
        Vector2 position;
        Vector2 startingPosition;
        Vector2 direction;
        bool hasFlipped = false;
        public GuardingEnemy(Texture2D texture, int x, int y)
        {
            //set texture
            this.texture = texture;
            //init animations
            walkingAnimation = new Animation.Animation();
            //flyinganimation
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));
            //set animation
            animation = walkingAnimation;
            //set position
            startingPosition = new Vector2(x, y);
            position = startingPosition;
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
        }
    }
}
