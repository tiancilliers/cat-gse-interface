using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Interface_V2
{
    class SLIP
    {
        const byte END = 0xC0;
        const byte ESC = 0xDB;
        const byte ESC_END = 0xDC;
        const byte ESC_ESC = 0xDD;

        //WifiMigrate
        TcpClient port;
        NetworkStream serverStream;
        //**

        TextBox txLog;
        TextBox rxLog;
        List<byte> buffer = new List<byte>();

        public SLIP(TcpClient port, TextBox txLog, TextBox rxLog)
        {
            //byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Helloo");
            //outStream[outStream.Length - 1] = END;
            //serverStream.Write(outStream, 0, outStream.Length);
            //serverStream.Flush();

            this.port = port;
            this.txLog = txLog;
            this.rxLog = rxLog;
        }

        public byte[] DoTransaction(byte[] message)
        {
            serverStream = port.GetStream();
            serverStream.Flush();
            txLog.Text = "TX >> " + BitConverter.ToString(message).Replace('-', ' ');
            List<byte> encoded = new List<byte>();
            foreach (byte b in message)
            {
                if (b == END)
                {
                    encoded.Add(ESC);
                    encoded.Add(ESC_END);
                }
                else if (b == ESC)
                {
                    encoded.Add(ESC);
                    encoded.Add(ESC_ESC);
                }
                else
                {
                    encoded.Add(b);
                }
            }
            encoded.Add(END);
            serverStream.Write(encoded.ToArray(), 0, encoded.Count);

            int c = 0;
            while ((c = serverStream.ReadByte()) != -1 && (c != END)) buffer.Add((byte)c);
            if (c != END) return new byte[] { };

            List<byte> translated = new List<byte>();
            for (int i = 0; i < buffer.Count; i++)
            {
                if (buffer[i] == ESC)
                {
                    i++;
                    if (buffer[i] == ESC_END) translated.Add(END);
                    else if (buffer[i] == ESC_ESC) translated.Add(ESC);
                }
                else translated.Add(buffer[i]);
            }
            buffer.Clear();
            rxLog.Text = "RX << " + BitConverter.ToString(translated.ToArray()).Replace('-', ' ');
            return translated.ToArray();
        }
    }
}
