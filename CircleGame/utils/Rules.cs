using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using System.Linq;

namespace CircleGame.world
{
    public class Enemy {
        public int Radius { get; set; }
        public string Type { get; set; }
    }

    public class Perk {
        public string PerkName { get; set;  }

        public int SpeedIncrease { get; set; }

        public int ScaleIncrease { get; set; }
    }
    public sealed class Rules
    {
        private static readonly Lazy<Rules> lazy = new Lazy<Rules>(() => new Rules());

        public Vector2 BoundryPosition {
            get {
                return new Vector2(this.getConfig<int>("boundry-start-x"), this.getConfig<int>("boundry-start-y"));
            }
        }
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
        public Enemy[] Enemies {
            get {
                return this.getConfig<Enemy[]>("Enemies");
            }
        }

        public Perk[] Perks {
            get {
                return this.getConfig<Perk[]>("Perks");
            }
        }

        public Perk FlashPerk {
            get {
                return this.Perks.Where(p => p.PerkName == "flash").First();
            }
        }

        public Perk HulkPerk {
            get {
                return this.Perks.Where(p => p.PerkName == "hulk").First();
            }
        }
        public int BaseSpeed {
            get {
                return this.getConfig<int>("BaseSpeed");
            }
        }
        public int PlayerSpeed {
            get {
                return this.getConfig<int>("PlayerSpeed");
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
