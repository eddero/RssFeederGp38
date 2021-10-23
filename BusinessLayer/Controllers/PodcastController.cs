using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;
using DataAccesLayer.Repositories;

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
            if (objectType.Equals("Feed"))
            {
                newPodcast = new Feed(name);
            }
            podcastRepository.Create(newPodcast);

        }
        public List<Podcast> GetAllPodcast()
        {
            return podcastRepository.GetAll();
        }

        public string GetPodcastDetailsByName(string name)
        {
            //
            return podcastRepository.GetByName(name).Display();
        }

        public void DeletePodcast(string name)
        {
            int index = podcastRepository.GetIndex(name);
            podcastRepository.Delete(index);
        }
    }
}
