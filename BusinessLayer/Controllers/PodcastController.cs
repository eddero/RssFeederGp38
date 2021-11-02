using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;
using DataAccesLayer.Repositories;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Threading;

namespace BusinessLayer.Controllers
{
    public class PodcastController
    {
        IPodcastRepository<Podcast> podcastRepository; //gets a IPodcastRepository Variable with the type of Super
        Chapter chapter;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository(); //Instansierar IPodcastRepository pattern.
            chapter = new Chapter();
        }

      
        public void UpdatePodcast(int index, string updateName)
        {
           Podcast updatePodcast = null;

           updatePodcast = new Category(updateName);
            
           podcastRepository.Update(index, updatePodcast);

        }

        public void UpdatePodcast(int index, string updateName, string url, string category, double frequncy)
        {
            Podcast updatePodcast = null;

            updatePodcast = new Feed(updateName, url, category, frequncy);

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
        public void CreatePodcast(string name, string url, string category, double frequncy, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category, frequncy);
            }
            podcastRepository.Create(newPodcast);
        }


        public void CreateFeed(string name, string url, string category, double frequncy, string objectType)
        {
            Podcast newPodcast = null;
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name, url, category, frequncy);
            }
            podcastRepository.Create(newPodcast);
        }

        public void SerializerForXml(string url)
        {
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);

        }

        public List<Podcast> GetAllPodcast() //Metod för att hämta en lisa över alla Podcasts så att den kan itereras.
        {
            
            return podcastRepository.GetAll();
        }


        public List<string> GetPodcastDetailsByChapter(string url)
        {
            return chapter.returnChapter(url);
        }

        public List<string> GetPodcastDetailsDexription(string url)
        {
            
            return chapter.returnChapterDescri(url);
        }

        public int GetPodcastDetailsNumber(string url)
        {

            return chapter.returnChapterCount(url);
        }

        public string GetPodcastDetailsByName(string name)
        {
            
            return podcastRepository.GetByName(name).Display();
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
