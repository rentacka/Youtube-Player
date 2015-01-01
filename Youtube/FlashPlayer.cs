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

namespace Youtube
{
    public partial class FlashPlayer : Form
    {
        private string videoID;

        public string setVideoID
        {
            get { return videoID; }
            set { videoID = value; }
        }
        public FlashPlayer()
        {
            InitializeComponent();
        }

        private void FlashPlayer_Load(object sender, EventArgs e)
        {
            Debug.Print(@"https://www.youtube.com/v/" + videoID);
            axShockwaveFlash1.Movie = (@"https://www.youtube.com/v/" + videoID);
            axShockwaveFlash1.Play();
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
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
    }
}
