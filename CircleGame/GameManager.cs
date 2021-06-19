using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.world;
using CircleGame.clips.enemies.factory;

namespace CircleGame
{
    class GameManager
    {
        private static int score = 0;
        private static bool isDead = false;
        private static bool isMainMenuOpen = true;
        public static bool IsDead {
            get {
                return isDead;
            }
        }   
        public static bool IsMainMenuOpen {
            get {
                return isMainMenuOpen;
            }
        }
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
                    isDead = true;
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
        
        public static void restart() {
            isDead = false;
            isMainMenuOpen = false;
            score = 0;
            initCircles();
        }

        public static void initCircles() {   
            Enemy[] enemiesConfig = Rules.Instance.Enemies;

            enemies = new List<EnemyCircle>();
            player = new Player(30);
            Vector2 boundryPosition = Rules.Instance.BoundryPosition;

            foreach (Enemy enemyConfig in enemiesConfig)
            {
                EnemyCircle enemy = EnemyManager.createEnemy(enemyConfig.Type, enemyConfig.Radius, boundryPosition + new Vector2(new System.Random().Next(100, Rules.Instance.Width), new System.Random().Next(100, Rules.Instance.Height)));
                enemies.Add(enemy);
            }
        }
    }
}