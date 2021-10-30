using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;


namespace RssFeederGp38.Models
{
    public class Feed : Podcast
    {
        public int Frequency { get; set; }
        public int ChapterCount { get; set; }

        public override string Display()
        {
            return Url;
        }
        public Feed(string name, string url, string category, int num) :base(name, url, category) 
        {
            Category = category;
            ChapterCount = getChapterNumber();


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
