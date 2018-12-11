using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OldFileDelete
{
    public partial class Form1 : Form
    {
        string filepath;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }
        int duration = 3600;
        private void Delete()
        {

            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath = openFileDialog.SelectedPath;
                //MessageBox.Show(filepath);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void myDelete()
        {
            if (filepath != null)
            {
                DirectoryInfo source = new DirectoryInfo(@filepath);
                //label1.Text = source.ToString();
                if (source != null)
                {
                    foreach (FileInfo fi in source.GetFiles())
                    {
                        var creationTime = fi.CreationTime;

                        if (creationTime < (DateTime.Now - new TimeSpan(15, 0, 0, 0)))
                        {
                            fi.Delete();
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration--;
            textBox1.Text = duration.ToString();
            if (duration == 0)
            {
                myDelete();
                //fileDelete();
                duration = 3600;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filepath == null)
            {
                label1.Text = "First Select A Folder Then Press Start";

            }
            else
            {
                label1.Text = " ";
                timer1.Enabled = true;
                timer1.Start();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        
        
    }
}
