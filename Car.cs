using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public Engine engine;
        public Transmission transmission;
        public Chassis chassis;
        public void CarPropertiesOutput()
        {
            Console.WriteLine(Model + " Characteristics: ");
            Console.WriteLine("\tColor: " + Color);
            Console.WriteLine("\tMax Speed: " + maxSpeed + "km/h");
            Console.WriteLine("\tPower: " + Power + "hp");
            Console.WriteLine("\tMax Load: " + MaxLoad + "kg\n");
            engine.EngineOutput();
            chassis.ChassisOutput();
            transmission.TransmissionOutput();
            Console.WriteLine("\n");
        }
        public Car(string model, string color, int maxSp, Engine eng, Transmission transm, Chassis chass)
        {
            Model = model;
            Color = color;
            maxSpeed = maxSp;
            engine = eng;
            transmission = transm;
            chassis = chass;
        }
        public Car()
        {
            Model = "";
            Color = "";
            maxSpeed = 0;
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }
        public XElement CarPropertiesXmlOutput()
        {
            XElement car = new XElement("Vehicle",
                new XElement("Model", Model),
                new XElement("Color", Color),
                new XElement("maxSpeed", maxSpeed),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                ); 
            return car;
        }
    }
}
