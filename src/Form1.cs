using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace OpenPortChecker{

    public partial class Form1 : Form{ 
        
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
        }

        private void button1_Click(object sender, EventArgs e){

           var portNames = SerialPort.GetPortNames();
           int PortCounter = 0;
            this.ListBox.Items.Clear();

            foreach (var port in portNames){
                PortCounter++;
                Counter.Text = Convert.ToString(PortCounter);
                
                try {
                    serPort.PortName = port;
                    serPort.Open();
                    this.ListBox.Items.Add(port, false);
                }
                catch{
                    this.ListBox.Items.Add(port, true);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            Process.Start("https://lama.host");
        }
    }
}
