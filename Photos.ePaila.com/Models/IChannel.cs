using System.Collections.Generic;

namespace Photos.ePaila.com.Models
{
    public interface IChannel
    {
        string Name { get; set; }
        string URL { get; set; }
        string FeedURL { get; set; }

        List<Photo> Read(int page = 1);
    }
}