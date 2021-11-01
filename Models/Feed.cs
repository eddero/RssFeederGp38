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
            return "hopla";
        }
        public Feed(string name, string url, string category, string frequncy) :base(name, url, category, frequncy) 
        {
            Category = category;
            UpdateInterval = double.Parse(frequncy);



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

        public void Update()
        {
            // nästa uppdatering sker om "UpdateInterval" minuter
            // Vi hittar den tidpunkten genom att lägga till det antalet millisekunder till den 
            // nuvarande tiden.
            NextUpdate = DateTime.Now.AddMilliseconds(UpdateInterval);
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
