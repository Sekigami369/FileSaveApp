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

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;

            //ファイルがすでにある場合はここに値を入れる
            //もしくは完全にファイルを新規製作したものに保存するようにするかも
            string file_Path = "";

            try
            {
                using(WebClient client = new WebClient())
                {
                    string htmlText = client.DownloadString(url);

                    //以下の処理をよく調べる
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc .LoadHtml(htmlText);

                    string textData = htmlDoc.DocumentNode.InnerText;

                    File.WriteAllText(file_Path, textData);
                }
            }catch(Exception ex)
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