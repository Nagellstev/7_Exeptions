using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark.VehicleDetails
{
    public class Chassis
    {
        public int WheelsNumber;
        public int SerialNumber;
        public decimal Load;

        public Chassis(int wheelsNumber, int SN, decimal load)
        {
            WheelsNumber = wheelsNumber;
            SerialNumber = SN;
            Load = load;
        }

        public Chassis()
        {
            WheelsNumber = 0;
            SerialNumber = 0;
            Load = 0;
        }

        public void ChassisOutput()
        {
            Console.WriteLine("Chassis Characteristics: ");
            Console.WriteLine($"Wheels Number: {WheelsNumber}");
            Console.WriteLine($"Serial Number: {SerialNumber}");
            Console.WriteLine($"Load: {Load} kg\n");
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
