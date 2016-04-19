using System;

namespace Photos.ePaila.com.Models
{
    public class Photo
    {
        public Photo()
        {
            Author = new Author();
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public string Path { get; set; }
        public DateTime PublishedDate { get; set; }

        public Author Author { get; set; }
    }
}