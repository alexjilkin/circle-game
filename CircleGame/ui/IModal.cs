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
using CommonClasses;
using Newtonsoft.Json;

namespace CircleGame.ui
{
    public interface IModal
    {
        public Panel Content {
            get;
        }

        public void init();
    }
}