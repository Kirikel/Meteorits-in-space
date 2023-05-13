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
    class Controller
    {
        public List<Asteroids> Asteroids = new List<Asteroids>();
        public double timer = 2D;
        public double maxTime = 2D;
        public int nextSpeed = 840;
        public float totalTime = 0f;

        public bool inGame = false;
        public void conUpdate(GameTime gameTime)
        {
            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState kState = Keyboard.GetState();
                if (kState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                    totalTime = 0f;
                    timer = 2D;
                    maxTime = 2D;
                    nextSpeed = 840;
                }
            }

            if (timer <= 0)
            {
                Asteroids.Add(new Asteroids(nextSpeed));
                timer = maxTime;
                if (maxTime > 0.5)
                {
                    maxTime -= 0.1D;
                }
                if (nextSpeed < 720)
                {
                    nextSpeed += 4;
                }

            }
        }
    }
}
//стало 840