using System.Threading;
using System.Timers;
using System;
using System.Collections.Generic;

namespace CanLogger
{
    public class CanUsbConnection
    {
        private bool _finished = false;

        private bool _connected = false;
        public bool Connected() { return _connected; }

        private uint _handle = 0;
        private LoggerCore _owner;

        private bool _test_mode = false;

        public void Finish()
        {
            _finished = true;
        }

        public CanUsbConnection(LoggerCore owner, bool test_mode)
        {
            _test_mode = test_mode;
            _owner = owner;
        }

        public void OpenConnection()
        {
            if (_test_mode)
            {
                _connected = true;
                return;
            }

            _handle = LAWICEL.canusb_Open(IntPtr.Zero,
                                            LAWICEL.CAN_BAUD_250K,
                                            LAWICEL.CANUSB_ACCEPTANCE_CODE_ALL,
                                            LAWICEL.CANUSB_ACCEPTANCE_MASK_ALL,
                                            LAWICEL.CANUSB_FLAG_TIMESTAMP);
            if (_handle > 0)
            {
                System.Console.WriteLine("Connected to CANUSB dongle.");
                _connected = true;
            }
            else
            {
                System.Console.WriteLine("Failed to connect.");
                _connected = false;
            }
        }

        private void Close()
        {
            if (_test_mode)
            {
                _connected = false;
                return;
            }

            int res = LAWICEL.canusb_Close(_handle);

            if (LAWICEL.ERROR_CANUSB_OK == res)
            {
                System.Console.WriteLine("CANUSB Connection Closed");
            }
            else
            {
                System.Console.WriteLine("Failed to Close CANUSB");
            }
            _connected = false;
        }

        public void MessageLoop()
        {
            if (!_connected)
                System.Console.WriteLine("Connection not opened, cannot start message loop");

            _finished = false;
            while (!_finished)
            {
                CatchMessages();
                Thread.Sleep(250);
            }

            Close();
        }

        private void CatchMessages()
        {
            LAWICEL.CANMsg canMsg = new LAWICEL.CANMsg();
            List<Message> msgList = new List<Message>();

            int counter = 0;
            bool needSaving = false;
            bool done = false;

            float temp1 = 0.01f;
            float temp2 = 0.01f;
            float sign = 1.0f;

            while (!done && counter < 64)
            {
                int retVal = 0;

                if (!_test_mode)
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
                        msgList.Add(new Message(canMsg.id, val1, val2, val3, val4));
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

                        msgList.Add(new Message(canMsg.id, WordToIEEEFloat(left), WordToIEEEFloat(right)));
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

//************************************************************************
/*private float WordToIEEEFloat(uint b)
    {
        //see http://www.psc.edu/general/software/packages/ieee/ieee.php

        uint sign = 0;
        uint exponent = 0;
        uint fraction = 0;

        //Extract sign, exponent and fraction
        sign = ((b >> 31) & 0x00000001);
        exponent = ((b >> 23) & 0xFF);
        fraction = (b & 0x7FFFFF);

        //System.Console.WriteLine("sign: " + sign + " exponent: " + exponent.ToString("X8") + " fraction: " + fraction.ToString("X8"));

        if (exponent == 255 && fraction != 0)
            return (float)Double.NaN; //TODO: NaN
        else if (exponent == 255 && sign == 1)
            return (float)Double.NaN; //TODO : negative infinity
        else if (exponent == 255 && sign == 0)
            return (float)Double.NaN; //TODO: infinity
        else if (exponent == 0 && fraction == 0)
            return 0;
        else
        {
            //Convert 23 fraction bits to decimal fraction
            int multb = 1;
            float fractionAsDec = 0;
            for (int i = 22; i >= 0; i--)
            {
                multb *= 2;
                fractionAsDec += ((fraction >> i) & 0x1) / (float)multb;
            }

            //System.Console.WriteLine("frac: " + fractionAsDec );

            if (0 < exponent && exponent < 255)
                return (float)((-2 * sign + 1) * Math.Pow(2, ((int)(exponent)) - 127) * (1 + fractionAsDec));
            else if (exponent == 0 && fraction != 0)
                return (float)((-2 * sign + 1) * Math.Pow(2, -126) * (fractionAsDec));

            System.Console.WriteLine("Should NOT BE HERE"); // TODO: assert
            return 0;
        }
    }*/