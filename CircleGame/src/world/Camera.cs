using System;
using Microsoft.Xna.Framework;
using CircleGame.clips;

namespace CircleGame.world
{
    public sealed class Camera
    {
        private static readonly Lazy<Camera> lazy = new Lazy<Camera>(() => new Camera());
        public Vector2 Position { get; set;}
        public static Camera Instance {
            get => lazy.Value;
        }

        private Camera()
        {
            Position = new Vector2(0, 0);
        }

        public void update(Player player) {
            int width = 1920;
            int height = 1080;

            Camera.Instance.Position = player.Position - new Vector2(width / 2, height / 2);

            if (Camera.Instance.Position.X < 0)
            {
                Camera.Instance.Position = new Vector2(0, Camera.Instance.Position.Y);
            }
            if (Camera.Instance.Position.Y < 0)
            {
                Camera.Instance.Position = new Vector2(Camera.Instance.Position.X, 0);
            }
        }

    }
}
