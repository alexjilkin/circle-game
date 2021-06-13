using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame
{
    public class SimpleEnemy : EnemyCircle
    {
        public SimpleEnemy(int radius, Vector2 position) : base(radius, position)
        {
            this._position = position;
            this._color = Color.LightPink;
            this.speed = 3;
        }

    }
}
