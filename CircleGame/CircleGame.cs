using System.Collections.Generic;
using System.IO;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;
using CircleGame.ui;
using Myra;

namespace CircleGame
{
    public class CircleGame : Game
    {
        MainMenu mainMenu;
        MainModal mainModal;
        private int width = 1800;
        private int height = 1000;

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
            MyraEnvironment.Game = this;
            mainMenu = new MainMenu();
            mainModal = new MainModal();
            hud = new HUD(GraphicsDevice);

            drawables.Add(mainModal);
            drawables.Add(hud);
            drawables.Add(background);
            drawables.Add(bounderies);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            initGame();
        }

        private void initGame() {
            GameManager.initCircles();
        }

        protected override void Update(GameTime gameTime)
        {
            if (mainMenu.IsOpen || GameManager.IsDead) {
                return;
            }

            KeyboardState state = Keyboard.GetState();
            Camera.Instance.update(GameManager.Player, GraphicsDevice);
            GameManager.handleItersection();

            GameManager.Player.update(state);

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
            if (mainMenu.IsOpen) {
                GraphicsDevice.Clear(Color.SeaGreen);
                mainMenu.draw();
                return;
            }

            if (GameManager.IsDead) {
                GraphicsDevice.Clear(Color.SeaShell);
                mainModal.draw(_spriteBatch);
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
