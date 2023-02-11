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
        public int TrackBodyVolume
        { get; set; }

        public Truck(string model, string color, int maxSpeed, int trackBodyVolume, Engine inputEngine, Transmission inputTransmission, Chassis inputChassis)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxSpeed;
            TrackBodyVolume = trackBodyVolume;
            engine = inputEngine;
            transmission = inputTransmission;
            chassis = inputChassis;
        }

        public Truck()
        {
            Model = "";
            Color = "";
            MaxSpeed = 0;
            TrackBodyVolume = 0;
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public override void PropertiesOutput()
        {
            Console.WriteLine($"{Model} Characteristics: ");
            Console.WriteLine($"Track Body Volume: {TrackBodyVolume} m3");
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
                new XElement("TrackBodyVolume", TrackBodyVolume),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
