using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    public class Game1 : Game
    {
        private int width;
        private int height;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Clip> _clips = new List<Clip>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 1000;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _clips.Add(new MovingCircle(_graphics.GraphicsDevice, 100));
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 30, new Vector2(300, 300)));
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 70, new Vector2(600, 100)));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (Clip clip in _clips)
            {
                clip.update(state);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (Clip clip in _clips)
            {
                _spriteBatch.Draw(clip.draw(Camera.Instance.position), clip._position, Color.White);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
