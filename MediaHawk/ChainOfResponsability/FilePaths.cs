using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHawk
{
    public static class FilePaths
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string UploadFolder = Path.Combine(BaseDirectory, "UploadedFiles");
        public static readonly string CleanedFolder = Path.Combine(BaseDirectory, "CleanedFiles");
        public static readonly string TokenizedFolder = Path.Combine(BaseDirectory, "TokenizedFiles");
        public static readonly string AnalyzerFolder = Path.Combine(BaseDirectory, "AnalyzerFolder");


        static FilePaths()
        {
            Directory.CreateDirectory(UploadFolder);
            Directory.CreateDirectory(CleanedFolder);
            Directory.CreateDirectory(TokenizedFolder);
            Directory.CreateDirectory(AnalyzerFolder);

        }
    }
}
