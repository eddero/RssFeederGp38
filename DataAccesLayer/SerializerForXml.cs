using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Exceptions;
using System.Xml.Serialization;
using RssFeederGp38.Models;
using System.IO;
using System.Xml;


namespace DataAccesLayer
{
    internal class SerializerForXml
    {
       

        public void Serialize(List<Podcast> podcastList)
        {
            
            try
            {
                Console.WriteLine(podcastList);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
                using (FileStream outFile = new FileStream("Podcasts.xml", FileMode.Create,
                    FileAccess.Write))
                {
                    xmlSerializer.Serialize(outFile, podcastList);
                   
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("Podcasts.xml", "Could not serialize to the file");
            }
        }


        
    

        public List<Podcast> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
                using (FileStream inFile = new FileStream("Podcasts.xml", FileMode.Open,
                    FileAccess.Read))
                {
                    return (List<Podcast>)xmlSerializer.Deserialize(inFile);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("Podcast.xml", "Could not deserialize the file");
            }
        }
    }
}
