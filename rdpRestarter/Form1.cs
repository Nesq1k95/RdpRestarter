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

            timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible || this.WindowState == FormWindowState.Minimized)
                this.Show();

            backgroundWorker1.RunWorkerAsync();

            timer1.Stop();
        }

        private void dayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Interval = day;
            timer1.Start();
            stopCountdown = true;
          
            backgroundWorker1.CancelAsync();      // Cancel the asynchronous operation.
        }

        private void HourButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Interval = hour;
            timer1.Start();
            stopCountdown = true;

            backgroundWorker1.CancelAsync();      // Cancel the asynchronous operation.
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            restartRdp();
            stopCountdown = true;
            timer1.Interval = hour;
            timer1.Start();
            Hide();
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
                        restartRdp();
                        timer1.Interval = hour;
                        timer1.Start();
                        Hide();
                    });
                }
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Interval = 1000 * 10;
            timer1.Start();
        }

        private void restartRdp()
        {
            var SERVICENAME1 = "UmRdpService";
            var SERVICENAME2 = "TermService";

            restartService(SERVICENAME1);
            restartService(SERVICENAME2);
        }

        void restartService(string serviceName)
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
                //MessageBox.Show("Cлужба " + serviceName + "перезапущена");
            }
            catch
            {
                MessageBox.Show("Не удалось перезапустить службу " + serviceName);
            };
        }
    }
}
