using GameDev_Project_Luca.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Luca.Interfaces
{
    internal interface IEnemy
    {
        Rectangle BoundingBox
        {
            get;
            set;
        }
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
