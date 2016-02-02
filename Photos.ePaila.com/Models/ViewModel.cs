using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photos.ePaila.com.Models
{
    public class ViewModel
    {
        private List<IChannel> Channels;
        public List<Photo> Photos { get; set; }

        public ViewModel()
        {
            Photos = new List<Photo>();
            Channels = new List<IChannel>();
        }

        public void AddChannel(IChannel channel)
        {
            Channels.Add(channel);
            Photos.AddRange(channel.Read());
        }
    }
}