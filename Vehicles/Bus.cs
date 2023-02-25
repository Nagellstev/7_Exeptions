using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    internal class Bus : Vehicle
    {
        public int PassengerCaparcity
        {
            get
            {
                return passengerCaparcity;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Passenger Caparcity must be >= 1");
                    thisPropertiesIsValid = false;
                }
                else
                {
                    passengerCaparcity = value;
                }
            }
        }

        private int passengerCaparcity;
        private bool thisPropertiesIsValid = true;

        public Bus(string model, string color, int maxSpeed, int number, int passengerCaparcity, Engine engine, Transmission transmission, Chassis chassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            Number = number;
            PassengerCaparcity = passengerCaparcity;
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
        }

        public Bus()
        {
            Model = "default";
            Color = "default";
            MaxSpeed = 1;
            Number = 1;
            PassengerCaparcity = 1;
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
                Console.WriteLine($"Passenger Caparcity: {PassengerCaparcity}");
                Console.WriteLine($"Color: {Color}");
                Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
                Console.WriteLine($"Number: {Number} km/h");
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
                    new XElement("PassengerCaparcity", PassengerCaparcity),
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
