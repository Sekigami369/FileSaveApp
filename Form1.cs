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

/*�w�肵��URL�̃e�L�X�g��ۑ�����
 * �����Ńt�@�C���𐶐�����
 * �����Ńt�@�C���ɕۑ�����
 * �^�O���w�肵�ē���̃e�L�X�g�̂ݕۑ�����@�\��
 * ��ꂽ��ǉ�����
 */