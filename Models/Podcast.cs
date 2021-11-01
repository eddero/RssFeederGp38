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
        public string Category { get; set; }
        public string Frequncy { get; set; }
        public DateTime NextUpdate { get; set; }
        public double UpdateInterval { get; set; }
        public Chapter chapter {get; set;}
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
                // Om nästa uppdatering är innan nuvarande klockslag så ska en uppdatering ske
                // dvs metoden NeedsUpdate ska returnera true
                return NextUpdate <= DateTime.Now;
            }
        }


        public string Update()
        {
            // nästa uppdatering sker om "UpdateInterval" minuter
            // Vi hittar den tidpunkten genom att lägga till det antalet millisekunder till den 
            // nuvarande tiden.
            NextUpdate = DateTime.Now.AddMilliseconds(UpdateInterval);
            return $"----{Name}-----{Frequncy} -- {Category}----{NextUpdate}"; 
        }

        public abstract string Display();

    }
}
