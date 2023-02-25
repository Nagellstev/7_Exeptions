using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark.VehicleDetails
{
    class Engine
    {
        public bool IsValid
        {
            get
            {
                return propertiesIsValid;
            }
        }
        public string EngineType
        {
            get
            {
                return engineType;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill engine type");
                    propertiesIsValid = false;
                }
                else
                {
                    engineType = value;
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
                if (value < 1
                    || value > 999)
                {
                    Console.WriteLine($"{GetType().Name}: Serial Number must be >= 0 and <= 999");
                    propertiesIsValid = false;
                }
                else
                {
                    serialNumber = value;
                }
            }
        }
        public decimal Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value < 0.1m)
                {
                    Console.WriteLine($"{GetType().Name}: Power must be >= 0.1");
                    propertiesIsValid = false;
                }
                else
                {
                    power = value;
                }
            }
        }
        public decimal Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < 0.1m)
                {
                    Console.WriteLine($"{GetType().Name}: Volume must be >= 0.1");
                    propertiesIsValid = false;
                }
                else
                {
                    volume = value;
                }
            }
        }

        private string engineType = "default";
        private int serialNumber = 1;
        private decimal power = 0.1m;
        private decimal volume = 0.1m;
        private bool propertiesIsValid = true;

        public Engine(string engineType, int SN, decimal power, decimal volume)
        {
            EngineType = engineType;
            SerialNumber = SN;
            Power = power;
            Volume = volume;
        }

        public Engine()
        {
            EngineType = engineType;
            SerialNumber = serialNumber;
            Power = power;
            Volume = volume;
        }

        public void EngineOutput()
        {
            Console.WriteLine($"Engine Characteristics: ");
            Console.WriteLine($"Type: {EngineType}");
            Console.WriteLine($"Serial Number: {SerialNumber}");
            Console.WriteLine($"Power: {Power} hp");
            Console.WriteLine($"Volume: {Volume} l\n");
        }

        public XElement EngineXmlOutput()
        {
            XElement engine = new XElement("Engine",
                new XElement("EngineType", EngineType),
                new XElement("SerialNumber", SerialNumber.ToString()),
                new XElement("Power", Power.ToString()),
                new XElement("Volume", Volume.ToString())
                );

            return engine;
        }
    }
}
