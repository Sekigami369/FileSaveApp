
namespace FileSaveApp
{
    public partial class PreViewForm : Form
    {
        Form1 form1;
        string tagText;



        public PreViewForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void PreViewForm_Load(object sender, EventArgs e)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            Controls.Add(richTextBox);
            try
            {
                tagText = form1.tagText;
                richTextBox.Text = tagText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("tagText is null");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
