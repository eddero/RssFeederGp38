﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void bthAddFeed_Click_1(object sender, EventArgs e)
        {
            podcastController.CreateFeed(txtUrl.Text, categoryComboBox.Text, "Feed");
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");
            PopulateList();


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        
    }
   
}
