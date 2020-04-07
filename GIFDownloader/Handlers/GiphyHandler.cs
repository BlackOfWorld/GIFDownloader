using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GIFDownloader.Handlers
{
    internal class GiphyHandler : Handler
    {
        public GiphyHandler(string url) : base(url) { }
        public override void DownloadToStream(FileStream stream) => this.downloadOpenGraph(stream);
        public override string GetFilename()
        {
            string[] file = this.url.Substring(url.LastIndexOf('/') + 1).Split('-');
            string filename = String.Join("-", file.Take(file.Length - 1));
            return string.IsNullOrWhiteSpace(filename) ? "NoNameGif" : filename;
        }
    }
}
