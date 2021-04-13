using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace k173652_Q1_
{
    class ProcessGenerator
    {

        private readonly Timer timer;
        static public string directory;
        static public int waitTime;
        public ProcessGenerator()
        {
            this.timer = new Timer(1000)
            {
                AutoReset = true
            };
            this.timer.Elapsed += this.RunProcess;
        }

        private void RunProcess(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = directory;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();

                    // This code assumes the process you are starting will terminate itself.
                    // Given that is is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                    Console.WriteLine("FileDownloaded:  " + directory);
                    System.Threading.Thread.Sleep(waitTime*1000);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Error: "+ exception.Message);

            }


        }
        public void Start()
        {
            this.timer.Start();
        }
        public void Stop()
        {
            this.timer.Stop();
        }

    }
}
