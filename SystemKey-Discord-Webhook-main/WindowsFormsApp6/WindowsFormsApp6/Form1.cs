using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net.Http;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {

        private string generatedCode;
        private string userHWID;

        private DateTime lastWebhookSendTime;
        private TimeSpan webhookCooldown = TimeSpan.FromHours(2);
        public Form1()
        {
            InitializeComponent();
            userHWID = GetHWID();
            lastWebhookSendTime = DateTime.MinValue;
        }

        private string GetHWID()
        {
            string hwid = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    hwid = wmi_HD["SerialNumber"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Getting HWID:  {ex.Message}", "Error");
            }
            return hwid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == generatedCode)
            {
                string currentHWID = GetHWID();
                if (currentHWID == userHWID)
                {
                    MessageBox.Show("Login Successful!", "Success");
                }
                else
                {
                    MessageBox.Show("Login Faild! Incorrect Hwid.", "Failed");
                }
            }
            else
            {
                MessageBox.Show("Invaild Code!", "Failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DateTime.Now - lastWebhookSendTime >= webhookCooldown)
            {
                generatedCode = GenetateRandomCode();
                SendCodeToDiscord(generatedCode, userHWID);
                lastWebhookSendTime = DateTime.Now;
                MessageBox.Show("A random code has been sent to discord!", "Code Generated");
            }
            else
            {
                TimeSpan timeRemaninig = webhookCooldown - (DateTime.Now - lastWebhookSendTime);
                MessageBox.Show($"Please Wait {timeRemaninig.Hours} Hour(s) and {timeRemaninig.Minutes} minte(s) Before Gen a new code");
            }
        }

        private async void SendCodeToDiscord(string generatedCode, string userHWID)
        {
            string webhookUrl = "https://discord.com/api/webhooks/1297393328442048642/BD5mXGkNxIv4OUyt_lNMf3zhGf2h08lH4J6vwNlOZ9K-DFU92j62LD0kcom4ahbpBh8w";
            string content = $"User Hwid: {userHWID}\nGen Code: {generatedCode}";

            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>()
                {
                    { "content", content }
                };
                var contentData = new FormUrlEncodedContent(values);
                var respone = await client.PostAsync(webhookUrl, contentData);
            }
        }

        private string GenetateRandomCode()
        {
            Random random = new Random();
            const string chars = "ABCDIFJIJFEOEFJEOIFJIEJF2392039";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray() );
        }
    }
}
