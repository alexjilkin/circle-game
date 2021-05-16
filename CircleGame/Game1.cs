using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public class Game1 : Game
    {
        private int width = 1800;
        private int height = 1000;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Clip> _clips = new List<Clip>();
        private Player player;
        private Background background;
        private Bounderies bounderies;
        private List<EnemyCircle> enemies = new List<EnemyCircle>();
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            background = new Background(GraphicsDevice);
            bounderies = new Bounderies(GraphicsDevice);

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(GraphicsDevice, 50);

            _clips.Add(player);
            
            enemies.Add(new EnemyCircle(GraphicsDevice, 15, new Vector2(300, 300)));
            enemies.Add(new EnemyCircle(GraphicsDevice, 35, new Vector2(600, 100)));
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Camera.Instance.update(player, GraphicsDevice);
            enemies = GameManager.handleItersection<EnemyCircle>(enemies, player);

            foreach (Clip clip in _clips)
            {
                clip.update(state);
            }

            foreach (Clip enemy in enemies)
            {
                enemy.update(state);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            background.draw(_spriteBatch);
            bounderies.draw(_spriteBatch);

            foreach (Clip clip in _clips)
            {
               clip.draw(_spriteBatch);
            }

             foreach (Clip enemy in enemies)
            {
              enemy.draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
