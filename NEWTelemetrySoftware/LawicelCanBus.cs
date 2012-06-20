// Lawicel_canusb.cs
//
// C# Declarations for LAWICEL CANUSB DLL Driver
//
// http://www.canusb.com
// (c) 2005-2006 Lawicel AB, Sweden
// Rev. 0.0.2, 2006-09-12
//
// This C# Software is NO freeware/shareware!
//
// You are only permitted to use & modify this software if you
// own a CANUSB from LAWICEL AB, Sweden.
//
// Do not use this C# Demo software or parts of it to communicate
// with other CAN hardware other than the LAWICEL AB CANUSB Hardware.
//

using System;
using System.Text;
using System.Runtime.InteropServices;

class LAWICEL
{
    // CAN message
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CANMsg
    {
        public uint id;			// 11/29 bit Identifier
        public uint timestamp;  // Hardware Timestamp (0-9999mS)
        public byte flags;		// Message Flags
        public byte len;		// Number of data bytes 0-8
        public ulong data;		// Data Bytes 0..7
    }

    // Alternative CAN Frame
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CANMsgEx
    {
        public uint id;         // Message id
        public uint timestamp;  // timestamp in milliseconds
        public byte flags;     // [extended_id|1][RTR:1][reserver:6]
        public byte len;       // Frame size (0.8)
    }

    #region Bitrate Codes
    // BTR0+BTR1 register
    // Register values for BTR0/BTR1
    public const string CAN_BAUD_BTR_1M = "0x00:0x14";     //   1 MBit/sec
    public const string CAN_BAUD_BTR_500K = "0x00:0x1C";   // 500 KBit/sec
    public const string CAN_BAUD_BTR_250K = "0x01:0x1C";   // 250 KBit/sec
    public const string CAN_BAUD_BTR_125K = "0x03:0x1C";   // 125 KBit/sec
    public const string CAN_BAUD_BTR_100K = "0x43:0x2F";   // 100 KBit/sec
    public const string CAN_BAUD_BTR_50K = "0x47:0x2F";    //  50 KBit/sec
    public const string CAN_BAUD_BTR_20K = "0x53:0x2F";    //  20 KBit/sec
    public const string CAN_BAUD_BTR_10K = "0x67:0x2F";    //  10 KBit/sec
    public const string CAN_BAUD_BTR_5K = "0x7F:0x7F";     //   5 KBit/sec

    // Baudrate can also be set with "real" value if set to one of the
    // values below
    public const string CAN_BAUD_1M = "1000";				//   1 MBit / s
    public const string CAN_BAUD_800K = "800";				// 800 kBit / s
    public const string CAN_BAUD_500K = "500";				// 500 kBit / s
    public const string CAN_BAUD_250K = "250";				// 250 kBit / s
    public const string CAN_BAUD_125K = "125";				// 125 kBit / s
    public const string CAN_BAUD_100K = "100";				// 100 kBit / s
    public const string CAN_BAUD_50K = "50";				//  50 kBit / s
    public const string CAN_BAUD_20K = "20";				//  20 kBit / s
    public const string CAN_BAUD_10K = "10";				//  10 kBit / s
    #endregion

    #region Error Codes
    //  error return codes
    public const int ERROR_CANUSB_OK = 1;                  // All is OK
    public const int ERROR_CANUSB_OPEN_SUBSYSTEM = -2;     // Problems with driver subsystem
    public const int ERROR_CANUSB_COMMAND_SUBSYSTEM = -3;  // Unable to send command to adapter
    public const int ERROR_CANUSB_NOT_OPEN = -4;           // Channel not open
    public const int ERROR_CANUSB_TX_FIFO_FULL = -5;       // Transmit fifo full
    public const int ERROR_CANUSB_INVALID_PARAM = -6;      // Invalid parameter
    public const int ERROR_CANUSB_NO_MESSAGE = -7;         // No message available
    public const int ERROR_CANUSB_MEMORY_ERROR = -8;       // Out of memory
    public const int ERROR_CANUSB_NO_DEVICE = -9;          // No adapter available 
    public const int ERROR_CANUSB_TIMEOUT = -10;           // Timeout
    public const int ERROR_CANUSB_INVALID_HARDWARE = -11;  // Invalid hardware present
    #endregion

    // Msg Type:
    public const byte CANMSG_EXTENDED = 0x80;				// Extended Frame
    public const byte CANMSG_RTR = 0x40;					// RTR Frame

    // Open flags
    public const byte CANUSB_FLAG_TIMESTAMP = 0x00000001;
    public const byte CANUSB_FLAG_QUEUE_REPLACE = 0x0002;	// If input queue is full remove
    // oldest message and insert new
    // message.
    public const byte CANUSB_FLAG_BLOCK = 0x0004;	        // Block receive/transmit
    public const byte CANUSB_FLAG_SLOW = 0x0008;	            // Check ACK/NACK's
    public const byte CANUSB_FLAG_NO_LOCAL_SEND = 0x0010;	// Don't send transmited frames on
    // other local channels for the same
    // interface

    // Filter mask settings
    // Use codes below to receive all frames
    public const uint CANUSB_ACCEPTANCE_CODE_ALL = 0x00000000;
    public const uint CANUSB_ACCEPTANCE_MASK_ALL = 0xFFFFFFFF;

    // Flush flags
    public const uint FLUSH_WAIT = 0x00;
    public const uint FLUSH_DONTWAIT = 0x01;
    public const uint FLUSH_EMPTY_INQUEUE = 0x02;

    ///////////////////////////////////////////////////////////////////////////////
    // cansub_Open
    //
    //
    // Open CANUSB interface to device
    //
    // Returs handle to device if open was successfull or zero on falure.
    //
    //
    // szID
    // ====
    // USB Serial number for adapter or NULL to open the first found.
    // Serial number is not CANUSB HW#, it is USB chip #
    //
    //
    // szBitrate
    // =========
    // "10" for 10kbps
    // "20" for 20kbps
    // "50" for 50kbps
    // "100" for 100kbps
    // "250" for 250kbps
    // "500" for 500kbps
    // "800" for 800kbps
    // "1000" for 1Mbps
    //
    // or
    //
    // btr0:btr1 pair  ex. "0x03:0x1c" or 3:28
    //
    // acceptance_code
    // ===============
    // Set to CANUSB_ACCEPTANCE_CODE_ALL to  get all messages.
    //
    // acceptance_mask
    // ===============
    // Set to CANUSB_ACCEPTANCE_MASk_ALL to  get all messages.
    //
    // flags
    // =====
    // CANUSB_FLAG_TIMESTAMP - Timestamp will be set by adapter.
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Open")]
    public static extern uint canusb_Open(string szID, string szBitrate, uint acceptance_code, uint acceptance_mask, uint flags);

    // Version of the above to be able to pass a null pointer
    // IntPtr.Zero is passed for szID to open first available driver
    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Open")]
    public static extern uint canusb_Open(IntPtr szID, string szBitrate, uint acceptance_code, uint acceptance_mask, uint flags);

    ///////////////////////////////////////////////////////////////////////////////
    // canusb_Close
    //
    // Close CANUSB interface with handle h.
    //
    // Returns <= 0 on failure. > 0 on success.

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Close")]
    public static extern int canusb_Close(uint handle);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_Read
    //
    // Read message from channel with handle h.
    //
    // Returns <= 0 on failure. >0 on success.
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Read")]
    public static extern int canusb_Read(uint handle, out CANMsg msg);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_ReadFirst 
    //
    // Read message from channel with handle h and id "id" which satisfy flags. 
    //
    // Returns <= 0 on failure. >0 on success.
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_ReadFirst")]
    public static extern int canusb_ReadFirst(uint h, uint id, uint flags, out CANMsg msg);

    ///////////////////////////////////////////////////////////////////////////////
    // canusb_Write
    //
    // Write message to channel with handle h.
    //
    // Returns <= 0 on failure. >0 on success.
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Write")]
    public static extern int canusb_Write(uint handle, ref CANMsg msg);

    ///////////////////////////////////////////////////////////////////////////////
    // canusb_Status
    //
    // Get CANUSB hardware status for channel with handle h.

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Status")]
    public static extern int canusb_Status(uint handle);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_VersionInfo
    //
    // Get hardware/firmware and driver version for channel with handle h.
    //
    // Returns <= 0 on failure. > 0 on success.
    //
    // Format
    //  "Hardware_Major.Hardware_Minor;Firmware_Major.Firmware_Minor;Driver_Major.Driver_Minor"
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_VersionInfo")]
    public static extern int canusb_VersionInfo(uint handle, StringBuilder verinfo);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_Flush
    //
    // Flush output buffer on channel with handle h. 
    //
    // Returns <= 0 on failure. >0 on success.
    //
    // If flushflags is set to FLUSH_DONTWAIT the queue is just emptied and 
    // there will be no wait for any frames in it to be sent 
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_Flush")]
    public static extern int canusb_Flush(uint h, byte flushflags);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_SetTimeouts
    //
    // Set timeouts used for blocking calls for channel with handle h. 
    //
    // Returns <= 0 on failure. >0 on success.
    //
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_SetTimeouts")]
    public static extern int canusb_SetTimeouts(uint h, uint receiveTimeout, uint transmitTimeout);

    ///////////////////////////////////////////////////////////////////////////////
    // canusb_getFirstAdapter
    //
    // Get the first found adapter that is connected to this machine.
    //
    // Returns <= 0 on failure. 0 if no adapter found. >0 if one or more adapters
    //			is found.
    //
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_getFirstAdapter")]
    public static extern int canusb_getFirstAdapter(StringBuilder szAdapter, int size);


    ///////////////////////////////////////////////////////////////////////////////
    // canusb_getNextAdapter
    //
    // Get the found adapter(s) in turn that is connected to this machine.
    //
    // Returns <= 0 on failure. 0 if all adapters has been enumerated. >0 for a valid 
    // adapter return.
    //
    //

    [DllImport("..\\..\\dll\\canusbdrv.dll", EntryPoint = "canusb_getNextAdapter")]
    public static extern int canusb_getNextAdapter(StringBuilder szAdapter, int size);
}
