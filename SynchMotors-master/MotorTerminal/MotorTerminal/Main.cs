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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //Обработчик события "Диагностика"
        private void Diagnostics_Click(object sender, EventArgs e)
        {
            Diagnostics newDiagnostics = new Diagnostics(this);
            newDiagnostics.Show();
            Hide();
        }

        //Обработчик события "Выход"
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Обработчик события "Обновить"
        private void Refresh_Click(object sender, EventArgs e)
        {
            getAvailablePorts();
        }

        //Проверка и вывод доступных COM-портов
        private void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            PortName.Items.Clear();
            PortName.Items.AddRange(ports);
        }

        //Обработчик события "Соединиться"
        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortName.Text == "")
                {
                    throw new Exception("Выберете имя порта");
                }
                else
                {
                    serialPort1.PortName = PortName.Text;
                    serialPort1.BaudRate = 19200;
                    serialPort1.Encoding = System.Text.Encoding.GetEncoding(28591);
                    serialPort1.Open();
                    PortState.Text = "Порт " + PortName.Text + " открыт";
                    Refresh.Enabled = false;
                    Connect.Enabled = false;
                    Disconnect.Enabled = true;
                    groupBox1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Обработчик события "Отключиться"
        private void Disconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            PortState.Text = "Порт " + PortName.Text + " закрыт";
            Refresh.Enabled = true;
            Connect.Enabled = true;
            Disconnect.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings newSettings = new Settings(this);
            newSettings.Show();
            Hide();
        }
    }
}
