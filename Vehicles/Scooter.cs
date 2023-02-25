using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    internal class Scooter : Vehicle
    {
        public string BrakesType
        {
            get
            {
                return brakesType;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill brakes type");
                    thisPropertiesIsValid = false;
                }
                else
                {
                    brakesType = value;
                }
            }
        }

        private string brakesType;
        private bool thisPropertiesIsValid = true;

        public Scooter(string model, string color, int maxSpeed, int number, string brakesType, Engine engine, Transmission transmission, Chassis chassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            BrakesType = brakesType;
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
        }

        public Scooter()
        {
            Model = "default";
            Color = "default";
            MaxSpeed = 1;
            Number = 1;
            BrakesType = "default";
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public void PropertiesOutput()
        {
            if (IsValid())
            {
                Console.WriteLine($"{Model} Characteristics: ");
                Console.WriteLine($"Vehicle Type: {GetType().Name}");
                Console.WriteLine($"Brakes Type: {BrakesType}");
                Console.WriteLine($"Color: {Color}");
                Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
                Console.WriteLine($"Number: {Number}");
                Console.WriteLine($"Power: {Power} hp");
                Console.WriteLine($"Max Load: {MaxLoad} kg\n");

                engine.EngineOutput();
                chassis.ChassisOutput();
                transmission.TransmissionOutput();

                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"Something went wrong. {GetType().Name} is not valid");
                Console.WriteLine("\n");
            }
        }

        public XElement PropertiesXmlOutput()
        {
            if (IsValid())
            {
                XElement car = new XElement("Vehicle",
                    new XElement("VehicleType", GetType().Name),
                    new XElement("Model", Model),
                    new XElement("Color", Color),
                    new XElement("maxSpeed", MaxSpeed),
                    new XElement("Number", Number),
                    new XElement("BrakesType", BrakesType),
                    engine.EngineXmlOutput(),
                    chassis.ChassisXmlOutput(),
                    transmission.TransmissionXmlOutput()
                    );

                return car;
            }
            else
            {
                XElement car = new XElement("Vehicle",
                new XElement("VehicleType", $"{GetType().Name}NotValid")
                );

                return car;
            }
        }

        public override bool IsValid()
        {
            if (base.IsValid() != true ||
                thisPropertiesIsValid != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
