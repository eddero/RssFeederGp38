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
using System.Threading.Tasks;
using System.Threading;



namespace RssFeederGp38
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        
        string Url { get; set; }
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();

            PopulateList();
            LoadTitlestestAsync();

        }
        private async Task LoadTitlestestAsync()
        {
            List<string> list = new List<string>();

            list = await GetTitles();

            foreach (var item in list)
            {
                
                listBox1.Items.Add(item);
            }

        }

        public async Task<List<string>> GetTitles()
        {
            List<string> list = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load("https://www.espn.com/espn/rss/news");
            XmlElement root1 = doc.DocumentElement;
            XmlNodeList nodes1 = root1.SelectNodes("descendant::title");

           

            return await Task.Run(() =>
            {
                foreach (XmlNode singularnode in nodes1)
                {

                    list.Add(singularnode.InnerText.ToString());
                    Thread.Sleep(5000);
                }
                
                return list;
            });

        }



        private async Task runDownloadAsync()
        {
            List<Podcast> list = podcastController.GetAllPodcast();

            
            foreach (var podcast in list)
            {
              string name = await Task.Run(() => podcast.Name.ToString());
                
              listBox3.Items.Add(name);

            }
        }

        private void SortList(string categoryName)
        {
            List<Podcast> list = podcastController.GetAllPodcast();

            list = list.Where(x => x.Category == categoryName).ToList();

            foreach (var podcast in list)
            {
                listBox3.Items.Add($"                       {podcast.Name}                            {podcast.Frequncy}                     {podcast.Category}");
            }
        }

        private void PopulateList()
        {

            List<string> lists = new List<string>();
            fqCB.Items.Add("1000");
            fqCB.Items.Add("2000");
            fqCB.Items.Add("3000");

            //lists = podcastController.GetPodcastDetailsByChapter(Url);

            categoryComboBox.Items.Clear();
            listBox2.Items.Clear();

            //string itemcount = lists.Count.ToString();

            foreach (Podcast item in podcastController.GetAllPodcast())
            {
                if (item != null && item is Feed)
                {
                    item.Display();
                    string frequncy = item.Frequncy;
                    string name = item.Name;
                    string category = item.Category;
                    listBox3.Items.Add($"                       {name}       {frequncy}            {category}");
   
                }
            }


            foreach (Podcast item in podcastController.GetAllPodcast())
            {
                if (item != null && item is Category)
                {
                    listBox2.Items.Add(item.Name);
                    categoryComboBox.Items.Add(item.Name);
                    

                } 
            
            }
        }


        private void bthAddFeed_Click_1(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtName.Text, txtUrl.Text, categoryComboBox.Text, fqCB.Text, "Feed");
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            podcastController.DeletePodcast(listBox2.SelectedItem.ToString());
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");

        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string text = listBox2.SelectedItem.ToString();

            SortList(text);

        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            //detail into async?
            list = podcastController.GetPodcastDetailsDexription(Url);

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

            try
            {
                doc.Load("Podcasts.xml");
                XmlElement root = doc.DocumentElement;
                XmlNode nodes = root.SelectSingleNode($"descendant::Url[{textindex + 1}]");

                foreach (XmlNode singularnode in nodes)
                {
                    Url = singularnode.InnerText;
                    LoadTitles(Url);
                }

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
   
        private void LoadTitles(string url)
        {
            listBox1.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root1 = doc.DocumentElement;
            XmlNodeList nodes1 = root1.SelectNodes("descendant::title");

            foreach (XmlNode singularnode in nodes1)
            {

                listBox1.Items.Add(singularnode.InnerText);

            }
            
        }
        
        private void bthDeleteFeed_Click(object sender, EventArgs e)
        {
            podcastController.DeletePodcast(listBox3.SelectedIndex);
        }


        private void button2_Click(object sender, EventArgs e)
        {

            podcastController.UpdatePodcast(listBox2.SelectedIndex, txtName.Text, txtUrl.Text, categoryComboBox.Text, fqCB.Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            podcastController.UpdatePodcast(listBox2.SelectedIndex, txtCategoryName.Text);
        }

       
    }
   
}
