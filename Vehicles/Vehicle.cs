using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarPark.VehicleDetails;

namespace CarPark.Vehicles
{
    public class Vehicle
    {
        public string Model
        { get; set; }
        public string Color
        { get; set; }
        public int MaxSpeed
        { get; set; }
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

        public virtual void PropertiesOutput()
        {
            Console.WriteLine($"{Model} Characteristics: ");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
            Console.WriteLine($"Power: {Power} hp");
            Console.WriteLine($"Max Load: {MaxLoad} kg\n");

            engine.EngineOutput();
            chassis.ChassisOutput();
            transmission.TransmissionOutput();

            Console.WriteLine("\n");
        }

        public virtual XElement PropertiesXmlOutput()
        {
            XElement car = new XElement("Vehicle",
                new XElement("Model", Model),
                new XElement("Color", Color),
                new XElement("maxSpeed", MaxSpeed),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }

        public virtual bool IsValid()
        {
            if (
                !string.IsNullOrEmpty(Model) &&
                !string.IsNullOrEmpty(Color) &&
                MaxSpeed > 0 &&
                Power > 0 &&

                !string.IsNullOrEmpty(engine.EngineType) &&
                engine.SerialNumber > 0 &&
                engine.Volume > 0 &&
                engine.Power > 0 &&

                chassis.WheelsNumber > 0 &&
                chassis.Load > 0 &&
                chassis.SerialNumber > 0 &&

                !string.IsNullOrEmpty(transmission.Manufacturer) &&
                transmission.GearsNumber > 0 &&
                !string.IsNullOrEmpty(transmission.Type)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
