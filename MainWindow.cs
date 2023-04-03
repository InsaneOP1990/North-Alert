using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Net;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using System.Collections.Specialized;
using System.Threading;

namespace TestReadText
{
    public partial class MainWindow : Form
    {
        private static string WebhookURL = "";
        private static string Message = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)

        {
            string path = @"C:\Users\Insane\Desktop\Space Engneering Stuff GG life\Torch-Server\Logs\Torch-2023-03-08.txt";
            // read .log file and display it in a textbox
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    richTextBox2.Text += line + Environment.NewLine;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //save settings
            richTextBox4.Text = richTextBox5.Text;
            NorthAlert.Properties.Settings.Default.DisURL = textBox3.Text;
            NorthAlert.Properties.Settings.Default.Logs = textBox1.Text;
            NorthAlert.Properties.Settings.Default.botname = textBox4.Text;
            NorthAlert.Properties.Settings.Default.Botpic = textBox5.Text;
            NorthAlert.Properties.Settings.Default.Keywords = richTextBox4.Text;
            NorthAlert.Properties.Settings.Default.Autorun = checkBox1.Checked;
            NorthAlert.Properties.Settings.Default.logname = textBox2.Text;
            NorthAlert.Properties.Settings.Default.Save();
        }

        private void FindWarrnings()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox1.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find line that contains "Session Loaded!", all lines after "Session Loaded!" that contain any word in richtextbox4 and display them in a Richtextbox1

            string[] lines = System.IO.File.ReadAllLines(path);
            //int index = Array.FindIndex(lines, line => line.Contains("[WARN]"));
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox1.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox2.Text == "")
                {
                    richTextBox2.Text += richTextBox1.Text;
                }
                else
                {
                    FindNewWarrnings();
                }
            }
            catch (Exception)
            {
            }
        }

        private void NewFindWarrnings()
        {
            //same as FindWarrnings() but checks multiple .log files in multiple directories
            timer1.Stop();
            Array warrnings = richTextBox4.Lines;
            richTextBox1.Text = "";
            string[] directories = richTextBox6.Lines;
            foreach (string dir in directories)
            {
                    //foreach file in dir if filename contains any word in richtextbox7 

                    string path = dir;

                    string[] files = Directory.GetFiles(path, textBox2.Text);
                            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
                            path = lastModifiedFile;
                            // Read all lines in .log file, find line that contain any word in richtextbox4 and display them in a Richtextbox1
                            string[] lines = System.IO.File.ReadAllLines(path);
                            //int index = Array.FindIndex(lines, line => line.Contains("[WARN]"));
                            try
                            {
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    for (int x = 0; x < warrnings.Length; x++)
                                    {
                                        string liney = warrnings.GetValue(x).ToString();
                                        if (lines[i].Contains(liney))
                                        {
                                            richTextBox1.Text += lines[i] + Environment.NewLine;
                                        }
                                    }
                                }
                                if (richTextBox2.Text == "")
                                {
                                    richTextBox2.Text += richTextBox1.Text;
                                }
                            }
                            catch (Exception)
                            {
                            }

                
            }
            FindNewWarrnings();
        }
        private void FindNewWarrnings()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox1.Text == "") 
            { 
            richTextBox2.Text = richTextBox1.Text;
            }
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text += richTextBox1.Text;
            }
              
            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox1.Lines;
            string[] lines2 = richTextBox2.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox2.Text != richTextBox1.Text)
                try
                {
                    try
                    {
                        for (int x = 0; x < warrnings2.Length; x++)
                        {
                            string liney = warrnings2.GetValue(x).ToString();
                            string line3 = lines2.GetValue(test2).ToString();
                            int index = Array.FindIndex(lines, line => line.Contains(line3));
                            for (int i = index; i < lines.Length; i++)
                            {
                                if (lines[i].Contains(liney))
                                {
                                    if (lines[i] != line3)
                                    richTextBox3.Text += lines[i] + Environment.NewLine;
                                    MsgQue(lines[i]);
                                    richTextBox2.Text = richTextBox1.Text;
                                    //every 100 lines clear richtextbox3
                                    if (richTextBox3.Lines.Length > 100)
                                    {
                                        richTextBox3.Text = "";
                                    }

                                    continue;
                                }
                            }
                        }
                    }

                    catch (Exception)
                    {
                    }
                }
                catch (Exception)
                {
                }

            timer1.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SendMessage("Test for North Alert");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                NewFindWarrnings();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                timer1.Start();

            //load settings
            textBox3.Text = NorthAlert.Properties.Settings.Default.DisURL;
            textBox1.Text = NorthAlert.Properties.Settings.Default.Logs;
            textBox4.Text = NorthAlert.Properties.Settings.Default.botname;
            textBox5.Text = NorthAlert.Properties.Settings.Default.Botpic;
            richTextBox4.Text = NorthAlert.Properties.Settings.Default.Keywords;
            richTextBox5.Text = richTextBox4.Text;
            textBox2.Text = NorthAlert.Properties.Settings.Default.logname;
            checkBox1 .Checked = NorthAlert.Properties.Settings.Default.Autorun;


        }

        private void MsgQue(string msg2)
        {
            // need to slow down messages so they dont get sent to fast, discord has a 5 second cooldown, so i need to make it so it sends 1 message every 5 seconds
            // i need to make it so it sends the first message, then waits 5 seconds, then sends the next message, then waits 5 seconds, then sends the next message, etc
            ArrayList msgque = new ArrayList();
            msgque.Add(msg2);
            foreach (string msg in msgque)
            {
                SendMessage(msg);
                Thread.Sleep(5000);
            }



        }

        private void SendMessage(string msg)
        {
            try
            {
                {
                    Message = msg;
                    WebhookURL = textBox3.Text;

                    Http.Post(WebhookURL, new NameValueCollection()
            {
                { "username", "North Alert: " + textBox4.Text },
                { "avatar_url", textBox5.Text },
                { "content", Message.ToString() }
            });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        }
        class Http
        {
            public static byte[] Post(string uri, NameValueCollection pairs)
            {
                using (WebClient webClient = new WebClient())
                    return webClient.UploadValues(uri, pairs);
            }

        }
        class Queue
    {
            public static void Enqueue(string msg)
        {
                ArrayList msgque = new ArrayList();
                msgque.Add(msg);
            }

    }
}

