using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 年越カウントダウン
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label3.Text = string.Format($"現在時刻  month:{d.Month} day:{d.Day} {d.Hour}:{d.Minute}:{d.Second}");
            int mon = d.Month;
            if (mon == 01)
            {
                mon = 13;
            }
            else if (mon == 02)
            {
                mon = 14;
            }
            double yuriusu1 = Math.Floor(365.25 * (d.Year)) + Math.Floor(d.Year / 400.0) - Math.Floor(d.Year / 100.0) + Math.Floor(30.59 * (mon - 2) + d.Day) - 678912;

            double yuriusu2 = Math.Floor(365.25 * 2024) + Math.Floor(2024 / 400.0) - Math.Floor(2024 / 100.0) + Math.Floor(30.59 * (13 - 2) )+1 - 678912;

            var nokori = yuriusu2 - yuriusu1-1;
            var nokori_minutes = (nokori * 1440)+((24-d.Hour)*60)+(60-d.Minute);
            var nokori_second = (nokori_minutes * 60) + (60 - d.Second);
            if (i == 1)
            {
                label2.Text = ($"{nokori}日");
            }
            else if(i == 2)
            {
                label2.Text = ($"{nokori_minutes}分");
            }
            else if (i == 3)
            {
                label2.Text = ($"{nokori_second}秒");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i= 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i= 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i= 3;
        }
    }
}
