using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids_in_space
{
    class asteroids
    {
        public Vector2 position;
        public int speed;
        public int radius = 59;

        static Random rand = new Random();
        public asteroids(int newSpeed)
        {
            speed = newSpeed;

            position = new Vector2(1280 + radius, rand.Next(0, 721));
        }
        public void asteroidsUpdate(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.X -= speed * dt;
        }
    }
}
