using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Car
    {
        public string Model
        { get; set; }
        public string Color
        { get; set; }
        public int maxSpeed
        { get; set; }
        public decimal Power
        {
            get
            {
                return engine.Power;
            }
        }
        public decimal MaxLoad
        {
            get
            {
                return chassis.Load;
            }
        }
        public Engine engine = new Engine();
        public Transmission transmission = new Transmission();
        public Chassis chassis = new Chassis();
        public void CarPropertiesOutput()
        {
            Console.WriteLine(Model + " Characteristics: ");
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Max Speed: " + maxSpeed + "km/h");
            Console.WriteLine("Power: " + Power + "hp");
            Console.WriteLine("Max Load: " + MaxLoad + "kg\n");
            engine.EngineOutput();
            chassis.ChassisOutput();
            transmission.TransmissionOutput();
            Console.WriteLine("\n");
        }
    }
}
