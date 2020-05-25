using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using GIFDownloader.Tools;

namespace GIFDownloader.Handlers
{
    class Handler
    {
        internal string Url;
        internal HtmlWeb WebGet = new HtmlWeb();
        internal HtmlDocument Document;
        public Handler(string url)
        {
            this.Url = url;
            this.Document = WebGet.Load(url);
        }
        internal virtual string GetFilename() { throw new NotImplementedException($"BlackOfWorld is retarded and forgot to implement handler for domain '{new Uri(Url).Host}'"); }
        protected internal virtual void Download() { throw new NotImplementedException($"BlackOfWorld is retarded and forgot to implement handler for domain '{new Uri(Url).Host}'"); }
        internal string GetOpenGraph()
        {
            var node = this.Document.DocumentNode;
            var head = node.SelectSingleNode("//head");
            foreach(var child in head.ChildNodes)
            {
                if (child.OriginalName != "meta") continue;
                if (!child.HasAttributes) continue;
                if (child.Attributes.AttributesWithName("property").All(f => f.Value != "og:url")) continue;
                return child.Attributes.AttributesWithName("content").First().Value;
            }
            return string.Empty;
        }
        public string FindFilename()
        {
            string filename = this.GetFilename();
            string fileName = $"{filename}.gif";
            int fileCount = 1;
            while (true)
            {
                if (!File.Exists(fileName)) return fileName;
                fileName = $"{filename}{++fileCount}.gif";
            }
        }
        internal void DownloadOpenGraph()
        {
            var contentUrl = this.GetOpenGraph();
            Downloader.Download(this.FindFilename(), contentUrl);
        }
    }
}
