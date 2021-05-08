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
        private GraphicsDevice _graphicsDevice;
        private Texture2D _circle;
        public Vector2 _position;

        public Clip(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _circle = createCircleText(50);
            _position = new Vector2(0, 0);
        }
        public Texture2D getTexture()
        {
            return _circle;
        }
        public virtual void update()
        {
        }


        Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(_graphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}
