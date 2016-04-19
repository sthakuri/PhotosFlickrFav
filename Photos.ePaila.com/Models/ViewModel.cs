using System.Collections.Generic;
using System.Linq;
using Photos.ePaila.com.Models.Channel;

namespace Photos.ePaila.com.Models
{
    public class ViewModel
    {
        private readonly List<IChannel> Channels;

        public ViewModel()
        {
            Photos = new List<Photo>();
            Channels = new List<IChannel>();
            AddChannel(new Flickr());
        }

        public List<Photo> Photos { get; set; }

        public void AddChannel(IChannel channel)
        {
            Channels.Add(channel);
            Photos.AddRange(channel.Read());
        }

        public void FetchNext(int page)
        {
            IChannel channel = Channels.First(); //currently it supports only one Channel
            Photos.AddRange(channel.Read(page));
        }
    }
}