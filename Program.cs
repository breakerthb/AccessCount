using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisitAmountIncreaser
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                Util util = new Util();
                util.StartThread();
                Thread.Sleep(3);
                util.Close();
            }
        }


        public class Util
        {
            public void StartThread()
            {
                ThreadStart start = new ThreadStart(StartIE);
                Thread thread = new Thread(start);
                thread.Start();

            }

            private void StartIE()
            {
                Process.Start("http://www.mojiax.com/knowledge/article?id=1310");
            }

            public void Close()
            {
                System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
                try
                { 
                foreach (System.Diagnostics.Process myProcess in myProcesses)
                {
                    if (myProcess.ProcessName.ToUpper() == "IEXPLORE")
                    {
                        myProcess.Kill();
                    }
                }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
