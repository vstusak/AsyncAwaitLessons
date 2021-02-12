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

namespace AsyncAwaitOnUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(5000);
            var context = SynchronizationContext.Current;
            await Task.Delay(5000).ConfigureAwait(false);
            int i = 0;

            await Task.Delay(5000).ConfigureAwait(false);
            int j = 0;

            await Task.Delay(5000).ConfigureAwait(false);
            context.Post(_ =>
            {
                button1.Text = "Hello WORLD";
            }, null);
        }
    }
}
