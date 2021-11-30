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
            //ConfigureAwait example

            //var context = SynchronizationContext.Current;
            ////Thread.Sleep(10000);
            //await Task.Delay(5000).ConfigureAwait(false);
            //int i = 0;
            //await Task.Delay(5000).ConfigureAwait(false);
            //int j = 0;
            //await Task.Delay(5000).ConfigureAwait(false);
            ////button1.Text = "Number one is finished";
            //context.Post(_ => button1.Text = "New",null);

            await GetStuffAsync();

            button1.Text = "Number one is finished";
        }

        private async Task<string> GetStuffAsync()
        {
            //using (var fileStream = new FileStream(String.Empty, FileMode.Open))
            //{
            //    var buffer = new byte[1024];
            //    await fileStream.ReadAsync(buffer,0,1024);
            //    return buffer.ToString();
            //}

            //lock (this)
            //{

            //}

            //var @object = new object();
            //Monitor.Enter(@object);
            //await Task.Delay(5000).ConfigureAwait(false);
            //Monitor.Exit(@object);

            var semafor = new SemaphoreSlim(1, 1);
            await semafor.WaitAsync();
            await Task.Delay(5000).ConfigureAwait(false);
            semafor.Release();


            return String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LoadImage().Wait();
            //var awaiter = LoadImage().GetAwaiter();
            //awaiter.GetResult();

            Task.Run(async () => await LoadImage());
        }

        private async Task LoadImage()
        {
            await Task.Delay(5000);
        }
    }
}
