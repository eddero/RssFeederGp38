﻿using System;
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
        private Timer timer1 = new Timer();
        int numberOfTimeUpdated = 0;
        int chaptercount;
        string Url { get; set; }

        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            FixWindowFormSetting();
            PopulateList();
            timer1.Interval = 6000;
            
            timer1.Tick += Timer1_Tick2;


            timer1.Start();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            PopulateList();

        }

        private void Timer1_Tick2(object sender, EventArgs e)
        {
            
            try
            {
                Chapter chapter = new Chapter();
                listBox3.Items.Clear();
                List<Podcast> podcasts = podcastController.GetAllPodcast();

                foreach (var podcast in podcasts)
                {
                    if (podcast.NeedsUpdate)
                    {

                        if (podcast is Feed)
                        {
                            listBox3.Items.Add($"{chapter.returnChapterCount(podcast.Url)}-----{podcast.Update()}");
                        }
                        
                        numberOfTimeUpdated++;
                    }
                }
                label12.Text = numberOfTimeUpdated + " times updated. Current time: " +
                    DateTime.Now.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private void SortList(string categoryName)
        {
            Chapter chapter = new Chapter();
            List<Podcast> list = podcastController.GetAllPodcast();

            list = list.Where(x => x.Category == categoryName).ToList();

            foreach (var podcast in list)
            {
                listBox3.Items.Add($"{chapter.returnChapterCount(podcast.Url)}--------{podcast.Name}--------{podcast.UpdateInterval}-------{podcast.Category}");
            }
        }

        private void FixWindowFormSetting()
        {
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fqCB.DropDownStyle = ComboBoxStyle.DropDownList;
            fqCB.Items.Add("10000");
            fqCB.Items.Add("15000");
            fqCB.Items.Add("20000");
            textBox2.ReadOnly = true;

        }

        private void PopulateList()
        {

            Chapter chapter = new Chapter();

            categoryComboBox.Items.Clear();
            listBox2.Items.Clear();


            foreach (Podcast item in podcastController.GetAllPodcast())
            {

                if (item != null && item is Feed)
                {

                    item.Display();
                    double frequncy = item.UpdateInterval;
                    string name = item.Name;
                    string url = item.Url;
                    int number = chapter.returnChapterCount(url);
                    chaptercount = number;
                    string category = item.Category;
                    listBox3.Items.Add($" {chaptercount}     {name}       {frequncy}            {category}");

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

            podcastController.CreatePodcast(txtName.Text, txtUrl.Text, categoryComboBox.Text, Convert.ToDouble(fqCB.Text), "Feed");
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            podcastController.DeletePodcast(listBox2.SelectedItem.ToString());
        }

        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");
            Task task = UpdateCategoryAsync();
            await task;

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox3.Items.Clear();
            if (listBox2.SelectedItem != null)
            {
                string text = listBox2.SelectedItem.ToString();
                SortList(text);
            }



        }

  
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

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
            //podcastController.GetPodcastDetailsByName(listBox3.SelectedItem);
            int textindex = listBox3.SelectedIndex;
            //string text = listBox3.SelectedItem.ToString();
            //listBox2.Items.Add(text[7..10]);

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("Podcasts.xml");
                XmlElement root = doc.DocumentElement;
                XmlNode nodes = root.SelectSingleNode($"descendant::Url[{textindex +1}]");
                if (nodes != null)
                {
                    foreach (XmlNode singularnode in nodes)
                    {
                        Url = singularnode.InnerText;

                        LoadTitles(Url);
                    }
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

            podcastController.UpdatePodcast(listBox3.SelectedIndex, txtName.Text, txtUrl.Text, categoryComboBox.Text, Convert.ToDouble(fqCB.Text));

        }

        private void button5_Click(object sender, EventArgs e)
        {

            podcastController.UpdatePodcast(listBox2.SelectedIndex, txtCategoryName.Text);
        }

        private  List<Podcast> GetAll()

        {

            List<Podcast> podcasts = podcastController.GetAllPodcast();
            System.Threading.Thread.Sleep(3000);

            MessageBox.Show("Done");

            return podcasts;

        }


        private async Task UpdateCategoryAsync()
        {
            categoryComboBox.Items.Clear();
            listBox2.Items.Clear();

            List<Podcast> alist = new List<Podcast>();


            alist = await Task.Run(() => GetAll());

            foreach (var item in alist)
            {
                if (alist != null && item is Category)

                {

                    listBox2.Items.Add(item.Name);
                    categoryComboBox.Items.Add(item.Name);

                }

            }

        }

    }
}
