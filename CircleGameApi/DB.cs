using System.Collections.Generic;
using StackExchange.Redis;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CircleGameApi
{
    public sealed class DB
    {    
        private static readonly Lazy<DB> lazy = new Lazy<DB>(() => new DB());
        readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("redis-14224.c73.us-east-1-2.ec2.cloud.redislabs.com:14224,password=CoSCoK5V0DgKmFpJOK1yIc2zLnltVpcT");
        IDatabase db;

        public static DB Instance {
            get {
                return lazy.Value;
            }
        }
        private DB() {
            db = muxer.GetDatabase();
        }

        public async Task SortedSetAddAsync<T>(string key, double score, T value) {
            await db.SortedSetAddAsync(key, JsonConvert.SerializeObject(value), score);
        }

        public  async Task<T> GetObjectAsync<T>(string key) {
            var value = await db.StringGetAsync(key);

            return JsonConvert.DeserializeObject<T>(value);
        }
        public  async Task<T[]> GetSortedSet<T>(string key, int limit) {
            RedisValue[] set = await db.SortedSetRangeByRankAsync(key, 0, limit, Order.Descending);
            return set.Select(d => JsonConvert.DeserializeObject<T>(d)).ToArray();
        }
        public async Task<T> GetHighestInSet<T>(string key) {
            RedisValue[] set = await db.SortedSetRangeByRankAsync(key, 0, 1, Order.Descending);
            return JsonConvert.DeserializeObject<T>(set[0]);
        }
    }
}