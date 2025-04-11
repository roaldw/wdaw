using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthLevelKey
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.LicenseAuthApp.user_data.subscriptions[0].subscription == "default")
            {
                MessageBox.Show("This Work.");
            }
            else
            {
                string level = Form1.LicenseAuthApp.user_data.subscriptions[0].subscription;
                MessageBox.Show($"You Cant Use this because you level is {level}.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.LicenseAuthApp.user_data.subscriptions[0].subscription == "2")
            {
                MessageBox.Show("This Work.");
            }
            else
            {
                string level = Form1.LicenseAuthApp.user_data.subscriptions[0].subscription;
                MessageBox.Show($"You Cant Use this because you level is {level}.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1.LicenseAuthApp.user_data.subscriptions[0].subscription == "3")
            {
                MessageBox.Show("This Work.");
            }
            else
            {
                string level = Form1.LicenseAuthApp.user_data.subscriptions[0].subscription;
                MessageBox.Show($"You Cant Use this because you level is {level}.");
            }
        }
    }
}
