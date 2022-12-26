using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Engine
    {
        public string EngineType
        { get; set; }
        public int SerialNumber
        { get; set; }
        public decimal Power
        { get; set; }
        public decimal Volume
        { get; set; }

        public void EngineOutput()
        {
            Console.WriteLine("Engine Characteristics: ");
            Console.WriteLine("Type: " + EngineType);
            Console.WriteLine("Serial Number: " + SerialNumber);
            Console.WriteLine("Power: " + Power + "hp");
            Console.WriteLine("Volume: " + Volume + "l\n");
        }
    }
}
