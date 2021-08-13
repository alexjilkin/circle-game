using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.clips;

namespace CircleGame.world
{
    public class Background: Clip
    {
        public Background() : base() {
            FileStream setStream = File.Open("..\\assets\\background.png", FileMode.Open);
            this.Texture = Texture2D.FromStream(GameManager.graphicsDevice, setStream);
        }
        public override void draw(SpriteBatch spriteBatch) {
            // Background moves differently to the camera, to create 
            // depth effect.
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(2.5f));
 
            spriteBatch.Draw(this.Texture, Vector2.Multiply(Camera.Instance.Position, -0.06f), Color.White);
            spriteBatch.End();
            spriteBatch.Begin();
        }
        
    }
}