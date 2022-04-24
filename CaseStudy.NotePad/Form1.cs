using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy.NotePad
{
    public partial  class Form1 : Form
    {
        public static string textbox = "";
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Çalışmanız Kaybolacak Emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                richTextBox1.Text = "";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Metin Dosyası Aç";
            opf.Filter = "Desteklenen Formatlar (*.txt)|*.txt";
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(opf.FileName, Encoding.UTF8);
                this.Text = "Açılan :" + opf.FileName;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfp = new SaveFileDialog();
            sfp.Title = "Metin Dosyası Kaydet";
            sfp.Filter = "Desteklenen Format (*.txt)|*.txt";

            if (sfp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfp.FileName, richTextBox1.Text, Encoding.UTF8);
                this.Text = "Kaydedilen :" + sfp.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfp = new SaveFileDialog();
            sfp.Title = "Metin Dosyası Kaydet";
            sfp.Filter = "Desteklenen Format (*.txt)|*.txt";

            if (sfp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfp.FileName, richTextBox1.Text, Encoding.UTF8);
                this.Text = "Kaydedilen :" + sfp.FileName;
            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.SelectedText;
            if (!string.IsNullOrEmpty(text))
            {
                Clipboard.SetText(text);
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.SelectedText;
            if (!string.IsNullOrEmpty(text))
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
            else
            {
                richTextBox1.Text += Clipboard.GetText();   
            }
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            textbox = richTextBox1.Text;
            
            form.Show();
            //var aranan=Form2.aranan.ToString();
            //var deger = Form2.degisen.ToString();
            //richTextBox1.Text.Contains(aranan);
            //richTextBox1.Text.Replace(aranan, deger);
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f11 = new Form1();
            f11.ShowDialog();
        }
    }
}
