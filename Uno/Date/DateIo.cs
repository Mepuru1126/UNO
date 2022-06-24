using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class DateIo
    {
        Date date = new Date();
        const string Path = "UnoDate\\Date\\Save.ini";

        /// <summary>
        /// データの読み込みを行う
        /// </summary>
        public void Load()
        {
            var ini = new Ini();

            date.PlayerName = ini.GetString("Save", "Name", Path);
            date.Lv = ini.GetInt("Save", "Lv", Path);
            date.WinCount = ini.GetInt("Save", "Win", Path);
            date.DefeatCount = ini.GetInt("Save", "Defeat", Path);
        }

        /// <summary>
        /// データの保存を行う
        /// </summary>
        public void Save()
        {
            var ini = new Ini();

            ini.Save("Save", "Name", date.PlayerName, Path);
            ini.Save("Save", "Lv", date.Lv, Path);
            ini.Save("Save", "Win", date.WinCount, Path);
            ini.Save("Save", "Defeat", date.DefeatCount, Path);
        }
    }
}
