using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Game : IScene, IDisposable
    {
        public static Game_PlayerInfo gameInfo = new Game_PlayerInfo();
        public static Game_Select select = new Game_Select();
        public static Game_CardOut cardOut = new Game_CardOut();
        private Game_DrawCard draw = new Game_DrawCard();
        private Game_CenterCard centerCard = new Game_CenterCard();
        private FadeIn fadeIn;
        private FadeOut fadeOut;
        public static bool isFadeOut;

        public void Start()
        {
            isFadeOut = false;

            gameInfo.Init();
            draw.Start();
            select.Start();
            centerCard.Start();

            fadeIn = new FadeIn();
            fadeOut = new FadeOut();
        }

        public void Update()
        {
            fadeIn?.Start(50);

            select.Update();
            select.AnimeUpdate();

            if (fadeIn != null && fadeIn.IsFinish())
                fadeIn = null;

            if(Program.input.IsPushed(DxLibDLL.DX.KEY_INPUT_A))
                isFadeOut = true;

            if (isFadeOut)
            {
                fadeOut?.Start(100);

                if (fadeOut != null && fadeOut.IsFinish())
                {
                    fadeOut = null;
                    Dispose();
                    Program.Scene.ChangeScene("Select");
                }
            }
        }

        public void Draw()
        {
            Program.tx.Game_Background.Draw(0, 0);
            draw.Draw();
            centerCard.Draw();

            fadeIn?.Draw();
            fadeOut?.Draw();
        }

        /// <summary>
        /// 解放
        /// </summary>
        public void Dispose()
        {
            draw.Dispose();
            centerCard.Dispose();
            gameInfo.Dispose();
        }
    }
}
