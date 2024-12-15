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
    internal class FollowingEnemy : IGameObject
    {
        //textures & animation
        private Texture2D texture;
        private Animation.Animation idleAnimation;
        private Animation.Animation walkingAnimation;
        private Animation.Animation deathAnimation;
        Animation.Animation animation;
        private SpriteEffects flipped = new SpriteEffects();
        //movement related
        private Hero target;
        private Vector2 speed = new Vector2(0.5f, 0.5f);
        Vector2 position = new Vector2(100, 100);
        Vector2 direction;
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
            //TODO: Implement
            throw new NotImplementedException();
        }
    }
}
