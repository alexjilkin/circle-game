using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CircleGame.utils;
using CircleGame.world;
using CircleGame.clips;
using CircleGame.clips.enemies;

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

        public static int Score { get; private set; } = 0;
        public static int TotalScore { get; private set; } = 0;

        public static int Level { get; private set; } = 0;

        private static List<EnemyCircle> enemies = new List<EnemyCircle>();
        public static List<EnemyCircle> Enemies {
            get => enemies;
        }

        public static Player Player {
            get;
            private set;
        }

        public static GraphicsDevice graphicsDevice;
        public static float MasterScale { get; set; } = 2f;
        public static void handleItersection(GameTime gameTime) {
            MovingCircle enemy;
            enemy = getIntersecting(enemies, Player);

            if (enemy != null) {
                if (Player.Radius >= enemy.Radius) {
                    Score += enemy.Radius / 5;
                    enemies = enemies.FindAll(e => e != enemy);
                    if (enemies.Count == 0) {
                       State = GameState.End;
                    } else if (enemy is FlashEnemy) {
                        Player.setPerk(Rules.Instance.FlashPerk, gameTime);
                    } else if (enemy is HulkEnemy) {
                        Player.setPerk(Rules.Instance.HulkPerk, gameTime);
                    }
                    
                    SoundManager.positive.Play();   
                } else {
                    State = GameState.Dead;
                    TotalScore += Score;
                    SoundManager.death.Play();
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
            TotalScore = 0;
            Level = 0;
            Score = 0;
            initCircles();
        }

        public static void goToNextLevel() {
            Level++;
            TotalScore += Score;
            Score = 0;
            initCircles();
            State = GameState.Play;
        }

        public static void initCircles() {
            EnemyConfig[] enemiesConfig = Rules.Instance.Levels[Level];

            enemies = new List<EnemyCircle>();
            Player = new Player(30);
            Vector2 boundryPosition = Rules.Instance.BoundryPosition;

            foreach (EnemyConfig enemyConfig in enemiesConfig)
            {
                EnemyCircle enemy = EnemyManager.createEnemy(
                    enemyConfig.Type, 
                    enemyConfig.Radius, 
                    boundryPosition + new Vector2(new System.Random().Next(300, Rules.Instance.Width), 
                    new System.Random().Next(300, Rules.Instance.Height))
                );
                enemies.Add(enemy);
            }
        }
    }
}