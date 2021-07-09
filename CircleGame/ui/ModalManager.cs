using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    
using System.Threading.Tasks;
using CircleGame;
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.UI;
using System.Linq;

namespace CircleGame.ui
{
    public enum ModalType {
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
        public ModalType OpenModal { set; get; }

        public Desktop Desktop {
            get => desktop;
        }

        public static ModalManager Instance {
            get => lazy.Value;
        }

        private ModalManager() {
            desktop = new Desktop();
            theEndModal = new TheEndModal();
            mainMenu = new MainMenu();
            instructionsModal = new InstructionsModal();
            instructionsModal.init();

            desktop.HasExternalTextInput = true;
            
            mainMenu.init();
            OpenModal = ModalType.MainMenu; 
            desktop.Root = mainMenu.Content;
            
            GameManager.StateChanged += () => {
                if(new GameState[]{GameState.End, GameState.Dead}.Contains(GameManager.State)) {
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
            };
        }

        public void draw(SpriteBatch _) {
            desktop.Render();
        }

        public void update(KeyboardState _) {
            
        }
    }
}