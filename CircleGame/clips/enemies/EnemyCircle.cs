using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.world;

namespace CircleGame
{
    abstract public class EnemyCircle : MovingCircle
    {
        public EnemyCircle(int radius, Vector2 position): base(radius, position) {}
    }
}
