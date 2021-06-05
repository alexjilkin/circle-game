using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame
{
    public interface IDrawable
    {
        void draw(SpriteBatch spriteBatch);
        void update(KeyboardState state);
    }
}