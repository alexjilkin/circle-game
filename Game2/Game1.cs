using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    public class Game1 : Game
    {
        private int width = 1800;
        private int height = 1000;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Clip> _clips = new List<Clip>();
        private Clip player;

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
            player = new MovingCircle(_graphics.GraphicsDevice, 100);
            _clips.Add(player);
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 30, new Vector2(300, 300)));
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 70, new Vector2(600, 100)));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 cameraPosition = Camera.Instance.position;
            Vector2 halfScreen = new Vector2(width / 2, height / 2);

            Camera.Instance.position = player._position - new Vector2(width / 2, height / 2);

            if (Camera.Instance.position.X < 0)
            {
                Camera.Instance.position = new Vector2(0, Camera.Instance.position.Y);
            }
            if (Camera.Instance.position.Y < 0)
            {
                Camera.Instance.position = new Vector2(Camera.Instance.position.X, 0);
            }


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
                _spriteBatch.Draw(clip.draw(Camera.Instance.position), clip._position - Camera.Instance.position, Color.White);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
