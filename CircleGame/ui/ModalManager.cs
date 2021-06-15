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
    public class ModalManager: IDrawable
    {
        private Desktop desktop;
        private DeathModal deathModal;
        private MainMenu mainMenu;
        private bool isModalOpen;
        public bool IsModalOpen {
            get {
                return isModalOpen;
            }
        }

        public ModalManager() {
            desktop = new Desktop();
            deathModal = new DeathModal();
            mainMenu = new MainMenu();
        }

        public void draw(SpriteBatch _) {
            desktop.Render();
        }

        public void update(KeyboardState _) {
            if(GameManager.IsDead && desktop.Root != deathModal.Content) {
                desktop.Root = deathModal.Content;
            } else if(GameManager.IsMainMenuOpen && mainMenu.Content != null && desktop.Root != mainMenu.Content) {
                desktop.Root = mainMenu.Content;
            }

            isModalOpen = GameManager.IsDead || GameManager.IsMainMenuOpen;
        }
    }
}