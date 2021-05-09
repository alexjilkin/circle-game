using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    class EnemyCircle : Clip

    {
        private int directionX = 1;
        private int directionY = 1;
        private Texture2D _circle;
        public EnemyCircle(GraphicsDevice graphicsDevice, int radius, Vector2 position) : base(graphicsDevice, position)
        {
            _circle = createCircleText(radius);
        }

        public override void update(KeyboardState state)
        {
     
        }

        public override Texture2D draw(Vector2 camera)
        {
            this._position -= camera;
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
