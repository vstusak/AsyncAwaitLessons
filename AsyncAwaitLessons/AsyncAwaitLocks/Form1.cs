using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitLocks
{
    public partial class Form1 : Form
    {

        private readonly object lockingObject = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Workload();
            button1.Text = "asdf";
        }

        private async Task Workload()
        {
            //lock (lockingObject)
            //{
            //    await Task.Delay(4000);
            //}

            Monitor.Enter(lockingObject);

            await Task.Delay(4000);

            Monitor.Exit(lockingObject);
        }
    }
}
