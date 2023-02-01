using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    internal class Scooter : Vehicle
    {
        public string BrakesType
        { get; set; }


        public Scooter(string model, string color, int maxSp, string brakesType, Engine eng, Transmission transm, Chassis chass)
        {
            Model = model;
            Color = color;
            maxSpeed = maxSp;
            BrakesType = brakesType;
            engine = eng;
            transmission = transm;
            chassis = chass;
        }

        public Scooter()
        {
            Model = "";
            Color = "";
            maxSpeed = 0;
            BrakesType = "";
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public override void PropertiesOutput()
        {
            Console.WriteLine($"{Model} Characteristics: ");
            Console.WriteLine($"Brakes Type: {BrakesType}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Max Speed: {maxSpeed} km/h");
            Console.WriteLine($"Power: {Power} hp");
            Console.WriteLine($"Max Load: {MaxLoad} kg\n");
            engine.EngineOutput();
            chassis.ChassisOutput();
            transmission.TransmissionOutput();
            Console.WriteLine("\n");
        }

        public override XElement PropertiesXmlOutput()
        {
            XElement car = new XElement("Vehicle",
                new XElement("Model", Model),
                new XElement("Color", Color),
                new XElement("maxSpeed", maxSpeed),
                new XElement("BrakesType", BrakesType),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
