using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame;

namespace CircleGame
{
    class GameManager
    {
        public static int Score {get; set;}
        public static List<T> handleItersection<T>(IEnumerable<MovingCircle> enemies, Player player) {
            foreach (MovingCircle enemy in enemies) 
            {
                if (player.isIntersecting(enemy)) {
                    Score++;
                    enemies = enemies.Where(e => e != enemy);
                }
            }

            return enemies.Cast<T>().ToList();
        }
    }
}