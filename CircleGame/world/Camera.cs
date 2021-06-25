﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.clips;

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

        public void update(Player player, GraphicsDevice device) {
            int width = device.DisplayMode.Width;
            int height = device.DisplayMode.Height;

            Camera.Instance.position = player.Position - new Vector2(width / 2, height / 2);

            if (Camera.Instance.position.X < 0)
            {
                Camera.Instance.position = new Vector2(0, Camera.Instance.position.Y);
            }
            if (Camera.Instance.position.Y < 0)
            {
                Camera.Instance.position = new Vector2(Camera.Instance.position.X, 0);
            }
        }

    }
}
