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
        public List<asteroids> asteroids = new List<asteroids>();
        public double timer = 2D;
        public double maxTime = 2D;
        public int nextSpeed = 740;

        public bool inGame = false;
        public void conUpdate(GameTime gameTime)
        {
            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState kState = Keyboard.GetState();
                if (kState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                }
            }

            if (timer <= 0)
            {
                asteroids.Add(new asteroids(nextSpeed));
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
//в контроллере 240 было стало 740