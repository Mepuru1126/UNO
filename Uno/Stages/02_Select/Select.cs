using System;
using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Select : IScene
    {
        private Select_Info infodraw = new Select_Info();
        private FadeIn fadeIn;
        private FadeOut fadeOut;
        private double fadeCount;
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

            fadeCount += (50 * Program.deltaTime);

            if (fadeCount > 180)
                fadeCount = 0;
        }

        public void Draw()
        {
            var barPoint = new Point((Program.windowSize.Width - Program.tx.Select_Bar.TextureSize.Width) / 2, 400);
            double fadeOpacity = Math.Sin(fadeCount * Math.PI / 180) * 255;
            Program.tx.Select_Label.Opacity = (float)fadeOpacity;

            Program.tx.Select_Background.Draw(0, 0);
            Program.tx.Select_Bar.Draw(barPoint.X, barPoint.Y);
            Program.tx.Select_Label.Draw(
                (Program.windowSize.Width - Program.tx.Select_Label.TextureSize.Width) / 2,
                barPoint.Y + (Program.tx.Select_Bar.TextureSize.Height - Program.tx.Select_Label.TextureSize.Height) / 2);

            infodraw.Draw();

            fadeIn?.Draw();
            fadeOut?.Draw();
        }
    }
}
