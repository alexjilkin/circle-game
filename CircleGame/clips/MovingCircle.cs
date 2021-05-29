using System.Runtime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CircleGame.world;
namespace CircleGame
{
    public class MovingCircle: Clip
    {
        
        protected int directionX = new System.Random().Next(0, 2) * 2 - 1;
        protected int directionY = new System.Random().Next(0, 2) * 2 - 1;
        protected int radius;
        protected int speed;

        public int Radius {
            get {
                return this.radius;
            }
        }

        public MovingCircle(GraphicsDevice graphicsDevice, int radius) : base(graphicsDevice)
        {
            this.radius = radius;
            this.speed = 6;
            this.origin = new Vector2(radius, radius);
            this.updateTexture();
        }

    public override void update(KeyboardState state)
    {
        this.handleBorderCollision(state);
        _position.X += directionX * speed;
        _position.Y += directionY * speed;
    }

    public void updateTexture() {
        this.texture = createCircleText(radius * 2);
    }

    protected void handleBorderCollision(KeyboardState state)
    {
        int width = Rules.Instance.Width;
        int height = Rules.Instance.Height;

        if (_position.X + this.radius > width)
        {
            _position.X = width - this.radius - 1;
            directionX *= -1;
        }

        if (_position.Y + this.radius > height)
        {
            _position.Y = height - this.radius - 1;
            directionY *= -1;
        }
        else if (_position.X - this.radius < 0)
        {
            _position.X = 0 + this.radius + 1;
            directionX *= -1;
        }
        else if (_position.Y - this.radius < 0)
        {
            _position.Y = 0 + this.radius + 1;
            directionY *= -1;
        }
    }
    public bool isIntersecting(MovingCircle circle) {
        int diam = this.radius * 2;
        if (this.Position.X + diam > circle.Position.X && this.Position.X < circle.Position.X + diam 
        && this.Position.Y + diam > circle.Position.Y && this.Position.Y < circle.Position.Y + diam) {
            return true;
        }

        return false;
    }

    Texture2D createCircleText(int diam)
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
