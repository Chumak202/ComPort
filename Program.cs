using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComPort
{
    class Program
    {
        public static List<Param> Params { get; set; } = new List<Param>();

        public static string Path = "\\\\hpstore\\PelengStore\\25T\\25E\\4-работа КИН\\Backup\\Sensor.txt";
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (File.Exists(Path))
            {

            }
            else
            {
                StreamWriter sw = new StreamWriter(Path, true);
                sw.Close();
            }
            ComPortData.SP();
           
        }
    }
}





