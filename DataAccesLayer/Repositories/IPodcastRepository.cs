using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;


namespace DataAccesLayer.Repositories
{
    public interface IPodcastRepository<T>:IRepository<T> where T:Podcast
    {
        T GetByName(string name);

        int GetIndex(string name);

    }
}
