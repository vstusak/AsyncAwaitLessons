using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitLocks
{
    public partial class Form1 : Form
    {

        private readonly object lockingObject = new object();
        //private readonly ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        private int counter;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Workload();

            counter++;

            button1.Text = counter.ToString();
        }

        private async Task Workload()
        {
            //lock (lockingObject)
            //{
            //    await Task.Delay(4000);
            //}

            //Monitor.Enter(lockingObject);

            await semaphoreSlim.WaitAsync();

            await Task.Delay(4000).ConfigureAwait(false);

            semaphoreSlim.Release();

            //Monitor.Exit(lockingObject);
        }
    }
}
