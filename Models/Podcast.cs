using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace  RssFeederGp38.Models
{
    [XmlInclude(typeof(Category))]
    [XmlInclude(typeof(Feed))]


    public abstract class Podcast
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Frequncy { get; set; }
        public DateTime NextUpdate { get; set; }
        public double UpdateInterval { get; set; }

        public Podcast(string name)
        {
            Name = name;

        }

        public Podcast(string name, string url, string category, double frequncy)
        {
            Name = name;
            Url = url;
            Category = category;
            UpdateInterval = frequncy;   
            Update();
        }

        public Podcast()
        {

        }
        public bool NeedsUpdate
        {
            get
            {
                
                return NextUpdate <= DateTime.Now;
            }
        }


        public string Update()
        {
            
            NextUpdate = DateTime.Now.AddMilliseconds(UpdateInterval);
            return $"----{Name}-----{Frequncy} -- {Category}----{NextUpdate}"; 
        }

        public abstract string Display();

    }
}
