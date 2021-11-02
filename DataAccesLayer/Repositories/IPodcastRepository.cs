using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;


namespace DataAccesLayer.Repositories
{
    public interface IPodcastRepository<T>:IRepository<T> where T:Podcast
    {
        int GetIndex(string name);

    }
}
