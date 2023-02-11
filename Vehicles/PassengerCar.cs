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
        { get; set; }

        public PassengerCar(string model, string color, int maxSpeed, string bodyType, Engine inputEngine, Transmission inputTransmission, Chassis inputChassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            BodyType = bodyType;
            engine = inputEngine;
            transmission = inputTransmission;
            chassis = inputChassis;
        }

        public PassengerCar()
        {
            Model = "";
            Color = "";
            MaxSpeed = 0;
            BodyType = "";
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public override void PropertiesOutput()
        {
            Console.WriteLine(Model + " Characteristics: ");
            Console.WriteLine($"\tColor: {Color}");
            Console.WriteLine($"\tMax Speed: {MaxSpeed} km/h");
            Console.WriteLine($"\tBody Type: {BodyType}");
            Console.WriteLine($"\tPower: {Power} hp");
            Console.WriteLine($"\tMax Load: {MaxLoad} kg\n");

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
                new XElement("BodyType", BodyType),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
