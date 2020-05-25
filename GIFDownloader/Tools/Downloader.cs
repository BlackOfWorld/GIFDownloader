using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GIFDownloader.Tools
{
    public static class Downloader
    {
        private class Range
        {
            public long Start { get; set; }
            public long End { get; set; }
        }
        private static readonly string tempPath = $"{Path.GetTempPath()}BlackOfWorld's GIF Downloader\\";
        static Downloader()
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.MaxServicePointIdleTime = 1000;
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            AppDomain.CurrentDomain.ProcessExit += delegate { if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true); };

        }
        public static void Download(string filename, String fileUrl, int numberOfParallelDownloads = 0)
        {
            //Handle number of parallel downloads  
            if (numberOfParallelDownloads <= 0) numberOfParallelDownloads = Environment.ProcessorCount;

            #region Get file size  
            WebRequest webRequest = WebRequest.Create(fileUrl);
            webRequest.Method = "HEAD";
            using WebResponse webResponse = webRequest.GetResponse();
            var responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));

            #endregion

            using FileStream destinationStream = new FileStream(filename, FileMode.Append);

            #region Calculate ranges  
            List<Range> readRanges = new List<Range>();
            for (int chunk = 0; chunk < numberOfParallelDownloads - 1; chunk++)
            {
                var range = new Range()
                {
                    Start = chunk * (responseLength / numberOfParallelDownloads),
                    End = ((chunk + 1) * (responseLength / numberOfParallelDownloads)) - 1
                };
                readRanges.Add(range);
            }


            readRanges.Add(new Range()
            {
                Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                End = responseLength - 1
            });

            #endregion


            #region Parallel download  

            int index = 0;
            string _filename = filename;
            ConcurrentDictionary<int, string> tempFilesDictionary = new ConcurrentDictionary<int, string>();
            Parallel.ForEach(readRanges, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads }, readRange =>
            {
                int _index = index++;
                HttpWebRequest httpWebRequest = WebRequest.Create(fileUrl) as HttpWebRequest;
                Debug.Assert(httpWebRequest != null, nameof(httpWebRequest) + " != null");
                httpWebRequest.Method = "GET";
                httpWebRequest.AddRange(readRange.Start, readRange.End);
                using HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

                string tempFilePath = $"{tempPath}{Path.GetFileNameWithoutExtension(_filename)}_{_index}.tmp";

                using var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write);
                Debug.Assert(httpWebResponse != null, nameof(httpWebResponse) + " != null");
                httpWebResponse.GetResponseStream()?.CopyTo(fileStream);
                tempFilesDictionary.TryAdd((int)_index, tempFilePath);
            });

            #endregion

            #region Merge to single file  
            foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
            {
                byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                File.Delete(tempFile.Value);
            }
            #endregion
        }
    }
}
