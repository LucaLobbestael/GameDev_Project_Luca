using GameDev_Project_Luca.Animation;
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
    internal class FlyingEnemy : IGameObject
    {
        //textures & animation
        private Texture2D flyTexture;
        private Animation.Animation flyingAnimation;
        private Animation.Animation deathAnimation;
        Animation.Animation animation;
        private SpriteEffects flipped = new SpriteEffects();
        //movement related
        private Hero target;
        private Vector2 speed = new Vector2(0.5f, 0.5f);
        Vector2 position = new Vector2(100, 100);
        Vector2 direction;

        public FlyingEnemy(Texture2D texture, Hero hero)
        {
            //set texture
            flyTexture = texture;
            //init animations
            flyingAnimation = new Animation.Animation();
            deathAnimation = new Animation.Animation();
            //flyinganimation
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            flyingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));
            //deathanimation
            deathAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 96, 32, 32)));
            deathAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            deathAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));
            deathAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 96, 32, 32)));
            //set target
            target = hero;
            //set animation
            animation = flyingAnimation;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction.X < 0)
                flipped = SpriteEffects.FlipHorizontally;
            else
                flipped = SpriteEffects.None;
            spriteBatch.Draw(flyTexture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1, flipped, 0f);
        }

        public void Update(GameTime gameTime)
        {
            if(target.position.X < this.position.X)
            {
                direction.X = -1;
            }
            else if(target.position.X > this.position.X)
            {
                direction.X = 1;
            }
            if (target.position.Y < this.position.Y)
            {
                direction.Y = -1;
            }
            else if(target.position.Y > this.position.Y)
            {
                direction.Y = 1;
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
