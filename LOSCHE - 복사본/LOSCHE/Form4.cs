using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSCHE
{
    public partial class Form4 : DevExpress.XtraEditors.XtraForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        int percent = 75;
        int ab1, ab2, ab3 = 0;
        int s1, s2, s3 = 0;
        string[] text1 = new string[10];
        string[] text2 = new string[10];
        string[] text3 = new string[10];

        private void Form4_Load(object sender, EventArgs e)
        {
            PercentLb.Text = percent.ToString() + "%";
        }


        private void IncreaseBtn1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < label1.Text.Length; i++)
            {
                text1[i] = label1.Text[i].ToString();
            }

            if (ab1 >= 10)
            {
                IncreaseBtn1.Enabled = false;
            }
            else
            {
                Random rand = new Random();
                int r = rand.Next(1, 100);

                if (r < percent)
                {
                    text1[ab1] = "◈";
                    MessageBox.Show("성공!");
                    label1.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label1.Text += text1[i];
                    }
                    if (percent > 25)
                        percent -= 10;
                    else
                        percent = 25;
                    PercentLb.Text = percent.ToString() + "%";
                    s1++;
                }
                else
                {
                    text1[ab1] = "◇";
                    MessageBox.Show("실패..");
                    label1.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label1.Text += text1[i];
                    }
                    if (percent >= 75)
                        percent = 75;
                    else
                        percent += 10;
                    PercentLb.Text = percent.ToString() + "%";
                }
                ab1++;
                labelControl1.Text = "남은 횟수 : " + (10 - ab1).ToString();
                Buff1Lb.Text = "증가 능력1 : " + s1.ToString();
            }
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < label2.Text.Length; i++)
            {
                text2[i] = label2.Text[i].ToString();
            }

            if (ab2 >= 10)
            {
                simpleButton2.Enabled = false;
            }
            else
            {
                Random rand = new Random();
                int r = rand.Next(1, 100);

                if (r < percent)
                {
                    text2[ab2] = "◈";
                    MessageBox.Show("성공!");
                    label2.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label2.Text += text2[i];
                    }
                    if (percent > 25)
                        percent -= 10;
                    else
                        percent = 25;
                    PercentLb.Text = percent.ToString() + "%";
                    s2++;
                }
                else
                {
                    text2[ab2] = "◇";
                    MessageBox.Show("실패..");
                    label2.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label2.Text += text2[i];
                    }
                    if (percent >= 75)
                        percent = 75;
                    else
                        percent += 10;
                    PercentLb.Text = percent.ToString() + "%";
                }
                ab2++;
                labelControl2.Text = "남은 횟수 : " + (10 - ab2).ToString();
                Buff2Lb.Text = "증가 능력2 : " + s2.ToString();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < label3.Text.Length; i++)
            {
                text3[i] = label3.Text[i].ToString();
            }

            if (ab3 >= 10)
            {
                simpleButton3.Enabled = false;
            }
            else
            {
                Random rand = new Random();
                int r = rand.Next(1, 100);

                if (r < percent)
                {
                    text3[ab3] = "◈";
                    MessageBox.Show("성공..");
                    label3.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label3.Text += text3[i];
                    }
                    if (percent > 25)
                        percent -= 10;
                    else
                        percent = 25;
                    PercentLb.Text = percent.ToString() + "%";
                    s3++;
                }
                else
                {
                    text3[ab3] = "◇";
                    MessageBox.Show("실패!");
                    label3.Text = "";
                    for (int i = 0; i < 10; i++)
                    {
                        label3.Text += text3[i];
                    }
                    if (percent >= 75)
                        percent = 75;
                    else
                        percent += 10;
                    PercentLb.Text = percent.ToString() + "%";
                }
                ab3++;
                labelControl3.Text = "남은 횟수 : " + (10 - ab3).ToString();
                deBuffLb.Text = "감소 능력1 : " + s3.ToString();
            }
        }
    }
}