﻿using System;
using System.Collections.Generic;
using FlickrNet;

namespace Photos.ePaila.com.Models.Channel
{
    //https://www.flickr.com/services/api/
    //http://flickrnet.codeplex.com/
    //http://www.nuget.org/packages/FlickrNet


    public class Flickr : IChannel
    {
        private readonly string _apiToken;
        private readonly int _perPage;
        private readonly string _secretKey;
        private readonly string _userid;

        public Flickr()
        {
            //FeedURL = "https://api.flickr.com/services/feeds/photos_faves.gne?id=138274132@N07";
            _apiToken = "6937bab0b406a6acec47209808dba534";
            _secretKey = "cae4ee1bc43b1d9b";
            _userid = "138274132@N07";
            _perPage = 90;
        }

        public string Name { get; set; }

        public string URL { get; set; }

        public string FeedURL { get; set; }

        public List<Photo> Read(int page = 1)
        {
            var photos = new List<Photo>();
            var flickr = new FlickrNet.Flickr(_apiToken, _secretKey);
            
            PhotoCollection col = flickr.FavoritesGetPublicList(_userid, DateTime.Now.AddYears(-10), DateTime.Now,
                                                                PhotoSearchExtras.All, page, _perPage);

            foreach (FlickrNet.Photo item in col)
            {
                var author = new Author
                    {
                        Name = item.OwnerName,
                        ID = item.UserId,
                        URL = string.Format("https://www.flickr.com/photos/{0}/", item.UserId)
                    };
                photos.Add(new Photo
                    {
                        Title = item.Title,
                        URL = item.WebUrl,
                        Path = item.DoesLargeExist ? item.LargeUrl : item.MediumUrl,
                        PublishedDate = item.DateTaken,
                        Author = author
                    });
            }
            return photos;
        }

        //public List<Photo> Read()
        //{
        //    List<Photo> photos = new List<Photo>();
        //    XmlDocument rssXmlDoc = new XmlDocument();
        //    try
        //    {
        //        try
        //        {
        //            rssXmlDoc.Load(this.FeedURL);
        //        }
        //        catch (Exception ex1)
        //        {

        //        }
        //        // Parse the Items in the RSS file
        //        XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
        //        nsmgr.AddNamespace("flickr", "http://www.w3.org/2005/Atom");
        //        XmlNodeList rssNodes = rssXmlDoc.SelectNodes("//flickr:entry", nsmgr);

        //        // Iterate through the items in the RSS file
        //        foreach (XmlNode rssNode in rssNodes)
        //        {
        //            string title = rssNode["title"].InnerText;

        //            var lnk1 = rssNode.ChildNodes[1];
        //            string url = lnk1.Attributes["href"].Value;

        //            var lnk2 = rssNode.ChildNodes[9];
        //            var rel = lnk2.Attributes["rel"].Value;
        //            string path = "";
        //            if (string.Compare(rel, "enclosure", true) != 0)
        //                lnk2 = rssNode.ChildNodes[10];

        //            path = lnk2.Attributes["href"].Value;
        //            DateTime pubDate = DateTime.Parse(rssNode["published"].InnerText);

        //            var temp = rssNode["author"];
        //            string aname = temp["name"].InnerText;
        //            string aurl = temp["uri"].InnerText;
        //            string aid = temp["flickr:nsid"].InnerText;

        //            Author author = new Author()
        //                {
        //                    Name = aname,
        //                    URL = aurl,
        //                    ID = aid
        //                };
        //            photos.Add(new Photo() { Title = title, URL = url, Path = path, PublishedDate = pubDate, Author = author });
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return photos;
        //}
    }
}