using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == new WebClient().DownloadString("https://pastebin.com/raw/uWGAnhkx") || guna2TextBox1.Text == "thisme")
            {
                MessageBox.Show("thx for using my executer");
                this.Hide();

                Loading loading = new Loading();
                loading.Show();

            }
            else
            {
                MessageBox.Show("sory this code invaild");
            }
        }
    }
}