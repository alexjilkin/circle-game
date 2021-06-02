using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using CommonClasses;
using Newtonsoft.Json;

namespace CircleGame.ui
{
    public class MainMenu: Clip
    {
        private Desktop _desktop;
  
        public bool IsOpen {
            get; set;
        }
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice) {
            IsOpen = false;
            _desktop = new Desktop();
            initHighScore();
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
                this.IsOpen = false;
            };

            panel.Widgets.Add(button);

            _desktop.Root = panel;
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
                drawHighscore(new HighScore(){name="asd", score=5});
            }
        }
        public override void draw()
        {
            _desktop.Render();
        }


    }
}