using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
        public string URL { get; set; }
        public string Category { get; set; }
        public int Frequency { get; set; }


        public override string Display()
        {
            throw new NotImplementedException();
        }
        public Feed(string name, string category)
        {
            Category = category;
            URL = name;
        }
        private Feed()
        {

        }
    }
}
