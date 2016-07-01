﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FilesCompare.Common
{
    public class IniReader
    {
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, byte[] val, string filePath);

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Write(string section, string key, string value, string path)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            WritePrivateProfileString(section, key, bytes, path);
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static string Read(string section, string key, string value, string path)
        {
            Encoding enc = Encoding.Default;
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(section, key, "", temp, 1024, path);
            byte[] buff = Encoding.Default.GetBytes(temp.ToString());
            return enc.GetString(buff);
        }
    }
}
