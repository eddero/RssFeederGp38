using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
        public override string Display()
        {
            throw new NotImplementedException();
        }
        public Feed(string name) : base(name)
        {

        }
        private Feed()
        {

        }
    }
}
