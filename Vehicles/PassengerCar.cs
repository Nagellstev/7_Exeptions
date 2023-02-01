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


        public PassengerCar(string model, string color, int maxSp, string bodyType, Engine eng, Transmission transm, Chassis chass)
        {
            Model = model;
            Color = color;
            maxSpeed = maxSp;
            BodyType = bodyType;
            engine = eng;
            transmission = transm;
            chassis = chass;
        }

        public PassengerCar()
        {
            Model = "";
            Color = "";
            maxSpeed = 0;
            BodyType = "";
            engine = new Engine();
            transmission = new Transmission();
            chassis = new Chassis();
        }

        public override void PropertiesOutput()
        {
            Console.WriteLine(Model + " Characteristics: ");
            Console.WriteLine($"\tColor: {Color}");
            Console.WriteLine($"\tMax Speed: {maxSpeed} km/h");
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
                new XElement("maxSpeed", maxSpeed),
                new XElement("BodyType", BodyType),
                engine.EngineXmlOutput(),
                chassis.ChassisXmlOutput(),
                transmission.TransmissionXmlOutput()
                );
            return car;
        }
    }
}
