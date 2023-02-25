using CarPark.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark.VehicleDetails
{
    class Chassis
    {
        public bool IsValid
        {
            get
            {
                return propertiesIsValid;
            }
        }
        public int WheelsNumber
        {
            get
            {
                return wheelsNumber;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Wheels Number must be integer >= 1");
                    propertiesIsValid = false;
                }
                else
                {
                    wheelsNumber = value;
                }
            }
        }
        public int SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Serial Number must be >= 1 and <= 999");
                    propertiesIsValid = false;
                }
                else
                {
                    serialNumber = value;
                }
            }
        }
        public decimal Load
        {
            get
            {
                return load;
            }
            set
            {
                if (value < 0.1m)
                {
                    Console.WriteLine($"{GetType().Name}: Load must be >= 0.1");
                    propertiesIsValid = false;
                }
                else
                {
                    load = value;
                }
            }
        }

        private int wheelsNumber = 1;
        private int serialNumber = 1;
        private decimal load = 0.1m;
        private bool propertiesIsValid = true;

        public Chassis(int wheelsNumber, int SN, decimal load)
        {
            WheelsNumber = wheelsNumber;
            SerialNumber = SN;
            Load = load;
        }

        public Chassis()
        {
            WheelsNumber = wheelsNumber;
            SerialNumber = serialNumber;
            Load = load;
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
