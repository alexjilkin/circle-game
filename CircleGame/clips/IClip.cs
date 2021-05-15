using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public interface IClip
    {
        void draw(SpriteBatch spriteBatch);
        void update(KeyboardState state);
            
        Color Color { get; }
        Vector2 Position { get; }
        GraphicsDevice GraphicsDevice { get; }

    }
}