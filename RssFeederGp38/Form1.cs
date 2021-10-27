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
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            PopulateList();



        }

        private void PopulateList()
        {
            categoryComboBox.Items.Clear();
            listBox2.Items.Clear();

            foreach (Podcast item in podcastController.GetAllPodcast())
            {
                if (item != null)
                {
                    listBox2.Items.Add(item.Name);
                    
                    categoryComboBox.Items.Add(item.Name);
                }
            }

            using (XmlReader xmlReader = XmlReader.Create("Podcasts.xml"))
            {
                XDocument xDocument = XDocument.Load(xmlReader);
                var result = xDocument.Descendants("Feed");
                    
                    
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                    listBox2.Items.Add(item);
                }
            }

        }

        private void bthAddFeed_Click_1(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtName.Text, txtUrl.Text, categoryComboBox.Text, "Feed");
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {

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
    }
   
}
