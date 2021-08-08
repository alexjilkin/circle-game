using Microsoft.Xna.Framework;

namespace CircleGame.clips.enemies
{
    public static class EnemyManager
    {
        public static EnemyCircle createEnemy(string type, int radius, Vector2 position) {
            EnemyFactory factory = null;

            switch(type) {
                case "flash":
                    factory = new FlashEnemyFactory();
                    break;
                case "hulk":
                    factory = new HulkEnemyFactory();
                    break;
                default:
                    factory = new SimpleEnemyFactory();
                    break;
            }

            return factory.GetEnemyCircle(radius, position);
        }
    }
}