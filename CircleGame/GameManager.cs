using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame;

namespace CircleGame
{
    static class GameManager
    {
        public static List<T> handleItersection<T>(IEnumerable<MovingCircle> enemies, Player player) {
            foreach (MovingCircle enemy in enemies) 
            {
                if (player.isIntersecting(enemy)) {
                    enemies = enemies.Where(e => e != enemy);
                }
            }

            return enemies.Cast<T>().ToList();
        }
    }
}