using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CircleGame.world
{
    public sealed class Rules
    {
        private static readonly Lazy<Rules> lazy = new Lazy<Rules>(() => new Rules());
        public int Width {
            get {
                return this.getConfig<int>("width");
            }
        }

        public int Height {
            get {
                return this.getConfig<int>("height");
            }
        }

        private IConfigurationRoot configuration;
        public static Rules Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        private Rules() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }
        private T getConfig<T>(string key) { 
            return this.configuration.GetSection(key).Get<T>();
        }

    }
}
