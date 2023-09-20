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

            //�t�@�C�������łɂ���ꍇ�͂����ɒl������
            //�������͊��S�Ƀt�@�C����V�K���삵�����̂ɕۑ�����悤�ɂ��邩��
            string file_Path = "";

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

                    //<body>�̓��e�������o����
                    HtmlNodeCollection tagNodes = htmlNode.SelectNodes(selectTag);

                    if (tagNodes != null)
                    {
                        foreach (HtmlNode tagNode in tagNodes)
                        {
                            //InnerText�v���p�e�B�̓^�O���������Ă����
                            string tagText = tagNode.InnerText;
                            File.WriteAllText(file_Path, tagText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�G���[����" + ex.Message);
            }
        }
    }
}

/*�w�肵��URL�̃e�L�X�g��ۑ�����
 * �����Ńt�@�C���𐶐�����
 * �����Ńt�@�C���ɕۑ�����
 * �^�O���w�肵�ē���̃e�L�X�g�̂ݕۑ�����@�\��
 * ��ꂽ��ǉ�����
 */