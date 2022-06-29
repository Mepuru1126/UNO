using System;
using static DxLibDLL.DX;

namespace Uno
{
    internal class FadeIn
    {
        public FadeIn()
        {
            counter = 0;
        }

        public void Start(double interval)
        {
            if (counter > 90)
                return;

            counter += (interval * Program.deltaTime);
        }

        public bool IsFinish()
        {
            return counter > 90;
        }

        public void Draw()
        {
            double opacity = Math.Sin(counter * Math.PI / 180) * 255;

            SetDrawBlendMode(DX_BLENDMODE_ALPHA, 255 - (int)Math.Floor(opacity));
            DrawBox(0, 0, 1920, 1080, GetColor(Program.BackColor.R, Program.BackColor.G, Program.BackColor.B), TRUE);
            SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
        }

        public double counter;
    }
}
