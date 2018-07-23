using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_Stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "FILE STREAMING";
            this.label1.Text = "File Streaming";
            this.label2.Text = "File Address:";
            this.label3.Text = "File Name:";
            this.label4.Text = "Output";
            this.label5.Text = "Format:";

            this.button1.Text = "File Stream";
            this.button2.Text = "Stream Reader";
            this.button3.Text ="Stream Writer";
            this.button4.Text = "Clear";
            this.button5.Text="Exit";

            string []format={".txt",".pdf",".doc"};
            this.comboBox1.Items.AddRange(format);

            this.textBox3.ScrollBars = ScrollBars.Both;

        }

        private void button1_Click(object sender, EventArgs e)
        {
         string fn =textBox1.Text+textBox2.Text+comboBox1.Text;
         FileStream fs = new FileStream(fn, FileMode.Open);
           
            byte [] bb = new byte[100];
            char[] ch = new char[100];

            fs.Read(bb,0,100);

            Decoder de = Encoding.UTF8.GetDecoder();
            de.GetChars(bb, 0, bb.Length, ch, 0);

            foreach (char c in ch)
            {
                this.textBox3.Text += c;
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string st = this.textBox1.Text + this.textBox2.Text + this.comboBox1.Text;
            StreamReader sr = new StreamReader(st);
          
            this.textBox3.Text = sr.ReadToEnd();
            sr.Close();
            this.textBox3.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string stw = this.textBox1.Text + this.textBox2.Text + comboBox1.Text;
            StreamWriter sw = new StreamWriter(stw);
            sw.Write(this.textBox1.Text.ToCharArray());
            sw.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.comboBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
