using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    $"Error!\n{ex.Message}",
                    "Uno-ErrorWindow",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void Init()
        {
            SetOutApplicationLogValidFlag(FALSE);
            SetGraphMode(windowSize.Width, windowSize.Height, 32);
            SetWindowSize(1280, 720);
            ChangeWindowMode(TRUE);
            SetBackgroundColor(BackColor.R, BackColor.G, BackColor.B);
            if (DxLib_Init() == -1)
            {
                throw new Exception("DxLibの初期化に失敗しました。");
            }
        }

        private static void Run()
        {
            do
            {
                // 閉じるボタンが押された
                if (ProcessMessage() == -1)
                {
                    break;
                }

                SetDrawScreen(DX_SCREEN_BACK);
                ClearDrawScreen();

                input.Update();

                ScreenFlip();
            }
            while (true);
        }

        private static void Finish()
        {
            // ガベージコレクションをしとく
            GC.Collect();
            InitGraph();
            DxLib_End();
        }

        public static readonly Size windowSize = new Size(1920, 1080);
        public static readonly Color BackColor = Color.FromArgb(100, 100, 200);

        public static Input input = new Input();
    }
}
