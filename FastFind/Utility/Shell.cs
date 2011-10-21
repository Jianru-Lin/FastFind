using System.Diagnostics;

namespace FastFind
{
    public class Shell
    {
        public static void Open(string filename)
        {
            Process.Start(filename);
        }
    }
}
