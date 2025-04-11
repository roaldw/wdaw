using cxapi;
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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CoreFunctions.Inject(false);
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            UpdateCheckBoxState();
        }

        private void UpdateCheckBoxState()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Executer executerForm)
                {
                    guna2CheckBox2.Checked = executerForm.TopMost;
                    break;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://nomorelife1.github.io/Website/");
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Executer executerForm)
                {
                    if (guna2CheckBox2.Checked)
                    {
                        executerForm.TopMost = true;
                    }
                    else
                    {
                        executerForm.TopMost = false;
                    }
                }
            }
        }
    }
}
