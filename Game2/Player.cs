using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame
{
    class Player : MovingCircle
    {
        public Player(GraphicsDevice graphicsDevice, int radius) : base(graphicsDevice, radius)
        {
            this._color = Color.LightGreen;   
        }

        public override void update(KeyboardState state)
        {
            base.update(state);

            if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down)))
            {
                this.directionX = 0;
                directionY = 0;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                this.directionX = 1;
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
        }
    }
}
