using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public class Clip: IClip
    {
        private GraphicsDevice _graphicsDevice;
        public Vector2 origin;
        public Vector2 _position;
        protected Color _color;
        public Texture2D texture;

        public Color Color { get { return _color; } }
        public Vector2 Position { get {
                return _position;
            }}

        public GraphicsDevice GraphicsDevice { get { return _graphicsDevice; } }
        public Clip(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _position = new Vector2(0, 0);
            origin = new Vector2(0, 0);
            texture = new Texture2D(_graphicsDevice, 1, 1);
        }
        public Clip(GraphicsDevice graphicsDevice, Vector2 position)
        {
            _graphicsDevice = graphicsDevice;

            _position = position;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Position - Camera.Instance.position, null, this.Color, 0, this.origin, 1, SpriteEffects.None, 0);
        }                               

        public virtual void update(KeyboardState state)
        {

        }

    }
}
