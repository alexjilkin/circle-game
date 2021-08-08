using Microsoft.Xna.Framework;
using CircleGame.world;

namespace CircleGame.clips.enemies
{
    public class FlashEnemy: EnemyCircle, IPerk 
    {
        private readonly string perkName = "flash";
        public string PerkName {
            get { return perkName; }
            private set { }
        }
        private readonly int speedIncrease = Rules.Instance.FlashPerk.SpeedIncrease;
        public int SpeedIncrease {
            get { return speedIncrease; }
        }
        private readonly int scaleIncrease = 0; 
        public int ScaleIncrease {
            get { return scaleIncrease; }
        }

        public FlashEnemy(int radius, Vector2 position) : base(radius, position) {
            this.Color = Color.Red;
            this.Speed = Rules.Instance.BaseSpeed;
            this.Speed = this.Speed + speedIncrease;
        }
    }
}