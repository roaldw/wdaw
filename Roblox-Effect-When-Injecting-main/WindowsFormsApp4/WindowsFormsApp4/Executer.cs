using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cxapi;

namespace WindowsFormsApp4
{
    public partial class Executer : Form
    {
        Timer time = new Timer();
        public Executer()
        {
            InitializeComponent();
            time.Tick += timertick;
            time.Start();
        }

        private void timertick(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void Executer_Load(object sender, EventArgs e)
        {

        }

        private async void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                CoreFunctions.Inject(false);

                await Task.Delay(2000);

                string luascript = @"
local screenGui = Instance.new(""ScreenGui"")
screenGui.Parent = game.Players.LocalPlayer:WaitForChild(""PlayerGui"")

local blurEffect = Instance.new(""BlurEffect"")
blurEffect.Parent = game.Lighting
blurEffect.Size = 0

local frame = Instance.new(""Frame"")
frame.Size = UDim2.new(1, 0, 1, 0)
frame.BackgroundTransparency = 1
frame.Parent = screenGui

local imageLabel = Instance.new(""ImageLabel"")
imageLabel.Size = UDim2.new(0, 200, 0, 200)
imageLabel.Position = UDim2.new(0.5, -100, 0.5, -100)
imageLabel.Image = ""rbxassetid://119196073370855""
imageLabel.BackgroundTransparency = 1
imageLabel.Parent = frame

for i = 0, 25, 1 do
    blurEffect.Size = i
    imageLabel.ImageTransparency = 1 - (i / 25)
    wait(0.1)
end

wait(3)

for i = 25, 0, -1 do
    blurEffect.Size = i
    imageLabel.ImageTransparency = 1 - (i / 25)
    wait(0.1)
end

screenGui:Destroy()
blurEffect:Destroy()";

                CoreFunctions.ExecuteScript(luascript);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"an error : {ex.Message}");
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            CoreFunctions.ExecuteScript(richTextBox1.Text);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
            richTextBox1.Text = readfile;
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }
    }
}
