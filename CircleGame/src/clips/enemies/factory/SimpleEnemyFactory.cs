using Microsoft.Xna.Framework;

namespace CircleGame.clips.enemies
{
    class SimpleEnemyFactory : EnemyFactory
    {
        public override EnemyCircle GetEnemyCircle(int radius, Vector2 position) =>
            new SimpleEnemy(radius, position);
    }
}