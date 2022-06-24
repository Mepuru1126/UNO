using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Select : IScene
    {
        private Select_Info infodraw = new Select_Info();
        private FadeIn fadeIn;
        private FadeOut fadeOut;
        private bool isFadeOut;

        public void Start()
        {
            infodraw.Start();
            fadeIn = new FadeIn();
            fadeOut = new FadeOut();
            isFadeOut = false;
        }

        public void Update()
        {
            fadeIn?.Start(70);

            if (fadeIn != null && fadeIn.IsFinish())
                fadeIn = null;

            if (Program.input.IsPushed(KEY_INPUT_RETURN))
                isFadeOut = true;

            if (isFadeOut)
            {
                fadeOut?.Start(70);
                if (fadeOut != null && fadeOut.IsFinish())
                {
                    fadeOut = null;
                    infodraw.Dispose();
                    Program.Scene.ChangeScene("Game");
                }
            }
        }

        public void Draw()
        {
            Program.tx.Select_Background.Draw(0, 0);
            infodraw.Draw();

            fadeIn?.Draw();
            fadeOut?.Draw();
        }
    }
}
