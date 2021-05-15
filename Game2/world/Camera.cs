using System;
using Microsoft.Xna.Framework;

namespace CircleGame.world
{
    public sealed class Camera
    {
        private static readonly Lazy<Camera> lazy = new Lazy<Camera>(() => new Camera());
        public Vector2 position { get; set;}

        public static Camera Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private Camera()
        {
            position = new Vector2(0, 0);
        }

    }
}
