using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.clips;

namespace CircleGame.world
{
    public class Bounderies: Clip
    {
        public Bounderies(): base() {
            this.Texture = new Texture2D(GameManager.graphicsDevice, 1, 1);
            this.Texture.SetData(new[] { Color.White });
        }
        public override void draw(SpriteBatch spriteBatch) {
            Vector2 startVector = Rules.Instance.BoundryPosition;
            int width = Rules.Instance.Width;
            int height = Rules.Instance.Height;

            spriteBatch.Draw(Texture, startVector - Camera.Instance.Position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(15f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(Texture, startVector - Camera.Instance.Position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width, 15f), SpriteEffects.None, 0f);
            spriteBatch.Draw(Texture, startVector + new Vector2(width, 0) - Camera.Instance.Position, null, Color.Chocolate, 0f, Vector2.Zero,  new Vector2(15f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(Texture, startVector + new Vector2(0, height) - Camera.Instance.Position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width + 15, 15f), SpriteEffects.None, 0f);
        }    
    }
}