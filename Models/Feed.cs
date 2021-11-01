using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;


namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
       
        public override string Display()
        {
            return "hopla";
        }
        public Feed(string name, string url, string category, double frequncy) :base(name, url, category, frequncy) 
        {
            
        }

        private Feed()
        {
           
        }

    }
}
