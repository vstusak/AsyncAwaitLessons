using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuppyKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var context = SynchronizationContext.Current;
            //Thread.Sleep(10000);
            await Task.Delay(5000).ConfigureAwait(false);
            int i = 0;
            await Task.Delay(5000).ConfigureAwait(false);
            int j = 0;
            await Task.Delay(5000).ConfigureAwait(false);
            //button1.Text = "Number one is finished";
            context.Post(_ => button1.Text = "New",null);
        }

        private async Task<string> GetStuffAsync()
        {
            using (var fileStream = new FileStream(String.Empty, FileMode.Open))
            {
                var buffer = new byte[1024];
                await fileStream.ReadAsync(buffer,0,1024);
                return buffer.ToString();
            }
        }
    }
}
