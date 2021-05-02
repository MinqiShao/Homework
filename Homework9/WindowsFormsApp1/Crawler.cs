using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

/*（1）只爬取某个指定网站上的网页 
 （2）只有当爬取的是html / html / aspx / jsp等网页时，才解析并爬取下一级URL。
 （3）相对地址(test / page.html, ./ test / page.html, .. / test2 / page2.html, / test3 / page.html)转成完整地址进行爬取。
 （4） 尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。*/

//未下载集合为空？
//取出一个链接，加入已下载   urls[url]=true
//发送http请求（download）
//接收服务器相应
//接收数据，保存页面文件
//提取页面链接并过滤，加入未下载队列


namespace WindowsFormsApp1
{
    public class Crawler
    {
        public Hashtable urls = new Hashtable();  //key是url,value：是否下载
        private int count = 0;
        public string current;
        public string HostFilter { get; set; }  //主机过滤规则
        public string FileFilter { get; set; }  //文件过滤规则
        public string StartUrl { get; set; }    //起始网址
        public int MaxPage { get; set; }        //最大下载数量

        private Queue<string> pending = new Queue<string>();//待下载队列

        //查找url
        public string urlFindRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        //解析url
        public string urlParseRegex= @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";

        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler,string,string> PageDownloaded;



        public Crawler()
        {
            MaxPage = 100;
        }

        public void Start()
        {
            Console.WriteLine("开始爬行...");
            urls.Clear();
            pending.Clear();
            pending.Enqueue(StartUrl);

            while (urls.Count<MaxPage&&pending.Count>0)
            {
                string url = pending.Dequeue();
                try
                {
                    urls[url] = true;             //1、加入已下载
                    string html = DownLoad(url);  //2、下载    并同时获得新连接html
                    current = url;
                    PageDownloaded(this,url,"success");      //在winform中显示url
                    Parse(html, url);          //6、过滤新链接html，并加入未下载队列
                }
                catch(Exception e)
                {
                    PageDownloaded(this, url, "fail");
                }
            }
            //Console.WriteLine("爬行结束");
            CrawlerStopped(this);
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);   //3、接受服务器响应，接收数据
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);  //4、保存页面文件
                return html;                                     //5、新页面链接
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html,string pageUrl)
        {
            MatchCollection matches = new Regex(urlFindRegex).Matches(html);
            foreach (Match match in matches)
            {
                string url = match.Groups["url"].Value;
                if (url == null || url == "") continue;
                url = ChangeUrl(url, pageUrl);    //转绝对地址

                Match urlMatch = Regex.Match(url, urlParseRegex);
                string host = urlMatch.Groups["host"].Value;
                string file= urlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";

                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter))
                {
                    if (!urls.ContainsKey(url))
                    {
                        urls.Add(url, false);
                        pending.Enqueue(url);     //加入未下载队列
                    }
                }
            }
        }

        public string ChangeUrl(string url,string pageUrl)  //相对路径转绝对路径
        {
            if (url.Contains("://"))
                return url;
            if (url.StartsWith("//"))
                return "http:" + url;
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex .Match(pageUrl, urlParseRegex);
                string site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }
            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return ChangeUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return ChangeUrl(url.Substring(2), pageUrl);
            }

            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }
    }
}

