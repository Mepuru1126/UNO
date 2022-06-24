using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Select_Info : IScene, IDisposable
    {
        private Shape shape;
        private int fontHandle;
        private string[] itemName;
        private object[] itemValue;

        public void Start()
        {
            SetFontCacheCharNum(50);
            fontHandle = CreateFontToHandle("Meiryo UI", 33, 10, DX_FONTTYPE_ANTIALIASING_4X4);
            SetFontCacheCharNum(0);

            shape = new Shape();

            itemName = new string[]
            {
                "名前",
                "レベル",
                "勝利回数",
                "敗北回数"
            };

            itemValue = new object[] 
            {
                Program.dateIo.date.PlayerName,
                Program.dateIo.date.Lv,
                Program.dateIo.date.WinCount,
                Program.dateIo.date.DefeatCount
            };
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            var boxPoint = new Point(50, 600);
            var boxSize = new Size(180, 100);
            const int boxInterval = 110;
            const int boxOpacity = 100;
            uint boxColor = shape.GetUintColor(Color.Black);
            uint textColor = shape.GetUintColor(Color.FromArgb(230, 230, 230));

            SetDrawBlendMode(DX_BLENDMODE_ALPHA, boxOpacity);
            for (int i = 0; i < itemName.Length; i++)
            {
                shape.RoundDraw(boxPoint.X, boxPoint.Y + (i * boxInterval), boxSize.Width, boxSize.Height, 10, boxColor);
            }
            SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);

            if (itemName != null && itemValue != null)
            {
                for (int i = 0; i < itemName.Length; i++)
                {
                    int titleWidth = GetDrawStringWidthToHandle(itemName[i], itemName[i].Length, fontHandle);
                    int valueWidth = GetDrawStringWidthToHandle(itemValue[i].ToString(), (itemValue[i].ToString()).Length, fontHandle);

                    DrawStringToHandle(
                        boxPoint.X + (boxSize.Width - titleWidth) / 2,
                        boxPoint.Y + (i * boxInterval + 5),
                        itemName[i],
                        textColor, fontHandle);

                    DrawStringToHandle(
                        boxPoint.X + (boxSize.Width - valueWidth) / 2,
                        boxPoint.Y + (i * boxInterval + 55),
                        itemValue[i].ToString(),
                        textColor, fontHandle);
                }
            }
        }

        public void Dispose()
        {
            shape = null;
            itemName = null;
            itemValue = null;
        }
    }
}
