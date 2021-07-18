using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using System.Linq;
using CircleGame.clips;

namespace CircleGame.world
{
    public class EnemyConfig {
        public int Radius { get; set; }
        public string Type { get; set; }
    }

    public class Perk: IPerk {
        public string PerkName { get; set;  }
        public int SpeedIncrease { get; set; }
        public int ScaleIncrease { get; set; }
    }
    public sealed class Rules
    {
        private static readonly Lazy<Rules> lazy = new Lazy<Rules>(() => new Rules());

        public Vector2 BoundryPosition {
            get => new Vector2(this.getConfig<int>("boundry-start-x"), this.getConfig<int>("boundry-start-y"));
        }
        public int MovementsLimit {
            get => this.getConfig<int>("MovementsLimits");
        }
        public int Width {
            get => this.getConfig<int>("width");
        }
        public int Height {
            get => this.getConfig<int>("height");
        }
        public EnemyConfig[] Enemies {
            get => this.getConfig<EnemyConfig[]>("Enemies");
        }

        public Perk[] Perks {
            get => this.getConfig<Perk[]>("Perks");
        }

        public Perk FlashPerk {
            get => this.Perks.Where(p => p.PerkName == "flash").First();
        }

        public Perk HulkPerk {
            get => this.Perks.Where(p => p.PerkName == "hulk").First();
        }
        public float BaseSpeed {
            get => this.getConfig<float>("BaseSpeed");
        }
        public float PlayerSpeed {
            get => this.getConfig<float>("PlayerSpeed");
        }

        private IConfigurationRoot configuration;
        public static Rules Instance {
            get => lazy.Value;
        }
        private Rules() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }
        private T getConfig<T>(string key) =>
            this.configuration.GetSection(key).Get<T>();
    }
}
