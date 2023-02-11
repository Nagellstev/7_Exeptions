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

        public Scooter(string model, string color, int maxSpeed, string brakesType, Engine inputEngine, Transmission inputTransmission, Chassis inputChassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            BrakesType = brakesType;
            engine = inputEngine;
            transmission = inputTransmission;
            chassis = inputChassis;
        }

        public Scooter()
        {
            Model = "";
            Color = "";
            MaxSpeed = 0;
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
            Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
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
                new XElement("maxSpeed", MaxSpeed),
                new XElement("BrakesType", BrakesType),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
