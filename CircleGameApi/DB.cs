using StackExchange.Redis;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

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

        public async Task SetObjectAsync<T>(string key, T value)
        {
            await db.StringSetAsync(key, JsonConvert.SerializeObject(value));
        }

        public  async Task<T> GetObjectAsync<T>(string key)
        {
            var value = await db.StringGetAsync(key);

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}