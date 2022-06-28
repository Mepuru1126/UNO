using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Uno
{

    internal class Game_Select : IScene
    {
        public int BarIndex;

        public void Start()
        {
            BarIndex = 0;
        }

        public void Update()
        {
            if (Program.input.IsPushed(KEY_INPUT_RIGHT) && BarIndex < Game.gameInfo.P1_Num.Count() - 1)
            {
                Right();
                Jump();
            }

            if (Program.input.IsPushed(KEY_INPUT_LEFT) && BarIndex > 0)
            {
                Left();
                Jump();
            }

            if (Program.input.IsPushed(KEY_INPUT_RETURN))
            {
                Decision();
            }
        }

        public void Draw()
        {

        }

        public void AnimeUpdate()
        {
            for (int i = 0; i < Game.gameInfo.CardJump.Count(); i++)
            {
                // 100以上になってるカードはjumpアニメをしない
                if (Game.gameInfo.CardJump[i] >= 100)
                    Game.gameInfo.isJump[i] = false;

                if (Game.gameInfo.isJump[i])
                {
                    // もし30まで来たらいったん止める
                    if (Game.gameInfo.CardJump[i] >= 30)
                    {
                        Game.gameInfo.isJump[i] = false;
                    }
                    else
                    {
                        Game.gameInfo.CardJump[i] += (int)(250 * Program.deltaTime);
                    }
                }
                else
                {
                    // 選択されいてるカード以外のカードに降下アニメさせる
                    if (BarIndex != i)
                    {
                        if (Game.gameInfo.CardJump[i] > 0)
                            Game.gameInfo.CardJump[i] -= (250 * Program.deltaTime);
                    }
                }
            }
        }

        public void Right()
        {
            BarIndex++;
        }

        public void Left()
        {
            BarIndex--;
        }

        private void Decision()
        {
            Game.cardOut.CardOut(0, BarIndex);
            Game.gameInfo.AllOutCount++;
            BarIndex--;
        }

        public void Jump()
        {
            Game.gameInfo.isJump[BarIndex] = true;
        }
    }
}
