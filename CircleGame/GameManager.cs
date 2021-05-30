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
        private static int score = 0;
        public static int Score {
            get {
                return score;
            }
        }

        private static List<EnemyCircle> enemies = new List<EnemyCircle>();
        public static List<EnemyCircle> Enemies {
            get {
                return enemies;
            }
        }
        private static Player player;
        public static Player Player {
            get {
                return player;
            }
        }

        public static GraphicsDevice graphicsDevice;
        
        public static void handleItersection() {
            MovingCircle enemy;
            enemy = getIntersecting(enemies, player);

            if (enemy != null) {
                if (player.Radius >= enemy.Radius) {
                    score += enemy.Radius / 5;
                    enemies = enemies.FindAll(e => e != enemy);
                } else {
                    GameManager.init();
                }
            }
        }
        

         public static MovingCircle getIntersecting(IEnumerable<MovingCircle> circles, Player player) {
            foreach (MovingCircle circle in circles) 
            {
                if (player.isIntersecting(circle)) {
                    return circle;
                }
            }

            return null;
         }
        

        public static void init() {
            score = 0;
            enemies = new List<EnemyCircle>();
            player = new Player(graphicsDevice, 30);
            enemies.Add(new EnemyCircle(graphicsDevice, 15, new Vector2(300, 300)));
            enemies.Add(new EnemyCircle(graphicsDevice, 35, new Vector2(600, 900)));
            enemies.Add(new EnemyCircle(graphicsDevice, 50, new Vector2(500, 500)));
            enemies.Add(new EnemyCircle(graphicsDevice, 20, new Vector2(300, 300)));
            enemies.Add(new EnemyCircle(graphicsDevice, 25, new Vector2(900, 300)));
            enemies.Add(new EnemyCircle(graphicsDevice, 60, new Vector2(900, 900)));
        }
    }
}