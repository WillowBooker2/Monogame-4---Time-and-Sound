using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_4___Time_and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture, kablooehTexture;
        Rectangle bombRect, kablooehRect;
        SpriteFont timeFont;
        float seconds;
        float startTime;
        MouseState mouseState;
        SoundEffect explode;
        bool exploded;
        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            exploded = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombRect = new Rectangle(50, 50, 700, 400);
            kablooehRect = new Rectangle(0, 0, 800, 500);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            timeFont = Content.Load<SpriteFont>("timeFont");
            bombTexture = Content.Load<Texture2D>("bomb");
            kablooehTexture = Content.Load<Texture2D>("kablooeh");
            explode = Content.Load<SoundEffect>("explosion");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (seconds > 10) 
            {
                seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            }

            if (Math.Round(seconds) == 15 && !exploded)
            {
                explode.Play();
                exploded = true;
            }
            mouseState = Mouse.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            if (seconds < 15)
            {
                _spriteBatch.DrawString(timeFont, (15 - seconds).ToString("00.0"), new Vector2(270, 200), Color.Black);
            }
            else if (seconds > 15) 
            {
                
                _spriteBatch.Draw(kablooehTexture, kablooehRect, Color.White);

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}