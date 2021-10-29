using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BusinessLayer.Controllers;
using RssFeederGp38.Models;

namespace RssFeederGp38
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        string url;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            PopulateList();
            

        }

        private void PopulateList()
        {
            List<string> parts = new List<string>();


            parts = podcastController.GetPodcastDetailsByChapter(url);

            categoryComboBox.Items.Clear();
            listBox2.Items.Clear();

            string itemcount = parts.Count.ToString();

            foreach (Podcast item in podcastController.GetAllPodcast())
            {
                if (item != null)
                {
                    string name = item.Name;
                    string url = item.Url;


                    listBox3.Items.Add($"{itemcount}     {name}         {url}");

                    categoryComboBox.Items.Add(item.Name);
                }
            }

            /*foreach (Feed item in podcastController.GetAllPodcast())
            {
                if (item != null)
                {
                    listBox2.Items.Add(item.Frequency);

                    
                }
            }*/

            XmlDocument doc1 = new XmlDocument();
            doc1.Load("https://www.espn.com/espn/rss/news");
            XmlElement root1 = doc1.DocumentElement;
            XmlNodeList nodes1 = root1.SelectNodes("descendant::title");

            foreach (XmlNode singularnode in nodes1)
            {
                
                listBox1.Items.Add(singularnode.InnerText);

            }



        }

        private void bthAddFeed_Click_1(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtName.Text, txtUrl.Text, categoryComboBox.Text, "Feed");
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            podcastController.DeletePodcast(string name);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");
            PopulateList();

        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            
            list = podcastController.GetPodcastDetailsDexription();

            textBox2.Text = "";
            
            try
            {
                textBox2.Text = list[listBox1.SelectedIndex - 1];
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int textindex = listBox3.SelectedIndex;
            string text = listBox3.SelectedItem.ToString();
            listBox2.Items.Add(text[7..10]);

            
            XmlDocument doc = new XmlDocument();
            {
                try
                {
                    doc.Load("Podcasts.xml");
                    XmlElement root = doc.DocumentElement;
                    XmlNode nodes = root.SelectSingleNode($"descendant::Url[{textindex +1}]");

                    foreach (XmlNode singularnode in nodes)
                    {
                        listBox2.Items.Add(singularnode.InnerText);

                    }

                }
                catch (Exception)
                {
                    throw new NotImplementedException();
                }

            }
            
        }
    }
   
}
