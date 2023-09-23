using HtmlAgilityPack;
using System.Net;
using System.IO;
using System;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text.RegularExpressions;

namespace FileSaveApp
{
    public partial class Form1 : Form
    {
        public string tagText;
        string basePath = "D:\\WebScrapingForC#";
        string fileExtension = ".txt";
        string file_Path;



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

                    //指定タグの内容だけ抽出する
                    HtmlNodeCollection tagNodes = htmlNode.SelectNodes(selectTag);

                    if (tagNodes != null)
                    {
                        foreach (HtmlNode tagNode in tagNodes)
                        {
                            //InnerTextプロパティはタグを除去してくれる
                            tagText = Regex.Replace(tagNode.InnerText, "<[^>]*?>", "").Trim(); ;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー処理" + ex.Message);
            }

            if (tagText != null)
            {
                DialogResult result = MessageBox.Show("読み込みが完了しました、プレビューを表示しますか？", "選択", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PreViewForm preViewForm = new PreViewForm(this);
                    preViewForm.Show();
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            file_Path = GenerateNewFileName(basePath, fileExtension);
            CreateNewFile(file_Path);
        }



        private void CreateNewFile(string file_Path)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(file_Path))
                {
                    string dataToWrite = tagText;
                    writer.WriteLine(dataToWrite);

                }
                MessageBox.Show($"新しいファイルに保存されました：{file_Path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが出ました、ファイルは生成されていません。：{ex.Message}");
            }
        }


        private string GenerateNewFileName(string basePath, string fileExtension)
        {
            int count = 0;
            string file_Path = $"{basePath}{count}{fileExtension}";

            while (File.Exists(file_Path))
            {
                count++;
                file_Path = $"{basePath}{count}{fileExtension}";
            }

            return file_Path;
        }
    }
}

