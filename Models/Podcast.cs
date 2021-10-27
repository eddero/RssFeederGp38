using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace  RssFeederGp38.Models
{
    [XmlInclude(typeof(Category))]
    [XmlInclude(typeof(Chapter))]
    [XmlInclude(typeof(Feed))]

    

    public abstract class Podcast
    {
        public string Name { get; set; }
        public string Url { get; set; }


        public Podcast(string name)
        {
            Name = name;

        }

        public Podcast(string name, string url)
        {
            Name = name;
            Url = url;

        }

        public Podcast()
        {

        }

        public abstract string Display();

    }
}
