using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno
{
    internal class Game_PlayerInfo : IDisposable
    {
        /// <summary>
        /// プレイヤーの人数
        /// </summary>
        public readonly int PlayerNum = 2;

        /// <summary>
        /// プレイヤー全員が引いたカードの枚数
        /// </summary>
        public int AllDrawCount;

        /// <summary>
        /// プレイヤー全員が出したカードの枚数
        /// </summary>
        public int AllOutCount;

        /// <summary>
        /// ターン
        /// </summary>
        public int Turn;

        /// <summary>
        /// プレイヤーが持ってるカードの枚数
        /// </summary>
        public int[] PlayerCordCount;

        public int[] Deck_Num;
        public int[] Deck_Color;

        public List<int> Center_Num;
        public List<int> Center_Color;

        public List<int> P1_Num;
        public List<int> P2_Num;

        public List<int> P1_Color;
        public List<int> P2_Color;

        public List<double> CardJump;
        public List<bool> isJump;

        public void Init()
        {
            AllDrawCount = 0;
            AllOutCount = 0;

            PlayerCordCount = new int[PlayerNum];
            Deck_Num = new int[110];
            Deck_Color = new int[110];

            Center_Num = new List<int>();
            Center_Color = new List<int>();

            P1_Num = new List<int>();
            P2_Num = new List<int>();
            P1_Color = new List<int>();
            P2_Color = new List<int>();

            CardJump = new List<double>();
            isJump = new List<bool>();

            int[] arrayNum = new int[110];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 10; j++)
                    arrayNum[i * 10 + j] = i + 1;
            }

            int[] arrayColor = new int[110];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (int)(110 / 4); j++)
                    arrayColor[i * (int)(110 / 4) + j] = i;
            }

            Random r = new Random();
            Deck_Num = arrayNum.OrderBy(i => r.Next()).ToArray();
            Deck_Color = arrayColor.OrderBy(i => r.Next()).ToArray();
            arrayNum = null;
            arrayColor = null;
            r = null;
        }

        /// <summary>
        /// 解放
        /// </summary>
        public void Dispose()
        {
            PlayerCordCount = null;
            Deck_Num = null;
            Deck_Color = null;
            Center_Num = null;
            Center_Color = null;
            P1_Num = null;
            P1_Color = null;
            P2_Num = null;
            P2_Color = null;
            CardJump = null;
            isJump = null;
        }
    }
}
