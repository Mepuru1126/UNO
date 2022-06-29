using System;
using System.Drawing;
using System.Windows.Forms;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Init();
                Run();
                Finish();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error!\n{ex}",
                    "Uno-ErrorWindow",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void Init()
        {
            dateIo.Load();

            Scene.AddAScene(title, "Title");
            Scene.AddAScene(select, "Select");
            Scene.AddAScene(game, "Game");

            SetOutApplicationLogValidFlag(FALSE);
            SetGraphMode(windowSize.Width, windowSize.Height, 32);
            SetWindowSize(1280, 720);
            ChangeWindowMode(TRUE);
            SetDoubleStartValidFlag(FALSE);
            SetBackgroundColor(BackColor.R, BackColor.G, BackColor.B);
            if (DxLib_Init() == -1)
                throw new Exception("DxLibの初期化に失敗しました。");

            tx.Load();
        }

        private static void Run()
        {
            double time = GetNowHiPerformanceCount();
            double nowTime = 0;

            while (true)
            {
                // 閉じるボタンが押された
                if (ProcessMessage() == -1)
                {
                    // 終了処理の前に今のデータを保存
                    dateIo.Save();
                    break;
                }

                SetDrawScreen(DX_SCREEN_BACK);
                ClearDrawScreen();

                input.Update();

                Scene.Start();
                Scene.Update();
                Scene.Draw();

                ScreenFlip();

                // デルタタイムの計算
                nowTime = GetNowHiPerformanceCount();
                deltaTime = (nowTime - time) / 1000000.0;
                time = nowTime;
            }

        }

        private static void Finish()
        {
            // ガベージコレクションをしとく
            GC.Collect();
            InitGraph();
            DxLib_End();
        }

        private static Title title = new Title();
        private static Select select = new Select();
        private static Game game = new Game();

        public static readonly Size windowSize = new Size(1920, 1080);
        public static readonly Color BackColor = Color.FromArgb(100, 100, 200);
        public static double deltaTime;

        public static Input input = new Input();
        public static SceneManager Scene = new SceneManager();
        public static TextureLoad tx = new TextureLoad();
        public static SoundLoad sl = new SoundLoad();
        public static DateIo dateIo = new DateIo();
    }
}
