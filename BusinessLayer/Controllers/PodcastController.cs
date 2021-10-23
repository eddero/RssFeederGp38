using System;
using System.Collections.Generic;
using System.Text;
using RssFeederGp38.Models;
using DataAccesLayer.Repositories;

namespace BusinessLayer.Controllers
{
    public class PodcastController
    {
        IRepository<Podcast> podcastRepository;
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
    }
}
