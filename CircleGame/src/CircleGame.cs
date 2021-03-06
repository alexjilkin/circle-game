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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<clips.IDrawable> drawables = new List<clips.IDrawable>();
        private RenderTarget2D renderTarget;
        public CircleGame() {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }
        protected override void Initialize() {
            GameManager.graphicsDevice = GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PresentationParameters pp = graphics.GraphicsDevice.PresentationParameters;
            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, 1920, 1080, false,
			    SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();

            GameManager.State = GameState.Initial;

            base.Initialize();
        }
        protected override void LoadContent() {
            Common.init();
            MyraEnvironment.Game = this;

            // Myra framework prequesite
            Window.TextInput += (s, a) => {
                ModalManager.Instance.Desktop.OnChar(a.Character);
            };
            
            drawables.Add(ModalManager.Instance);  
            drawables.Add(new Background());
            drawables.Add(new Bounderies());
            drawables.Add(new HUD());

            base.LoadContent();
        }
        protected override void Update(GameTime gameTime) {
            GameManager.GameTime = gameTime;
            KeyboardState state = Keyboard.GetState();
            
            if (GameManager.State != GameState.Play) {
                ModalManager.Instance.update(state);
                base.Update(gameTime);
            } else {
                if (state.IsKeyDown(Keys.Escape)) {
                    GameManager.State = GameState.Pause;
                }

                Camera.Instance.update(GameManager.Player);
                GameManager.handleItersection(gameTime);
                GameManager.Player.update(state, gameTime);

                foreach (Clip enemy in GameManager.Enemies) {
                    enemy.update(state);
                }

                foreach (clips.IDrawable drawable in drawables) {
                    drawable.update(state);
                }
            }
            
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime) {
            if (GameManager.State != GameState.Play) {
                GameManager.graphicsDevice.Clear(Color.SeaShell);
                ModalManager.Instance.draw(spriteBatch);
            } else {
                GameManager.graphicsDevice.SetRenderTarget(renderTarget);
            
                spriteBatch.Begin();
                foreach (clips.IDrawable drawable in drawables) {
                    drawable.draw(spriteBatch);
                }
                foreach (Clip enemy in GameManager.Enemies) {
                    enemy.draw(spriteBatch);
                }
                GameManager.Player.draw(spriteBatch);
                spriteBatch.End();
                
                GameManager.graphicsDevice.SetRenderTarget(null);

                // Render target to screen size, game stays the same on all screens.
                spriteBatch.Begin();
                spriteBatch.Draw(renderTarget, new Rectangle(0, 0,  GraphicsDevice.DisplayMode.Width,  GraphicsDevice.DisplayMode.Height), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
