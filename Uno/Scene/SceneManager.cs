using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class SceneManager
    {
        List<IScene> SceneList = new List<IScene>();
        Dictionary<string, int> SceneIndex = new Dictionary<string, int>();
        int sceneIndex = 0;
        int sceneCount = 0;
        bool isStart = true;
        
        /// <summary>
        /// シーンを追加する
        /// </summary>
        /// <param name="scene">追加するシーンのインスタンス</param>
        /// <param name="sceneName">追加するシーンの名前</param>
        public void AddAScene(IScene scene, string sceneName)
        {
            SceneList.Add(scene);
            SceneIndex.Add(sceneName, sceneCount);
            sceneCount++;
        }

        /// <summary>
        /// シーンを変更する
        /// </summary>
        /// <param name="sceneName">変更先シーンの名前</param>
        public void ChangeScene(string sceneName)
        {
            sceneIndex = SceneIndex[sceneName];
            isStart = true;
            GC.Collect();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Start()
        {
            if (!isStart)
                return;

            SceneList[sceneIndex].Start();

            isStart = false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            SceneList[sceneIndex].Update();
        }

        /// <summary>
        /// 描画
        /// </summary>
        public void Draw()
        {
            SceneList[sceneIndex].Draw();
        }
    }
}
