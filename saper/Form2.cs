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
        int toFind;
        int buttonSize = 35;
        int spacing = 40;
        int timeleft;

        private Random random = new Random();
        private List<Button> targetButtons = new List<Button>();

        public Form2(int size, int toFind)
        {
            this.size = size;
            this.toFind = toFind;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(size * 50 + 100, size * 50);
            timeleft = toFind * 3;
            stopwatch1.Tick += new EventHandler(stopwatch1_Tick);
            stopwatch1.Start();
            label1.Text = timeleft.ToString();
            label1.Location = new Point(spacing * (size + 1), spacing);
            CreateGrid();
            SetTargetButtons();
        }
        private void CreateGrid()
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Button b = new Button();
                    b.Size = new Size(buttonSize, buttonSize);
                    b.Location = new Point(spacing * j, spacing * i);
                    b.BackColor = Color.Blue;
                    b.Click += Button_Click;
                    Controls.Add(b);
                }
            }
        }

        private void SetTargetButtons()
        {
            int count = toFind;
            while (count > 0)
            {
                int randomIndex = random.Next(0, size * size);
                Button b = (Button)Controls[randomIndex];
                if (b.BackColor == Color.Blue && !targetButtons.Contains(b))
                {
                    b.Tag = "Target";
                    targetButtons.Add(b);
                    count--;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.Blue)
            {
                if (b.Tag != null && b.Tag.ToString() == "Target")
                {
                    b.BackColor = Color.Red;
                    targetButtons.Remove(b);
                    CheckGameCompletion();
                }
            }
        }

        private void CheckGameCompletion()
        {
            if (targetButtons.Count == 0)
            {
                stopwatch1.Stop();
                MessageBox.Show("Wygrales");
                this.Close();
            }
        }

        private void stopwatch1_Tick(object sender, EventArgs e)
        {
            timeleft--;
            label1.Text = timeleft.ToString();

            if(timeleft == 0)
            {
                stopwatch1.Stop();
                MessageBox.Show("Przegrales");
                this.Close();
            }
        }
    }
}
