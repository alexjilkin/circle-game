using System;

namespace CircleGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new CircleGame())
                game.Run();
        }
    }
}
