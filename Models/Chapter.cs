using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeederGp38.Models
{
    public class Chapter : Podcast
    {
        public Chapter(string name) : base(name)
        {
        }

        private Chapter()
        {
        }
        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}
