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

        private async void button1_Click(object sender, EventArgs e)
        {
            //SynchronizationContext.Current
            //Thread.Sleep(5000);

            await Task.Delay(5000).ConfigureAwait(false);
            
            button1.Text = "Hello Dolly";

        }
    }
}
