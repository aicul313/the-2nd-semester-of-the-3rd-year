using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.IO;

namespace project1___221128
{
    public partial class Form1 : Form
    {
       /* private List<string> ComName = new List<string>();
        private void Form1_Load(object sender, EventArgs e) { 
            
        }*/
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                else
                {
                    serialPort1.PortName = comboBox1.SelectedItem.ToString();
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Parity = Parity.None;
                    serialPort1.Open();

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Connect Error ", "Notice ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button1.Text = serialPort1.IsOpen ? "DISCONNECT" : "CONNECT";
            comboBox1.Enabled = !serialPort1.IsOpen;
        }

        //led 전원 켜기
        private void button2_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;
            serialPort1.Write("1");
        }

        //led 전원 끄기
        private void button3_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;
            serialPort1.Write("0");
        }
    }
}