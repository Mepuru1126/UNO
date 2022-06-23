using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Uno
{
    internal class Ini
    {
        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            uint nSize,
            string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileInt(
            string lpAppName,
            string lpKeyName,
            int nDefault,
            string lpFileName);

        [DllImport("KERNEL32.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpString,
           string lpFileName);

        /// <summary>
        /// iniファイルからString型の値を取得する
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetString(string section, string key, string path)
        {
            StringBuilder str = new StringBuilder();

            GetPrivateProfileString(section, key, "NotFound", str, 1000, path);

            return str.ToString();
        }

        /// <summary>
        /// iniファイルからInt型の値を取得する
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public int GetInt(string section, string key, string path)
        {
            int result;

            result = (int)GetPrivateProfileInt(section, key, -1, path);

            return result;
        }

        /// <summary>
        /// 値をiniファイルに保存する
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="path"></param>
        public void Save(string section, string key, object value, string path)
        {
            WritePrivateProfileString(section, key, value.ToString(), path);
        }
    }
}
