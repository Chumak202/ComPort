using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPort
{
    internal class ComPortData : SerialPort
    {
        public static void SP()
        {
            SerialPort mySerialPort = new SerialPort("COM4");
            mySerialPort.BaudRate = 2400;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
            Console.ReadKey();
            mySerialPort.Close();
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            ParcelChek.Parcel(indata);
        }
    }
}
