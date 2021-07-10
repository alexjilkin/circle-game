using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.clips.enemies
{
    abstract public class EnemyCircle : MovingCircle
    {
        public EnemyCircle(int radius, Vector2 position): base(radius, position) {}
    }
}
