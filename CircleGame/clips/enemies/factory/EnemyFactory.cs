using CircleGame.clips;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.clips.enemies
{
    abstract class EnemyFactory
    {
        public abstract EnemyCircle GetEnemyCircle(int radius, Vector2 position);
    }
}