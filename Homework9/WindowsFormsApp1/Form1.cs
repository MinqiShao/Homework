using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Crawler crawler = new Crawler();
        
        public string StartUrl { get; set; }
        public Form1()
        {
            InitializeComponent();
            startUrlBox.DataBindings.Add("Text", this, "StartUrl");

            crawler.CrawlerStopped += Crawler_Stopped;
            crawler.PageDownloaded += Page_Downloaded;

        }

        private void Crawler_Stopped(Crawler obj)
        {
            Action action = new Action(() => stateLabel.Text = "爬虫已停止");
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void Page_Downloaded(Crawler crawler,string url,string state)
        {
            var result = new {Num= resultBindingSource.Count+1, Url=url,State=state};
            Action action = new Action(() => resultBindingSource.Add(result));
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        

        private void startButton_Click(object sender, EventArgs e)
        {
            crawler.StartUrl = this.StartUrl;

            Match match = Regex.Match(crawler.StartUrl, crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = "((.html?|.aspx|.jsp|.php)$|^[^.]+$)";

            //successListBox.Items.Add("爬虫已启动....");
            new Thread(crawler.Start).Start();
        }
    }
}
