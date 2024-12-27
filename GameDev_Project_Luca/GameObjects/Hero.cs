using GameDev_Project_Luca.GameComponents;
using GameDev_Project_Luca.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace GameDev_Project_Luca.GameObjects
{
    internal class Hero : IGameObject, IMovable
    {
        //textures
        private Texture2D heroTexture;
        private Animation.Animation animation;
        private Animation.Animation idleAnimation;
        private Animation.Animation walkingAnimation;
        private Animation.Animation layingAnimation;
        public SpriteEffects flipped = new SpriteEffects();
        private int scale = 2;
        //checks
        private bool isGrounded;
        private bool isFalling;
        private bool reachedMaxJumpHeight;
        private IInputreader inputreader;
        //movement
        public Vector2 position;
        private Vector2 lastGroundedPosition;
        private Vector2 speed;
        private Vector2 maxSpeed;
        private Vector2 accelleration;
        private Vector2 maxAccelleration;
        private Vector2 maxJumpHeight;
        public Rectangle boundingBox;
        public Block collidedBlock;
        public List<Block> blocks;


        Vector2 IMovable.position { get => this.position; set => this.position = position; }
        Vector2 IMovable.speed { get => this.speed; set => this.speed = speed; }
        IInputreader IMovable.inputreader { get => this.inputreader; set => this.inputreader = inputreader; }

        public Hero(Texture2D texture, IInputreader inputreader)
        {
            //initialize properties
            animation = new Animation.Animation();
            idleAnimation = new Animation.Animation();
            walkingAnimation = new Animation.Animation();
            layingAnimation = new Animation.Animation();
            //add animationframes
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            idleAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));

            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(0, 32, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 32, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 32, 32, 32)));
            walkingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 32, 32, 32)));

            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));
            layingAnimation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 96, 32, 32)));

            //add data to vars
            heroTexture = texture;
            this.inputreader = inputreader;
            position = new Vector2(0, 0);
            speed = new Vector2(1, 1);
            maxAccelleration = new Vector2(2, 25);
            maxSpeed = new Vector2(10, 10);
            boundingBox = new Rectangle(6*scale, 22*scale, 17*scale, 10*scale);
            isFalling = true;
            reachedMaxJumpHeight = false;
            collidedBlock = new Block();
        }
        public void Update(GameTime gameTime)
        {
            //set grounded
            foreach (var block in blocks)
            {
                if (boundingBox.Intersects(block.BoundingBox))
                {
                    collidedBlock = block;
                    position.Y -= 1;
                }

            }
            if (boundingBox.Bottom == collidedBlock.BoundingBox.Top && boundingBox.Right > collidedBlock.BoundingBox.Left && boundingBox.Left < collidedBlock.BoundingBox.Right)
            {
                isGrounded = true;
                isFalling = false;
                accelleration = Vector2.Zero;
                reachedMaxJumpHeight = false;
            }
            else
            {
                isGrounded = false;
                if (accelleration.Y < maxAccelleration.Y)
                    accelleration += new Vector2(0, 1);
            }

            //set last grounded position + max jump height
            if (isGrounded)
            {
                this.lastGroundedPosition = position;
                this.maxJumpHeight.Y = (this.lastGroundedPosition.Y -= 75);
            }
            Move();
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //if go left look left and vice-versa
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                flipped = SpriteEffects.FlipHorizontally;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                flipped = SpriteEffects.None;
            }
            //draw hero
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, flipped, 0f);
        }
        private void Move()
        {
            Vector2 direction = inputreader.ReadInput();
            //set right animation
            if (direction != new Vector2(0, 0))
            {
                animation = walkingAnimation;
            }
            else
            {
                animation = idleAnimation;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && isGrounded)
                animation = layingAnimation;
            //basic gravity
            if (isFalling)
            {
                direction.Y = 1;
                if (direction.Length() < maxSpeed.Length())
                {
                    direction.Y += 2 * (accelleration.Y * (float)0.1);
                }
            }
            boundingBox.X += (int)direction.X;
            boundingBox.Y += (int)direction.Y;

            if (boundingBox.Intersects(collidedBlock.BoundingBox))
            {
                boundingBox.X -= (int)direction.X;
                boundingBox.Y -= (int)direction.Y;
                direction.Y = (float)0.1;
            }


            //basic jumping
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                if (position.Y >= maxJumpHeight.Y && reachedMaxJumpHeight == false)
                {
                    direction.Y = -6;
                }
                else
                {
                    isFalling = true;
                    reachedMaxJumpHeight = true;
                }
            }
            else
            {
                isFalling = true;
                reachedMaxJumpHeight = true;
            }

            //sprinting
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                direction.X *= 2;

            //moving left/right
            direction.X *= speed.X;
            boundingBox.X = (int)position.X + 7*scale;
            boundingBox.Y = (int)position.Y + 22*scale;
            boundingBox.X += (int)direction.X;
            boundingBox.Y += (int)direction.Y;

            Rectangle futureBound = boundingBox;
            futureBound.X += (int)direction.X;
            futureBound.Y += (int)direction.Y + 1;
            Rectangle nextBlock = new Rectangle();

            foreach (var block in blocks)
            {
                if (block.BoundingBox != Rectangle.Empty)
                {
                    if (futureBound.Intersects(block.BoundingBox))
                    {
                        nextBlock = block.BoundingBox;
                    }
                }
            }

            if (boundingBox.Intersects(collidedBlock.BoundingBox))
            {
                boundingBox.X -= (int)direction.X;
                boundingBox.Y -= (int)direction.Y;
            }
            else
            {
                if (!nextBlock.Intersects(boundingBox))
                {
                    position += direction;
                }
                
            }
        }
    }
}