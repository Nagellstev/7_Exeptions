using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    internal class Truck : Vehicle
    {
        public int TruckBodyVolume
        {
            get
            {
                return truckBodyVolume;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Number must be >= 1");
                    thisPropertiesIsValid = false;
                }
                else
                {
                    truckBodyVolume = value;
                }
            }
        }

        private int truckBodyVolume;
        private bool thisPropertiesIsValid = true;

        public Truck(string model, string color, int maxSpeed, int number, int truckBodyVolume, Engine engine, Transmission transmission, Chassis chassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            TruckBodyVolume = truckBodyVolume;
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
        }

        public Truck()
        {
            Model = "default";
            Color = "default";
            MaxSpeed = 1;
            Number = 1;
            TruckBodyVolume = 1;
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
                Console.WriteLine($"Truck Body Volume: {TruckBodyVolume} m3");
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
                    new XElement("TruckBodyVolume", TruckBodyVolume),
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
