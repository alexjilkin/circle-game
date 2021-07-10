
using Microsoft.Xna;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.ui;
using CircleGame.clips;
using CircleGame.world;
using Myra;

namespace CircleGame
{
    public class CircleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<clips.IDrawable> drawables = new List<clips.IDrawable>();
        private Background background;
        private HUD hud;
        private Bounderies bounderies;
        
        public CircleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameManager.graphicsDevice = GraphicsDevice;
            GameManager.State = GameState.Initial;
            background = new Background();
            bounderies = new Bounderies();

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            MyraEnvironment.Game = this;
            hud = new HUD();
            
            Window.TextInput += (s, a) =>
            {
                ModalManager.Instance.Desktop.OnChar(a.Character);
            };
            
            drawables.Add(ModalManager.Instance);  
            drawables.Add(background);
            drawables.Add(bounderies);
            drawables.Add(hud);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            initGame();
        }

        private void initGame() {
            GameManager.initCircles();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            
            if (GameManager.State != GameState.Play) {
                ModalManager.Instance.update(state);
                return;
            }

           
            Camera.Instance.update(GameManager.Player, GraphicsDevice);
            GameManager.handleItersection(gameTime);

            GameManager.Player.update(state, gameTime);

            foreach (Clip enemy in GameManager.Enemies)
            {
                enemy.update(state);
            }

            foreach (clips.IDrawable drawable in drawables) {
                drawable.update(state);
            }
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            if (GameManager.State != GameState.Play) {
                GraphicsDevice.Clear(Color.SeaShell);
                ModalManager.Instance.draw(_spriteBatch);
                return;
            }

            _spriteBatch.Begin();

            foreach (clips.IDrawable drawable in drawables) 
            {
                drawable.draw(_spriteBatch);
            }
            foreach (Clip enemy in GameManager.Enemies)
            {
              enemy.draw(_spriteBatch);
            }

            GameManager.Player.draw(_spriteBatch);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
