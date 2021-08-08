using Microsoft.Xna.Framework;

namespace CircleGame.clips.enemies
{
    class HulkEnemyFactory : EnemyFactory
    {
        public override EnemyCircle GetEnemyCircle(int radius, Vector2 position) =>
            new HulkEnemy(radius, position);
        
    }
}