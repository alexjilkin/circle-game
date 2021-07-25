
using System.Net.Http;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using CircleGame.utils;
using Myra.Graphics2D.UI;
using CommonClasses;

using FontStashSharp;


namespace CircleGame.ui
{
    public class MainMenu: IModal
    {
        private Panel content = new Panel();
        private InstructionsModal instructionsModal;
        private SoundEffectInstance themeAudio;
        public Panel Content {
            get => content;
        }
        
        public MainMenu() {
            init();
            instructionsModal = new InstructionsModal();
            instructionsModal.init();
            //themeAudio = SoundManager.theme.CreateInstance();
            // themeAudio.Volume = 0.6f;
            // themeAudio.Play();
        }
        private void draw(HighScore[] highScores) {
            var panel = new Panel();

            panel.Widgets.Add(new Label{
                Text = "Circle Game",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(65)
            });

            var scoreGrid = new Grid(){
                ColumnSpacing = 50,
                RowSpacing = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 150, 0, 0),
            };

            for (int i = 0; i < highScores.Length; i++)
            {
                scoreGrid.ColumnsProportions.Add(new Proportion());
                scoreGrid.RowsProportions.Add(new Proportion());

                scoreGrid.Widgets.Add(new Label{
                    Id = "name",
                    Text = highScores[i].name,
                    TextColor = Color.Red,
                    GridColumn = 1,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent),
                    Font = Common.Font.GetFont(25)
                });

                scoreGrid.Widgets.Add(new Label {
                    Id = "score",
                    Text = highScores[i].score.ToString(),
                    TextColor = Color.Red,
                    GridColumn = 2,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent),
                    Font = Common.Font.GetFont(25)
                });
            }

            panel.Widgets.Add(scoreGrid);

            var button = Common.getButton("Start", 50, HorizontalAlignment.Center, VerticalAlignment.Bottom, (s, a) => {
                //themeAudio.Stop();
                GameManager.restart();
            });
            
            button.Margin = new Thickness(0, 0, 0, 50);

            panel.Widgets.Add(button);

            System.EventHandler handleClick = (s, a) =>
            {
                content.Widgets.Clear();
                content.Widgets.Add(instructionsModal.Content);
                instructionsModal.Back += () => {
                    content.Widgets.Clear();
                    content.Widgets.Add(panel);
                };
            };
            var instructionsButton = Common.getButton("How?", 30, HorizontalAlignment.Left, VerticalAlignment.Bottom, handleClick);
            instructionsButton.Margin = new Thickness(50, 0, 0, 50);

            panel.Widgets.Add(instructionsButton);

            content.Widgets.Clear();
            content.Widgets.Add(panel);
        }

        private void noScoreDraw() {
            var panel = new Panel();

            panel.Widgets.Add(new Label{
                Text = "Circle Game",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(65)
            });

            var button = Common.getButton("Start", 50, HorizontalAlignment.Center, VerticalAlignment.Bottom, (s, a) => { GameManager.restart(); });

            panel.Widgets.Add(button);

            content.Widgets.Clear();
            content.Widgets.Add(panel);
        }

        private void loading() {
            var panel = new Panel();

            panel.Widgets.Add(new Label{
                Text = "Loading...",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(50)
            });

            content.Widgets.Clear();
            content.Widgets.Add(panel);
        }

        public async Task initHighScore() {
            HttpClient client = new HttpClient();

            try {
                loading();
                var highScores = await Api.GetHighScores();
                draw(highScores);
            }
            catch(HttpRequestException) {
                noScoreDraw();
            }
        }
        public void init() {
            Task _ = initHighScore();
        }
    }
}