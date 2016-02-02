using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photos.ePaila.com.Models
{
    public class Photo
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Path { get; set; }
        public DateTime PublishedDate { get; set; }

        public Author Author { get; set; }

        public Photo()
        {
            Author=new Author();
        }
    }
}