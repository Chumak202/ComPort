using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Text.Json;
using System.Text.Encodings.Web;
using System.Collections;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ComPort
{
    
    public class Param
    {
        public string NameSensors { get; set; }
        public double WindDirrection { get; set; }
        public double WindSpeed { get; set; }
        public DateTime Realtime { get; set; }

    }
    public class Parse
    {


        public void ParseToParam(string message)
        {

            double windDir = double.Parse(message.ToString().Substring(7, 6));
            if (windDir >= 0.0 && windDir <= 359.99)
            {

            }
            else
            {
                windDir = -1;
            }
            double windSpeed = double.Parse(message.ToString().Substring(1, 5));
            DateTime realtime = DateTime.Now;
            Program.Params.Add(new Param
            {
                NameSensors = "WMT700",
                WindDirrection = windDir,
                WindSpeed = windSpeed,
                Realtime = realtime
            });
            var json = JsonConvert.SerializeObject(Program.Params);
            StreamWriter sw = new StreamWriter(Program.Path, false);
            sw.Write(json);
            sw.Close();

        }
          
    }
}
