using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Clip
    {
        private VertexPositionColor[] _vertexPositionColors;
        private BasicEffect _basicEffect;
        protected GraphicsDevice _graphicsDevice;
      
        public Vector2 _position;

        public Clip(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            
            _position = new Vector2(0, 0);
        }

        public virtual Texture2D getTexture()
        {
            return new Texture2D(_graphicsDevice, 1, 1);
        }

        public virtual void update(KeyboardState state)
        {
        }

    }
}
