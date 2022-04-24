using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy.TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            var total_cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var process_cpu_usage = (total_cpu.NextValue() / 100) * total_cpu.NextValue();
            var processUsage = process_cpu_usage / total_cpu.NextValue() / Environment.ProcessorCount;


            foreach (Process p in Process.GetProcesses("."))

            {

                listView1.Items.Add(p.ProcessName);

                listView1.Items[i].SubItems.Add(p.Id.ToString());

                listView1.Items[i].SubItems.Add(Convert.ToInt32(Math.Round(Convert.ToDecimal(p.PrivateMemorySize64 / 1024))) + "KB");

                listView1.Items[i].SubItems.Add(processUsage.ToString());

                listView1.Items[i].SubItems.Add(p.Responding.ToString());

                i++;//www.gorselprogramlama.com

            }
        }

        public void programiKapat(int pid)
        {
            Process.GetProcessById(pid).Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            programiKapat(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
            listView1.SelectedItems[0].Remove();
        }

        private void newTaskRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var file=openFileDialog1.FileName;
            Process.Start(file);
        }
    }
}
