using System;
using System.Net.Http;
using CommonClasses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CircleGame.utils
{
    public class Api
    {
        static HttpClient client = new HttpClient() {
            BaseAddress = new Uri("https://circlegameapi.azurewebsites.net/api/")
        };

        public static async Task<HighScore[]> GetHighScores() {
            var res = await client.GetAsync("Score/Leaderboard");
            string scores = await res.Content.ReadAsStringAsync();

            HighScore[] highScores = JsonConvert.DeserializeObject<HighScore[]>(scores);

            return highScores;
        }

        public static async Task<HighScore> GetMaxHighScore() {
            var res = await client.GetAsync("Score/Max");
            string score = await res.Content.ReadAsStringAsync();

            HighScore highScore = JsonConvert.DeserializeObject<HighScore>(score);

            return highScore;
        }

        public static async Task SetHighScore(HighScore highScore) {
            var res = await client.PostAsJsonAsync("Score", highScore);
            string score = await res.Content.ReadAsStringAsync();
        }
    }
}