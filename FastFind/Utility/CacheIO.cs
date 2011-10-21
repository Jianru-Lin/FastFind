using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FastFind
{
    class CacheIO
    {
        // 加载缓存
        public static bool Load(List<FileEntry> fileEntries, string filename)
        {
            if (string.IsNullOrEmpty(filename) || fileEntries == null)
            {
                return false;
            }

            if (!File.Exists(filename))
            {
                return false;
            }

            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                while (true)
                {
                    FileEntry fileEntry = new FileEntry();
                    fileEntry.Filename = reader.ReadLine();
                    fileEntry.FilePath = reader.ReadLine();
                    if (fileEntry.FilePath == null)
                    {
                        break;
                    }
                    fileEntries.Add(fileEntry);
                }
            }

            return true;
        }

        public static void Save(List<FileEntry> fileEntries, string filename)
        {
            if (fileEntries != null && fileEntries.Count > 0 && !string.IsNullOrEmpty(filename))
            {
                try
                {
                    // 如果文件已经存在了，先尝试将其删除
                    if (File.Exists(filename))
                    {
                        try
                        {
                            File.Delete(filename);
                        }
                        catch (System.Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine(ex.Message);
                            return;
                        }
                    }

                    // 创建文件，准备写入数据
                    using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8, 10 * 1024 * 1024))
                    {
                        foreach (FileEntry fileEntry in fileEntries)
                        {
                            writer.WriteLine(fileEntry.Filename);
                            writer.WriteLine(fileEntry.FilePath);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
