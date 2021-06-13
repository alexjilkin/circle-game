using CircleGame.clips;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.clips.enemies.factory
{
    class HulkEnemyFactory : EnemyFactory
    {
        public override EnemyCircle GetEnemyCircle(int radius, Vector2 position) {
            return new HulkEnemy(radius, position);
        }
    }
}