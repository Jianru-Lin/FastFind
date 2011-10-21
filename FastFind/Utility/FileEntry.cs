
namespace FastFind
{
    class FileEntry
    {
        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
                FilenameLC = string.IsNullOrEmpty(filename) ? filename : filename.ToLower();
            }
        }

        public string FilenameLC
        {
            get;
            private set;
        }

        public string FilePath
        {
            get;
            set;
        }

        string filename;
    }
}
