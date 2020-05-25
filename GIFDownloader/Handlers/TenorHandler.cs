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
        protected internal override void Download() => this.DownloadOpenGraph();
        internal override string GetFilename()
        {
            string filename = this.Url.Split('/').Last();
            return $"{filename.Substring(0, filename.LastIndexOf("-gif-", StringComparison.Ordinal))}";
        }
    }
}
