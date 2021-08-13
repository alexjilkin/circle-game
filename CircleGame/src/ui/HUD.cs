using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using CircleGame.clips;

namespace CircleGame.ui
{
    public class HUD: Clip
    {
        private Desktop Desktop { get; set; }
        private Label Score { get; set; }
        public bool IsOpen { get; set; }

        public HUD() : base() {
            IsOpen = true;
            Desktop = new Desktop();
            
            drawScore();
        }
        private void drawScore() {
            var panel = new Panel() {};

            Score = new Label() {
                Text = "",
                TextColor = Color.Pink,
                Padding = new Thickness(12),
                Font = Common.Font.GetFont(32)
            };

            panel.Widgets.Add(Score);
            Desktop.Root = panel;
        }

        public override void update(KeyboardState state) {
            Score.Text = "Score " + (GameManager.Score + GameManager.TotalScore);
        }

        public override void draw(SpriteBatch _) {
            Desktop.Render();
        }
    }
}