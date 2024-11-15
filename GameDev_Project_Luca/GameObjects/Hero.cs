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
        bool isFalling;
        private IInputreader inputreader;
        private Vector2 position;
        private Vector2 speed;
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
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(0,0,32,32)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new Animation.AnimationFrame(new Rectangle(96, 0, 32, 32)));
            position = new Vector2(0, 0);
            speed = new Vector2(2, 2);
            boundingBox = new Rectangle(6, 22, 17, 10);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            if (boundingBox.Bottom == block.Top && boundingBox.X > block.Left && boundingBox.X < block.Right)
            {
                isFalling = false;
            }
            else
            {
                isFalling = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
        private void Move()
        {
            Vector2 direction = inputreader.ReadInput();
            if (isFalling)
            {
                direction.Y = 1;
            }
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
