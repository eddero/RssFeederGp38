using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;


namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
        public DateTime NextUpdate { get; set; }
        public double UpdateInterval { get; set; }

        public override string Display()
        {
            return Url;
        }
        public Feed(string name, string url, string category, string frequncy) :base(name, url, category, frequncy) 
        {
            Category = category;
            UpdateInterval = double.Parse(frequncy);



        }

        public int getChapterNumber()
        {
            Chapter chapter = new Chapter();

            return chapter.getChapterCount();
        }
        private Feed()
        {
           
        }

    }
}
