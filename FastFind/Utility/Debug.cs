using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FastFind
{
    public class DebugHelper
    {
        public static void LogDebugInfo(string debugInfo)
        {
            debugInfo = string.Format("{0}: {1}\r\n", DateTime.Now, debugInfo);
            File.AppendAllText("debug.txt", debugInfo, Encoding.UTF8);
        }
    }
}
