using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy.NotePad
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //f1 = new Form1();
            var aranan = textBox1.Text;
            var degisen = textBox2.Text;
            var textbox = Form1.textbox;
            var change=textbox.Replace(aranan, degisen);
            Form1.instance.richTextBox1.Text = change;
            //f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var aranan = textBox1.Text;
            int startIndex = 0;
            var select = Form1.instance.richTextBox1.Text.Contains(aranan);
            if (select)
            {
                startIndex=Form1.instance.richTextBox1.Find(aranan,startIndex,RichTextBoxFinds.None);
                Form1.instance.richTextBox1.SelectionStart = startIndex;
                Form1.instance.richTextBox1.SelectionLength = aranan.Length;
                Form1.instance.richTextBox1.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
