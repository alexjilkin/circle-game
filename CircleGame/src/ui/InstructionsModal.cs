using System;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using CircleGame.utils;
using CommonClasses;

namespace CircleGame.ui
{
    public class InstructionsModal: IModal
    {
        private Panel content;
        public Action Back;
        private void OnBack() => Back?.Invoke();

        public Panel Content {
            get => content;
        }
        public InstructionsModal() {
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
            grid.RowsProportions.Add(new Proportion());
            grid.ColumnsProportions.Add(new Proportion());

            string text = "Circles that are bigger than you are dangerous";

            var line1 = new Label {
                Text = text,
                TextColor=Color.Red,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(20),
                GridRow=1,
                Background = new SolidBrush(Color.Transparent)
            };

            line1.Font = Common.Font.GetFont(40);
            grid.Widgets.Add(line1);


            panel.Widgets.Add(grid);

            var button = Common.getButton("Back", 50);
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Bottom;
            button.Margin = new Thickness(0, 0, 0, 50);
            
            button.Click += (s, a) =>
            {
                OnBack();
            };

            panel.Widgets.Add(button);

            content = panel;
        }
    }
}