using System.Collections.Generic;
using System.IO;
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
        private Texture2D background;
        private Texture2D whiteRect;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            FileStream setStream = File.Open("assets\\background.png", FileMode.Open);
 
            background = Texture2D.FromStream(_graphics.GraphicsDevice, setStream);
            whiteRect = new Texture2D(GraphicsDevice, 1, 1);
            whiteRect.SetData(new[] { Color.White });

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 1000;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(_graphics.GraphicsDevice, 50);
            _clips.Add(player);
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 15, new Vector2(300, 300)));
            _clips.Add(new EnemyCircle(_graphics.GraphicsDevice, 35, new Vector2(600, 100)));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 cameraPosition = Camera.Instance.position;
            Vector2 halfScreen = new Vector2(width / 2, height / 2);

            Camera.Instance.position = player.Position - new Vector2(width / 2, height / 2);

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
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(3f));
 
                _spriteBatch.Draw(background, Vector2.Multiply(Camera.Instance.position, -0.1f), Color.White);

            _spriteBatch.End();
            _spriteBatch.Begin();


            foreach (Clip clip in _clips)
            {
                _spriteBatch.Draw(clip.draw(Camera.Instance.position), clip.Position - Camera.Instance.position, null, clip.Color, 0, clip.origin, 1, SpriteEffects.None, 0);
            }
            _spriteBatch.Draw(whiteRect, Vector2.Multiply(Camera.Instance.position, -1f), null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(30f, Rules.height), SpriteEffects.None, 0f);
            _spriteBatch.Draw(whiteRect, Vector2.Multiply(Camera.Instance.position, -1f), null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(Rules.width, 30f), SpriteEffects.None, 0f);
            _spriteBatch.Draw(whiteRect, new Vector2(Rules.width, 0) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero,  new Vector2(30f, Rules.height), SpriteEffects.None, 0f);
            _spriteBatch.Draw(whiteRect, new Vector2(0, Rules.height) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(Rules.width, 30f), SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
