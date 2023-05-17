using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saper
{
    public partial class Form1 : Form
    {
        int size;
        int toFind;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string size_s = textBox1.Text;
            size = int.Parse(size_s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(size, toFind);
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            string toFind_s = textBox2.Text;
            toFind = int.Parse(toFind_s);
        }
    }
}
