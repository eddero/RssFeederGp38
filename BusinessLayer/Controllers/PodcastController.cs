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
        Chapter chapter;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
            chapter = new Chapter();
        }
        public void UpdatePodcast(int index, Podcast entity)
        {
            Podcast updatePodcast = null;

            podcastRepository.Update(index, entity);

            podcastRepository.Update(index, updatePodcast);
        }

        public void CreatePodcast(string name, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Category"))
            {
                newPodcast = new Category(name);
            }
            
            podcastRepository.Create(newPodcast);

        }
        public void CreatePodcast(string name, string url, string category, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category, chapter.getChapterCount());
            }
            podcastRepository.Create(newPodcast);
        }


        public void CreateFeed(string name, string url, string category, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category, chapter.getChapterCount());
            }
            podcastRepository.Create(newPodcast);
        }

        public void SerializerForXml(string url)
        {
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);

        }

        public List<Podcast> GetAllPodcast()
        {
            return podcastRepository.GetAll();
        }

        public List<string> GetPodcastDetailsByChapter(string url)
        {
            
            return chapter.returnChapter(url);
        }

        public List<string> GetPodcastDetailsDexription()
        {
            
            return chapter.returnChapterDescri();
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
        public void DeletePodcast(int index)
        {
            podcastRepository.Delete(index);
        }
    }
}
