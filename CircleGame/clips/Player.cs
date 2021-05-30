using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public class Player: MovingCircle
    {
        public Player(GraphicsDevice graphicsDevice, int radius) : base(graphicsDevice, radius)
        {
            this._color = Color.LightGreen;
            this._position = Rules.Instance.BoundryPosition + new Vector2(100, 100);
            this.speed = 6;
        }

        public override void update(KeyboardState state)
        {
            base.update(state);
            this.handleMovement(state);
            this.handleSize();
        }

        private void handleSize() {
            int newRadius = 20 + (GameManager.Score);

             if (newRadius != this.radius) {
                this.radius = newRadius;
                this.updateTexture();
            }
        }

        private void handleMovement(KeyboardState state) {
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
