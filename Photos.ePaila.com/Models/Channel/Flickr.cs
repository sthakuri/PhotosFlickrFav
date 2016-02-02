using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Photos.ePaila.com.Models.Channel
{
    public class Flickr : IChannel
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public string FeedURL { get; set; }

        public Flickr()
        {
            FeedURL = "https://api.flickr.com/services/feeds/photos_faves.gne?id=138274132@N07";
        }

        public List<Photo> Read()
        {
            List<Photo> photos = new List<Photo>();
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    rssXmlDoc.Load(this.FeedURL);
                }
                catch (Exception ex1)
                {

                }
                // Parse the Items in the RSS file
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                nsmgr.AddNamespace("flickr", "http://www.w3.org/2005/Atom");
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("//flickr:entry", nsmgr);

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    string title = rssNode["title"].InnerText;

                    var lnk1 = rssNode.ChildNodes[1];
                    string url = lnk1.Attributes["href"].Value;

                    var lnk2 = rssNode.ChildNodes[9];
                    string path = lnk2.Attributes["href"].Value;

                    DateTime pubDate = DateTime.Parse(rssNode["published"].InnerText);

                    var temp = rssNode["author"];
                    string aname = temp["name"].InnerText;
                    string aurl = temp["uri"].InnerText;
                    string aid = temp["flickr:nsid"].InnerText;

                    Author author = new Author()
                        {
                            Name = aname,
                            URL = aurl,
                            ID = aid
                        };
                    photos.Add(new Photo() { Title = title, URL = url, Path = path, PublishedDate = pubDate, Author = author });
                }

            }
            catch (Exception ex)
            {

            }
            return photos;
        }
    }
}