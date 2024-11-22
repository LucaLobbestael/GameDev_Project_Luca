using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.GameObjects
{
    internal class Hero:IGameObject, IMovable
    {
        Texture2D heroTexture;
        Animation.Animation animation;
        Animation.Animation idleAnimation;
        Animation.Animation walkingAnimation;
        private SpriteEffects flipped = new SpriteEffects();
        private bool isGrounded;
        private IInputreader inputreader;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 maxSpeed;
        private Vector2 accelleration;
        private Rectangle boundingBox;
        public Rectangle block;
        

        Vector2 IMovable.position { get => this.position; set => this.position = position; }
        Vector2 IMovable.speed { get => this.speed; set => this.speed = speed; }
        IInputreader IMovable.inputreader { get => this.inputreader; set => this.inputreader = inputreader; }

        public Hero(Texture2D texture, IInputreader inputreader)
        {
            heroTexture = texture;
            this.inputreader = inputreader;
            animation = new Animation.Animation();
            idleAnimation = new Animation.Animation();
            walkingAnimation = new Animation.Animation();
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));

            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0,32,32,32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 32, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 32, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 32, 32, 32)));
            position = new Vector2(0, 0);
            speed = new Vector2(1, 1);
            maxSpeed = new Vector2(10, 10);
            boundingBox = new Rectangle(6, 22, 17, 10);
        }

        public void Update(GameTime gameTime)
        {
            if (boundingBox.Bottom == block.Top && boundingBox.X > block.Left && boundingBox.X < block.Right)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                accelleration += new Vector2(1,1);
            }
            Move();
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) ||Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                flipped = SpriteEffects.FlipHorizontally;
            }
            else
            {
                flipped = SpriteEffects.None;
            }
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1, flipped, 0f);
        }
        private void Move()
        {
            Vector2 direction = inputreader.ReadInput();
            if (direction != new Vector2(0, 0))
            {
                animation = walkingAnimation;
            }
            else
            {
                animation = idleAnimation;
            }

            if (!isGrounded)
            { 
                direction.Y = 1;
                //direction.Y *= accelleration.Y;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                direction.X *= 2;
            //if (direction.Length() <= maxSpeed.Length())
            direction *= speed;
            boundingBox.X = (int)position.X+3;
            boundingBox.Y = (int)position.Y+22;
            boundingBox.X += (int)direction.X;
            boundingBox.Y += (int)direction.Y;
            if (boundingBox.Intersects(block))
            {
                boundingBox.X -= (int)direction.X;
                boundingBox.Y -= (int)direction.Y;
            }
            else
            {
                position += direction;
            }
            
            
        }
    }
}
