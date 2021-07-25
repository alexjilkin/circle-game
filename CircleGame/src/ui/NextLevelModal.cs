using System;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using CircleGame.utils;
using CommonClasses;

namespace CircleGame.ui
{
    public class NextLevelModal: IModal
    {
        private Panel content;
        public Action Back;
        private void OnBack() => Back?.Invoke();

        public Panel Content {
            get => content;
        }
        public NextLevelModal() {
            init();
        }
        public void init() {
            var panel = new Panel();

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
            grid.ColumnsProportions.Add(new Proportion());

            grid.Widgets.Add(new Label {
                Text = "Congratulations, you finished level " + GameManager.Level,
                TextColor=Color.Pink,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(10),
                GridRow=1,
                Background = new SolidBrush(Color.Transparent),
                Font = Common.Font.GetFont(36)
            });


            panel.Widgets.Add(grid);

            var button = Common.getButton("Next", 50, HorizontalAlignment.Center, VerticalAlignment.Bottom);
            button.Margin = new Thickness(0, 0, 0, 50);
            
            button.Click += (s, a) =>
            {
                GameManager.goToNextLevel();
            };

            panel.Widgets.Add(button);

            content = panel;
        }
    }
}