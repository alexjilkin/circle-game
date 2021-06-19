using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Xna.Framework;

using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Newtonsoft.Json;
using FontStashSharp;

namespace CircleGame.ui
{
    public class DeathModal: IModal
    {
        private Panel content;

        public Panel Content {
            get {
                return content;
            }
        }
        public DeathModal() {
            init();
        }
        private void init() {
            var font = FontSystemFactory.Create(GameManager.graphicsDevice);
            font.AddFont(File.ReadAllBytes("assets\\ka1.ttf"));
            var panel = new Panel();

            var title = new TextBox{
                Text = "You are DEAD",
                TextColor=Color.Red,
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Top,
                Margin=new Thickness(0, 20, 0 ,0),
                Padding=new Thickness(20)
            };
            title.Font = font.GetFont(62);
            panel.Widgets.Add(title);

            var button = new TextButton
            {
                Text = "Restart",
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
    }
}