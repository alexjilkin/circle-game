using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public class Clip: IDrawable
    {
        private GraphicsDevice _graphicsDevice;
        private Vector2 origin;
        private Vector2 position;
        private Color _color;
        private Texture2D texture;
        public Color Color { 
            get { return _color; } 
            protected set {
                _color = value;
            }
        }
        public Vector2 Position { 
            get {
                return position;
            }
            protected set {
                position = value;
            }
        }

        protected Vector2 Origin { 
            get {
                return origin;
            }
            set {
                origin = value;
            }
        }

        protected Texture2D Texture {
            get {
                return texture;
            }
            set {
                texture = value;
            }
        }

        public GraphicsDevice GraphicsDevice { get { return _graphicsDevice; } }
        public Clip()
        {
            _graphicsDevice = GameManager.graphicsDevice;
            position = new Vector2(0, 0);
            origin = new Vector2(0, 0);
            texture = new Texture2D(_graphicsDevice, 1, 1);
        }
       
        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Position - Camera.Instance.position, null, this.Color, 0, this.origin, 1, SpriteEffects.None, 0);
        }                            

        public virtual void update(KeyboardState state) {}
        public virtual void update(KeyboardState state, GameTime gameTime) {}

    }
}
