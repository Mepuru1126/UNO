using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class TextureLoad
    {
        #region TitleTexture
        public Texture
            Title_Backgeround,
            Title_Logo,
            Title_Logo2,
            Title_Label;
        #endregion

        public void Load()
        {
            Title_Backgeround = new Texture($"{TX}{TITLE}Background.png");
            Title_Logo = new Texture($"{TX}{TITLE}Logo.png"); 
            Title_Logo2 = new Texture($"{TX}{TITLE}Logo2.png");
            Title_Label = new Texture($"{TX}{TITLE}Label.png");
        }

        const string TX = "UnoDate\\Theme\\Texture\\";
        const string TITLE = "01_Title\\";
        const string SELECT = "02_Select\\";
    }
}
