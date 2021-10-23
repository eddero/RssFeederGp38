using System;
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
            listBox2.Items.Add("hello");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtUrl.Text, "Chapter");
            
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");


            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            foreach (Podcast item in podcastController.GetAllPodcast())
            {
                Console.WriteLine("hello");
            }

        }

    }
}
