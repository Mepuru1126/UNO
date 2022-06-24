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

        #region SelectTextuer
        public Texture
            Select_Background,
            Select_Bar,
            Select_Label;
        #endregion

        #region GameTexture
        public Texture
            Game_Background,
            Game_CardBase;

        public Texture[]
            Game_CardNum,
            Game_CardColor;
        #endregion

        public void Load()
        {
            Title_Backgeround = new Texture($"{TX}{TITLE}Background{ex}");
            Title_Logo = new Texture($"{TX}{TITLE}Logo{ex}"); 
            Title_Logo2 = new Texture($"{TX}{TITLE}Logo2{ex}");
            Title_Label = new Texture($"{TX}{TITLE}Label{ex}");

            Select_Background = new Texture($"{TX}{SELECT}Background{ex}");
            Select_Bar = new Texture($"{TX}{SELECT}Bar{ex}");
            Select_Label = new Texture($"{TX}{SELECT}Label{ex}");

            Game_Background = new Texture($"{TX}{GAME}Background{ex}");
            Game_CardBase = new Texture($"{TX}{GAME}{CARD}Base{ex}");

            Game_CardColor = new Texture[4];
            for (int i = 0; i < 4; i++)
                Game_CardColor[i] = new Texture($"{TX}{GAME}{CARD}Color\\{i}{ex}");
        }

        string ex = ".png";
        const string TX = "UnoDate\\Theme\\Texture\\";
        const string TITLE = "01_Title\\";
        const string SELECT = "02_Select\\";
        const string GAME = "03_Game\\";
        const string CARD = "Card\\";
    }
}
