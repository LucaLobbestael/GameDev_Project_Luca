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
    internal class Hero:IGameObject, IMovable
    {
        Texture2D heroTexture;
        Animation.Animation animation;
        private IInputreader inputreader;
        private Vector2 position;
        private Vector2 speed;

        Vector2 IMovable.position { get => this.position; set => this.position = position; }
        Vector2 IMovable.speed { get => this.speed; set => this.speed = speed; }
        IInputreader IMovable.inputreader { get => this.inputreader; set => this.inputreader = inputreader; }

        public Hero(Texture2D texture, IInputreader inputreader)
        {
            heroTexture = texture;
            this.inputreader = inputreader;
            animation = new Animation.Animation();
            //animation.AddFrame();
            //Add spritesheet and add animationframes!!!
            position = new Vector2(0, 0);
            speed = new Vector2(1, 1);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
        private void Move()
        {
            Vector2 direction = inputreader.ReadInput();
            direction *= speed;
            position += direction;
        }
    }
}
