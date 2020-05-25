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
        protected internal override void Download() => this.DownloadOpenGraph();
        internal override string GetFilename()
        {
            string[] file = this.Url.Substring(Url.LastIndexOf('/') + 1).Split('-');
            string filename = String.Join("-", file.Take(file.Length - 1));
            return string.IsNullOrWhiteSpace(filename) ? "NoNameGif" : filename;
        }
    }
}
