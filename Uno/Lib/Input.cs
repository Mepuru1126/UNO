using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Input
    {
        byte[] buffer = new byte[256];
        byte[] value = new byte[256];

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (GetHitKeyStateAll(buffer) != -1)
            {
                for (int i = 0; i < 256; i++)
                {
                    if (buffer[i] == 1)
                    {
                        value[i]++;
                    }
                    else
                    {
                        value[i] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// キーを押下しているか
        /// </summary>
        /// <param name="keyCode">キーコード</param>
        /// <returns></returns>
        public bool IsPushing(int keyCode)
        {
            return value[keyCode] > 1;
        }

        /// <summary>
        /// キーを押下した直後か
        /// </summary>
        /// <param name="keyCode">キーコード</param>
        /// <returns></returns>
        public bool IsPushed(int keyCode)
        {
            return value[keyCode] == 1;
        }
    }
}
