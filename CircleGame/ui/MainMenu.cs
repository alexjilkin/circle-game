using System.Net.Http;
using Microsoft.Xna.Framework;    
using System.Threading.Tasks;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using Myra;
using CircleGame.utils;
using Myra.Graphics2D.UI;
using CommonClasses;

using FontStashSharp;
using System.IO;

namespace CircleGame.ui
{
    public class MainMenu: IModal
    {
        private Panel content;
  
        public Panel Content {
            get {
                return content;
            }
        }
        
        public MainMenu() {
            init();
        }
        private void draw(HighScore[] highScores) {
            var panel = new Panel();

            var title = new Label {
                Text = "Circle Game",
                TextColor = Color.Pink,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(20),
                Background = new SolidBrush(Color.Transparent)
            };

            var font = FontSystemFactory.Create(GameManager.graphicsDevice);
            font.AddFont(File.ReadAllBytes("assets\\ka1.ttf"));
            title.Font = Common.Font.GetFont(65);

            panel.Widgets.Add(title);

            var scoreGrid = new Grid(){
                ColumnSpacing = 50,
                RowSpacing = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin=new Thickness(0, 150, 0, 0),
            };

            var a = FontSystemFactory.Create(GameManager.graphicsDevice);

            for (int i = 0; i < highScores.Length; i++)
            {
                scoreGrid.ColumnsProportions.Add(new Proportion());
                scoreGrid.RowsProportions.Add(new Proportion());

                var name = new Label
                {
                    Id = "name",
                    Text = highScores[i].name,
                    TextColor = Color.Red,
                    GridColumn = 1,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent)
                };

                var score = new Label
                {
                    Id = "score",
                    Text = highScores[i].score.ToString(),
                    TextColor = Color.Red,
                    GridColumn = 2,
                    GridRow = i,
                    Background= new SolidBrush(Color.Transparent)
                };
            
                name.Font = font.GetFont(25);
                score.Font = font.GetFont(25);

                scoreGrid.Widgets.Add(name);
                scoreGrid.Widgets.Add(score);
            }

            


            panel.Widgets.Add(scoreGrid);

            var button = Common.getButton("Start", 50);
            button.Margin = new Thickness(0, 0, 0, 50);
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;

            button.Click += (s, a) =>
            {
                GameManager.restart();
            };

            panel.Widgets.Add(button);

            content = panel;
        }

        private void draw() {
            var panel = new Panel();

            var title = new TextBox{
                Text = "Circle Game",
                TextColor=Color.Pink,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(20),
                Background= new SolidBrush(Color.Transparent)
            };

            title.Font = Common.Font.GetFont(65);

            panel.Widgets.Add(title);

            var button = new TextButton
            {
                Text = "Start",
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Center,
                Margin=new Thickness(0, 0, 0, 50),
                Padding=new Thickness(10),
                Background= new SolidBrush(Color.LightGreen)
            };

            button.Font = Common.Font.GetFont(50);

            button.Click += (s, a) =>
            {
                GameManager.restart();
            };

            panel.Widgets.Add(button);

            content = panel;
        }

        public async Task initHighScore() {
            HttpClient client = new HttpClient();

            try {
                var highScores = await Api.GetHighScores();
                draw(highScores);
            }
            catch(HttpRequestException e) {
                draw();
            }
        }
        public void init() {
            initHighScore();
        }


    }
}