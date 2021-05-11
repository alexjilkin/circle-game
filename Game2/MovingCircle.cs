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
        protected int directionX = 1;
        protected int directionY = 1;
        private Texture2D _circle;
        protected int radius;
        protected int speed;

        public MovingCircle(GraphicsDevice graphicsDevice, int radius) : base(graphicsDevice)
        {
            _circle = createCircleText(radius * 2);
            this.radius = radius;
            this.speed = 5;
            this.origin = new Vector2(radius, radius);
        }

    public override void update(KeyboardState state)
    {
        this.handleBorderCollision(state);
        _position.X += directionX * speed;
        _position.Y += directionY * speed;
    }

    protected void handleBorderCollision(KeyboardState state)
    {
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
        else if (_position.X - this.radius < 0)
        {
            _position.X = 0 + this.radius + 1;
            directionX *= -1;
        }
        else if (_position.Y - this.radius < 0)
        {
            _position.Y = 0 + this.radius + 1;
            directionY *= -1;
        }
    }

    public override Texture2D draw(Vector2 camera)
    {
        return _circle;
    }
    Texture2D createCircleText(int diam)
    {
        Texture2D texture = new Texture2D(_graphicsDevice, diam, diam);
        Color[] colorData = new Color[diam * diam];

        float radius = diam / 2f;
        float radiussq = radius * radius;

        for (int x = 0; x < diam; x++)
        {
            for (int y = 0; y < diam; y++)
            {
                int index = x * diam + y;
                Vector2 pos = new Vector2(x - radius, y - radius);
                if (pos.LengthSquared() <= radiussq)
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
