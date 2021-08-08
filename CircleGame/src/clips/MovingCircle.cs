using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;

namespace CircleGame.clips
{
    public class MovingCircle: Clip
    {
        protected int DirectionX {get; set;}
        protected int DirectionY {get; set;}
        protected Action BorderHit;
        private void OnBorderHit() => BorderHit?.Invoke();
        private int radius;
        private int scale = 1;

        public int Radius {
            get => this.radius;
            protected set {
                this.radius = value;
                this.Origin = new Vector2(radius * scale, radius * scale);
                this.updateTexture();
            }
        }

        public float Speed { get; protected set; }
        public int Scale {
            get => this.scale;
            protected set {
                this.scale = value;
                this.Origin = new Vector2(radius * scale, radius * scale);
                this.updateTexture();
            }
        }

        public MovingCircle(int radius, Vector2 position) : base() {
            this.Position = position;
            this.Radius = radius;
            this.Origin = new Vector2(radius * Scale, radius * Scale);
            this.DirectionX = new System.Random().Next(0, 2) * 2 - 1;
            this.DirectionY = new System.Random().Next(0, 2) * 2 - 1;
            this.updateTexture();
        }

        public override void update(KeyboardState state) {
            if(this.handleBorderCollision(state)) {
                OnBorderHit();
            }
            
            this.Position = Vector2.Add(this.Position, new Vector2(DirectionX * Speed, DirectionY * Speed));
        }

        private void updateTexture() {
            this.Texture = createCircleTexture(radius * 2 * this.Scale);
        }

        protected bool handleBorderCollision(KeyboardState state) {
            int width = Rules.Instance.Width;
            int height = Rules.Instance.Height;
            float x = Rules.Instance.BoundryPosition.X;
            float y = Rules.Instance.BoundryPosition.Y;
            int drawRadius = (this.Radius * this.Scale);

            if (this.Position.X + drawRadius > width + x) {
                this.Position = new Vector2(x + width - drawRadius - 1, this.Position.Y);
                DirectionX *= -1;

                return true;
            } else if (this.Position.Y + drawRadius > height + y) {
                this.Position = new Vector2(this.Position.X, y + height - drawRadius - 1);
                DirectionY *= -1;

                return true;
            } else if (this.Position.X - drawRadius < x + 15) {
                this.Position = new Vector2(x + drawRadius + 16, this.Position.Y);
                DirectionX *= -1;

                return true;
            } else if (this.Position.Y - drawRadius < y + 15) {
                this.Position = new Vector2(this.Position.X, y + drawRadius + 16);
                DirectionY *= -1;

                return true;
            }

            return false;
        }
        public bool isIntersecting(MovingCircle circle) {
            int diam = this.Radius * 2 * this.Scale;

            if (this.Position.X + diam > circle.Position.X && this.Position.X < circle.Position.X + diam 
            && this.Position.Y + diam > circle.Position.Y && this.Position.Y < circle.Position.Y + diam) {
                return true;
            }

            return false;
        }

        private Texture2D createCircleTexture(int diam) {
            Texture2D texture = new Texture2D(GameManager.graphicsDevice, diam, diam);
            Color[] colorData = new Color[diam * diam];

            float radius = diam / 2f;
            float radiussq = radius * radius;

            for (int x = 0; x < diam; x++)
            {
                for (int y = 0; y < diam; y++)
                {
                    int index = x * diam + y;
                    Vector2 pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiussq) {
                        colorData[index] = Color.White;
                    } else {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}
