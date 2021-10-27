using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;
using DataAccesLayer;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class PodcastRepository : IPodcastRepository<Podcast>
    {
        SerializerForXml dataManager;
        List<Podcast> listOfPodcasts;
        public PodcastRepository()
        {
            dataManager = new SerializerForXml();
            listOfPodcasts = new List<Podcast>();
            listOfPodcasts = GetAll();
        }
        public void Create(Podcast entity)
        {
            listOfPodcasts.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfPodcasts.RemoveAt(index);
            SaveChanges();
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> listOfPodcastDeserialized = new List<Podcast>();
            try
            {
                listOfPodcastDeserialized = dataManager.Deserialize();

            }
            catch (Exception)
            {
                
            }
            return listOfPodcastDeserialized;
            
        }

        public Podcast GetByName(string name)
        {
            return GetAll().FirstOrDefault(p => p.Name.Equals(name));
            
        }

        public Podcast GetByUrl(string url)
        {
            return GetAll().FirstOrDefault(p => p.Url.Equals(url));
        }

        public int GetIndex(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            dataManager.Serialize(listOfPodcasts);
        }

        public void Update(int index, Podcast entity)
        {
            if(index >= 0)
            {
                listOfPodcasts[index] = entity;
            }
            SaveChanges();
        }
    }
}
