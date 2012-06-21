using System.Threading;
using System.Timers;
using System;
using System.Collections.Generic;

namespace Telemetry
{
    public class CANUSBConnection
    {
        private bool isFinished = false;
        private bool isConnected = false;
        private bool test = false;
        private uint _handle = 0;
        private LoggerCore _owner;

        // getter
        public bool get_isConnected() 
        { 
            return isConnected; 
        }

        public void get_isFinished()
        {
            isFinished = true;
        }

        public CANUSBConnection(LoggerCore owner, bool test_mode)
        {
            test = test_mode;
            _owner = owner;
        }

        public void OpenConnection()
        {
            if (test)
            {
                isConnected = true;
                return;
            }

            _handle = LAWICEL.canusb_Open(IntPtr.Zero,
                                            LAWICEL.CAN_BAUD_250K,
                                            LAWICEL.CANUSB_ACCEPTANCE_CODE_ALL,
                                            LAWICEL.CANUSB_ACCEPTANCE_MASK_ALL,
                                            LAWICEL.CANUSB_FLAG_TIMESTAMP);
            if (_handle > 0)
            {
                System.Console.WriteLine("Connected to CANUSB.");
                isConnected = true;
            }
            else
            {
                System.Console.WriteLine("Failed to connect.");
                isConnected = false;
            }
        }

        private void Close()
        {
            if (test)
            {
                isConnected = false;
                return;
            }

            int res = LAWICEL.canusb_Close(_handle);

            if (LAWICEL.ERROR_CANUSB_OK == res)
            {
                System.Console.WriteLine("CANUSB connection closed.");
            }
            else
            {
                System.Console.WriteLine("Failed to close.");
            }
            isConnected = false;
        }

        public void MessageLoop()
        {
            if (!isConnected)
                System.Console.WriteLine("Connection not opened; cannot start message loop.");

            isFinished = false;
            while (!isFinished)
            {
                CatchMessages();
                Thread.Sleep(150);
            }

            Close();
        }

        private void CatchMessages()
        {
            LAWICEL.CANMsg canMsg = new LAWICEL.CANMsg();
            List<CANMessage> msgList = new List<CANMessage>();

            int counter = 0;
            bool needSaving = false;
            bool done = false;

            float temp1 = 0.01f;
            float sign = 1.0f;

            while (!done && counter < 64)
            {
                int retVal = 0;

                if (!test)
                    retVal = LAWICEL.canusb_Read(_handle, out canMsg);
                else
                {
                    canMsg.data = 0x3FC000003F800000;
                    canMsg.id = Globals.MCBA + 3;
                    retVal = LAWICEL.ERROR_CANUSB_OK;
                }
                if (IsValidId(canMsg.id))
                {
                    if (canMsg.id >= 0x700)
                    {
                        float val1 = ((canMsg.data >> 48) & 0xFFFF);
                        float val2 = ((canMsg.data >> 32) & 0xFFFF);
                        float val3 = ((canMsg.data >> 16) & 0xFFFF);
                        float val4 = canMsg.data & 0xFFFF;
                        val1 = (val1 / 0xFFFF) * 5;
                        val2 = (val2 / 0xFFFF) * 5;
                        val3 = (val3 / 0xFFFF) * 5;
                        val4 = (val4 / 0xFFFF) * 5;
                        msgList.Add(new CANMessage(canMsg.id, val1, val2, val3, val4));
                    }
                    else
                    {
                        uint left = 0;
                        uint right = 0;
                        left = (uint)((canMsg.data >> 32) & 0xFFFFFFFF);
                        right = (uint)(canMsg.data & 0xFFFFFFFF);

                        if (temp1 >= 100.0)
                            sign = -sign;
                        else if (temp1 <= 0.0)
                            sign = -sign;

                        msgList.Add(new CANMessage(canMsg.id, WordToIEEEFloat(left), WordToIEEEFloat(right)));
                    }

                    needSaving = true;
                    counter++;
                }
                else
                {
                    done = true;
                }
            }

            if (needSaving)
            {
                _owner.PushMessageList(msgList);
            }

            counter = 0;
            needSaving = false;
        }

        private float WordToIEEEFloat(uint b)
        {
            float f;
            unsafe
            {
                uint* intref = &b;
                f = *((float*)intref);
            }
            return f;
        }

        private uint FlipEndian(uint beforeFlip)
        {
            uint retval = 0;

            retval = (beforeFlip >> 24) & 0x000000FF;
            retval |= (beforeFlip >> 8) & 0x0000FF00;
            retval |= (beforeFlip << 8) & 0x00FF0000;
            retval |= (beforeFlip << 24) & 0xFF000000;

            return retval;
        }

        private bool IsValidId(uint id)
        {
            if ((id == Globals.DCBA + 1) ||
                (id == Globals.DCBA + 2) ||
                (id == Globals.MCBA + 3) ||
                (id == Globals.MCBA + 2) ||
                (id == Globals.MCBA + 14))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}