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
    public class GSE
    {
        public const byte CMD_IDENT = 0x00;
        public const byte CMD_VERSION = 0x01;
        public const byte CMD_SET_VALVES = 0x02;
        public const byte CMD_GET_VALVES = 0x03;
        public const byte CMD_TEMP_STATES = 0x04;
        public const byte CMD_PRESS_STATES = 0x05;
        public const byte CMD_TEMP_TYPES = 0x06;
        public const byte CMD_PRESS_TYPES = 0x07;
        public const byte CMD_SINGLE_VALVE = 0x08;
        public const byte CMD_SET_OX_STATES = 0x11;
        public const byte CMD_SET_FUEL_STATES = 0x12;
        public const byte CMD_RESET_STATE = 0x13;
        public const byte CMD_BUTTON_PRESSED = 0x14;
        public const byte CMD_GET_STATES = 0x15;
        public const byte CMD_ABORT_ABORT = 0xFF;

        public const byte ACK = 0xFF;
        public const byte NACK = 0x00;



        [StructLayout(LayoutKind.Sequential, Size = 6 * 8)]
        public struct SensorData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
            public double[] sensors;
        }

        [StructLayout(LayoutKind.Sequential, Size = 6)]
        public struct SensorTypeData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] types;
        }

        [StructLayout(LayoutKind.Sequential, Size = 32)]
        public struct ServoData
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
            public ushort[] servos;
        }

        [StructLayout(LayoutKind.Sequential, Size = 12)]
        public struct ServoKeyframe
        {
            public uint delay_ms_before;
            public uint servo_state;
            public byte servo_idx;
            public byte temp1, temp2, temp3;
        }

        [StructLayout(LayoutKind.Sequential, Size = 60)]
        public struct StateTransition
        {
            public byte transition_flags; // bit0: abort transition
            public byte trigger_type;
            public byte target_state;
            public byte temp1;
            public uint trigger_param1;
            public uint trigger_param2;//12
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
            public ServoKeyframe[] transition;//48
        }

        [StructLayout(LayoutKind.Sequential, Size = 516)]
        public struct StateNode
        {
            public uint state_flags; // bit0: state active
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
            public ushort[] state_servos;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
            public StateTransition[] transitions;
        }

        SLIP slip;

        public GSE(SerialPort port, TextBox txLog, TextBox rxLog)
        {
            slip = new SLIP(port, txLog, rxLog);
        }

        public string GetIdent()
        {
            return Encoding.ASCII.GetString(slip.DoTransaction(new byte[] { CMD_IDENT }));
        }

        public string GetVersion()
        {
            return Encoding.ASCII.GetString(slip.DoTransaction(new byte[] { CMD_VERSION }));
        }

        public SensorData GetPressureData()
        {
            return ByteArrayToStructure<SensorData>(slip.DoTransaction(new byte[] { CMD_PRESS_STATES }));
        }

        public SensorData GetTemperatureData()
        {
            return ByteArrayToStructure<SensorData>(slip.DoTransaction(new byte[] { CMD_TEMP_STATES }));
        }

        public ServoData GetValveStates()
        {
            return ByteArrayToStructure<ServoData>(slip.DoTransaction(new byte[] { CMD_GET_VALVES }));
        }

        public void SetSensorType(byte type, SensorTypeData data)
        {
            byte[] command = new byte[97];
            command[0] = type;
            StructureToByteArray<SensorTypeData>(data).CopyTo(command, 1);
            slip.DoTransaction(command);
        }

        public void SetMachineStates(byte type, StateNode[] nodes)
        {
            byte[] command = new byte[1+ 516 * 8];
            command[0] = type;
            for (int i = 0; i < 8; i++)
            {
                byte[] tesrt = StructureToByteArray<StateNode>(nodes[i]);
                StructureToByteArray<StateNode>(nodes[i]).CopyTo(command, 1+ 516 * i);
            }
            //MessageBox.Show(BitConverter.ToString(command));
            slip.DoTransaction(command);
        }

        public void ResetState()
        {
            slip.DoTransaction(new byte[] { CMD_RESET_STATE });
        }

        public void SendButtonPressed(byte buttonIdx)
        {
            slip.DoTransaction(new byte[] { CMD_BUTTON_PRESSED, buttonIdx });
        }

        public void Abort()
        {
            slip.DoTransaction(new byte[] { CMD_ABORT_ABORT });
        }

        public byte[] GetStates()
        {
            return slip.DoTransaction(new byte[] { CMD_GET_STATES });
        }

        public void SetValveStates(ServoData data)
        {
            byte[] command = new byte[33];
            command[0] = CMD_SET_VALVES;
            StructureToByteArray<ServoData>(data).CopyTo(command, 1);
            slip.DoTransaction(command);
        }

        public void SetValveState(byte servo, int value)
        {
            byte[] command = new byte[6];
            command[0] = CMD_SINGLE_VALVE;
            command[1] = servo;
            BitConverter.GetBytes(value).CopyTo(command, 2);
            slip.DoTransaction(command);
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
