using CircleGame.clips;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.world;

namespace CircleGame.clips.enemies
{
    public class HulkEnemy: EnemyCircle, IPerk 
    {
        private readonly string perkName = "hulk";
        public string PerkName {
            get { return perkName; }
        }
        private readonly int speedIncrease = 0;
        public int SpeedIncrease {
            get { return speedIncrease; }
        }
        private readonly int scaleIncrease = Rules.Instance.HulkPerk.ScaleIncrease; 
        public int ScaleIncrease {
            get { return scaleIncrease; }
        }

        public HulkEnemy(int radius, Vector2 position) : base(radius, position)
        {
            this.Color = Color.Green;
            this.speed = Rules.Instance.BaseSpeed;
            this.Scale = this.ScaleIncrease;
        }
    }
}