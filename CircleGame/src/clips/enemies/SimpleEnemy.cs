using Microsoft.Xna.Framework;
using CircleGame.world;

namespace CircleGame.clips.enemies
{
    public class SimpleEnemy : EnemyCircle
    {
        public SimpleEnemy(int radius, Vector2 position) : base(radius, position) {
            this.Position = position;
            this.Color = Color.LightPink;
            this.Speed = Rules.Instance.BaseSpeed;
        }

    }
}
