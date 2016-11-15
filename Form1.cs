using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.btnStop.Enabled = false;
        }

        int cnt = 0;
        WebBrowser wb = new WebBrowser();

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;

            cnt = Convert.ToInt32(this.txtStartTimes.Text);


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private void OpenURLWithWebBrowser(string strURL)
        {
            wb.Dispose();
            wb = new WebBrowser();

            wb.Navigate(strURL);

            //Thread.Sleep(3000);//3000毫秒

            
        }

        private void OpenURL(string strURL)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "IEXPLORE.EXE";//\\打开IEXPLORE
            p.StartInfo.Arguments = strURL;//\\输入要打开的网址
            p.Start();
            string mytime = p.StartTime.ToString();

            //Thread.Sleep(3000);//3000毫秒

            //p.CloseMainWindow();

            Process[] pp = Process.GetProcessesByName("iexplore");
            for (int i = 0; i < pp.Length; i++)
            {
                //if (pp[i].StartTime.ToString() == mytime)//\\判断已打开的网页启动时间
                {
                    pp[i].Kill();//关闭网页（进程）
                }
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str = txtURL.Text.ToString();

            cnt++;

            OpenURLWithWebBrowser(str);

            lblShow.Text = "AccessTime:" + cnt.ToString();

        }


    }
}
