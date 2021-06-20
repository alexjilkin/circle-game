using Microsoft.Xna.Framework;
using FontStashSharp;
using System.IO;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;

namespace CircleGame.utils
{
    public static class Common
    {
        static Common() {
            Font.AddFont(File.ReadAllBytes("assets\\ka1.ttf"));
        }
        public static readonly FontSystem  Font = FontSystemFactory.Create(GameManager.graphicsDevice);

        public static TextButton getButton(string text, int fontSize) {
            return new TextButton {
                Text = text,
                Padding=new Thickness(10),
                Font = Common.Font.GetFont(fontSize),
                Background = new SolidBrush(Color.LightGreen),
                PressedBackground = new SolidBrush(Color.DarkGreen),
                OverBackground = new SolidBrush(Color.LimeGreen),
            };
        }
    }
}