using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeederGp38.Models
{
    public class Category : Podcast
    {
        public override string Display()
        {
            return $"Category is name is {Name}";
        }
        public Category(string name): base (name)
        {

        }
        private Category()
        {

        }
    }
}
