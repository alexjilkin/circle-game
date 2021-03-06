using System;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;

namespace CircleGame.ui
{
    public class InstructionsModal: IModal
    {
        public Action Back;
        private void OnBack() => Back?.Invoke();

        public Panel Content {
            private set;
            get;
        }
        public InstructionsModal() {
            init();
        }
        public void init() {
            var panel = new Panel();

            var grid = new Grid
            {
                ShowGridLines = false,
                ColumnSpacing = 8,
                RowSpacing = 8,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Center,
            };

            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.ColumnsProportions.Add(new Proportion());

            grid.Widgets.Add(new Label {
                Text = "Use your arrow keys to change direction",
                TextColor = Color.Gray,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(10),
                GridRow = 1,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(36)
            });

             grid.Widgets.Add(new Label {
                Text = "press ESC to stop",
                TextColor = Color.Gray,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(10),
                GridRow = 2,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(36)
            });
            
            grid.Widgets.Add(new Label {
                Text = "Eat circles whose radius is smaller than your own",
                TextColor = Color.Salmon,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(10),
                GridRow = 3,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(34)
            });

            grid.Widgets.Add(new Label {
                Text = "Red enemy boosts your speed",
                TextColor = Color.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(10),
                GridRow = 4,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(30)
            });

            grid.Widgets.Add(new Label {
                Text = "Green enemy is bigger than it actually is",
                TextColor = Color.Green,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 20, 0 ,0),
                Padding = new Thickness(10),
                GridRow = 5,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(30)
            });


            panel.Widgets.Add(grid);

            var button = Common.getButton("Back", 50, HorizontalAlignment.Center, VerticalAlignment.Bottom);
            button.Margin = new Thickness(0, 0, 0, 50);
            
            button.Click += (s, a) => {
                OnBack();
            };

            panel.Widgets.Add(button);

            Content = panel;
        }
    }
}