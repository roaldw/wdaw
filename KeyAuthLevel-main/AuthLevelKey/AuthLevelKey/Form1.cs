using LicenseAuth;
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
    public partial class Form1 : Form
    {

        public static api LicenseAuthApp = new api(
    name: "nomorelife",
    ownerid: "u59wDIUX1e",
    secret: "41f1688e4bd5dab7ee41adbb735827ebfd63d83bff8b263ac3026173d9c25b94",
    version: "1.10"
);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LicenseAuthApp.init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LicenseAuthApp.license(textBox1.Text);
            if (LicenseAuthApp.response.success)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }
    }
}
