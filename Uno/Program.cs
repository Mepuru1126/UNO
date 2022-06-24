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
            dateIo.Load();

            Scene.AddAScene(title, "Title");
            Scene.AddAScene(select, "Select");

            SetOutApplicationLogValidFlag(FALSE);
            SetGraphMode(windowSize.Width, windowSize.Height, 32);
            SetWindowSize(1280, 720);
            ChangeWindowMode(TRUE);
            SetDoubleStartValidFlag(FALSE);
            SetBackgroundColor(BackColor.R, BackColor.G, BackColor.B);
            if (DxLib_Init() == -1)
            {
                throw new Exception("DxLibの初期化に失敗しました。");
            }
        }

        private static void Run()
        {
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
            }
            
        }

        private static void Finish()
        {
            // ガベージコレクションをしとく
            GC.Collect();
            InitGraph();
            DxLib_End();
        }

        private static DateIo dateIo = new DateIo();

        private static Title title = new Title();
        private static Select select = new Select();

        public static readonly Size windowSize = new Size(1920, 1080);
        public static readonly Color BackColor = Color.FromArgb(100, 100, 200);

        public static Input input = new Input();
        public static SceneManager Scene = new SceneManager();
        public static Date date = new Date();
    }
}
