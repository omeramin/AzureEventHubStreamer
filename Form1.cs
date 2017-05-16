using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHubStreamer
{
    public partial class Form1 : Form
    {
        // <TO DO>
        // UPDATE 5 strings below here, otherwise you wont connect to the event hub successfully
        // </TO DO>
        private static string sbURI = "sb://example.servicebus.windows.net";//ServiceBus URL - i.e. "sb://example.servicebus.windows.net"
        private static string eventHubName = "ingest";//Event Hub Name
        private static string SASKeyName = "RootManageSharedAccessKey";//SAS Key Name - i.e. "RootManageSharedAccessKey"
        private static string SASKey = "8jRh0iAMn7Lehwit73nf7QZJVFzOQ75DPIJzEcM0d+E=";//SAS Key Value - "kjd43298782nbjksdfuywerbdfsduoiewr"
        private static string receiverName = "Receiver1";//Create custom receiver in Azure portal

        private static EventHubClient ehClient;
        private static PartitionReceiver receiver;

        public delegate void SetTextCallback(string str);


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connectEventHub_Click(object sender, EventArgs e)
        {
            btn_connectEventHub.Enabled = false;
            btn_closeEventHub.Enabled = true;

            label1.Text = "Connecting to Hub";
            Uri uri = new Uri(sbURI);
            EventHubsConnectionStringBuilder connectionString = new EventHubsConnectionStringBuilder(uri, eventHubName, SASKeyName, SASKey);
            ehClient = EventHubClient.CreateFromConnectionString(connectionString.ToString());
            receiver = ehClient.CreateReceiver(receiverName, "1", null);

            label1.Text = "Connected to Hub, Attempting to receive... - " + sbURI;
            //Pick one of the following methods
            //**Method 1 - Uses a Task object to receive events, and updates the TextBox using the BeginInvoke method.
            //**Method 2 - Uses a BackgroundWorker to receive events, updates UI thread ProgressChanged EventHandler pattern.

            //Method1();
            Method2();
            
        }

        private void Method1()
        {
            try
            {
                SetTextCallback d = new SetTextCallback(SetText);

                Task task = new Task(() => {

                    do
                    {
                        IEnumerable<EventData> events = receiver.ReceiveAsync(1000).Result;

                        if (events != null)
                        {
                            string str = "";
                            foreach (EventData ev in events)
                            {

                                str += ev.SystemProperties.SequenceNumber + " - " + ev.SystemProperties.Offset + ", " + Encoding.UTF8.GetString(ev.Body.ToArray()) + "\r\n";
                            }

                            textBox1.BeginInvoke(d, str);

                        }
                    } while (true);

                });

                task.Start();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException.Message);
                Application.Exit();
            }
            
        }

        private void SetText(string str)
        {
            textBox1.AppendText(str);
        }

        private void Method2()
        {
            updateTextBoxbackgroundWorker.WorkerReportsProgress = true;
            updateTextBoxbackgroundWorker.RunWorkerAsync();
        }

        private void updateTextBoxbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                do
                {
                    IEnumerable<EventData> events = receiver.ReceiveAsync(1000).Result;
                    if (events != null)
                        updateTextBoxbackgroundWorker.ReportProgress(50, events);

                } while (true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException.Message);
                Application.Exit();
            }
            

        }

        private void updateTextBoxbackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string str = "";
            foreach (EventData ev in (IEnumerable<EventData>)e.UserState)
            {
                str += ev.SystemProperties.SequenceNumber + " - " + ev.SystemProperties.Offset + ", " + Encoding.UTF8.GetString(ev.Body.ToArray()) + "\r\n";
            }

            textBox1.AppendText(str);

        }

        private void btn_closeEventHub_Click(object sender, EventArgs e)
        {
            if (ehClient != null)
            {
                ehClient.Close();
            }

            btn_closeEventHub.Enabled = false;
            btn_connectEventHub.Enabled = true;
        }
    }
}
