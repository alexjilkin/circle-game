using Microsoft.Xna.Framework;

namespace CircleGame.clips.enemies
{
    class FlashEnemyFactory : EnemyFactory
    {
        public override EnemyCircle GetEnemyCircle(int radius, Vector2 position) =>
            new FlashEnemy(radius, position);
    }
}