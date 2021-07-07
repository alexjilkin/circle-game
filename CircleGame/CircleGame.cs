
using System.IO;
using Microsoft.Xna;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;
using CircleGame.ui;
using CircleGame.clips;
using Myra;

namespace CircleGame
{
    public class CircleGame : Game
    {
        private ModalManager modalManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IDrawable> drawables = new List<IDrawable>();
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
            modalManager = new ModalManager();
            hud = new HUD();
            
            Window.TextInput += (s, a) =>
            {
                modalManager.Desktop.OnChar(a.Character);
            };
            
            drawables.Add(modalManager);  
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
            
            if (modalManager.IsModalOpen) {
                modalManager.update(state);
                return;
            }

           
            Camera.Instance.update(GameManager.Player, GraphicsDevice);
            GameManager.handleItersection(gameTime);

            GameManager.Player.update(state, gameTime);

            foreach (Clip enemy in GameManager.Enemies)
            {
                enemy.update(state);
            }

            foreach (IDrawable drawable in drawables) {
                drawable.update(state);
            }
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            if (modalManager.IsModalOpen) {
                GraphicsDevice.Clear(Color.SeaShell);
                modalManager.draw(_spriteBatch);
                return;
            }

            _spriteBatch.Begin();

            foreach (IDrawable drawable in drawables) 
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
