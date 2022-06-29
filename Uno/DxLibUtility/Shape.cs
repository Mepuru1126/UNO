using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Shape
    {
        /// <summary>
        /// 四角形を描画する
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">横幅</param>
        /// <param name="heigth">高さ</param>
        /// <param name="color">色</param>
        public void BoxDraw(float x, float y, float width, float heigth, uint color)
        {
            DrawBoxAA(x, y, x + width, y + heigth, color, TRUE);
        }

        /// <summary>
        /// 角丸の四角形を描画します
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">横幅</param>
        /// <param name="heigth">高さ</param>
        /// <param name="ps">半径</param>
        /// <param name="color">色</param>
        public void RoundDraw(float x, float y, float width, float heigth, float ps, uint color)
        {
            DrawRoundRectAA(x, y, x + width, y + heigth, ps, ps, 255, color, TRUE);
        }

        /// <summary>
        /// Color構造体をuintに変換して変えす
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public uint GetUintColor(Color color)
        {
            return GetColor(color.R, color.G, color.B);
        }
    }
}
