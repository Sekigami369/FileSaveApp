using HtmlAgilityPack;
using System.Net;
using System.IO;
using System;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace FileSaveApp
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string htmlTag = textBox2.Text;
            string selectTag = "//" + htmlTag;

            //ファイルがすでにある場合はここに値を入れる
            //もしくは完全にファイルを新規製作したものに保存するようにするかも
            string file_Path = "";

            try
            {
                using (WebClient client = new WebClient())
                {
                    //htmlContentにはHTMLデータが格納されている
                    string htmlContent = client.DownloadString(url);

                    //HtmlDocumentはHTMLを解析と操作を行う
                    HtmlDocument htmlDoc = new HtmlDocument();

                    //LoadHtmlはHTMLを解析してhtmlDoc にDOMツリーを構築する
                    htmlDoc.LoadHtml(htmlContent);

                    HtmlNode htmlNode = htmlDoc.DocumentNode;

                    //<body>の内容だけ抽出する
                    HtmlNodeCollection tagNodes = htmlNode.SelectNodes(selectTag);

                    if (tagNodes != null)
                    {
                        foreach (HtmlNode tagNode in tagNodes)
                        {
                            //InnerTextプロパティはタグを除去してくれる
                            string tagText = tagNode.InnerText;
                            File.WriteAllText(file_Path, tagText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー処理" + ex.Message);
            }
        }
    }
}

/*指定したURLのテキストを保存して
 * 自動でファイルを生成して
 * 自動でファイルに保存する
 * タグを指定して特定のテキストのみ保存する機能も
 * 作れたら追加する
 */