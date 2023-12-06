using ComponentFactory.Krypton.Ribbon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthAlert
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------- Todo list ------------------------------------------------------------------------------
        //

        //
        //      what should the big button do?  (go to settings page with a debug option or title menu check box)
        //
        //      update UI out ?
        //
        //
        //--------------------------------------------------------------------------- Memory Management Start ------------------------------------------------------------------------------
        private void MainWindowK_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //load settings
            Webhook_Textbox.Text = NorthAlert.Properties.Settings.Default.DisURL;
            ServerBoxname_Textbox.Text = NorthAlert.Properties.Settings.Default.botname;
            BotPicture_Textbox.Text = NorthAlert.Properties.Settings.Default.Botpic;
            Run_checkBox.Checked = NorthAlert.Properties.Settings.Default.Autorun;
            LogFileDir_RichText.Text = NorthAlert.Properties.Settings.Default.FileLogs;
            FileDescription_RichText.Text = NorthAlert.Properties.Settings.Default.FileDisc;
            PingList_Richtext.Text = NorthAlert.Properties.Settings.Default.DisPing;
            Keywords_Richtext.Text = NorthAlert.Properties.Settings.Default.Keywords;
            Exclude_richTextBox.Text = NorthAlert.Properties.Settings.Default.Excludelist;
            LogFileName_RichText.Text = NorthAlert.Properties.Settings.Default.logname;
            Cooldown_Textbox.Value = NorthAlert.Properties.Settings.Default.Cooldown;
        }
        private void Save_Button(object sender, EventArgs e)
        {
            //save settings
            NorthAlert.Properties.Settings.Default.DisURL = Webhook_Textbox.Text;
            NorthAlert.Properties.Settings.Default.botname = ServerBoxname_Textbox.Text;
            NorthAlert.Properties.Settings.Default.Botpic = BotPicture_Textbox.Text;
            NorthAlert.Properties.Settings.Default.Autorun = Run_checkBox.Checked;
            NorthAlert.Properties.Settings.Default.FileDisc = FileDescription_RichText.Text;
            NorthAlert.Properties.Settings.Default.FileLogs = LogFileDir_RichText.Text;
            NorthAlert.Properties.Settings.Default.DisPing = PingList_Richtext.Text;
            NorthAlert.Properties.Settings.Default.Keywords = Keywords_Richtext.Text;
            NorthAlert.Properties.Settings.Default.Excludelist = Exclude_richTextBox.Text;
            NorthAlert.Properties.Settings.Default.logname = LogFileName_RichText.Text;
            NorthAlert.Properties.Settings.Default.Cooldown = ((int)Cooldown_Textbox.Value);
            NorthAlert.Properties.Settings.Default.Save();
        }
        //--------------------------------------------------------------------------- Memory Management End ------------------------------------------------------------------------------
        public List<string> logData;
        public List<string> comparelogData;
        public ArrayList Uiout = new ArrayList();
        public string DIR;
        public string Ext;
        public String Server;
        public string Comfile;
        public string[] ComData;
        public Array keywords;
        public Array Exclude;
        public Array PingList;
        public string[] Serverdir;
        public string[] Filetypes;
        public string[] ServerS;
        private static string WebhookURL = "";
        private static string Message = "";
        ArrayList msgque = new ArrayList();
        public int RunCount = 0;
        public int Open = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Run_checkBox.Checked == true)
            {
                Starter();
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
        public void Starter()
        {
            Uioutput("NorthAlert: Starting");
            Filetypes = this.LogFileName_RichText.Lines;
            Serverdir = this.LogFileDir_RichText.Lines;
            ServerS = this.FileDescription_RichText.Lines;
            Exclude = this.Exclude_richTextBox.Lines;
            keywords = this.Keywords_Richtext.Lines;
            PingList = this.PingList_Richtext.Lines;
            this.timer1.Stop();
            logData = new List<string>();
            kryptonHeaderGroup1.ValuesSecondary.Heading = "Check Count: " + RunCount.ToString();
            RunCount++;
            Go();
        }
        //--------------------------------------------------------------------------- Run ------------------------------------------------------------------------------
        private async void Go()
        {
            int maxAttempts = 26; // Set the maximum number of attempts
            int attempt = 1;
            tryagain:;
            try
            {
                for (int a = 0; a < Filetypes.Length; a++)
                {
                    Ext = Filetypes[a];
                    //Uioutput("NorthAlert: Check for file type: " + Filetypes[a]);
                    for (int b = 0; b < Serverdir.Length; b++)
                    {
                        DIR = Serverdir[b];
                        Server = ServerS[b];
                        //Uioutput("NorthAlert: Directory is: " + Serverdir[b]);
                        //Uioutput("NorthAlert: Server is: " + ServerS[b]);

                        if (Ext != null && DIR != null && Server != null)
                        {
                            string path = DIR;
                            string napath = DIR + "\\NA\\";
                            string napathfail = DIR + "\\NA";
                            if (!Directory.Exists(napathfail))
                            {
                                Directory.CreateDirectory(napathfail);
                            }
                            Uioutput("NorthAlert:Add Task: " + Server + " : " + DIR + " : " + Ext);
                            //tasks.Add(PullData(Ext, DIR, Server));

                            
                            string[] files = Directory.GetFiles(path, Ext);
                            string[] nafiles = Directory.GetFiles(napath, Ext);
                            List<string> Filesdata = files.Where(file => !file.Contains("\\NA\\")).ToList();
                            files = Filesdata.ToArray();
                            string lastModifiedFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
                            string Newpath;
                            string[] Grabfilename = lastModifiedFile.Split('\\');
                            //MessageBox.Show(napath + Grabfilename.Last());
                            //string nalastModifiedFile = nafiles.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();
                            string nalastModifiedFile = napath + Grabfilename.Last();
                            string NANewpath;

                            if (lastModifiedFile != null && nalastModifiedFile != null)
                            {
                                Newpath = lastModifiedFile;
                                NANewpath = nalastModifiedFile;
                                Uioutput("NorthAlert: Pulling Data From - " + Newpath);

                                if (File.Exists(Newpath))
                                {
                                    if (File.Exists(NANewpath))
                                    {
                                        FileInfo file1Info = new FileInfo(Newpath);
                                        FileInfo file2Info = new FileInfo(NANewpath);
                                        DateTime lastWriteTime1 = file1Info.LastWriteTime;
                                        DateTime lastWriteTime2 = file2Info.LastWriteTime;
                                        int result = DateTime.Compare(lastWriteTime1, lastWriteTime2);

                                        if (result < 0)
                                        {
                                            Uioutput("NorthAlert: wtf? how is is the clone newer then the orgin ");
                                        }
                                        else if (result > 0)
                                        {
                                            //Console.WriteLine($"{filePath1} was last written after {filePath2}.");
                                            string[] filelines = System.IO.File.ReadAllLines(Newpath);
                                            string[] nafilelines = System.IO.File.ReadAllLines(NANewpath);
                                            Uioutput("NorthAlert: Compare New data vs old data" + Newpath + " VS. " + NANewpath);
                                            List<string> lines = filelines.ToList();
                                            List<string> lines2 = nafilelines.ToList();
                                            List<string> newlines = lines.Except(lines2).ToList();
                                            Uioutput("NorthAlert: Logdata - Compare Data = NewLines " + newlines.Count);
                                            File.Copy(Newpath, nalastModifiedFile, true);

                                            for (int i = 0; i < newlines.Count; i++)
                                            {
                                                for (int x = 0; x < keywords.Length; x++)
                                                {
                                                    string key = keywords.GetValue(x).ToString();
                                                    if (newlines[i].Contains(key))
                                                    {
                                                        string lineout = "**" + Server + " : " + Grabfilename.Last() + "** - " + newlines[i];
                                                        Uioutput(lineout);
                                                        //Uioutput("NorthAlert: Sending line to que ");
                                                        await MsgQueAsync(lineout);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Uioutput("NorthAlert: No new data :(");
                                            goto done;
                                        }
                                        //--------------------------------------------------------------------------- Catching Errrors ------------------------------------------------------------------------------
                                    }
                                    else
                                    {
                                        // File does not exist, handle accordingly
                                        Uioutput("NorthAlert: 1strun? - updating NA folder ");
                                        try
                                        {
                                            File.Copy(Newpath, nalastModifiedFile, true);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }

                                }
                                else
                                {
                                    Uioutput("NorthAlert: This path does not Exist: " + Newpath);
                                }
                            }
                            else
                            {
                                Uioutput("NorthAlert: No files found for extension: " + Ext);
                                if (lastModifiedFile != null)
                                {
                                    File.Copy(lastModifiedFile, nalastModifiedFile, true);
                                }
                                goto done;
                            }
                        }
                        done:;
                    }
                }
            }
            catch (IOException)
            {

                if (attempt < maxAttempts)
                {
                    Uioutput("NorthAlert: Failed to open file, Trying agian...  Try: " + attempt);

                    Task.Delay(1000).Wait();
                    attempt++;
                    RunCount++;
                    goto tryagain;
                }
                else
                {
                    Run_checkBox.Checked = false;
                    Uioutput("NorthAlert: ERROR: Unable to open the file " + Ext + " in " + DIR + " after multiple attempts." + Environment.NewLine);
                    MessageBox.Show("Unable to open the file " + Ext + " in " + DIR + " after multiple attempts.");
                    goto PastError;
                    //return;
                }
            }
            catch (Exception ex)
            {
                string catchtest = ex.ToString();

                if (catchtest.Contains("The path is not of a legal form"))
                {
                    Run_checkBox.Checked = false;
                    Uioutput("NorthAlert: ERROR: Something wrong in the directories: (Blank Line or bad File directory?) " + Environment.NewLine + ex.Message);
                    MessageBox.Show("North Alert: Something wrong in the directories: (Blank Line or bad File directory? " + Environment.NewLine + ex.Message);
                    goto PastError;
                }
                if (catchtest.Contains("Sequence contains no elements"))
                {
                    Run_checkBox.Checked = false;
                    Uioutput("NorthAlert: ERROR: Something wrong in the Log file extensions: (Blank Line or bad file extension?) " + Environment.NewLine + ex.Message);
                    MessageBox.Show("North Alert: Something wrong in the Log file extensions: (Blank Line or bad file extension?) " + Environment.NewLine + ex.Message);
                    goto PastError;
                }
                if (catchtest.Contains("Index was outside the bounds of the array"))
                {
                    Run_checkBox.Checked = false;
                    Uioutput("NorthAlert: ERROR: Server list is empty or something?  " + Environment.NewLine + ex.Message);
                    MessageBox.Show("North Alert: ERROR: Server list is empty or something? " + Environment.NewLine + ex.Message);
                    goto PastError;
                }
                if (catchtest.Contains("Could not find a part of the path"))
                {
                    Run_checkBox.Checked = false;
                    Uioutput("NorthAlert: ERROR: Path not found  " + Environment.NewLine + ex.Message);
                    MessageBox.Show("North Alert: ERROR: Path not found " + Environment.NewLine + ex.Message);
                    goto PastError;
                }
                Run_checkBox.Checked = false;
                Uioutput("NorthAlert: ERROR: ? " + Environment.NewLine + ex.Message);
                MessageBox.Show(ex.Message);
            }
            PastError:;
            int CodeCoolDown = (((int)Cooldown_Textbox.Value) * 1000);
            await Task.Delay(CodeCoolDown);
            timer1.Start();
            //RunCount++;
        }

        //--------------------------------------------------------------------------- Bottom ------------------------------------------------------------------------------
        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            this.Close(); //4 tile menu X control box
        }
        //--------------------------------------------------------------------------- Drag the tile start  ------------------------------------------------------------------------------
        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        //--------------------------------------------------------------------------- Drag the tile end ------------------------------------------------------------------------------



        //--------------------------------------------------------------------------- Update UI text Start ------------------------------------------------------------------------------

        
            //Uiout.Add(Uioutlog);
           //UiUpdate(Uioutlog);
        

        private void Uioutput(string Uioutlog)
        {
            //this was going to be a list and a async task but yeah
            OutputDisocrd_RichText.Invoke((MethodInvoker)delegate
            {
                //OutputDisocrd_RichText.Text += UiSend + Environment.NewLine;
                OutputDisocrd_RichText.AppendText(Uioutlog + Environment.NewLine);

                if (OutputDisocrd_RichText.Lines.Length >= 100)
                {
                    //Debug log
                    if (MenuItem1.Checked == true)
                    {
                    string AppOutpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string Outpath = Directory.GetParent(AppOutpath).FullName;
                    string Outfile = "\\NA-Debug\\Debug.txt";
                        if (Directory.Exists(Outpath + "\\NA-Debug") == false)
                        {
                            Directory.CreateDirectory(Outpath + "\\NA-Debug");
                        }
                        else
                        {
                            
                            if (Open < 1)
                            {
                                System.Diagnostics.Process.Start(Outpath);
                                Open++;
                            }
                            File.AppendAllText(Outpath + Outfile, OutputDisocrd_RichText.Text);
                        }
                    }
                    OutputDisocrd_RichText.Text = "";
                }

            });
            //Uiout.Remove(Uisend);
        }
        //--------------------------------------------------------------------------- Update UI text End ------------------------------------------------------------------------------





        //--------------------------------------------------------------------------- Send Msgs external ------------------------------------------------------------------------------
        private void Discordtestbutton_Click(object sender, EventArgs e)
        {
            SendMessage("This is a Test msg for North Alert");
        }

        //ArrayList msgque = new ArrayList();
        private async Task MsgQueAsync(string msg2)
        {
            try
            {
                for (int h = 0; h < Exclude.Length; h++)
                {
                    string exkey = Exclude.GetValue(h).ToString();
                    if (msg2.ToString().Contains(exkey))
                    {
                        Uioutput("NorthAlert: Excluded Text: " + exkey + " Line: " + msg2);
                        msgque.Remove(msg2);

                        goto done;
                    }
                }
                msgque.Add(msg2);
                for (int j = 0; j < msgque.Count; j++)
                {
                    string msg3 = (string)msgque[j];

                    for (int k = 0; k < keywords.Length; k++)
                    {
                        string line = keywords.GetValue(k).ToString();

                        if (msg3.Contains(line))
                        {
                            if (PingList.Length > k)
                            {
                                string msg01 = "<@" + PingList.GetValue(k).ToString() + "> " + msg3;

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
                SendMessage(msg2);
                msgque.Remove(msg2);
                done:
                await Task.Delay(5000);
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

        private void OutputDisocrd_RichText_TextChanged(object sender, EventArgs e)
        {
            //OutputDisocrd_RichText.SelectionStart = OutputDisocrd_RichText.Text.Length;
            // scroll it automatically
            //OutputDisocrd_RichText.ScrollToCaret();
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
