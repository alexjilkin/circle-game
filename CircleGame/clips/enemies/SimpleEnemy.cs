using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame
{
    public class SimpleEnemy : EnemyCircle
    {
        public SimpleEnemy(int radius, Vector2 position) : base(radius, position)
        {
            this.Position = position;
            this.Color = Color.LightPink;
            this.speed = 3;
        }

    }
}
