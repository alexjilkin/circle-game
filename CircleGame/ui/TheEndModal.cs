using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using CircleGame.utils;
using CommonClasses;
using System.Net.Http;

namespace CircleGame.ui
{
    public class TheEndModal: IModal
    {
        private Panel content;

        public Panel Content {
            get {
                return content;
            }
        }
        public TheEndModal() {
            init();
        }
        public void init() {
            var panel = new Panel();

            string titleText = GameManager.IsDead ? "You are DEAD" : "You Finished!";
            var title = new Label {
                Text = titleText,
                TextColor=Color.Red,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(20),
                Background = new SolidBrush(Color.Transparent)
            };

            title.Font = Common.Font.GetFont(62);
            panel.Widgets.Add(title);

            panel.Widgets.Add(getNameInputGrid());

            var button = Common.getButton("Restart", 50);
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Bottom;
            button.Margin = new Thickness(0, 0, 0, 50);
            
            button.Click += (s, a) =>
            {
                GameManager.restart();
            };

            panel.Widgets.Add(button);

            content = panel;
        }

        private Grid getNameInputGrid() {
            var grid = new Grid
            {
                ShowGridLines = true,
                ColumnSpacing = 8,
                RowSpacing = 8,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Center,
            };

            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.ColumnsProportions.Add(new Proportion());

            var text = new Label {
                Text = "You scored " + GameManager.Score + " !  type in your name for eternal glory",
                TextColor=Color.Red,
                Padding=new Thickness(20),
                Background = new SolidBrush(Color.Transparent),
                GridRow = 1,
                Font = Common.Font.GetFont(20)
            };

            var nameInput = new TextBox {
                TextColor=Color.White,
                Padding=new Thickness(20),
                Background = new SolidBrush(Color.LightSlateGray),
                GridRow = 2
            };


            var button = Common.getButton("Submit", 20);
            button.GridRow = 3;

            button.Click += async (s, a) =>
            {
                try {
                    await Api.SetHighScore(new HighScore(){
                        score=GameManager.Score,
                        name=nameInput.Text
                    });

                    grid.Widgets.Clear();

                    var text = new Label {
                        Text = "Submitted!",
                        TextColor=Color.Green,
                        Padding=new Thickness(20),
                        Background = new SolidBrush(Color.Transparent),
                        GridRow = 1,
                        Font = Common.Font.GetFont(32)
                    };

                    grid.Widgets.Add(text);
                } catch (HttpRequestException) {
                    var text = new Label {
                        Text = "Failed to submit, try again later or never.",
                        TextColor=Color.Red,
                        Padding=new Thickness(20),
                        Background = new SolidBrush(Color.Transparent),
                        GridRow = 1,
                        Font = Common.Font.GetFont(32)
                    };

                    grid.Widgets.Add(text);
                }
                
            };


            grid.Widgets.Add(text);
            grid.Widgets.Add(nameInput);
            grid.Widgets.Add(button);

            return grid;
        }
    }
}