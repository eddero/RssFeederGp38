using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace RssFeederGp38.Models
{
    public class Chapter
    {


        public Chapter() 
        {
              

        }

        
        public int returnChapterCount(string url)
        {
            List<string> ChapterList = new List<string>();
            try
            {
                XmlDocument doc = new XmlDocument();
                if (url != null)
                {
                    doc.Load(url);
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList nodes = root.SelectNodes("descendant::title");

                    foreach (XmlNode singularnode in nodes)
                    {

                        ChapterList.Add(singularnode.InnerText);

                    }
                }
            }
            catch (XmlException)
            {

                throw;
            }
            
            return ChapterList.Count;
        }

        public List<string> returnChapter(string url)
        {
            List<string> ChapterList = new List<string>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("descendant::title");

                foreach (XmlNode singularnode in nodes)
                {

                    ChapterList.Add(singularnode.InnerText);

                    
                }
            }
            catch (XmlException)
            {

                throw;
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
 
            return ChapterList;
        }
    }
 
}
