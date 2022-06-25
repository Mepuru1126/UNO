using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Game : IScene, IDisposable
    {
        public static Game_PlayerInfo gameInfo = new Game_PlayerInfo();
        public static Game_Select select = new Game_Select();
        private Game_DrawCard draw = new Game_DrawCard();
        private FadeIn fadeIn;
        private FadeOut fadeOut;

        public void Start()
        {
            select.Start();
            gameInfo.Init();
            draw.Start();

            fadeIn = new FadeIn();
            fadeOut = new FadeOut();
        }

        public void Update()
        {
            fadeIn?.Start(50);

            select.Update();
            select.AnimeUpdate();

            if (fadeIn != null && fadeIn.IsFinish())
                fadeIn = null;
        }

        public void Draw()
        {
            Program.tx.Game_Background.Draw(0, 0);
            draw.Draw();

            fadeIn?.Draw();
            fadeOut?.Draw();
        }

        public void Dispose()
        {
            
        }
    }
}
