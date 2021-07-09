using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.world;
using CircleGame.clips;
using CircleGame.clips.enemies;
using CircleGame.clips.enemies.factory;

namespace CircleGame
{
    public enum GameState {
        Initial,
        Play,
        Pause,
        End,
        Dead
    }

    class GameManager
    {
        private static int score = 0;
        private static GameState state;
        public static Action StateChanged;
        private static void OnStateChanged() => StateChanged?.Invoke();

        public static GameState State {
            get => state;
            set {
                state = value;
                OnStateChanged();
            }
        }

        public static int Score {
            get => score;
        }

        private static List<EnemyCircle> enemies = new List<EnemyCircle>();
        public static List<EnemyCircle> Enemies {
            get => enemies;
        }
        private static Player player;
        public static Player Player {
            get => player;
        }

        public static GraphicsDevice graphicsDevice;
        
        public static void handleItersection(GameTime gameTime) {
            MovingCircle enemy;
            enemy = getIntersecting(enemies, player);

            if (enemy != null) {
                if (player.Radius >= enemy.Radius) {
                    score += enemy.Radius / 5;
                    enemies = enemies.FindAll(e => e != enemy);
                    if (enemies.Count == 0) {
                       State = GameState.End;
                    }
                    if(enemy is FlashEnemy) {
                        player.setPerk(Rules.Instance.FlashPerk, gameTime);
                    } else if (enemy is HulkEnemy) {
                        player.setPerk(Rules.Instance.HulkPerk, gameTime);
                    }
                } else {
                    State = GameState.Dead;
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
            State = GameState.Play;
            score = 0;
            initCircles();
        }

        public static void initCircles() {   
            EnemyConfig[] enemiesConfig = Rules.Instance.Enemies;

            enemies = new List<EnemyCircle>();
            player = new Player(30);
            Vector2 boundryPosition = Rules.Instance.BoundryPosition;

            foreach (EnemyConfig enemyConfig in enemiesConfig)
            {
                EnemyCircle enemy = EnemyManager.createEnemy(
                    enemyConfig.Type, 
                    enemyConfig.Radius, 
                    boundryPosition + new Vector2(new System.Random().Next(100, Rules.Instance.Width), 
                    new System.Random().Next(100, Rules.Instance.Height))
                );
                enemies.Add(enemy);
            }
        }
    }
}