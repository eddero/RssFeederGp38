using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;
using DataAccesLayer.Repositories;
using System.Xml;
using System.ServiceModel.Syndication;

namespace BusinessLayer.Controllers
{
    public class PodcastController
    {
        IPodcastRepository<Podcast> podcastRepository;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public void CreatePodcast(string name, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Category"))
            {
                newPodcast = new Category(name);
            }
            if (objectType.Equals("Chapter"))
            {
                newPodcast = new Chapter(name);
            }
            podcastRepository.Create(newPodcast);

        }
        public void CreatePodcast(string name, string url, string category, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category);
            }
            podcastRepository.Create(newPodcast);
        }


        public void CreateFeed(string name, string url, string category, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category);
            }
            podcastRepository.Create(newPodcast);
        }

        public void SerializerForXml(string url)
        {
            XmlReader reader = XmlReader.Create("https://www.espn.com/espn/rss/news");

            SyndicationFeed feed = SyndicationFeed.Load(reader);

        }     

        public List<Podcast> GetAllPodcast()
        {
            return podcastRepository.GetAll();
        }

        public string GetPodcastDetailsByName(string name)
        {
            
            return podcastRepository.GetByName(name).Display();
        }

        public string GetPodcastDetailsByUrl(string url)
        {
            return podcastRepository.GetByUrl(url).Display();
        }

        public void DeletePodcast(string name)
        {
            int index = podcastRepository.GetIndex(name);
            podcastRepository.Delete(index);
        }
    }
}
