using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.clips;

namespace CircleGame.world
{
    public class Background: Clip
    {
        private Texture2D background;

        public Background() : base() {
            FileStream setStream = File.Open("..\\assets\\background.png", FileMode.Open);
            this.background = Texture2D.FromStream(GameManager.graphicsDevice, setStream);
        }
        public override void draw(SpriteBatch spriteBatch) {
            // Background moves differently to the camera, to create 
            // depth effect.
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(3f));
 
            spriteBatch.Draw(background, Vector2.Multiply(Camera.Instance.position, -0.1f), Color.White);
            spriteBatch.End();
            spriteBatch.Begin();
        }
        
    }
}