using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark
{
    class Chassis
    {
        public int WheelsNumber;
        public int SerialNumber;
        public decimal Load;
        public void ChassisOutput()
        {
            Console.WriteLine("  Chassis Characteristics: ");
            Console.WriteLine("\tWheels Number: " + WheelsNumber);
            Console.WriteLine("\tSerial Number: " + SerialNumber);
            Console.WriteLine("\tLoad: " + Load + "kg\n");
        }
        public Chassis(int wheelsNum, int SN, decimal load)
        {
            WheelsNumber = wheelsNum;
            SerialNumber = SN;
            Load = load;
        }
        public Chassis()
        {
            WheelsNumber = 0;
            SerialNumber = 0;
            Load = 0;
        }
        public XElement ChassisXmlOutput()
        {
            XElement chassis = new XElement("Chassis",
                new XElement("WheelsNumber", WheelsNumber.ToString()),
                new XElement("SerialNumber", SerialNumber.ToString()),
                new XElement("Load", Load.ToString())
                );
            return chassis;
        }
    }
}
