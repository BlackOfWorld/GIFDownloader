using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GIFDownloader.Handlers;
using GIFDownloader.Tools;

namespace GIFDownloader
{
    class Program
    {
        private static readonly object lockObject = new object();
        private static int threadCount;

        private static Task handleUrl(object u)
        {
            lock (lockObject) threadCount++;
            Handler handler = null;
            string url = (string)u;
            if (url.Contains("//tenor.com/view/")) handler = new TenorHandler(url);
            if (url.Contains("//giphy.com/gifs/")) handler = new GiphyHandler(url);
            Debug.Assert(handler != null, nameof(handler) + " != null");
            handler.Download();
            lock (lockObject) threadCount--;
            return Task.CompletedTask;
        }

        static void Main(string[] args)
        {
            Console.Title = "Gay ass GIF downloader";
            Console.WriteLine("§cReading url.txt!");
            if (!File.Exists("url.txt")) { Console.WriteLine("§4url.txt does not exist! §aCreating and exiting..."); File.WriteAllText("url.txt", ""); return; }
            if (new FileInfo("url.txt").Length == 0) { Console.WriteLine("§4url.txt is empty! Exiting..."); return; }
            var URLs = File.ReadAllLines("url.txt").Distinct().ToArray();
            Console.WriteLine("§2url.txt read!");
            if (!Directory.Exists("GIFs"))
            {
                Console.WriteLine("§cCreating GIFs folder!");
                Directory.CreateDirectory("GIFs");
                Console.WriteLine("§2Folder created!");
            }
            Directory.SetCurrentDirectory("GIFs");
            Console.WriteLine($"§3Downloading §b{URLs.Length} §3GIFs!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, URLs.Length, (f, fuck) => handleUrl(URLs[f]));
            Thread.Sleep(300);
            while(threadCount != 0) Console.ReadKey(true);
            stopwatch.Stop();
            Console.WriteLine($"§b{URLs.Length} §5GIFs downloaded in §d{stopwatch.ElapsedMilliseconds}ms!");
            Console.ReadKey();
        }
    }
}
