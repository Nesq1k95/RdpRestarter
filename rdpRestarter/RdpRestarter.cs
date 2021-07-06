using System;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;

namespace rdpRestarter
{
    public partial class RdpRestarter : Form
    {
        int hour = 1000 * 60 * 60 * 1;
        int day = 1000 * 60 * 60 * 24;
        bool stopCountdown = false;


        public RdpRestarter()
        {
            InitializeComponent();
            testButton.Visible = false;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
            TopMost = true;
            timer1.Stop();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Visible || WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Maximized;
                Focus();
                Show();
                WindowState = FormWindowState.Normal;
            }
                
            backgroundWorker1.RunWorkerAsync();

            timer1.Stop();
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Hide();
            timer1.Interval = day;
            timer1.Start();
            stopCountdown = true;
          
            backgroundWorker1.CancelAsync();      // Cancel the asynchronous operation.
        }

        private void HourButton_Click(object sender, EventArgs e)
        {
            Hide();
            timer1.Interval = hour;
            timer1.Start();
            stopCountdown = true;

            backgroundWorker1.CancelAsync();      // Cancel the asynchronous operation.
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            RestartRdp();
            stopCountdown = true;
            timer1.Interval = hour;
            timer1.Start();
            Hide();
        }


        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 10; i != -1; --i)
            {
                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate
                {
                    timeLabel.Text = i.ToString();
                });

                if (i == 0 && !stopCountdown)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Hide();
                        RestartRdp();
                        timer1.Interval = hour;
                        timer1.Start();
                    });
                }
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            Hide();
            timer1.Interval = 1000 * 10; // 10 sec
            timer1.Start();
        }

        private void RestartRdp()
        {
            var childServiceName = "UmRdpService";
            var mainServiceName = "TermService";

            RestartService(childServiceName);
            RestartService(mainServiceName);
        }

        void RestartService(string serviceName)
        {
            try
            {
                var sc = new ServiceController(serviceName);

                if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    sc.Stop();

                    while (sc.Status != ServiceControllerStatus.Stopped)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                }

                sc.Start();

                while (sc.Status == ServiceControllerStatus.Stopped)
                {
                    Thread.Sleep(1000);
                    sc.Refresh();
                }

                sc.Dispose();
                //MessageBox.Show("Service " + serviceName + "succesfully restarted");
            }
            catch
            {
                MessageBox.Show("Failed to restart service " + serviceName);
            };
        }
    }
}
