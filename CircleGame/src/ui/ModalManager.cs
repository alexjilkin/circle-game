using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using Myra.Graphics2D.UI;
using System.Linq;

namespace CircleGame.ui
{
    public enum ModalType {
        None,
        TheEnd,
        NextLevel,
        MainMenu,
        Instructions
    }
    public sealed class  ModalManager: clips.IDrawable
    {
        private static readonly Lazy<ModalManager> lazy = new Lazy<ModalManager>(() => new ModalManager());
        private Desktop desktop;
        private TheEndModal theEndModal;
        private NextLevelModal nextLevelModal;
        private MainMenu mainMenu;
        public ModalType OpenModal { set; get; }

        public Desktop Desktop {
            get => desktop;
        }

        public static ModalManager Instance {
            get => lazy.Value;
        }

        private ModalManager() {
            desktop = new Desktop();
            mainMenu = new MainMenu();
            mainMenu.init();
            desktop.Root = mainMenu.Content;

            theEndModal = new TheEndModal();
            nextLevelModal = new NextLevelModal();
            desktop.HasExternalTextInput = true;
            
            OpenModal = ModalType.MainMenu;
            
            GameManager.StateChanged += handleStateChanged;
        }
        private void handleStateChanged() {
            if (GameManager.State == GameState.End) {
                nextLevelModal.init();
                OpenModal = ModalType.NextLevel;
                desktop.Root = nextLevelModal.Content;
            } else if(GameManager.State == GameState.Dead) {
                theEndModal.init();
                OpenModal = ModalType.TheEnd;
                desktop.Root = theEndModal.Content;
            } else if(GameManager.State == GameState.Initial) {
                mainMenu.init();
                OpenModal = ModalType.MainMenu;
                desktop.Root = mainMenu.Content;
            } else if (GameManager.State == GameState.Play) {
                desktop.Root = null;
                OpenModal = ModalType.None;
            }
        }
        public void draw(SpriteBatch _) {
            desktop.Render();
        }
        public void update(KeyboardState _) { }
    }
}