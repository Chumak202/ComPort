using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComPort
{
    public static class ParcelChek
    {
        public static string Message { get; set; } = "";

        public static void Parcel(string indata)
        {

            if (indata.Length == 15)
            {
                Message = indata;
                Chek(Message);
            }
            else
            {
                foreach (char b in indata)
                {
                    switch (b)
                    {
                        case '$':
                            if (Message.Length == 0)
                            {
                                Message += b;
                                break;
                            }
                            Message = Message.Remove(0);
                            Message += b;
                            break;
                        case '\n':
                            if (Message.Length == 14)
                            {
                                Message += b;
                                Chek(Message);
                                break;
                            }
                            Message += b;
                            break;
                        default:
                            Message += b;
                            break;
                    }
                }
            }
        }

        public static void Chek(string message)
        {
            Regex regex = new Regex(@"^\x24\d{2}.\d{2},\d{3}.\d{2}\r\n$");
            MatchCollection matches = regex.Matches(message);
            if (matches.Count > 0)
            {
                Message = Message.Remove(0);
                Parse parse = new Parse();
                parse.ParseToParam(message);
            }
        }
    }
}
