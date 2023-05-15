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
using System.Reflection;

namespace NorthAlert
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
            Real_Keywords_Richtext.Text = Keywords_Richtext.Text;
            NorthAlert.Properties.Settings.Default.DisURL = Webhook_Textbox.Text;
            NorthAlert.Properties.Settings.Default.Logs = CurrentPath_Textbox.Text;
            NorthAlert.Properties.Settings.Default.botname = ServerBoxname_Textbox.Text;
            NorthAlert.Properties.Settings.Default.Botpic = BotPicture_Textbox.Text;
            NorthAlert.Properties.Settings.Default.Keywords = Real_Keywords_Richtext.Text;
            NorthAlert.Properties.Settings.Default.Autorun = Run_checkBox.Checked;
            NorthAlert.Properties.Settings.Default.logname = OldLogname_Textbox.Text;
            NorthAlert.Properties.Settings.Default.FileDisc = FileDescription_RichText.Text;
            NorthAlert.Properties.Settings.Default.FileLogs = LogFileDir_RichText.Text;
            NorthAlert.Properties.Settings.Default.DisPing = PingList_Richtext.Text;
            NorthAlert.Properties.Settings.Default.Save();
        }
        //------------------------------------------------- new Find keywords -------------------------------------------------------
        private void FindWarrningsWritetofile()
        {
            try
            {
                Array LogfileName = LogFileName_RichText.Lines;
                

                for (int a = 0; a < LogfileName.Length; a++)
                {
                    Array LogFileDir = LogFileDir_RichText.Lines;
                    for (int b = 0; b < LogFileDir.Length; b++)
                    {
                        string path = LogFileDir.GetValue(b).ToString();
                        string[] files = Directory.GetFiles(path, LogfileName.GetValue(a).ToString());
                        string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
                        path = lastModifiedFile;
                        // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
                        if (System.IO.File.Exists(path))
                        {
                            string[] lines = System.IO.File.ReadAllLines(path);
                            try
                            {
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    for (int x = 0; x < Real_Keywords_Richtext.Lines.Length; x++)
                                    {
                                        string key = Real_Keywords_Richtext.Lines.GetValue(x).ToString();
                                        if (lines[i].Contains(key))
                                        {
                                            LogfileWarning_0_RichText.Text += lines[i] + Environment.NewLine;
                                            
                                        }
                                    }
                                }
                                if (CompareLogfileWarning_0_RichText.Text == "")
                                {
                                    CompareLogfileWarning_0_RichText.Text = LogfileWarning_0_RichText.Text;
                                }
                                else
                                {
                                    goto next;
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                                goto next;
                            }
                            next:;
                        }
                    }

                }
                Thread.SpinWait(100);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            NewFindNewWarrnings0();

        }

        private void FindWarrnings0()
        {

            timer1.Stop();
            LogfileWarning_0_RichText.Text = "";
            Array keywords = Real_Keywords_Richtext.Lines;
            //find last motified .log file in directory that has "Torch" in the name
                 if (LogFileDir_RichText.Lines.Length > 0)
            {
                CurrentPath_Textbox.Text = LogFileDir_RichText.Lines[0];
            }
            else
            {
                goto next;
            }
            string path = CurrentPath_Textbox.Text;
            string[] files = Directory.GetFiles(path, OldLogname_Textbox.Text);
            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
            path = lastModifiedFile;
            // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a Richtextbox1
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {

                    for (int x = 0; x < keywords.Length; x++)
                    {
                        string key = keywords.GetValue(x).ToString();
                        if (lines[i].Contains(key))
                        {
                            LogfileWarning_0_RichText.Text += lines[i] + Environment.NewLine;
                        }
                    }
                }
                if (CompareLogfileWarning_0_RichText.Text == "")
                {
                    CompareLogfileWarning_0_RichText.Text = LogfileWarning_0_RichText.Text;
                }
                else
                {
                    goto next;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            next:
            NewFindNewWarrnings0();
        }



    //--------------------------------------------------- Find Keywords 0 -------------------------------------------------------

        private void NewFindNewWarrnings0()
        {
            try
            {
                Array keywords = Real_Keywords_Richtext.Lines;
                String Server = FileDescription_RichText.Lines[0];
                // compare two listList<string> lines = richTextBox1.Lines.ToList();
                List<string> lines = LogfileWarning_0_RichText.Lines.ToList();
                List<string> lines2 = CompareLogfileWarning_0_RichText.Lines.ToList();
                List<string> newlines = lines.Except(lines2).ToList();
                for (int i = 0; i < newlines.Count; i++)
                {
                    for (int x = 0; x < keywords.Length; x++)
                    {
                        string key = keywords.GetValue(x).ToString();
                        if (newlines[i].Contains(key))
                        {
                            OutputDisocrd_RichText.Text += Server + ": " + newlines[i] + Environment.NewLine;
                            CompareLogfileWarning_0_RichText.Text = LogfileWarning_0_RichText.Text;
                            MsgQue(Server + ": " + newlines[i]);
                            //every 100 lines clear richtextbox3
                            if (OutputDisocrd_RichText.Lines.Length > 100)
                            {
                                OutputDisocrd_RichText.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //FindWarrnings0();
            timer1.Start();
        }
        ////--------------------------------------------------- Find Keywords 1 -------------------------------------------------------
        //private void FindWarrnings1()
        //{
        //    richTextBox8.Text = "";
        //    Array keywords = richTextBox4.Lines;
        //    //find last motified .log file in directory that has "Torch" in the name
        //    if (richTextBox6.Lines.Length > 1)
        //    {
        //        textBox1.Text = richTextBox6.Lines[1];
        //    }
        //    else
        //    {
        //        goto next;
        //    }
        //    string path = textBox1.Text;
        //    string[] files = Directory.GetFiles(path, textBox2.Text);
        //    string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
        //    path = lastModifiedFile;
        //    // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a richTextBox8
        //    string[] lines = System.IO.File.ReadAllLines(path);
        //    try
        //    {
        //        for (int i = 0; i < lines.Length; i++)
        //        {

        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (lines[i].Contains(key))
        //                {
        //                    richTextBox8.Text += lines[i] + Environment.NewLine;
        //                }
        //            }
        //        }
        //        if (richTextBox9.Text == "")
        //        {
        //            richTextBox9.Text = richTextBox8.Text;
        //        }
        //        else
        //        {
        //            goto next;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    next:
        //    NewFindNewWarrnings1();

        //}

        //private void NewFindNewWarrnings1()
        //{
        //    try
        //    {
        //        Array keywords = richTextBox4.Lines;
        //        String Server = richTextBox7.Lines[1];
        //        // compare two listList<string> lines = richTextBox8.Lines.ToList();
        //        List<string> lines = richTextBox8.Lines.ToList();
        //        List<string> lines2 = richTextBox9.Lines.ToList();
        //        List<string> newlines = lines.Except(lines2).ToList();
        //        for (int i = 0; i < newlines.Count; i++)
        //        {
        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (newlines[i].Contains(key))
        //                {
        //                    richTextBox3.Text += Server + ": " + newlines[i] + Environment.NewLine;
        //                    richTextBox9.Text = richTextBox8.Text;
        //                    MsgQue(Server + ": " + newlines[i]);
        //                    //every 100 lines clear richtextbox3
        //                    if (richTextBox3.Lines.Length > 100)
        //                    {
        //                        richTextBox3.Text = "";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    FindWarrnings2();
        //}

        ////--------------------------------------------------- Find Keywords 2 -------------------------------------------------------

        //private void FindWarrnings2()
        //{
        //    richTextBox11.Text = "";
        //    Array keywords = richTextBox4.Lines;
        //    //find last motified .log file in directory that has "Torch" in the name
        //    if (richTextBox6.Lines.Length > 2)
        //    {
        //        textBox1.Text = richTextBox6.Lines[2];
        //    }
        //    else
        //    {
        //        goto next;
        //    }
        //    string path = textBox1.Text;
        //    string[] files = Directory.GetFiles(path, textBox2.Text);
        //    string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
        //    path = lastModifiedFile;
        //    // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a richTextBox11
        //    string[] lines = System.IO.File.ReadAllLines(path);
        //    try
        //    {
        //        for (int i = 0; i < lines.Length; i++)
        //        {

        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (lines[i].Contains(key))
        //                {
        //                    richTextBox11.Text += lines[i] + Environment.NewLine;
        //                }
        //            }
        //        }
        //        if (richTextBox12.Text == "")
        //        {
        //            richTextBox12.Text = richTextBox11.Text;
        //        }
        //        else
        //        {
        //            goto next;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    next:
        //    NewFindNewWarrnings2();

        //}

        //private void NewFindNewWarrnings2()
        //{
        //    try
        //    {
        //        Array keywords = richTextBox4.Lines;
        //        String Server = richTextBox7.Lines[2];
        //        // compare two listList<string> lines = richTextBox11.Lines.ToList();
        //        List<string> lines = richTextBox11.Lines.ToList();
        //        List<string> lines2 = richTextBox12.Lines.ToList();
        //        List<string> newlines = lines.Except(lines2).ToList();
        //        for (int i = 0; i < newlines.Count; i++)
        //        {
        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (newlines[i].Contains(key))
        //                {
        //                    richTextBox3.Text += Server + ": " + newlines[i] + Environment.NewLine;
        //                    richTextBox12.Text = richTextBox11.Text;
        //                    MsgQue(Server + ": " + newlines[i]);
        //                    //every 100 lines clear richtextbox3
        //                    if (richTextBox3.Lines.Length > 100)
        //                    {
        //                        richTextBox3.Text = "";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    FindWarrnings3();
        //}


        //private void FindWarrnings3()
        //{
        //    richTextBox13.Text = "";
        //    Array keywords = richTextBox4.Lines;
        //    //find last motified .log file in directory that has "Torch" in the name
        //    if (richTextBox6.Lines.Length > 3)
        //    {
        //        textBox1.Text = richTextBox6.Lines[3];
        //    }
        //    else
        //    {
        //        goto next;
        //    }
        //    string path = textBox1.Text;
        //    string[] files = Directory.GetFiles(path, textBox2.Text);
        //    string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
        //    path = lastModifiedFile;
        //    // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a richTextBox13
        //    string[] lines = System.IO.File.ReadAllLines(path);
        //    try
        //    {
        //        for (int i = 0; i < lines.Length; i++)
        //        {

        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (lines[i].Contains(key))
        //                {
        //                    richTextBox13.Text += lines[i] + Environment.NewLine;
        //                }
        //            }
        //        }
        //        if (richTextBox14.Text == "")
        //        {
        //            richTextBox14.Text = richTextBox13.Text;
        //        }
        //        else
        //        {
        //            goto next;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    next:
        //    NewFindNewWarrnings3();

        //}

        //private void NewFindNewWarrnings3()
        //{
        //    try
        //    {
        //        Array keywords = richTextBox4.Lines;
        //        String Server = richTextBox7.Lines[3];
        //        // compare two listList<string> lines = richTextBox13.Lines.ToList();
        //        List<string> lines = richTextBox13.Lines.ToList();
        //        List<string> lines2 = richTextBox14.Lines.ToList();
        //        List<string> newlines = lines.Except(lines2).ToList();
        //        for (int i = 0; i < newlines.Count; i++)
        //        {
        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (newlines[i].Contains(key))
        //                {
        //                    richTextBox3.Text += Server + ": " + newlines[i] + Environment.NewLine;
        //                    richTextBox14.Text = richTextBox13.Text;
        //                    MsgQue(Server + ": " + newlines[i]);
        //                    //every 100 lines clear richtextbox3
        //                    if (richTextBox3.Lines.Length > 100)
        //                    {
        //                        richTextBox3.Text = "";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    FindWarrnings4();
        //}
        //private void FindWarrnings4()
        //{
        //    richTextBox15.Text = "";
        //    Array keywords = richTextBox4.Lines;
        //    //find last motified .log file in directory that has "Torch" in the name
        //    if (richTextBox6.Lines.Length > 4)
        //    {
        //        textBox1.Text = richTextBox6.Lines[4];
        //    }
        //    else
        //    {
        //        goto next;
        //    }
        //    string path = textBox1.Text;
        //    string[] files = Directory.GetFiles(path, textBox2.Text);
        //    string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
        //    path = lastModifiedFile;
        //    // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a richTextBox15
        //    string[] lines = System.IO.File.ReadAllLines(path);
        //    try
        //    {
        //        for (int i = 0; i < lines.Length; i++)
        //        {

        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (lines[i].Contains(key))
        //                {
        //                    richTextBox15.Text += lines[i] + Environment.NewLine;
        //                }
        //            }
        //        }
        //        if (richTextBox16.Text == "")
        //        {
        //            richTextBox16.Text = richTextBox15.Text;
        //        }
        //        else
        //        {
        //            goto next;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    next:
        //    NewFindNewWarrnings4();

        //}

        //private void NewFindNewWarrnings4()
        //{
        //    try
        //    {
        //        Array keywords = richTextBox4.Lines;
        //        String Server = richTextBox7.Lines[4];
        //        // compare two listList<string> lines = richTextBox15.Lines.ToList();
        //        List<string> lines = richTextBox15.Lines.ToList();
        //        List<string> lines2 = richTextBox16.Lines.ToList();
        //        List<string> newlines = lines.Except(lines2).ToList();
        //        for (int i = 0; i < newlines.Count; i++)
        //        {
        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (newlines[i].Contains(key))
        //                {
        //                    richTextBox3.Text += Server + ": " + newlines[i] + Environment.NewLine;
        //                    richTextBox16.Text = richTextBox15.Text;
        //                    MsgQue(Server + ": " + newlines[i]);
        //                    //every 100 lines clear richtextbox3
        //                    if (richTextBox3.Lines.Length > 100)
        //                    {
        //                        richTextBox3.Text = "";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    FindWarrnings5();
        //}

        //private void FindWarrnings5()
        //{
        //    richTextBox17.Text = "";
        //    Array keywords = richTextBox4.Lines;
        //    //find last motified .log file in directory that has "Torch" in the name
        //    if (richTextBox6.Lines.Length > 5)
        //    {
        //        textBox1.Text = richTextBox6.Lines[5];
        //    }
        //    else
        //    {
        //        goto next;
        //    }
        //    string path = textBox1.Text;
        //    string[] files = Directory.GetFiles(path, textBox2.Text);
        //    string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
        //    path = lastModifiedFile;
        //    // Read all lines in .log file, find lines that contain any word in richtextbox4 and display them in a richTextBox17
        //    string[] lines = System.IO.File.ReadAllLines(path);
        //    try
        //    {
        //        for (int i = 0; i < lines.Length; i++)
        //        {

        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (lines[i].Contains(key))
        //                {
        //                    richTextBox17.Text += lines[i] + Environment.NewLine;
        //                }
        //            }
        //        }
        //        if (richTextBox18.Text == "")
        //        {
        //            richTextBox18.Text = richTextBox17.Text;
        //        }
        //        else
        //        {
        //            goto next;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    next:
        //    NewFindNewWarrnings5();

        //}

        //private void NewFindNewWarrnings5()
        //{
        //    try
        //    {
        //        Array keywords = richTextBox4.Lines;
        //        String Server = richTextBox7.Lines[5];
        //        // compare two listList<string> lines = richTextBox17.Lines.ToList();
        //        List<string> lines = richTextBox17.Lines.ToList();
        //        List<string> lines2 = richTextBox18.Lines.ToList();
        //        List<string> newlines = lines.Except(lines2).ToList();
        //        for (int i = 0; i < newlines.Count; i++)
        //        {
        //            for (int x = 0; x < keywords.Length; x++)
        //            {
        //                string key = keywords.GetValue(x).ToString();
        //                if (newlines[i].Contains(key))
        //                {
        //                    richTextBox3.Text += Server + ": " + newlines[i] + Environment.NewLine;
        //                    richTextBox18.Text = richTextBox17.Text;
        //                    MsgQue(Server + ": " + newlines[i]);
        //                    //every 100 lines clear richtextbox3
        //                    if (richTextBox3.Lines.Length > 100)
        //                    {
        //                        richTextBox3.Text = "";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    timer1.Start();
        //}
        //---------------------------------------------------------------------Bottom-----------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            NorthAlert.Properties.Settings.Default.Reload();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SendMessage("Test for North Alert");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Run_checkBox.Checked == true)
            {
                FindWarrningsWritetofile();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                timer1.Start();
            //load settings
            Webhook_Textbox.Text = NorthAlert.Properties.Settings.Default.DisURL;
            CurrentPath_Textbox.Text = NorthAlert.Properties.Settings.Default.Logs;
            ServerBoxname_Textbox.Text = NorthAlert.Properties.Settings.Default.botname;
            BotPicture_Textbox.Text = NorthAlert.Properties.Settings.Default.Botpic;
            Real_Keywords_Richtext.Text = NorthAlert.Properties.Settings.Default.Keywords;
            Keywords_Richtext.Text = Real_Keywords_Richtext.Text;
            OldLogname_Textbox.Text = NorthAlert.Properties.Settings.Default.logname;
            Run_checkBox .Checked = NorthAlert.Properties.Settings.Default.Autorun;
            LogFileDir_RichText.Text = NorthAlert.Properties.Settings.Default.FileLogs;
            FileDescription_RichText.Text = NorthAlert.Properties.Settings.Default.FileDisc;
            PingList_Richtext.Text = NorthAlert.Properties.Settings.Default.DisPing;



        }
        ArrayList msgque = new ArrayList();
        private void MsgQue(string msg2)
        {
            // need to slow down messages so they dont get sent to fast, discord has a 5 second cooldown, so i need to make it so it sends 1 message every 5 seconds
            // i need to make it so it sends the first message, then waits 5 seconds, then sends the next message, then waits 5 seconds, then sends the next message, etc
            // find if msg 2 contains value from richtextbox4
            Array warrnlist1 = Real_Keywords_Richtext.Lines;
            Array warrnlist2 = PingList_Richtext.Lines;
            try
            {
                msgque.Add(msg2);
                foreach (string msg3 in msgque)
                {
                    for (int k = 0; k < warrnlist1.Length; k++)
                    {
                        string line = warrnlist1.GetValue(k).ToString();

                        if (msg3.Contains(line))
                        {
                            if (warrnlist2.Length > k)
                            {
                                string msg01 = "<@" + warrnlist2.GetValue(k).ToString() + "> " + msg3;

                                if (msg01.Contains("<@>"))
                                {
                                    SendMessage(msg3);
                                    msgque.Remove(msg3);
                                    goto done;
                                }
                                else
                                {
                                    SendMessage(msg01);
                                    msgque.Remove(msg3);
                                    goto done;
                                }
                            }
                            else
                            {
                                SendMessage(msg3);
                                msgque.Remove(msg3);
                                goto done;
                            }
                        }
                    }
                }
                //send message from msgque arraylist
                SendMessage(msg2);
                msgque.Remove(msg2);

                done:
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SendMessage(string Dmessage)
        {
            try
            {
                {
                    Message = Dmessage;
                    WebhookURL = Webhook_Textbox.Text;

                    Http.Post(WebhookURL, new NameValueCollection()
            {
                { "username", "North Alert: " + ServerBoxname_Textbox.Text },
                { "avatar_url", BotPicture_Textbox.Text },
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

