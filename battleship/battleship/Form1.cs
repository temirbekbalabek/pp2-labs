using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class Form1 : Form
    {
        int k = 0;
        
        List<Button> l1, l11;
        List<Button> l2, l22;
        int[] a = new int[100];
        int[] aa = new int[100];
        int[] b = new int[100];
        int[] bb=new int[100];
        int[] c = new int[100];
        int[] d = new int[100];
        int[] g = new int[100];
        int[] f = new int[100];
        string[] s = new string[2];
        Ship ship = new Ship();
        string direction = "";
        public Form1()
        {
            InitializeComponent();
            l1 = new List<Button>();
            l11 = new List<Button>();
            l2 = new List<Button>();
            l22 = new List<Button>();
            s[0] = "Left";
            s[1] = "Down";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i <10; i++)
            {
                for(int j = 0; j <10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(35, 35);
                    btn.Location = new Point(j * 35 + 10, i * 35);
                    btn.Text = "";
                    btn.BackColor = Color.White;
                    btn.Click += Buttons1_Click;
                    Controls.Add(btn);
                    l1.Add(btn);
                }
            }
        }
       
        private void Buttons1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (k == 4)
            {
                if (label4.Text == "0")
                    return;
                if(button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction, label4, g);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label4, g);
                }
            }
            if (k == 3)
            {
                if (label3.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction, label3, g);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label3, g);
                }
            }
            if (k == 2)
            {
                if (label2.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction,label2,g);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label2,g);
                }
            }
            if (k == 1)
            {
                if (label1.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction,label1,g);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction,label1,g);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Left")
                button1.Text = "Down";
            else
                button1.Text = "Left";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ship.ships == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Button btn = new Button();
                        btn.Size = new Size(35, 35);
                        btn.Location = new Point(j * 35 + 460, i * 35);
                        btn.Text = "";
                        btn.BackColor = Color.White;
                        btn.Click += Buttons2_Click;
                        Controls.Add(btn);
                        l2.Add(btn);
                    }
                }
                int dir, loc, size;
                string direction2;
                while (true)
                {
                    dir = new Random().Next(0, 2);
                    loc = new Random().Next(0, 100);
                    size = 4;
                    direction2 = s[dir];
                    if (ship.cnt1 == 0)
                    {
                        size = 3;
                    }
                    if (ship.cnt2 == 0)
                    {
                        size = 2;
                    }
                    if (ship.cnt3 == 0)
                        size = 1;
                    if ((ship.cnt1 == 0 && ship.cnt2 == 0 && ship.cnt3 == 0 && ship.cnt4 == 0))
                        return;
                    if ((ship.cnt1 == 0 && size == 4) || (ship.cnt2 == 0 && size == 3) || (ship.cnt3 == 0 && size == 2) || (ship.cnt4 == 0 && size == 1))
                    {
                        continue;
                    }
                    if (size == 4)
                    {
                        ship.BotDraw(l2, b, l2[loc], loc, size, direction2,c);
                    }
                    if (size == 3)
                    {
                        ship.BotDraw(l2, b, l2[loc], loc, size, direction2,c);
                    }
                    if (size == 2)
                    {
                        ship.BotDraw(l2, b, l2[loc], loc, size, direction2,c);
                    }
                    if (size == 1)
                    {
                        ship.BotDraw(l2, b, l2[loc], loc, size, direction2,c);
                    }
                }
            }
            else
                MessageBox.Show("You can start the game only after putting all the ships");
            
        }

        private void Buttons2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (ship.canikill==true && ship.canbotkill==false)
            {
                if (ship.IsItGameOver(l1) || ship.IsItGameOver(l2))
                {
                    MessageBox.Show("GameOver");
                }
                    
                ship.IsShipOfBotDied(l2, btn, c, d);
                if (!ship.canikill)
                    ship.canbotkill = true;
                else
                    ship.canbotkill = false;
            }
            if (ship.canbotkill == true && ship.canikill == false)
            {
                if (ship.IsItGameOver(l1) || ship.IsItGameOver(l2))
                {
                    MessageBox.Show("GameOver");
                }

                int locat = new Random().Next(0, 100);
                ship.IsMyBotDied(l1, l1[locat], g, f);
                if (!ship.canbotkill)
                    ship.canikill = true;
                else
                    ship.canikill = false;
            }
        }
        private void Ships(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "4")
                k = 4;
            if (btn.Text == "3")
                k = 3;
            if (btn.Text == "2")
                k = 2;
            if (btn.Text == "1")
                k = 1;
        }
    }
}
