using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    class MovingCircle:Clip

    {
        private int directionX = 1;
        private int directionY = 1;
        private Texture2D _circle;
        private int radius;
        public MovingCircle(GraphicsDevice graphicsDevice, int radius) : base(graphicsDevice)
        {
            _circle = createCircleText(radius);
            this.radius = radius;
        }

        public override void update(KeyboardState state)
        {
            if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down))) {
                directionX = 0;
                directionY = 0;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                directionX = 1;
            } 
            if (state.IsKeyDown(Keys.Left))
            {
                directionX = -1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                directionY = -1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                directionY = 1;
            }

            if (_position.X + this.radius > Rules.width)
            {
                _position.X = Rules.width - this.radius - 1;
                directionX *= -1;
            }

            if (_position.Y + this.radius > Rules.height)
            {
                _position.Y = Rules.height - this.radius - 1;
                directionY *= -1;
            }

            _position.X += directionX * 5;
            _position.Y += directionY * 5;
        }

        public override Texture2D draw(Vector2 camera)
        {
            //this._position -= camera;
            return _circle;
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
