using System.Net.Http;
using Microsoft.Xna.Framework;    
using System.Threading.Tasks;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using CommonClasses;
using Newtonsoft.Json;

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
        private void drawHighscore(HighScore highScore) {
            var panel = new Panel();

            var title = new TextBox{
                Text = "Circle Game",
                TextColor=Color.Pink,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(20)
            };

            panel.Widgets.Add(title);

            var scorePanel = new Panel(){
                HorizontalAlignment=HorizontalAlignment.Center,
                Margin=new Thickness(0, 100, 0 ,0),
            };

            var name = new TextBox
            {
                Id = "name",
                Text = highScore.name,
                TextColor = Color.Red,
            };
            var score = new TextBox
            {
                Id = "score",
                Text = highScore.score.ToString(),
                TextColor = Color.Red,
            };

            scorePanel.Widgets.Add(name);
            scorePanel.Widgets.Add(score);
            panel.Widgets.Add(scorePanel);

            var button = new TextButton
            {
                Text = "Start",
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Center,
                Margin=new Thickness(0, 0, 0, 50),
                Padding=new Thickness(10)
            };

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
                var res = await client.GetAsync("http://localhost:5000/api/HighScore");
                
                string score = await res.Content.ReadAsStringAsync();

                HighScore highScore = JsonConvert.DeserializeObject<HighScore>(score);
                drawHighscore(highScore);
            }
            catch(HttpRequestException e) {
                drawHighscore(new HighScore(){name="Error", score=5});
            }
        }
        public void init() {
            initHighScore();
        }


    }
}