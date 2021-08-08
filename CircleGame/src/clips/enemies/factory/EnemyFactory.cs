using Microsoft.Xna.Framework;

namespace CircleGame.clips.enemies
{
    abstract class EnemyFactory
    {
        public abstract EnemyCircle GetEnemyCircle(int radius, Vector2 position);
    }
}