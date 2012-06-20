using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

static class Globals
{
    public const int JORDAN = 0x700;
    public const int DCBA = 0x500;
    public const int MCBA = 0x400;

    static private Dictionary<uint, List<string>> entryNames = new Dictionary<uint, List<string>>{
        {DCBA + 1, new List<string>{"motorCurrent", "motorVelocity"}},
        {DCBA + 2, new List<string>{"", "busCurrent"}},
        {MCBA + 2, new List<string>{"", "busCurrent"}},
        {MCBA + 3, new List<string>{"vehicleVelocity", "motorVelocity"}},
        {MCBA + 14, new List<string>{"DCBusAmpHours", "odometer"}}
        // add battery voltage somewhere
    };

    static private Dictionary<uint, string> groupNames = new Dictionary<uint,string>{
        {DCBA + 1, "MotorDriveDriverControls"},
        {DCBA + 2, "MotorPowerDriverControls"},
        {MCBA + 2, "BusMeasurement"},
        {MCBA + 3, "VelocityMeasurement"}
    };

    public static string GetRowNameFromIdAndIndex(uint id, int index)
    {
        try
        {
            lock (typeof(Globals))
            {
                return entryNames[id][index];
            }
        }
        catch
        {
            return "index_not_found[" + id + "][" + index + "]";
        }
    }

    public static string GetGroupNameFromId(uint id)
    {
        try
        {
            lock (typeof(Globals))
            {
                return groupNames[id];
            }
        }
        catch
        {
            return "index_not_found[" + id + "]";
        }
    }
}

namespace Telemetry
{
    public class Run
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new LoggerCore().Start(); 
        }
    }

    public class LoggerCore
    {
        CANUSBConnection _CanUsbCon;
        DBConnection _SqliteCon;
        TelemetryGUI _GUI;
        
        public void Start()
        {
            _SqliteCon = new DBConnection();
            _CanUsbCon = new CANUSBConnection(this, false);
            _GUI = new TelemetryGUI(_CanUsbCon, _SqliteCon);
            Application.Run(_GUI);
        }

        public void PushMessageList(List<CANMessage> msgList)
        {
            _GUI.DisplayMessage(msgList);
            _SqliteCon.SaveMessageList(msgList);
        }
    }
}
