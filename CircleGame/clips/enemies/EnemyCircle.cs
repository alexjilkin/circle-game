using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame
{
    public class EnemyCircle : MovingCircle
    {
        public EnemyCircle(int radius, Vector2 position) : base(GameManager.graphicsDevice, radius)
        {
            this._position = position;
            this._color = Color.LightPink;
            this.speed = 3;
        }

    }
}
