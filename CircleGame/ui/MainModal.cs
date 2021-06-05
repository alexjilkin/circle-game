using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;

namespace CircleGame.ui
{
    public class MainModal: IDrawable
    {
        private Desktop desktop;
        private DeathModal deathModal;

        public MainModal() {
            desktop = new Desktop();
            deathModal = new DeathModal();
        }

        public void draw(SpriteBatch _) {
            desktop.Render();
        }

        public void update(KeyboardState _) {
            if(GameManager.IsDead) {
                desktop.Root = deathModal.Content;
            }
        }
    }
}