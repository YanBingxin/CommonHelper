using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace FilesCompare.CompareHelper
{
    /// <summary>
    /// ID:MD5获取
    /// Describe:获取文件MD5
    /// Author:ybx-参考网上资料
    /// Date:2016-6-17 17:57:49
    /// </summary>
    public class MD5Helper
    {
        /// <summary>
        /// 获取文件MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetMD5(string path)
        {
            string strResult = string.Empty;
            string strHashData = string.Empty;
            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;
            MD5CryptoServiceProvider oMD5Hasher = new MD5CryptoServiceProvider();
            try
            {
                oFileStream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);//计算指定Stream 对象的哈希值
                oFileStream.Close();

                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                strHashData = System.BitConverter.ToString(arrbytHashValue);
                //替换-
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strResult;
        }

        public static bool CompareMD5()
        {
            return false;
        }
    }
}
