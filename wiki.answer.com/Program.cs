using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiki.answer.com
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Helper.start();
            //CategoriesHelper.FilePath = "omid.txt";
            //CategoriesHelper.Start();
            //Console.ReadLine();
                //Console.WriteLine(i .ToString() + ":" + WebHelper.FetchData("http://wiki.answers.com/Q/FAQ").Length);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

    }
    public class Helper
    {
        public static void start()
        {
            var vList = GetCategories();
        }

        private static void DoforOneNode(string url)
        {
        }
        public static int CategoriesCount { get; set; }
        public static string FilePath { get; set; }

        public static object Locker = new object();
        private static string[] GetCategories()
        {
            HtmlAgilityPack.HtmlDocument doc = WebHelper.GetDocument("http://wiki.answers.com/Q/FAQ");

            if (doc == null || doc.DocumentNode == null) return new string[] { };
            var topics = doc.DocumentNode.SelectSingleNode("//dl[@class='topiclist']");
            var links = topics.SelectNodes(".//a[@class='internal']");
            var urlList = new List<string>();

            Parallel.ForEach(links, (item) =>
            {
                var newcats = getSubCategories(item.GetAttributeValue("href", ""));

                foreach (var cat in newcats)
                {
                    lock (Locker)
                    {
                        System.IO.File.AppendAllText(FilePath, cat + Environment.NewLine);
                    }
                    CategoriesCount++;
                }
                urlList.AddRange(newcats);
            });
            return urlList.ToArray();
        }

        private static List<string> getSubCategories(string Url)
        {
            Console.WriteLine(WebHelper.FileDownloaded);
            List<string> strs = new List<string>();
            strs.Add(Url);

            HtmlAgilityPack.HtmlDocument doc = WebHelper.GetDocument(Url);

            if (doc == null || doc.DocumentNode == null) return new List<string>();

            var subcat = doc.DocumentNode.SelectSingleNode("//div[@class='categoryHead']/ul[@class='subCats']");
            if ( subcat == null)
                return strs;


            var links = subcat.SelectNodes(".//a[@class='internal']");
            if (links == null) 
                return strs;

            Parallel.ForEach(links, item =>
            {
                strs.AddRange(getSubCategories(item.GetAttributeValue("href", "")));
            });
            
            return strs;
        }
    }
    public class WebHelper
    {
        public static string FetchData(string url, int i = 0)
        {
            if (!url.StartsWith("http")) url = "http://wiki.answers.com" + url;
            try
            {
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                req.Timeout = 30000;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.22 (KHTML, like Gecko) Chrome/25.0.1364.172 Safari/537.22";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                req.Headers.Add("Accept-Encoding: gzip,deflate,sdch");
                req.Headers.Add("Accept-Language: en-US,en;q=0.8,fa;q=0.6");
                req.AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip;
                using (System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse())
                {
                    System.IO.StreamReader reader = new StreamReader(res.GetResponseStream());
                    string str = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();
                    FileDownloaded++;
                    return str;
                }
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(100000);
                i++;
                if (i == 4) return "";
                return FetchData(url, i);
            }
        }
        public static HtmlAgilityPack.HtmlDocument GetDocument(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            var v = FetchData(url);
            if (v == "")
            {
                MissedFiles++;
                //addUrlsToMissed(url);
                return null;
            }
            doc.LoadHtml(v);
            return doc;
        }
        public static void addUrlsToMissed(string url, string type)
        {
            //MissedPage P = new MissedPage()
            //{
            //    Type = type,
            //    URLs = url
            //};
            //DataHelper.AddToMissedPage(P);
        }
        public static int MissedFiles { get; set; }
        public static int FileDownloaded { get; set; }
        public static int TotlaCategoryLink { get; set; }
        public static int FinishedCategoryLink { get; set; }
        public static int FinishedFiles { get; set; }
    }

    public class CategoriesHelper
    {
        public static string FilePath { get; set; }
        public static void
            Start()
        {
            Prepair();
            if (string.IsNullOrEmpty(FilePath))
            {
                return;
            }

            var Urls = FileHelper.LoadFile(FilePath);
            var doned = FileHelper.LoadFile("doed.txt");
            Urls = Urls.Where(aa => !doned.Contains(aa));

            Parallel.ForEach(Urls, (url) =>
            {
                DoJobForOneUrl(url);
                File.AppendAllText("doed.txt", url + Environment.NewLine);
            });

            return;
        }

        private static void Prepair()
        {
            if (File.Exists(QHelper.FilePath))
            {
                var newFilename = Path.Combine(new FileInfo(QHelper.FilePath).DirectoryName, Guid.NewGuid().ToString());
                Console.WriteLine(string.Format("The file {0} exist moved to {1}", QHelper.FilePath, newFilename));
                File.Move(QHelper.FilePath, newFilename);

            }
        }
        public static string FolderPath { get; set; }

        private static void DoJobForOneUrl(string url)
        {
            var doc = WebHelper.GetDocument(url);
            if (doc == null || doc.DocumentNode == null) return; //Error
            var titleN = doc.DocumentNode.SelectSingleNode("//div[@id='preFooter']");
            var TitleText = titleN == null ? "" : titleN.InnerText;

            while (true)
            {

                var ques = doc.DocumentNode.SelectNodes("//div[@id[starts-with(., 'qfaq_')]]");

                if (ques != null)
                {
                    foreach (var qa in ques)
                    {
                        var Q = qa.SelectSingleNode(".//b/a");
                        var A = qa.SelectSingleNode(".//p[@class='answersnippet']");
                        var Qstr = "";
                        var Astr = "";
                        var Qurl = "";
                        if (Q != null) { Qstr = Q.InnerText; Qurl = Q.GetAttributeValue("href", ""); }
                        else
                        {
                        }
                        if (A != null) { Astr = A.InnerText; }
                        else
                        {
                        }
                        if (string.IsNullOrWhiteSpace(Qstr)||
                            string.IsNullOrWhiteSpace(Qurl))
                        {
                        }
                        else
                        {
                            QHelper.AddQuetion(Qstr, Astr, TitleText, Qurl);
                        }
                    }
                }


                #region GetNext Url
                var nextUrl = doc.DocumentNode.SelectSingleNode("//a[@class='internal' and @title='Next']");

                if (nextUrl == null) break;

                url = nextUrl.GetAttributeValue("href", "");
                if (string.IsNullOrEmpty(url)) break;

                doc = WebHelper.GetDocument(url);
                #endregion


            }
        }
    }

    public class FileHelper
    {
        internal static IEnumerable<string> LoadFile(string FilePath)
        {
            if (!File.Exists(FilePath)) yield break;
            using (var stramReader = File.OpenText(FilePath))
            {
                var strs = stramReader.ReadToEnd();
                foreach (var item in strs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    yield return item;
                }
            }
        }
    }

    public class QHelper
    {
        public static string FilePath = "C://Scrap";
        public static string currentFilePath = "C://Scrap.csv";
        public static object xyz = new object();
        public static int QuetionPerFile = 500000;
        public static int CurrentQuetionCount = 0;

        public static void AddQuetion(string Qstr, string Astr, string TitleText, string url)
        {
            if (CurrentQuetionCount % QuetionPerFile == 0)
            {
                var tmp = FilePath.Replace(".csv", "");
                currentFilePath = tmp + "/file_" + (CurrentQuetionCount / QuetionPerFile).ToString() + ".csv";
            }

            CurrentQuetionCount++;


            List<QuetionData> ps = new List<QuetionData>();
            if (!url.StartsWith("http")) url = "http://wiki.answers.com" + url;
            if (Astr.EndsWith("..."))
            {
                //Astr = GetFullAnswer(url);
            }
            ps.Add(new QuetionData()
            {
                Answer = Astr,
                Category = TitleText.Replace("&gt;", ">"),
                DateScraped = DateTime.Now,
                Quetion = Qstr,
                Url = url
            });
            CsvExport<QuetionData> E = new CsvExport<QuetionData>(ps);
            lock (xyz)
            {
                E.ExportToFile(currentFilePath, false);
            }
        }
        private static string GetFullAnswer(string url)
        {
            try
            {
                var doc = WebHelper.GetDocument(url);
                if (doc == null || doc.DocumentNode == null) return "";
                var d = doc.DocumentNode.SelectSingleNode("//div[@class='answer_text']");

                if (d == null) return "";
                else return d.InnerText;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
    public class CsvExport<T> where T : class
    {
        public List<T> Objects;

        public CsvExport(List<T> objects)
        {
            Objects = objects;
        }

        public string Export()
        {
            return Export(true);
        }

        public string Export(bool includeHeaderLine)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                //Get properties using reflection.
                IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

                if (includeHeaderLine)
                {
                    //add header line.
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(propertyInfo.Name).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }

                //add value for each property.
                foreach (T obj in Objects)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        //export to a file.
        public void ExportToFile(string path, bool bIncludeHeader)
        {
            File.AppendAllText(path, Export(bIncludeHeader));
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }

    public class QuetionData
    {
        public string Url { get; set; }
        public string Quetion { get; set; }
        public string Category { get; set; }
        public string Answer { get; set; }
        public DateTime DateScraped { get; set; }
    }


}
