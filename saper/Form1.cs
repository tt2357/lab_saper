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
        int s;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string size_s = textBox1.Text;
            size = Int16.Parse(size_s);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string s_s = textBox2.Text;
            s = Int16.Parse(s_s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(size, s);
            form2.Show();
        }
    }
}
