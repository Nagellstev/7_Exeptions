using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    internal class PassengerCar : Vehicle
    {
        public string BodyType
        {
            get
            {
                return bodyType;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill body type");
                    thisPropertiesIsValid = false;
                }
                else
                {
                    bodyType = value;
                }
            }
        }

        private string bodyType = "default";
        private bool thisPropertiesIsValid = true;

        public PassengerCar(string model, string color, int maxSpeed, int number, string bodyType, Engine engine, Transmission transmission, Chassis chassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            BodyType = bodyType;
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
        }

        public PassengerCar()
        {
            Model = "default";
            Color = "default";
            MaxSpeed = 1;
            Number = 1;
            BodyType = "default";
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
                Console.WriteLine($"\tColor: {Color}");
                Console.WriteLine($"\tMax Speed: {MaxSpeed} km/h");
                Console.WriteLine($"\tNumber: {Number}");
                Console.WriteLine($"\tBody Type: {BodyType}");
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
                //Console.WriteLine($"IsValid {IsValid()}");
                //Console.WriteLine($"chassis {chassis.IsValid}");
                //Console.WriteLine($"engine {engine.IsValid}");
                //Console.WriteLine($"transmission {transmission.IsValid}");
                //Console.WriteLine($"thisPropertiesIsValid {thisPropertiesIsValid}");
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
                    new XElement("BodyType", BodyType),
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
