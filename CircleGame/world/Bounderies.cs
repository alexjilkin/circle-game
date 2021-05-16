using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CircleGame.world
{
    public class Bounderies: Clip
    {
        private Texture2D whiteRect;
        public Bounderies(GraphicsDevice device): base(device) {
            whiteRect = new Texture2D(GraphicsDevice, 1, 1);
            whiteRect.SetData(new[] { Color.White });
        }
        public override void draw(SpriteBatch spriteBatch) {
            int width = Rules.Instance.Width;
            int height = Rules.Instance.Height;

            spriteBatch.Draw(whiteRect, Vector2.Multiply(Camera.Instance.position, -1f), null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(30f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(whiteRect, Vector2.Multiply(Camera.Instance.position, -1f), null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width, 30f), SpriteEffects.None, 0f);
            spriteBatch.Draw(whiteRect, new Vector2(width, 0) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero,  new Vector2(30f, height), SpriteEffects.None, 0f);
            spriteBatch.Draw(whiteRect, new Vector2(0, height) - Camera.Instance.position, null, Color.Chocolate, 0f, Vector2.Zero, new Vector2(width, 30f), SpriteEffects.None, 0f);
        }    
    }
}