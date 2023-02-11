using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark.VehicleDetails
{
    public class Engine
    {
        public string EngineType
        { get; set; }
        public int SerialNumber
        { get; set; }
        public decimal Power
        { get; set; }
        public decimal Volume
        { get; set; }


        public Engine(string engineType, int SN, decimal power, decimal volume)
        {
            EngineType = engineType;
            SerialNumber = SN;
            Power = power;
            Volume = volume;
        }

        public Engine()
        {
            EngineType = "";
            SerialNumber = 0;
            Power = 0;
            Volume = 0;
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
