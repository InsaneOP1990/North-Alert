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
        //Old Button
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

        private void FindWarrnings0()
        {
            timer1.Stop();
            Array warrnings = richTextBox4.Lines;
            richTextBox1.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[0] != null)
            {
                textBox1.Text = richTextBox6.Lines[0];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
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
                    richTextBox2.Text = richTextBox1.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings0();
        }
        private void FindNewWarrnings0()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox1.Text == "") 
            { 
            richTextBox2.Text = richTextBox1.Text;
            }
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = richTextBox1.Text;
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[0] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[0] + ": " + lines[i]);
                                        richTextBox2.Text = richTextBox1.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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

            FindWarrnings1();
        }
        private void FindWarrnings1()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox8.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[1] != null)
            {
                textBox1.Text = richTextBox6.Lines[1];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox8.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox9.Text == "")
                {
                    richTextBox9.Text = richTextBox8.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings1();
        }
        private void FindNewWarrnings1()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox8.Text == "")
            {
                richTextBox9.Text = richTextBox8.Text;
            }
            if (richTextBox9.Text == "")
            {
                richTextBox9.Text = richTextBox8.Text;
            }

            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox8.Lines;
            string[] lines2 = richTextBox9.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox9.Text != richTextBox8.Text)
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[1] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[1] + ": " + lines[i]);
                                        richTextBox9.Text = richTextBox8.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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

            FindWarrnings2();
        }

        private void FindWarrnings2()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox11.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[2] != null)
            {
                textBox1.Text = richTextBox6.Lines[2];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox11.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox12.Text == "")
                {
                    richTextBox12.Text = richTextBox11.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings2();
        }
        private void FindNewWarrnings2()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox11.Text == "")
            {
                richTextBox12.Text = richTextBox11.Text;
            }
            if (richTextBox12.Text == "")
            {
                richTextBox12.Text = richTextBox11.Text;
            }

            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox11.Lines;
            string[] lines2 = richTextBox12.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox12.Text != richTextBox11.Text)
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[2] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[2] + ": " + lines[i]);
                                        richTextBox12.Text = richTextBox11.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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

            FindWarrnings3();
        }
        private void FindWarrnings3()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox13.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[3] != null)
            {
                textBox1.Text = richTextBox6.Lines[3];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox13.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox14.Text == "")
                {
                    richTextBox14.Text = richTextBox13.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings3();
        }
        private void FindNewWarrnings3()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox13.Text == "")
            {
                richTextBox14.Text = richTextBox13.Text;
            }
            if (richTextBox14.Text == "")
            {
                richTextBox14.Text = richTextBox13.Text;
            }

            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox13.Lines;
            string[] lines2 = richTextBox14.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox14.Text != richTextBox13.Text)
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[3] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[3] + ": " + lines[i]);
                                        richTextBox14.Text = richTextBox13.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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

            FindWarrnings4();
        }
        private void FindWarrnings4()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox15.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[4] != null)
            {
                textBox1.Text = richTextBox6.Lines[4];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox15.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox16.Text == "")
                {
                    richTextBox16.Text = richTextBox15.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings4();
        }
        private void FindNewWarrnings4()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox15.Text == "")
            {
                richTextBox16.Text = richTextBox15.Text;
            }
            if (richTextBox16.Text == "")
            {
                richTextBox16.Text = richTextBox15.Text;
            }

            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox15.Lines;
            string[] lines2 = richTextBox16.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox16.Text != richTextBox15.Text)
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[4] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[4] + ": " + lines[i]);
                                        richTextBox16.Text = richTextBox15.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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

            FindWarrnings5();
        }
        private void FindWarrnings5()
        {
            Array warrnings = richTextBox4.Lines;
            richTextBox17.Text = "";
            //find last motified .log file in directory that has "Torch" in the name
            if (richTextBox6.Lines[5] != null)
            {
                textBox1.Text = richTextBox6.Lines[5];
            }
            else
            {
                goto next;
            }
            string path = textBox1.Text;
            string[] files = Directory.GetFiles(path, textBox2.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < warrnings.Length; x++)
                    {
                        string liney = warrnings.GetValue(x).ToString();
                        if (lines[i].Contains(liney))
                        {
                            richTextBox17.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (richTextBox18.Text == "")
                {
                    richTextBox18.Text = richTextBox17.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception)
            {
            }
            next:;
            FindNewWarrnings5();
        }
        private void FindNewWarrnings5()
        {

            //Incase richtextbox1 is empty, set richtextbox2 to richtextbox1 / this can Happen at Midnight when the server restarts
            if (richTextBox17.Text == "")
            {
                richTextBox18.Text = richTextBox17.Text;
            }
            if (richTextBox18.Text == "")
            {
                richTextBox18.Text = richTextBox17.Text;
            }

            Array warrnings2 = richTextBox4.Lines;
            //trim richtextbox1 by removing all lines that are in richtextbox2 then display the rest that contain "[WARN]" in richtextbox3
            string[] lines = richTextBox17.Lines;
            string[] lines2 = richTextBox18.Lines;
            int test = lines2.Length;
            int test2 = test -= 2;
            if (richTextBox18.Text != richTextBox17.Text)
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
                                    {
                                        richTextBox3.Text += richTextBox7.Lines[5] + ": " + lines[i] + Environment.NewLine;
                                        MsgQue(richTextBox7.Lines[5] + ": " + lines[i]);
                                        richTextBox18.Text = richTextBox17.Text;
                                        //every 100 lines clear richtextbox3
                                        if (richTextBox3.Lines.Length > 100)
                                        {
                                            richTextBox3.Text = "";
                                        }
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
            //Old Button
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SendMessage("Test for North Alert");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                FindWarrnings0();
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
                //send message from msgque arraylist
                SendMessage(msg);
                //remove messages that have been sent from the msgque arraylist so it doesnt send them again when the timer ticks again in 5 seconds time
                //wait 5 seconds
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
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
}

