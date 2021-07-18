using Microsoft.Xna.Framework;
using CircleGame.utils;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame.clips
{
    public class Player: MovingCircle
    {
        private double TotalSecondsAtPerk { get; set; }
        public IPerk Perk { get; private set; }
        private int AllowedMovements { get; set; }

        private bool IsRightHandled { get; set; }
        private bool IsLeftHandled { get; set; }
        private bool IsUpHandled { get; set; }
        private bool IsDownHandled { get; set; }

        public Player(int radius) : base(radius, Rules.Instance.BoundryPosition + new Vector2(100, 100)) {
            this.Color = Color.FloralWhite;
            this.Speed = Rules.Instance.PlayerSpeed;
            this.Perk = null;
            this.AllowedMovements = Rules.Instance.MovementsLimit;
            this.IsRightHandled = false;
            this.IsLeftHandled = false;
            this.IsUpHandled = false;
            this.IsDownHandled = false;
            this.BorderHit += () => {
                this.AllowedMovements = Rules.Instance.MovementsLimit;
                SoundManager.hit.Play();
            };
        }

        public override void update(KeyboardState state, GameTime gameTime) {
            base.update(state);
            this.handleMovement(state);
            this.handleRadiusChange();
            this.handlePerk(gameTime);
        }

        private void handlePerk(GameTime gameTime) {
            if (this.Perk != null && (gameTime.TotalGameTime.TotalSeconds - this.TotalSecondsAtPerk) > 5) {
                this.Perk = null;
                this.Speed = Rules.Instance.PlayerSpeed;
            }
        }
        private void handleRadiusChange() {
            int newRadius = 20 + (GameManager.Score);

             if (newRadius != this.Radius) {
                this.Radius = newRadius;
            }
        }

        public void setPerk(IPerk perk, GameTime gameTime) {
            this.Perk = perk;
            this.Speed = Rules.Instance.PlayerSpeed + this.Perk.SpeedIncrease;
            TotalSecondsAtPerk = gameTime.TotalGameTime.TotalSeconds;
        }

        private void handleMovement(KeyboardState state) {
            
            bool isRight = state.IsKeyDown(Keys.Right);
            bool isLeft = state.IsKeyDown(Keys.Left);
            bool isUp = state.IsKeyDown(Keys.Up);
            bool isDown =  state.IsKeyDown(Keys.Down);
            bool isVertical = isUp || isDown;
            bool isHorizontal = isLeft || isRight;

            if (this.AllowedMovements == 0) {
                return;
            }

            if (state.IsKeyUp(Keys.Right)) {
                this.IsRightHandled = false;
            }
            if (state.IsKeyUp(Keys.Left)) {
                this.IsLeftHandled = false;
            }
            if (state.IsKeyUp(Keys.Up)) {
                this.IsUpHandled = false;
            }
            if (state.IsKeyUp(Keys.Down)) {
                this.IsDownHandled = false;
            }

            bool isChangedDirection = false;
    
            if (isRight && !this.IsRightHandled) {
                this.IsRightHandled = true;
                this.DirectionX = 1;
                if (!isVertical) {
                    this.DirectionY = 0;
                }
                isChangedDirection = true;
            }
            if (isLeft && !this.IsLeftHandled) {
                this.IsLeftHandled = true;
                DirectionX = -1;
                 if (!isVertical) {
                    this.DirectionY = 0;
                }
                isChangedDirection = true;
            }
            if (isUp && !this.IsUpHandled) {
                this.IsUpHandled = true;
                DirectionY = -1;
                if (!isHorizontal) {
                    this.DirectionX = 0;
                }
                isChangedDirection = true;
            }
            if (isDown && !this.IsDownHandled) {
                this.IsDownHandled = true;
                DirectionY = 1;
                if (!isHorizontal) {
                    this.DirectionX = 0;
                }
                isChangedDirection = true;
            }

            if (isChangedDirection) {
                this.AllowedMovements--;
            }
        }
    }
}
