using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.world
{
    public class Bounderies: Clip
    {
        public Bounderies(GraphicsDevice device): base(device) {
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
        }
        public override void draw(SpriteBatch spriteBatch) {
            Vector2 startVector = Rules.Instance.BoundryPosition;
            int width = Rules.Instance.Width;
            int height = Rules.Instance.Height;

            spriteBatch.Draw(texture, startVector - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(15f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, startVector - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width, 15f), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, startVector + new Vector2(width, 0) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero,  new Vector2(15f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, startVector + new Vector2(0, height) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width + 15, 15f), SpriteEffects.None, 0f);
        }    
    }
}