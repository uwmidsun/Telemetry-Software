using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Telemetry
{
    public partial class TelemetryGUI : Form
    {
        //public System.Data.DataSet MotorDataSet; // Dataset for storing Motor values 
        int motorCurrent_X = 0; int motorVelocity_X = 0; int BUSCurrent_X = 0;
        CANUSBConnection _CanUsbCon;
        DBConnection _SqliteCon;
        bool isStarted = false;

        public TelemetryGUI(CANUSBConnection CanUsbCon, DBConnection SqliteCon)
        {
            _CanUsbCon = CanUsbCon;      
            _SqliteCon = SqliteCon;
            InitializeComponent();
        }

        private delegate void ListAppendDelegate(List<CANMessage> msgList);

        public void DisplayMessage(List<CANMessage> msgList)
        {
            if (MessageList.InvokeRequired)
            {
                ListAppendDelegate d = new ListAppendDelegate(DisplayMessage);
                this.Invoke(d, new object[] { msgList });
            }
            else
            {
                foreach (CANMessage msg in msgList)
                {
                    int len = msg.getLength();
                    float[] arr = msg.getArr();

                    // Chart controls - Logger
                    for (int i = 0; i < len; ++i)
                    {
                        if (MessageList.Items.Count > 300)
                            MessageList.Items.RemoveAt(300);
                        
                       
                        // Store points in separate database and clear the graph so far
                        /*
                        if (MotorChart.Series["series1"].Points.Count >= 30)
                        {
                            System.Data.DataSet MotorDataSet_ = MotorChart.DataManipulator.ExportSeriesValues();
                            MotorDataSet.Merge(MotorDataSet_);
                            MotorChart.Series["series1"].Points.Clear();
                            MotorChart.Series["series2"].Points.Clear();
                        }
                        */
                        
                        ListViewItem MessageItem;

                        try
                        {
                            MessageItem = MessageList.Items.Insert(0, Globals.GetGroupNameFromId(msg.getId()));
                        }
                        catch (Exception x)
                        {
                            MessageItem = MessageList.Items.Insert(0, "index_not_found[" + msg.getId() + "]");
                        }
                        try
                        {
                            MessageItem.SubItems.Add(Globals.GetRowNameFromIdAndIndex(msg.getId(), i));
                        }
                        catch (Exception x)
                        {
                            MessageItem.SubItems.Add("index_not_found[" + msg.getId() + "][" + i + "]");
                        }
                        MessageItem.SubItems.Add("0x" + msg.getId().ToString("X3"));
                        MessageItem.SubItems.Add(arr[i].ToString());
                        MessageItem.SubItems.Add(DateTime.Now.ToString("yyyy h:mm:ss:fff"));

                        // chart controls - motor
                        if (msg.getId() == Globals.MCBA + 3)
                        {
                            Motor_Chart.Series["Motor Current"].Points.AddXY(motorCurrent_X, (double)arr[0]);
                            Motor_Chart.Series["Motor Velocity"].Points.AddXY(motorVelocity_X, (double)arr[1]);
                            motorCurrent_X++;
                            motorVelocity_X++;
                        }
                        
                        // chart controls - BUS
                        if (msg.getId() == Globals.MCBA + 2)
                        {
                            BUSChart.Series["BUSCurrent"].Points.AddXY(BUSCurrent_X, (double)arr[1]);
                        }
                         
                        // chart controls - battery
                        // not implemented yet; will display voltage for every battery cell                        
                        int numBattery = 30; // number of batteries to keep track of
                        for (int c = 1; c <= numBattery; c++)
                        {
                            BatteryChart.Series["BatteryVoltage"].Points.AddXY(c, 1);
                        }


                        // chart controls - misc
                        if (msg.getId() == Globals.MCBA + 14)
                        {
                            Misc_DCAmp.Text = arr[0].ToString();
                            Misc_Odometer.Text = arr[1].ToString();
                        }
                    }
                }
            }
        }

        // calculate ideal speed based on the information given
        public void calcIdealSpeed(double speed)
        {

        }


        private void Button_Logger_Start_Click(object sender, EventArgs e)
        {
            // check to prevent crashing
            if (isStarted)
                return;
            isStarted = true;

            // opens connection to CAN and the database
            _SqliteCon.OpenDatabase("C:/test.db");
            _SqliteCon.PrepareTables();
                
            _CanUsbCon.OpenConnection();
            if (_CanUsbCon.get_isConnected())
            {
                Thread _canUsbThread = new Thread(_CanUsbCon.MessageLoop);
                _canUsbThread.Start();
            }
            else
            {
                System.Console.WriteLine("Could not connect to CAN");
                return;
            }

            // GUI text label
            Logger_Status.Text = "Connected";
            Logger_Status.ForeColor = Color.Green;
            Motor_Status.Text = "Connected";
            Motor_Status.ForeColor = Color.Green;    

        }

        private void Button_Logger_Stop_Click(object sender, EventArgs e)
        {
            // check to prevent crashing
            if (!isStarted)
                return;

            isStarted = false;


            lock (_CanUsbCon)
            {
                _CanUsbCon.get_isFinished();
            }
            while (!_CanUsbCon.get_isConnected())
            {
                Thread.Sleep(10);
            }
            Logger_Status.Text = "Disconnected";
            Logger_Status.ForeColor = Color.Red;
            Motor_Status.Text = "Disconnected";
            Motor_Status.ForeColor = Color.Red;

            isStarted = false;
        }

        private void Button_Logger_Clear_Click(object sender, EventArgs e)
        {
            // Clear Logger
            MessageList.Items.Clear();
            
            // Clear motor chart
            // Currently this erases the whole graph, unable to resume the program once it's stopped. FIx it.
            Motor_Chart.Series["Motor Current"].Points.Clear();
            Motor_Chart.Series["Motor Velocity"].Points.Clear();
        }

        private void Button_Motor_Start_Click(object sender, EventArgs e)
        {
            Button_Logger_Start_Click(sender, e);
        }

        private void Button_Motor_Stop_Click(object sender, EventArgs e)
        {
            Button_Logger_Stop_Click(sender, e);
        }

        private void Button_Motor_Clear_Click(object sender, EventArgs e)
        {
            Button_Logger_Clear_Click(sender, e);
        }


        // Algorithm for calculating the ideal velocity based on the information gathered
        public void calcIdealVelocity()
        {
            // ?
        }
    }
}
