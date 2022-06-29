using System;
using System.Linq;

namespace Uno
{
    internal class Game_CenterCard : IScene, IDisposable
    {
        public int[] Rotates;
        Card card;

        public void Start()
        {
            card = new Card();
            Rotates = new int[110];
            Random r = new Random();
            for (int i = 0; i < 110; i++)
                Rotates[i] = r.Next(-5, 5);
            r = null;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            for (int i = 0; i < Game.gameInfo.Center_Num.Count(); i++)
            {
                card.DrawCard(
                    Program.windowSize.Width / 2,
                    Program.windowSize.Height / 2,
                    Game.gameInfo.Center_Num[i],
                    Game.gameInfo.Center_Color[i],
                    0.7f,
                    Rotates[i], Texture.drawpoints.Center);
            }
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
