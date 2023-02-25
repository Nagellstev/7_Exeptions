using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    class Vehicle
    {
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill model");
                    propertiesIsValid = false;
                }
                else
                {
                    model = value;
                }
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill color");
                    propertiesIsValid = false;
                }
                else
                {
                    color = value;
                }
            }
        }
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Speed must be >= 1");
                    propertiesIsValid = false;
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 1
                    || value > 999)
                {
                    Console.WriteLine($"{GetType().Name}: Number must be >= 1 and <= 999");
                    propertiesIsValid = false;
                }
                else
                {
                    number = value;
                }
            }
        }
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

        private string model = "default";
        private string color = "default";
        private int maxSpeed = 1;
        private int number = 1;
        private bool propertiesIsValid = true;

        public Vehicle() 
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public Vehicle(string model, string color, int maxSpeed, int number, Engine engine, Transmission transmission, Chassis chassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
        }
        public virtual bool IsValid()
        {
            if (chassis.IsValid != true ||
                engine.IsValid != true ||
                transmission.IsValid != true ||
                propertiesIsValid != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PropertiesOutput()
        {
            if (IsValid())
            {
                Console.WriteLine($"{Model} Characteristics: ");
                Console.WriteLine($"Vehicle Type: {GetType().Name}");
                Console.WriteLine($"\tColor: {Color}");
                Console.WriteLine($"\tMax Speed: {MaxSpeed} km/h");
                Console.WriteLine($"\tNumber: {Number}");
                Console.WriteLine($"\tPower: {Power} hp");
                Console.WriteLine($"\tMax Load: {MaxLoad} kg\n");

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
    }
}
