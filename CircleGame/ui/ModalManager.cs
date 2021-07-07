using System;
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
        MainMenu,
        Instructions
    }
    public sealed class  ModalManager: IDrawable
    {
        private static readonly Lazy<ModalManager> lazy = new Lazy<ModalManager>(() => new ModalManager());
        private Desktop desktop;
        private TheEndModal theEndModal;
        private MainMenu mainMenu;
        private InstructionsModal instructionsModal;
        private bool isModalOpen;
        public ModalState State {
            set; get;
        }
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

        public static ModalManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private ModalManager() {
            desktop = new Desktop();
            theEndModal = new TheEndModal();
            mainMenu = new MainMenu();
            instructionsModal = new InstructionsModal();

            desktop.HasExternalTextInput = true;
        }

        public void draw(SpriteBatch _) {
            desktop.Render();
        }

        public void update(KeyboardState _) {
            if (State == ModalState.Instructions && desktop.Root != instructionsModal.Content) {
                instructionsModal.init();
                desktop.Root = instructionsModal.Content;
            } else if(GameManager.IsEnd && State != ModalState.TheEnd) {
                State = ModalState.TheEnd;
                theEndModal.init();
                desktop.Root = theEndModal.Content;
            } else if(GameManager.IsMainMenuOpen && desktop.Root != mainMenu.Content && mainMenu.Content != null && State != ModalState.Instructions) {
                State = ModalState.MainMenu;
                mainMenu.init();
                desktop.Root = mainMenu.Content;
            }

            isModalOpen = GameManager.IsEnd || GameManager.IsMainMenuOpen ;
            if (!isModalOpen) {
                desktop.Root = null;
                State = ModalState.None;
            }
        }
    }
}