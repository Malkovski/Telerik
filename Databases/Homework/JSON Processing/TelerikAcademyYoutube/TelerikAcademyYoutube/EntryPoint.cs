namespace TelerikAcademyYoutube
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using HtmlTags;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class EntryPoint
    {
        private static readonly string DestinationFile = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\qa.xml");
        private static readonly WebClient MyWebClient = new WebClient();
        private static readonly XmlDocument Doc = new XmlDocument();
        private static readonly List<VideoItem> VideoItems = new List<VideoItem>();
        private static readonly StringBuilder Html = new StringBuilder();

        private const string SourceFile = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        private static void Main()
        {
            MyWebClient.DownloadFile(SourceFile, DestinationFile);
            Doc.Load(DestinationFile);

            string jsonFromXml = JsonConvert.SerializeXmlNode(Doc);
            
            JObject jsonObj = JObject.Parse(jsonFromXml);

            JToken items = jsonObj["feed"]["entry"];

            CreatePoco(items);

            GenerateHtml();
        }

        private static void CreatePoco(JToken items)
        {
            foreach (JToken item in items)
            {
                Console.WriteLine(item["title"]);

                var videoItem = new VideoItem
                {
                    Title = item["title"].ToString(),
                    Link = item["yt:videoId"].ToString()
                };

                VideoItems.Add(videoItem);
            }
        }

        private static void GenerateHtml()
        {
            foreach (VideoItem item in VideoItems)
            {
                var span = new HtmlTag("a");
                span.Text(string.Format("{0}", item.Title));

                span.Style("display", "block");
                span.Attr(string.Format("href = http://www.youtube.com/watch?v={0}", item.Link));

                var newLine = new HtmlTag("br");

                var iframe = new HtmlTag("iframe");
                iframe.Attr(string.Format("src = http://www.youtube.com/embed/{0}", item.Link));

                Html.Append(iframe);
                Html.Append(span);
                Html.Append(newLine);
            }
			
            using (var sw = new StreamWriter(File.Open("items.html", FileMode.Create), Encoding.Unicode))
            {
                sw.WriteLine(Html.ToString());
            }
        }
    }
}