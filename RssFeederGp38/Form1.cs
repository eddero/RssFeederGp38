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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            podcastController.CreatePodcast(txtCategoryName.Text, "Category");
        }
    }
}
