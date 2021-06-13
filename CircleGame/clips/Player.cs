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
        public Player(int radius) : base(radius, Rules.Instance.BoundryPosition + new Vector2(100, 100))
        {
            this.Color = Color.LightGreen;
            this.speed = Rules.Instance.PlayerSpeed;
        }

        public override void update(KeyboardState state)
        {
            base.update(state);
            this.handleMovement(state);
            this.handleRadiusChange();
        }

        private void handleRadiusChange() {
            int newRadius = 20 + (GameManager.Score);

             if (newRadius != this.Radius) {
                this.Radius = newRadius;
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
