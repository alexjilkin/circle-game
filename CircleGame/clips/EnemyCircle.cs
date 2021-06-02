using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    public class EnemyCircle : MovingCircle
    {
        public EnemyCircle(GraphicsDevice graphicsDevice, int radius, Vector2 position) : base(graphicsDevice, radius)
        {
            this._position = position;
            this._color = Color.LightPink;
            this.speed = 3;
        }

    }
}
