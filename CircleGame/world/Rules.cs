using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CircleGame.world
{
    public static class Rules
    {
        public static int width = Rules.getConfig<int>("width");
        public static int height = Rules.getConfig<int>("height");

        public static T getConfig<T>(string key) {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetSection(key).Get<T>();
        }

    }
}
