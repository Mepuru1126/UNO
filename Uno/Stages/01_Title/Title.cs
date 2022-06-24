using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Title : IScene
    {
        private double fadeCount;
        private bool isFadeOut;
        private FadeOut fadeOut;

        public void Start()
        {
            fadeCount = 0;
            isFadeOut = false;
            fadeOut = new FadeOut();
        }

        public void Update()
        {
            fadeCount += (65 * Program.deltaTime);

            if (fadeCount > 180)
                fadeCount = 0;

            if (Program.input.IsPushed(KEY_INPUT_RETURN))
                isFadeOut = true;

            if (isFadeOut)
            {
                fadeOut?.Start(70);
                if (fadeOut != null && fadeOut.IsFinish())
                {
                    fadeOut = null;
                    Program.Scene.ChangeScene("Select");
                }
            }
        }

        public void Draw()
        {
            double fadeOpacity = Math.Sin(fadeCount * Math.PI / 180) * 255;

            Program.tx.Title_Label.Opacity = (float)fadeOpacity;

            Program.tx.Title_Backgeround.Draw(0, 0);
            Program.tx.Title_Logo.Draw(
                (Program.windowSize.Width - Program.tx.Title_Logo.TextureSize.Width) / 2,
                0);
            Program.tx.Title_Label.Draw(
                (Program.windowSize.Width - Program.tx.Title_Label.TextureSize.Width) / 2,
                950);

            fadeOut.Draw();
        }
    }
}
