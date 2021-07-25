using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame.clips
{
    public class Clip: IDrawable
    {
        public Color Color { get; protected set; }
        public Vector2 Position { get; protected set; }
        public Vector2 Origin { get; protected set; }
        protected Texture2D Texture { get; set; }
        public Clip() {
            Position = new Vector2(0, 0);
            Origin = new Vector2(0, 0);
            Texture = new Texture2D(GameManager.graphicsDevice, 1, 1);
        }
       
        public virtual void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.Texture, this.Position - Camera.Instance.position, null, this.Color, 0, this.Origin, 1, SpriteEffects.None, 0);
        }                            

        public virtual void update(KeyboardState state) {}
        public virtual void update(KeyboardState state, GameTime gameTime) {}

    }
}
