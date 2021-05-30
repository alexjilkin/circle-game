using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using CommonClasses;

namespace CircleGame.ui
{
    public class HUD: Clip
    {
        private Desktop _desktop;
        TextBox score;
        public bool IsOpen {
            get; set;
        }

        public HUD(GraphicsDevice graphicsDevice) : base(graphicsDevice) {
            IsOpen = true;
            _desktop = new Desktop();
            drawScore();
        }
        private void drawScore() {
            var panel = new Panel() {};

            score = new TextBox {
                Text = "Score: " + GameManager.Score,
                TextColor = Color.Pink,
                Padding = new Thickness(12)
            };

            panel.Widgets.Add(score);
        
            _desktop.Root = panel;
        }

        public override void update(KeyboardState state)
        {
            score.Text = "Score: " + GameManager.Score;
        }

        public override void draw()
        {
            _desktop.Render();
        }


    }
}