using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public interface IDrawable
    {
        Color Color { get; }
        Vector2 Position { get; }
        void draw(SpriteBatch spriteBatch);
        void draw();
        void update(KeyboardState state);
    }
}