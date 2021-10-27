using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;


namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
        public string Category { get; set; }
        public int Frequency { get; set; }



        public override string Display()
        {
            return Url;
        }
        public Feed(string name, string url, string category) :base(name, url) 
        {
            Category = category;
           
        }
        private Feed()
        {
           
        }

    }
}
