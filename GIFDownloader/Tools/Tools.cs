using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GIFDownloader
{
    public static class Tools
    {
        public static string FindFilename(string filename)
        {
            string fileName = $"{filename}.gif";
            int fileCount = 1;
            while (true)
            {
                if (!File.Exists(fileName)) return fileName;
                fileName = $"{filename}{++fileCount}.gif";
            }
        }
    }
}
