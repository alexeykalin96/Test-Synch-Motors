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

namespace MotorTerminal
{
    public partial class Settings : Form
    {
        string rxBuffer; //буфер приема
        bool currentCheckEn = false; //синхронизация по току

        Main main;
        public Settings(Main pointer)
        {
            InitializeComponent();
            this.main = pointer;
            main.Enabled = false;
            main.serialPort1.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            maxCurrent.Text = Convert.ToString(trackBar1.Value);
            timeWork.Text = Convert.ToString(trackBar2.Value);
            timer1.Start();
        }

        //Анализ принятых данных
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                rxBuffer += main.serialPort1.ReadExisting();
                for (int i = 0; i < rxBuffer.Length; i++)
                {
                    if ((rxBuffer[i] == '<') && (rxBuffer[i + 7] == '>'))
                    {
                        if((rxBuffer[i + 1] == '0') && (rxBuffer[i + 2]) == '0')
                        {
                            currentCheckEn = false;
                        }

                        else if((rxBuffer[i + 1] == '0') && (rxBuffer[i + 2]) == '1')
                            {
                            currentCheckEn = true;
                        }
                    }
                }
                this.Invoke(new EventHandler(showData1));
                rxBuffer = null;
                main.serialPort1.DiscardInBuffer();
            }

            catch (Exception)
            {
                
            }
        }

        private void showData1(object sender, EventArgs e)
        {
            CurrentCheck.Checked = currentCheckEn;
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            main.Enabled = true;
            Close();
            main.Show();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            main.serialPort1.WriteLine("<S>");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string sendData = "<P";
            char current1 = Convert.ToChar(trackBar1.Value);
            char current2 = Convert.ToChar(trackBar1.Value << 8);

            switch (CurrentCheck.Checked)
            {
                case false:
                    sendData += "00";
                    currentCheckEn = false;
                    break;

                case true:
                    sendData += "01"; 
                    currentCheckEn = true;
                    break;
            }

            sendData += Convert.ToString(current1) + Convert.ToString(current2);

            sendData += "00p>";

            main.serialPort1.WriteLine(sendData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(CurrentCheck.Checked)
            {
                case false:
                    SynchSet.Enabled = false;
                    break;

                case true:
                    SynchSet.Enabled = true;
                    break;
            }
        }

        private void showMaxCurrent(object sender, EventArgs e)
        {
            maxCurrent.Text = Convert.ToString(trackBar1.Value);
        }

        private void showTimeWork(object sender, EventArgs e)
        {
            timeWork.Text = Convert.ToString(trackBar2.Value);
        }
    }
}
