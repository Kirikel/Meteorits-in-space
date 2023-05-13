using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids_in_space
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D ship_Sprite;
        Texture2D asteroids_Sprite;
        Texture2D space_Sprite;

        SpriteFont gameFont;
        SpriteFont timerFont;

        Ship player = new Ship();

        Controller gameController = new Controller();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship_Sprite = Content.Load<Texture2D>("ship");
            asteroids_Sprite = Content.Load<Texture2D>("asteroid");
            space_Sprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.shipUpdate(gameTime, gameController);
            gameController.conUpdate(gameTime);

            for (int i = 0; i < gameController.Asteroids.Count; i++)
            {
                gameController.Asteroids[i].AsteroidsUpdate(gameTime);

                if (gameController.Asteroids[i].position.X < (0 - gameController.Asteroids[i].radius))
                {
                    gameController.Asteroids[i].offscreen = true;
                }

                int sum = gameController.Asteroids[i].radius + 30;
                if (Vector2.Distance(gameController.Asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position = Ship.defaultPosition;
                    i = gameController.Asteroids.Count;
                    gameController.Asteroids.Clear();
                }
            }

            gameController.Asteroids.RemoveAll(a => a.offscreen);   
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(space_Sprite, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(ship_Sprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            if (gameController.inGame == false)
            {
                string menuMessage = "Press Enter to Begin!";
                Vector2 sizeOfText = gameFont.MeasureString(menuMessage);
                spriteBatch.DrawString(gameFont, menuMessage, new Vector2(640 - sizeOfText.X / 2, 200), Color.White);
            }

            for (int i = 0; i < gameController.Asteroids.Count; i++)
            {
                Vector2 tempPos = gameController.Asteroids[i].position;
                int tempRadius = gameController.Asteroids[i].radius;
                spriteBatch.Draw(asteroids_Sprite, new Vector2(tempPos.X - tempRadius, tempPos.Y - tempRadius), Color.White);
            }

            spriteBatch.DrawString(timerFont, "Time: "+ Math.Floor(gameController.totalTime).ToString(),new Vector2(3,3), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}