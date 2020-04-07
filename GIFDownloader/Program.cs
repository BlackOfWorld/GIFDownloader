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

namespace GIFDownloader
{
    class Program
    {
        private static object lockObject = new object();
        private static int threadCount = 0;

        static Task handleUrl(object u)
        {
            lock (lockObject) threadCount++;
            Handler handler = null;
            string url = (string)u;
            if (url.Contains("//tenor.com/view/")) handler = new TenorHandler(url);
            if (url.Contains("//giphy.com/gifs/")) handler = new GiphyHandler(url);
            string filename = Tools.FindFilename(handler.GetFilename());
            using FileStream fs = File.Create(filename);
            handler.DownloadToStream(fs);
            lock (lockObject) threadCount--;
            return Task.CompletedTask;
        }

        static void Main(string[] args)
        {
            Console.Title = "Gay ass GIF downloader";
            Console.WriteLine("§cReading url.txt!");
            if (!File.Exists("url.txt")) { Console.WriteLine("§4url.txt does not exist! Exiting..."); return; }
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
