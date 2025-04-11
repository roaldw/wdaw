using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();

            timer1 = new Timer();
            timer1.Interval = 5000;
            timer1.Tick += Timer_Tick;
            timer1.Start();

            timer2 = new Timer();
            timer2.Interval = 3000;
            timer2.Tick += Timer2_Tick;
            timer2.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            Executer executer = new Executer();
            executer.Show();
            this.Hide();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            label2.Text = "All Good, Well Start now...";
            label2.ForeColor = Color.Green;
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
