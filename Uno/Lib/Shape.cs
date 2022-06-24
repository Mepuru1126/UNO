using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Shape
    {
        public void BoxDraw(float x, float y, float width, float heigth, uint color)
        {
            DrawBoxAA(x, y, x + width, y + heigth, color, TRUE);
        }

        public void RoundDraw(float x, float y, float width, float heigth, float ps, uint color)
        {
            DrawRoundRectAA(x, y, x + width, y + heigth, ps, ps, 255, color, TRUE);
        }

        public uint GetUintColor(Color color)
        {
            return GetColor(color.R, color.G, color.B);
        }
    }
}
