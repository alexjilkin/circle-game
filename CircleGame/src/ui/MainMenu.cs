
using System;
using System.Net.Http;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using CircleGame.utils;
using Myra.Graphics2D.UI;
using CommonClasses;

namespace CircleGame.ui
{
    public class MainMenu: IModal
    {
        private InstructionsModal instructionsModal;
        private SoundEffectInstance themeAudio;
        public Panel Content { get; private set; }

        private Panel Container { get; set; }
        
        public MainMenu() {
            init();
            instructionsModal = new InstructionsModal();
            instructionsModal.init();

            Content = new Panel();
            Container = new Panel();
            
            themeAudio = SoundManager.theme.CreateInstance();
            themeAudio.Volume = 0.6f;
            themeAudio.Play();
        }
        private void draw(HighScore[] highScores) {
            Container = new Panel();

            var topGrid = new Grid(){
                ColumnSpacing = 50,
                RowSpacing = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(300, 0, 0 ,0)

            };
            topGrid.RowsProportions.Add(new Proportion());
            topGrid.RowsProportions.Add(new Proportion());
            topGrid.ColumnsProportions.Add(new Proportion());

            topGrid.Widgets.Add(new Label {
                Text = "Circle Game",
                TextColor = Color.Pink,
                Padding = new Thickness(70),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(65),
                GridRow = 1
            });

            var scoreGrid = new Grid() {
                ColumnSpacing = 50,
                RowSpacing = 50,
                GridRow = 2,
            };

            for (int i = 0; i < highScores.Length; i++) {
                HighScore highScore = highScores[i];

                scoreGrid.ColumnsProportions.Add(new Proportion());
                scoreGrid.ColumnsProportions.Add(new Proportion());
                scoreGrid.RowsProportions.Add(new Proportion());

                scoreGrid.Widgets.Add(new Label{
                    Id = "name",
                    Text = highScore.name,
                    TextColor = Color.Red,
                    GridColumn = 1,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent),
                    Font = Common.Font.GetFont(27)
                });

                scoreGrid.Widgets.Add(new Label {
                    Id = "score",
                    Text = highScore.score.ToString(),
                    TextColor = Color.Red,
                    GridColumn = 2,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent),
                    Font = Common.Font.GetFont(27)
                });

                scoreGrid.Widgets.Add(new Label {
                    Id = "time",
                    Text = (Math.Floor(highScore.time * 10) / 10).ToString() + "  s",
                    TextColor = Color.Red,
                    GridColumn = 3,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent),
                    Font = Common.Font.GetFont(27)
                });
            }

            topGrid.Widgets.Add(scoreGrid);

            Container.Widgets.Add(topGrid);
            var button = Common.getButton("Start", 70, HorizontalAlignment.Center, VerticalAlignment.Bottom, (s, a) => {
                themeAudio.Stop();
                GameManager.restart();
            });
            
            button.Margin = new Thickness(0, 0, 0, 50);

            Container.Widgets.Add(button);

            
            var instructionsButton = Common.getButton("How?", 38, HorizontalAlignment.Left, VerticalAlignment.Bottom, handleInstructionClick);
            instructionsButton.Margin = new Thickness(50, 0, 0, 50);

            Container.Widgets.Add(instructionsButton);

            Content.Widgets.Clear();
            Content.Widgets.Add(Container);
        }

        private void handleInstructionClick (object s, EventArgs e) {
            Content.Widgets.Clear();
            Content.Widgets.Add(instructionsModal.Content);
            instructionsModal.Back += () => {
                Content.Widgets.Clear();
                Content.Widgets.Add(Container);
            };
        }

        private void noScoreDraw() {
            Container = new Panel();

            Container.Widgets.Add(new Label{
                Text = "Circle Game",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(65)
            });

            var button = Common.getButton("Start", 70, HorizontalAlignment.Center, VerticalAlignment.Center, (s, a) => {
                themeAudio.Stop();
                GameManager.restart();
            });

            Container.Widgets.Add(button);

            var instructionsButton = Common.getButton("How?", 38, HorizontalAlignment.Left, VerticalAlignment.Bottom, handleInstructionClick);
            instructionsButton.Margin = new Thickness(50, 0, 0, 50);

            Container.Widgets.Add(instructionsButton);
            Content.Widgets.Clear();
            Content.Widgets.Add(Container);
        }

        private void Loading() {
            Container.Widgets.Add(new Label{
                Text = "Loading...",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(60)
            });

            Content.Widgets.Clear();
            Content.Widgets.Add(Container);
        }

        public async Task initHighScore() {
            try {
                Loading();
                HighScore[] highScores = await Api.GetHighScores();
                draw(highScores);
                
            } catch(HttpRequestException) {
                noScoreDraw();
            }
        }
        public void init() {
            Task _ = initHighScore();
        }
    }
}