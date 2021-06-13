using System.Runtime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;
namespace CircleGame
{
    public class MovingCircle: Clip
    {
        protected int directionX;
        protected int directionY = new System.Random().Next(0, 2) * 2 - 1;
        private int radius;
        protected int speed;

        public int Radius {
            get {
                return this.radius;
            } 
            protected set {
                this.radius = value;
                this.Origin = new Vector2(radius, radius);
                this.updateTexture();
            }
        }

        public MovingCircle(int radius, Vector2 position) : base()
        {
            this.Position = position;
            this.Radius = radius;
            this.Origin = new Vector2(radius, radius);
            this.directionX = new System.Random().Next(0, 2) * 2 - 1;
            this.directionY = new System.Random().Next(0, 2) * 2 - 1;
            this.updateTexture();
        }

    public override void update(KeyboardState state)
    {
        this.handleBorderCollision(state);
        this.Position = Vector2.Add(this.Position, new Vector2(directionX * speed, directionY * speed));
    }

    private void updateTexture() {
        this.Texture = createCircleTexture(radius * 2);
    }

    protected void handleBorderCollision(KeyboardState state)
    {
        int width = Rules.Instance.Width;
        int height = Rules.Instance.Height;
        float x = Rules.Instance.BoundryPosition.X;
        float y = Rules.Instance.BoundryPosition.Y;

        if (this.Position.X + this.Radius > width + x)
        {
            this.Position = new Vector2(x + width - this.Radius - 1, this.Position.Y);
            directionX *= -1;
        }

        if (this.Position.Y + this.Radius > height + y)
        {
            this.Position = new Vector2(this.Position.X, y + height - this.Radius - 1);
            directionY *= -1;
        }
        else if (this.Position.X - this.Radius < x + 15)
        {
            this.Position = new Vector2(x + this.Radius + 16, this.Position.Y);
            directionX *= -1;
        }
        else if (this.Position.Y - this.Radius < y + 15)
        {
            this.Position = new Vector2(this.Position.X, y + this.Radius + 16);
            directionY *= -1;
        }
    }
    public bool isIntersecting(MovingCircle circle) {
        int diam = this.Radius * 2;
        if (this.Position.X + diam > circle.Position.X && this.Position.X < circle.Position.X + diam 
        && this.Position.Y + diam > circle.Position.Y && this.Position.Y < circle.Position.Y + diam) {
            return true;
        }

        return false;
    }

    private Texture2D createCircleTexture(int diam)
    {
        Texture2D texture = new Texture2D(this.GraphicsDevice, diam, diam);
        Color[] colorData = new Color[diam * diam];

        float radius = diam / 2f;
        float radiussq = radius * radius;

        for (int x = 0; x < diam; x++)
        {
            for (int y = 0; y < diam; y++)
            {
                int index = x * diam + y;
                Vector2 pos = new Vector2(x - radius, y - radius);
                if (pos.LengthSquared() <= radiussq)
                {
                    colorData[index] = Color.White;
                }
                else
                {
                    colorData[index] = Color.Transparent;
                }
            }
        }

            texture.SetData(colorData);
            return texture;
        }
    }

    
}
