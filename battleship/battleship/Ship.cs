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
    public class Ship
    {
        public int ships = 0;
        public int cnt1 = 1, cnt2 = 2, cnt3 = 3, cnt4 = 4, cnt5=1, cnt6=1;
        public bool issize4clicked = false;
        public string dirofbotship = "";
        public bool canbotkill = false, canikill = true;
        public Ship()
        {
        }
        public bool Check(List<Button> l1, int[] a, int i)
        {
            if (a[i] == 1)
            {
                return true;
            }
            return false;
        }
        public void IsItPossibleToDraw(List<Button> l1, int[] a, int index, int size)
        {
            a[index] = 1;
            if (index - 10 >= 0)
            {
                if (l1[index - 10].BackColor == Color.White)
                    a[index - 10] = 1;
            }
            if (index + 10 < 100)
            {
                if (l1[index + 10].BackColor == Color.White)
                    a[index + 10] = 1;
            }

            if ((index + 1) % 10 != 0 && index + 1 < 100)
            {
                if (l1[index + 1].BackColor == Color.White)
                    a[index + 1] = 1;
            }

            if ((index + 1) % 10 != 1 && index - 1 > 0)
            {
                if (l1[index - 1].BackColor == Color.White)
                    a[index - 1] = 1;
            }

            if ((index + 1) % 10 != 0 && index - 9 > 0)
            {
                if (l1[index - 9].BackColor == Color.White)
                    a[index - 9] = 1;
            }

            if ((index + 1) % 10 != 1 && index - 11 > 0)
            {
                if (l1[index - 11].BackColor == Color.White)
                    a[index - 11] = 1;
            }

            if ((index + 1) % 10 != 1 && index + 9 < 100)
            {
                if (l1[index + 9].BackColor == Color.White)
                    a[index + 9] = 1;
            }

            if ((index + 1) % 10 != 0 && index + 11 < 100)
            {
                if (l1[index + 11].BackColor == Color.White)
                    a[index + 11] = 1;
            }

        }
        
        public bool Check2(int[] c, int index, string dir, int[] d)
        {
            int asd = c[index];
            c[index] = -1;
            d[index] = asd;
            for (int i = 0; i < 100; i++)
            {
                if (c[i] == asd)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsItGameOver(List<Button> l)
        {
            int coun = 0;
            for(int i = 0; i < 100; i++)
            {
                if (l[i].BackColor == Color.Red)
                    coun++;
            }
            if (coun == 20)
            {
                return true;
            }
            return false;
        }
        public void IsShipOfBotDied(List<Button> l2, Button btn, int[] c, int[]d)
        {
            bool isitfound = false;
            for (int i = 0; i < 100; i++)
            {
                if (l2[i] == btn && c[i] != 0)
                {
                    isitfound = true;
                    if (!Check2(c, i, dirofbotship, d))
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (c[j] == -1 && d[j] != 0)
                            {
                                l2[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }
                }
            }
            if (isitfound)
                canikill = true;
            else
                canikill = false;
        }

        public void IsMyBotDied(List<Button> l2, Button btn, int[] c, int[] d)
        {
            bool isitfound = false;
            for (int i = 0; i < 100; i++)
            {
                if (l2[i] == btn && c[i] != 0)
                {
                    isitfound = true;
                    if (!Check2(c, i, dirofbotship, d))
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (c[j] == -1 && d[j] != 0)
                            {
                                l2[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }
                }
            }
            if (isitfound)
                canbotkill = true;
            else
                canbotkill = false;
        }
        public void BotDraw(List<Button> l2, int[] b, Button btn, int i, int size, string direction, int[] c)
        {
            if (i % 10 + 1 < size && direction == "Left")
                return;
            if (10 - (i / 10) < size && direction == "Down")
                return;
            int cnt = 0;
            for (int j = 0; j < size; j++)
            {
                if (direction == "Left")
                {
                    if (Check(l2, b, i - j))
                        cnt++;
                }
                else
                {
                    if (Check(l2, b, i + 10 * j))
                        cnt++;
                }
            }
            if (cnt == 0)
            {
                if (size == 4)
                    cnt1--;
                if (size == 3)
                    cnt2--;
                if (size == 2)
                    cnt3--;
                if (size == 1)
                    cnt4--;
                for (int kk = 0; kk < size; kk++)
                {
                    if (direction == "Left")
                    {
                        c[i - kk] = cnt5;
                        IsItPossibleToDraw(l2, b, i - kk, size);
                    }
                    else
                    {
                        c[i + 10 * kk] = cnt5;
                        IsItPossibleToDraw(l2, b, i + 10 * kk, size);
                    }
                }
                cnt5++;
            }
        }
        public void Draw(List<Button> l1, int[] a, Button btn, int size, string direction, Label label,int[] g)
        {
            for (int i = 0; i < 100; i++)
            {
                if (l1[i] == btn)
                {
                    if (i % 10 + 1 < size && direction == "Left")
                        return;
                    if (10 - (i / 10) < size && direction == "Down")
                        return;
                    int cnt = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (direction == "Left")
                        {
                            if (Check(l1, a, i - j))
                                cnt++;
                        }
                        else
                        {
                            if (Check(l1, a, i + 10 * j))
                                cnt++;
                        }
                    }
                    if (cnt == 0)
                    {
                        ships++;
                        for (int k = 0; k < size; k++)
                        {
                            if (direction == "Left")
                                l1[i - k].BackColor = Color.Green;
                            else
                                l1[i + 10 * k].BackColor = Color.Green;
                        }
                        int v = int.Parse(label.Text);
                        v--;
                        label.Text = v.ToString();
                        for (int kk = 0; kk < size; kk++)
                        {
                            if (direction == "Left")
                            {
                                IsItPossibleToDraw(l1, a, i - kk, size);
                                g[i - kk] = cnt6;
                            }
                            else
                            {
                                IsItPossibleToDraw(l1, a, i + 10 * kk, size);
                                g[i + 10 * kk] = cnt6;
                            }
                        }
                        cnt6++;
                    }

                }
            }
        }
    }
}

