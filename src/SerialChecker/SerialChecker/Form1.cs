using System;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialChecker
{
    public partial class SerialChecker : Form
    {

        public SerialChecker()
        {
            InitializeComponent();
            count.Text = "Click "+"Update";
        }

        new void Update()
        {

            var portNames = SerialPort.GetPortNames();
            int PortCounter = 0;
            this.ListBox.Items.Clear();

            count.Text = "Count: " + Convert.ToString(PortCounter);

            foreach (var port in portNames)
            {
                PortCounter++;
                count.Text = "Count: " + Convert.ToString(PortCounter);

                try
                {
                    serPort.PortName = port;
                    serPort.Open();
                    this.ListBox.Items.Add(port, false);
                }
                catch
                {
                    this.ListBox.Items.Add(port, true);
                }
                
                try
                {
                    serPort.Close();
                }
                catch { }  //If a port is open, it will get closed.
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }
   

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://lama.host");
        }

    }
}
