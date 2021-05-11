using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    class Clip
    {
        private VertexPositionColor[] _vertexPositionColors;
        private BasicEffect _basicEffect;
        protected GraphicsDevice _graphicsDevice;
        public Vector2 origin;
        public Vector2 _position;
        protected Color _color;

        public Color Color { get { return _color; } }
        public Vector2 Position { get {
                return _position;
            }}

        public Clip(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _position = new Vector2(0, 0);
            origin = new Vector2(0, 0);
        }
        public Clip(GraphicsDevice graphicsDevice, Vector2 position)
        {
            _graphicsDevice = graphicsDevice;

            _position = position;
        }

        public virtual Texture2D draw(Vector2 camera)
        {
            this._position -= camera;
            return new Texture2D(_graphicsDevice, 1, 1);
        }

        public virtual void update(KeyboardState state)
        {
        }

    }
}
