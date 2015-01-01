using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

namespace Youtube
{

    public partial class YoutubePlayer : Form
    {
        YouTubeRequestSettings settings;
        YouTubeRequest request;
        YouTubeQuery query;
        Feed<Video> videoFeed;
        string[] image;
        string[] description;
        string[] videoID;
        FlashPlayer fp;

        public YoutubePlayer()
        {
            InitializeComponent();
            settings = new YouTubeRequestSettings("Youtube", "AIzaSyBpG42l_JoVhJ2IAsDjeVfBxyOClJ5TBhA");
            request = new YouTubeRequest(settings);
            query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
            image = new string[25];
            description = new string[25];
            videoID = new string[25];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query.Query = textBox1.Text.Trim();
            videoFeed = request.Get<Video>(query);
            int counter = 0;
            foreach (Video v in videoFeed.Entries)
            {
                listBox1.Items.Add(v.Title);
                image[counter] = v.Thumbnails[1].Url;
                description[counter] = v.Description;
                videoID[counter] = v.VideoId;
                Debug.Print(v.VideoId);
                counter++;
            }         
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Load(image[listBox1.SelectedIndex]);
            richTextBox1.Text = description[listBox1.SelectedIndex];
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Debug.Print(sender.ToString());
            fp = new FlashPlayer();
            fp.setVideoID = videoID[listBox1.SelectedIndex];
            fp.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        int TogMove, MValX, MValY;
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if(TogMove==1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
    }
}
