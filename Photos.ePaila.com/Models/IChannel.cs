using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photos.ePaila.com.Models
{
    public interface IChannel
    {
        string  Name { get; set; }
        string URL { get; set; }
        string FeedURL { get; set; }

        List<Photo> Read();
    }
}