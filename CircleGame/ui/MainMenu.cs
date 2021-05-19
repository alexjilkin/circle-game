using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Attributes;
using Myra.Graphics2D.UI;
using Myra.MML;
using Myra.Utility;
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
            IsOpen = true;
            _desktop = new Desktop();
            initHighScore();
        }

        private void drawHighscore(HighScore highScore) {
            var grid = new Grid
                {
                RowSpacing = 2,
                ColumnSpacing = 2
                };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            var name = new Label
            {
                Id = "label",
                Text = highScore.name
            };
            var number = new Label
            {
                Id = "asd",
                Text = highScore.score.ToString()
            };
            grid.Widgets.Add(name);
            grid.Widgets.Add(number);

            // Button
            var button = new TextButton
            {
            GridColumn = 0,
            GridRow = 1,
            Text = "Start"
            };

            button.Click += (s, a) =>
            {
                this.IsOpen = false;
            };

            grid.Widgets.Add(button);

            _desktop.Root = grid;
        }

        public async Task initHighScore() {
            HttpClient client = new HttpClient();

            try {
                var res = await client.GetAsync("https://localhost:5001/api/HighScore");
                
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