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
        public int Frequnce { get; set; }
        public int ChapterCount { get; set; }
        public DateTime ChapterUpdate {get; set;}



        public Chapter() 
        {
              

        }

        public int getChapterCount()
        {

            return ChapterCount;
        }

        public List<string> returnChapter(string url)
        {
            List<string> ChapterList = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("descendant::title");

            foreach (XmlNode singularnode in nodes)
            {

                ChapterList.Add(singularnode.InnerText);


            }
            
            return ChapterList;
        }


        public List<string> returnChapterDescri(string url)
        {

            List<string> ChapterList = new List<string>();
            
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("descendant::description");

            foreach (XmlNode singularnode in nodes)
            {
                ChapterList.Add(singularnode.InnerText);
            }
            ChapterCount = ChapterList.Count;
            return ChapterList;
        }
    }
 
}
