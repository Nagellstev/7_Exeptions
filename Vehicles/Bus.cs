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
        { get; set; }


        public Bus(string model, string color, int maxSp, int passengerCaparcity, Engine eng, Transmission transm, Chassis chass)
        {
            Model = model;
            Color = color;
            maxSpeed = maxSp;
            PassengerCaparcity = passengerCaparcity;
            engine = eng;
            transmission = transm;
            chassis = chass;
        }

        public Bus()
        {
            Model = "";
            Color = "";
            maxSpeed = 0;
            PassengerCaparcity = 0;
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public override void PropertiesOutput()
        {
            Console.WriteLine($"{Model} Characteristics: ");
            Console.WriteLine($"Passenger Caparcity: {PassengerCaparcity}");
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
                new XElement("PassengerCaparcity", PassengerCaparcity),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
