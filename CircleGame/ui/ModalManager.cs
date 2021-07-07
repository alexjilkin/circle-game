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
    public enum ModalState {
        None,
        TheEnd,
        MainMenu
    }
    public class ModalManager: IDrawable
    {
        private Desktop desktop;
        private TheEndModal theEndModal;
        private MainMenu mainMenu;
        private bool isModalOpen;
        private ModalState state;
        public bool IsModalOpen {
            get {
                return isModalOpen;
            }
        }

        public Desktop Desktop {
            get {
                return desktop;
            }
        }

        public ModalManager() {
            desktop = new Desktop();
            theEndModal = new TheEndModal();
            mainMenu = new MainMenu();

            desktop.HasExternalTextInput = true;
        }

        public void draw(SpriteBatch _) {
            desktop.Render();
        }

        public void update(KeyboardState _) {
            if(GameManager.IsEnd && state != ModalState.TheEnd) {
                state = ModalState.TheEnd;
                theEndModal.init();
                desktop.Root = theEndModal.Content;
            } else if(GameManager.IsMainMenuOpen && mainMenu.Content != null && state != ModalState.MainMenu) {
                state = ModalState.MainMenu;
                mainMenu.init();
                desktop.Root = mainMenu.Content;
            } 

            isModalOpen = GameManager.IsEnd || GameManager.IsMainMenuOpen ;
            if (!isModalOpen) {
                desktop.Root = null;
                state = ModalState.None;
            }
        }
    }
}