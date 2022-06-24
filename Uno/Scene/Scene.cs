using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    interface IScene 
    {
        /// <summary>
        /// 初期化
        /// </summary>
        void Start();

        /// <summary>
        /// 更新
        /// </summary>
        void Update();

        /// <summary>
        /// 描画
        /// </summary>
        void Draw();
    }
}
