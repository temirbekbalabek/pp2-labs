using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                        Button btn = new Button();
                        btn.Text = 0.ToString();
                        btn.Size = new Size(50, 50);
                        btn.Location = new Point(j * 50, i * 50);
                        btn.Click += numbers_Click;
                        Controls.Add(btn);
                }
            }
        }
        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int k = int.Parse(btn.Text);
            k++;
            btn.Text =k.ToString();
        }
    }
}
