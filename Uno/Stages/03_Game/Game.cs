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
        private FadeIn fadeIn;
        private FadeOut fadeOut;

        public void Start()
        {
            gameInfo.Init();

            fadeIn = new FadeIn();
            fadeOut = new FadeOut();
        }

        public void Update()
        {
            fadeIn?.Start(50);

            if (fadeIn != null && fadeIn.IsFinish())
                fadeIn = null;
        }

        public void Draw()
        {
            Program.tx.Game_Background.Draw(0, 0);

            fadeIn?.Draw();
            fadeOut?.Draw();
        }

        public void Dispose()
        {
            
        }
    }
}
