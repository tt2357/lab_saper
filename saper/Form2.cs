using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace saper
{
    public partial class Form2 : Form
    {
        int size;
        int s;
        int[] chs;
        int s1;
        int licznik = 0;
        int licznik1 = 0;

        public Form2(int size, int s)
        {
            this.size = size;
            this.s = s;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(size * 50 + 100, size * 50);
            licznik = s * 3;
            stopwatch1.Tick += new EventHandler(stopwatch1_Tick);
            stopwatch1.Start();
            label1.Text = licznik.ToString();

            Random rnd = new Random();
            Button[] buttons = new Button[size * size];

            chs = new int[s];

            int s1 = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++, s1++)
                {
                    buttons[s1] = new Button();
                    buttons[s1].Location = new Point(j * 50, i * 50);
                    buttons[s1].Size = new Size(50, 50);
                    buttons[s1].BackColor = System.Drawing.SystemColors.Highlight;
                    buttons[s1].TabIndex = s1;

                    buttons[s1].Click += Button_Click;
                    this.Controls.Add(buttons[s1]);

                }
            }

            int[] all= new int[size * size];

            for (int i = 0; i < size * size; i++)
            {
                all[i] = i;
            }

            all = all.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < s; i++)
            {
                chs[i] = all[i];
            }

            label1.Location = new Point(size * 50, 50);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (Array.Exists(chs, element => element == button.TabIndex))
            {
                button.BackColor = Color.Red;
                button.Enabled = false;
                licznik1++;
            }

            if (licznik1 == s)
            {
                MessageBox.Show("Wygrales");
            }

        }

        private void stopwatch1_Tick(object sender, EventArgs e)
        {
            licznik--;

            if (licznik == 0)
            {
                stopwatch1.Stop();
                MessageBox.Show("Przegrales");
                this.Close();
            }
            label1.Text = licznik.ToString();
        }
    }
}
