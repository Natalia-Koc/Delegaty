using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegaty_6_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Click += PictureBox1_Click;

            //anonim
            pictureBox3.Click += delegate (object sender, EventArgs e)
                {pictureBox5.Image = pictureBox3.Image;};

            //operator lambda
            pictureBox4.Click += (sender, e) => {pictureBox5.Image = pictureBox4.Image;}; 
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = pictureBox1.Image;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = pictureBox2.Image;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = pictureBox3.Image;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = pictureBox4.Image;
        }
    }
}
