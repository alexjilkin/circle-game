using Myra.Graphics2D.UI;

namespace CircleGame.ui
{
    public interface IModal
    {
        public Panel Content { get; }
        public void init();
    }
}