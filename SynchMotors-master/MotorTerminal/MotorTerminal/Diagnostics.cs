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
    public partial class Diagnostics : Form
    {
        string rxBuffer; //буфер приема
        int currentState; //значение силы тока
        int rotateState; //направление вращения
        string groupRequest = "<1>"; //команда запроса
        double timeState = 0; //стостояние временного интервала

        Main main;
        public Diagnostics(Main pointer)
        {
            InitializeComponent();
            this.main = pointer;
            main.Enabled = false;
            initCharts();
            main.serialPort1.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            timer1.Start();
        }

        //Инициализация chart1 и chart2
        private void initCharts()
        {
            // Настраиваем оси графика 1
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 60;
            chart1.ChartAreas[0].AxisY.Minimum = -200;
            chart1.ChartAreas[0].AxisY.Maximum = 1200;

            // Определяем шаг сетки 1
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 100;
            //timer1.Start();

            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].BorderWidth = 2;

            chart1.Series[0].Points.AddXY(0, 0);


            // Настраиваем оси графика 2
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 60;
            chart2.ChartAreas[0].AxisY.Minimum = -200;
            chart2.ChartAreas[0].AxisY.Maximum = 1200;

            // Определяем шаг сетки 2
            chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            chart2.ChartAreas[0].AxisY.MajorGrid.Interval = 100;

            chart2.Series[0].Color = Color.Red;
            chart2.Series[0].BorderWidth = 2;

            chart2.Series[0].Points.AddXY(0, 0);
        }

        //Анализ принятых данных
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                rxBuffer += main.serialPort1.ReadExisting();
                for (int i = 0; i < rxBuffer.Length; i++)
                {
                    if ((rxBuffer[i] == '<') && (rxBuffer[i + 5] == '>'))
                    {
                        switch (rxBuffer[i + 1])
                        {
                            case '1':
                                currentState = (rxBuffer[i + 2] << 8) | (rxBuffer[i + 3]);
                                rotateState = rxBuffer[i + 4];
                                this.Invoke(new EventHandler(showData1));
                                rxBuffer = null;
                                main.serialPort1.DiscardInBuffer();
                                break;

                            case '2':
                                currentState = (rxBuffer[i + 2] << 8) | (rxBuffer[i + 3]);
                                rotateState = rxBuffer[i + 4];
                                this.Invoke(new EventHandler(showData2));
                                rxBuffer = null;
                                main.serialPort1.DiscardInBuffer();
                                break;
                        }
                    }
                }


            }
            catch (Exception)
            {

            }
        }

        //Отображение состояния мотора 1
        private void showData1(object sender, EventArgs e)
        {
            //Мотор остановлен
            if (rotateState == 0)
            {
                Current1.Text = "0";
                Rotate1.Text = "Остановлен";
            }

            //Вращение мотора вправо или влево
            else
            {
                chart1.Series[0].Points.AddXY(timeState, currentState);
                Current1.Text = Convert.ToString(currentState);
                switch (rotateState)
                {
                    case 1:
                        Rotate1.Text = "Вправо";
                        break;

                    case 2:
                        Rotate1.Text = "Влево";
                        break;
                }

                if (timeState > 60)
                {
                    chart1.Series[0].Points.Clear();
                    timeState = 0;
                    currentState = 0;
                    chart1.Series[0].Points.AddXY(timeState, currentState);
                }
            }      
        }
        //Отображение состояния мотора 2
        private void showData2(object sender, EventArgs e)
        {
            //Мотор остановлен
            if (rotateState == 0)
            {
                Current2.Text = "0";
                Rotate2.Text = "Остановлен";
            }

            //Вращение мотора вправо или влево
            else
            {
                chart2.Series[0].Points.AddXY(timeState, currentState);
                Current2.Text = Convert.ToString(currentState);
                switch (rotateState)
                {
                    case 1:
                        Rotate2.Text = "Вправо";
                        break;

                    case 2:
                        Rotate2.Text = "Влево";
                        break;
                }

                if (timeState > 60)
                {
                    chart2.Series[0].Points.Clear();
                    timeState = 0;
                    currentState = 0;
                    chart2.Series[0].Points.AddXY(timeState, currentState);
                }
            }
        }

        //Обработчик события выход
        private void Exit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            main.Enabled = true;
            Close();
            main.Show();
        }

        //Обработчик timer1
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Проверка checkBox1
                if (checkBox1.Checked == false)
                {
                    groupBox1.Enabled = false;
                    chart1.Visible = false;
                }
                else if(checkBox1.Checked == true)
                {
                    groupBox1.Enabled = true;
                    chart1.Visible = true;
                }

                //Проверка checkBox2
                if (checkBox2.Checked == false)
                {
                    groupBox2.Enabled = false;
                    chart2.Visible = false;
                }
                else if (checkBox2.Checked == true)
                {
                    groupBox2.Enabled = true;
                    chart2.Visible = true;
                }

                //Установка временного интервала
                if (rotateState != 0)
                {
                    timeState += 0.2;
                }
                else if(rotateState == 0)
                {
                    timeState += 0;
                }

                if (groupRequest.Contains("<1>"))
                {
                    main.serialPort1.WriteLine(groupRequest);
                    groupRequest = "<2>";
                }
                else if (groupRequest.Contains("<2>"))
                {
                    main.serialPort1.WriteLine(groupRequest);
                    groupRequest = "<1>";
                }
            }
            catch
            {

            }
        }

        private void Diagnostics_Load(object sender, EventArgs e)
        {

        }
    }
}
