using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CircleGame.world
{
    public class Background: Clip
    {
        private Texture2D background;

        public Background() : base()
        {
            FileStream setStream = File.Open("assets\\background.png", FileMode.Open);
 
            this.background = Texture2D.FromStream(this.GraphicsDevice, setStream);
        }

        public override void draw(SpriteBatch spriteBatch) {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(3f));
 
            spriteBatch.Draw(background, Vector2.Multiply(Camera.Instance.position, -0.1f), Color.White);
            spriteBatch.End();
            spriteBatch.Begin();

        }
        
    }
}