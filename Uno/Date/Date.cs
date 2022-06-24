using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Date
    {
        /// <summary>
        /// 自分の名前
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// 自分のレベル
        /// </summary>
        public long Lv { get; set; }

        /// <summary>
        /// 自分が勝った回数
        /// </summary>
        public int WinCount { get; set; }

        /// <summary>
        /// 自分が負けた回数
        /// </summary>
        public int DefeatCount { get; set; }
    }
}
