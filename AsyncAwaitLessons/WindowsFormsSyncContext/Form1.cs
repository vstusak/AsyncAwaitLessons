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

namespace WindowsFormsSyncContext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////var ctx = SynchronizationContext.Current;
            ////Thread.Sleep(5000);

            //await Workload().ConfigureAwait(false);

            ////ctx.Post(_ => {
            ////    button1.Text = "Hello Dolly";
            ////}, null);

            //int i = 0;

            //await Task.Delay(5000).ConfigureAwait(false);

            //int j = 0;

            //await Task.Delay(5000).ConfigureAwait(false);
            string s = "";
            Task.Run(async () => { s = await Workload(); }).Wait();


            button1.Text = s;



        }


        private async Task<string> Workload()
        {
            int x = 0;
            await Task.Delay(5000);
            int y = 0;
            return "x";
        }


    }
}
