using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;


namespace Interface_V2
{
    class UI
    {
        const byte CMD_IDENT = 0x01;
        const byte CMD_VERSION = 0x02;
        const byte CMD_VALVE_STATES = 0x03;
        const byte CMD_TEMP_STATES = 0x04;
        const byte CMD_PRESS_STATES = 0x05;
        const byte CMD_SET_SEQUENCE = 0x10;
        const byte CMD_SET_POSITION = 0x11;

        const byte ACK = 0xFF;
        const byte NACK = 0x00;

        [StructLayout(LayoutKind.Sequential, Size = 6*8)]
        public struct SensorData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
            public double[] sensors;
        }

        [StructLayout(LayoutKind.Sequential, Size = 32)]
        public struct ServoData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
            public ushort[] servos;
        }

        SLIP slip;

        public UI(SerialPort port, TextBox txLog, TextBox rxLog)
        {
            slip = new SLIP(port, txLog, rxLog);
        }

        public string GetIdent()
        {
            slip.SendPacket(new byte[]{ CMD_IDENT });
            return Encoding.ASCII.GetString(slip.ReceivePacket());
        }

        public string GetVersion()
        {
            slip.SendPacket(new byte[] { CMD_VERSION });
            return Encoding.ASCII.GetString(slip.ReceivePacket());
        }

        public SensorData GetPressureData()
        {
            slip.SendPacket(new byte[] { CMD_PRESS_STATES });
            return ByteArrayToStructure<SensorData>(slip.ReceivePacket());
        }

        public SensorData GetTemperatureData()
        {
            slip.SendPacket(new byte[] { CMD_TEMP_STATES });
            return ByteArrayToStructure<SensorData>(slip.ReceivePacket());
        }

        public void SetServoData(ServoData data)
        {
            byte[] command = new byte[33];
            command[0] = CMD_VALVE_STATES;
            StructureToByteArray<ServoData>(data).CopyTo(command, 1);
            slip.SendPacket(command);
            slip.ReceivePacket();
        }

        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            T obj = new T();
            int size = Marshal.SizeOf(obj);
            IntPtr handle = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, handle, size);
            obj = (T)Marshal.PtrToStructure(handle, obj.GetType());
            Marshal.FreeHGlobal(handle);
            return obj;
        }

        public static byte[] StructureToByteArray<T>(T obj) where T : struct
        {
            int size = Marshal.SizeOf(obj);
            IntPtr handle = Marshal.AllocHGlobal(size) ;
            byte[] arr = new byte[size];
            Marshal.StructureToPtr<T>(obj, handle, true);
            Marshal.Copy(handle, arr, 0, size);
            Marshal.FreeHGlobal(handle);
            return arr;
        }
    }
}
