using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame.clips
{
    public class Player: MovingCircle
    {
        public IPerk Perk { get; private set; }

        public Player(int radius) : base(radius, Rules.Instance.BoundryPosition + new Vector2(100, 100))
        {
            this.Color = Color.LightGreen;
            this.Speed = Rules.Instance.PlayerSpeed;
            this.Perk = null;
        }

        public override void update(KeyboardState state, GameTime gameTime)
        {
            base.update(state);
            this.handleMovement(state);
            this.handleRadiusChange();
            this.handlePerk();
        }

        private void handlePerk() {
            if (this.Perk != null) {
                
            }
        }
        private void handleRadiusChange() {
            int newRadius = 20 + (GameManager.Score);

             if (newRadius != this.Radius) {
                this.Radius = newRadius;
            }
        }

        public void setPerk(IPerk perk) {
            this.Perk = perk;
            this.Speed += this.Perk.SpeedIncrease;
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
