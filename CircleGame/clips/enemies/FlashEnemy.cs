using CircleGame.clips;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.clips.enemies
{
    public class FlashEnemy: EnemyCircle, IPerk 
    {
        private readonly string perkName = "flash";
        public string PerkName {
            get { return perkName; }
        }
        private readonly int speedIncrease = 3;
        public int SpeedIncrease {
            get { return speedIncrease; }
        }
        private readonly int scaleIncrease = 0; 
        public int ScaleIncrease {
            get { return scaleIncrease; }
        }

        public FlashEnemy(int radius, Vector2 position) : base(radius, position)
        {
            this._color = Color.Red;
            this.speed = this.speed + speedIncrease;
        }
    }
}