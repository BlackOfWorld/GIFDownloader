using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GIFDownloader.Handlers
{
    internal class TenorHandler : Handler
    {
        public TenorHandler(string url) : base(url) { }
        public override void DownloadToStream(FileStream stream) => this.downloadOpenGraph(stream);
        public override string GetFilename()
        {
            string filename = this.url.Split('/').Last();
            return $"{filename.Substring(0, filename.LastIndexOf("-gif-"))}";
        }
    }
}
