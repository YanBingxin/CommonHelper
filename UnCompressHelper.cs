using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FilesCompare.CompareHelper
{
    /// <summary>
    /// ID:解压缩jar，zip
    /// Describe:解压缩jar包，zip文件
    /// Author:ybx
    /// Date:2016-6-29 11:48:41
    /// </summary>
    public class UnCompressHelper
    {
        /// <summary>
        /// 解压缩 zip 文件
        /// </summary>
        /// <param name="zipFileName">要解压的 zip 文件</param>
        /// <param name="extractLocation">zip 文件的解压目录</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public static void UnZipDir(string zipFileName, string location, bool overWrite)
        {
            if (!location.EndsWith(@"/"))
                location = location + @"/";

            ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));
            ZipEntry theEntry;

            while ((theEntry = s.GetNextEntry()) != null)//判断下一个zip 接口是否未空
            {
                string directoryName = string.Empty;//下级目录名
                string fileName = Path.GetFileName(theEntry.Name);//压缩文件名

                if (!string.IsNullOrEmpty(theEntry.Name))
                    directoryName = Path.GetDirectoryName(theEntry.Name) + @"/";

                //创建目录
                Directory.CreateDirectory(location + directoryName);
                //创建文件
                if (!string.IsNullOrEmpty(fileName))
                {
                    if ((File.Exists(location + directoryName + fileName) && overWrite) || (!File.Exists(location + directoryName + fileName)))
                    {
                        FileStream streamWriter = File.Create(location + directoryName + fileName);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                                streamWriter.Write(data, 0, size);
                            else
                                break;
                        }
                        streamWriter.Close();
                    }
                }
            }
            s.Close();
        }
    }
}

