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
                    //htmlContent�ɂ�HTML�f�[�^���i�[����Ă���
                    string htmlContent = client.DownloadString(url);

                    //HtmlDocument��HTML����͂Ƒ�����s��
                    HtmlDocument htmlDoc = new HtmlDocument();

                    //LoadHtml��HTML����͂���htmlDoc ��DOM�c���[���\�z����
                    htmlDoc.LoadHtml(htmlContent);

                    HtmlNode htmlNode = htmlDoc.DocumentNode;

                    //�w��^�O�̓��e�������o����
                    HtmlNodeCollection tagNodes = htmlNode.SelectNodes(selectTag);

                    if (tagNodes != null)
                    {
                        foreach (HtmlNode tagNode in tagNodes)
                        {
                            //InnerText�v���p�e�B�̓^�O���������Ă����
                            tagText = Regex.Replace(tagNode.InnerText, "<[^>]*?>", "").Trim(); ;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�G���[����" + ex.Message);
            }

            if (tagText != null)
            {
                DialogResult result = MessageBox.Show("�ǂݍ��݂��������܂����A�v���r���[��\�����܂����H", "�I��", MessageBoxButtons.YesNo);
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
                MessageBox.Show($"�V�����t�@�C���ɕۑ�����܂����F{file_Path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�G���[���o�܂����A�t�@�C���͐�������Ă��܂���B�F{ex.Message}");
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

