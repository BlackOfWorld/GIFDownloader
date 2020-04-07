using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GIFDownloader.Handlers
{
    class Handler
    {
        internal string url = @"http://example.com";
        internal HtmlWeb webGet = new HtmlWeb();
        internal HtmlDocument document;
        public Handler(string url)
        {
            this.url = url;
            this.document = webGet.Load(url);
        }
        public virtual string GetFilename() { throw new NotImplementedException($"BlackOfWorld is retarded and forgot to implement handler for domain '{new Uri(url).Host}'"); }
        public virtual void DownloadToStream(FileStream stream) { throw new NotImplementedException($"BlackOfWorld is retarded and forgot to implement handler for domain '{new Uri(url).Host}'"); }
        internal string getOpenGraph()
        {
            var node = this.document.DocumentNode;
            var head = node.SelectSingleNode("//head");
            foreach(var child in head.ChildNodes)
            {
                if (child.OriginalName != "meta") continue;
                if (!child.HasAttributes) continue;
                if (!child.Attributes.AttributesWithName("property").Any(f => f.Value == "og:url")) continue;
                return child.Attributes.AttributesWithName("content").First().Value;
            }
            return String.Empty;
        }
        internal void downloadOpenGraph(FileStream stream)
        {
            var contentUrl = this.getOpenGraph();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(contentUrl);
            using (Stream webStream = httpWebRequest.GetResponse().GetResponseStream()) webStream.CopyTo(stream);
        }
    }
}
