using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    /// <summary>
    /// カードを引く・描画することに関するクラス
    /// </summary>
    internal class Game_DrawCard : IScene, IDisposable
    {
        Card card;

        public void Start()
        {
            card = new Card();

            // 初期ドローをする
            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < Game.gameInfo.PlayerNum; j++)
                    GetCard(j);
            }
        }

        public void Update()
        {

        }

        public void Draw()
        {
            for (int i = 0; i < Game.gameInfo.PlayerNum; i++)
            {
                for (int j = 0; j < Game.gameInfo.PlayerCordCount[i]; j++)
                {
                    int width = (j * 70);

                    switch (i)
                    {
                        case 0:
                            card.DrawCard(width, 900 - (int)Game.gameInfo.CardJump[j], Game.gameInfo.P1_Num[j], Game.gameInfo.P1_Color[j], 0.4f, 0);
                            break;

                        case 1:
                            card.DrawCard(width, 0, Game.gameInfo.P2_Num[j], Game.gameInfo.P2_Color[j], 0.4f, 0);
                            break;
                    }
                }
            }
        }

        public void GetCard(int playerIndex)
        {
            var info = Game.gameInfo;

            switch (playerIndex)
            {
                case 0:
                    info.P1_Num.Add(info.Deck_Num[info.AllDrawCount]);
                    info.P1_Color.Add(info.Deck_Color[info.AllDrawCount]);
                    break;

                case 1:
                    info.P2_Num.Add(info.Deck_Num[info.AllDrawCount]);
                    info.P2_Color.Add(info.Deck_Color[info.AllDrawCount]);
                    break;
            }

            Game.gameInfo.CardJump.Add(0);
            Game.gameInfo.isJump.Add(false);
            info.AllDrawCount++;
            info.PlayerCordCount[playerIndex]++;
        }

        /// <summary>
        /// 解放
        /// </summary>
        public void Dispose()
        {
            card = null;
        }
    }
}
