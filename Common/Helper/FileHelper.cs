using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;

namespace CSFramework.Common.Helper
{
    public static class FileHelper
    {

        /// <summary>
        /// Zip文件压缩
        /// ZipOutputStream：相当于一个压缩包；
        /// ZipEntry：相当于压缩包里的一个文件；
        /// 以上两个类是SharpZipLib的主类。
        /// </summary>
        /// <param name="sourceFileLists"></param>
        /// <param name="descFile">压缩文件保存的目录</param>
        /// <param name="compression">压缩级别</param>
        public static void ZipCompress(List<string> sourceFileLists, string descFile, int compression)
        {
            if (compression < 0 || compression > 9)
            {
                throw new ArgumentException("错误的压缩级别");
            }

            var directoryInfo = new FileInfo(descFile).Directory;
            if (directoryInfo != null && !Directory.Exists(directoryInfo.ToString()))
            {
                throw new ArgumentException("保存目录不存在");
            }
            foreach (string c in sourceFileLists)
            {
                if (!File.Exists(c))
                {
                    throw new ArgumentException($"文件{c} 不存在！");
                }
            }
            Crc32 crc32 = new Crc32();
            using (ZipOutputStream stream = new ZipOutputStream(File.Create(descFile)))
            {
                stream.SetLevel(compression);
                foreach (var t in sourceFileLists)
                {
                    var entry = new ZipEntry(Path.GetFileName(t)) {DateTime = DateTime.Now};
                    using (FileStream fs = File.OpenRead(t))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        entry.Size = fs.Length;
                        crc32.Reset();
                        crc32.Update(buffer);
                        entry.Crc = crc32.Value;
                        stream.PutNextEntry(entry);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    stream.CloseEntry();
                }
            }
        }

        /// <summary>
        /// unZip文件解压缩
        /// </summary>
        /// <param name="sourceFile">要解压的文件</param>
        /// <param name="path">要解压到的目录</param>
        /// <param name="password">解压密码</param>
        public static void ZipDeCompress(string sourceFile, string path, string password)
        {
            if (!File.Exists(sourceFile))
            {
                throw new ArgumentException("要解压的文件不存在。");
            }
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("要解压到的目录不存在！");
            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
            {
                s.Password = password;
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string tempPath = path + @"\" + theEntry.Name;
                    if (theEntry.IsDirectory)
                    {
                        if (!Directory.Exists(tempPath))
                        {
                            Directory.CreateDirectory(tempPath);
                        }
                    }
                    else
                    {
                        string fileName = Path.GetFileName(theEntry.Name);
                        if (fileName != string.Empty)
                        {
                            using (FileStream streamWriter = File.Create(tempPath))
                            {
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    var size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 复制文件夹内容到另一个文件夹
        /// </summary>
        /// <param name="srcPath">原文件夹</param>
        /// <param name="destPath">目标文件夹</param>
        public static void CopyDirectory(string srcPath, string destPath)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileInfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
            foreach (FileSystemInfo i in fileInfo)
            {
                if (i is DirectoryInfo)     //判断是否文件夹
                {
                    if (!Directory.Exists(destPath + "\\" + i.Name))
                    {
                        Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                    }
                    CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                }
                else
                {
                    File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                }
            }
        }
    }
}

