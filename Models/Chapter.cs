using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace RssFeederGp38.Models
{
    public class Chapter 
    {
       public string ChapterName { get; set; }
       public string ChapterDescription { get; set; }
       public List<string> ChapterList { get; set; }




        public Chapter() 
        {
              

        }

        public List<string> returnChapter()
        {
            List<string> ChapterList = new List<string>();

            XmlDocument doc1 = new XmlDocument();
            doc1.Load("https://www.espn.com/espn/rss/news");
            XmlElement root1 = doc1.DocumentElement;
            XmlNodeList nodes1 = root1.SelectNodes("descendant::title");

            foreach (XmlNode singularnode in nodes1)
            {

                ChapterList.Add(singularnode.InnerText);

            }
            return ChapterList;
        }
    }
 
}
