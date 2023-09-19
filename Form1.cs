using HtmlAgilityPack;
using System.Net;
using System.IO;
using System;


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
            string file_Path = "";

            try
            {
                using(WebClient client = new WebClient())
                {

                }
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