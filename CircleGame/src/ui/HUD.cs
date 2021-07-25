using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using CommonClasses;
using CircleGame.clips;
using CircleGame.utils;

namespace CircleGame.ui
{
    public class HUD: Clip
    {
        private Desktop _desktop;
        Label score;
        public bool IsOpen { get; set; }

        public HUD() : base() {
            IsOpen = true;
            _desktop = new Desktop();
            
            drawScore();
        }
        private void drawScore() {
            var panel = new Panel() {};

            score = new Label() {
                Text = "",
                TextColor = Color.Pink,
                Padding = new Thickness(12),
                Font = Common.Font.GetFont(32)
            };

            panel.Widgets.Add(score);
            _desktop.Root = panel;
        }

        public override void update(KeyboardState state) {
            score.Text = "Score " + (GameManager.Score + GameManager.TotalScore);
        }

        public override void draw(SpriteBatch _) {
            _desktop.Render();
        }
    }
}