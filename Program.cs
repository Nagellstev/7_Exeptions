/// The program described in README.md

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Program
    {
        static void Main()
        {

            Car PassengerCar = new Car();
            PassengerCar.Model = "Passenger Car";
            PassengerCar.maxSpeed = 200;
            PassengerCar.Color = "Blue";

            PassengerCar.engine.EngineType = "Gas";
            PassengerCar.engine.SerialNumber = 123;
            PassengerCar.engine.Volume = 2.4m;
            PassengerCar.engine.Power = 180;

            PassengerCar.chassis.WheelsNumber = 4;
            PassengerCar.chassis.Load = 2000;
            PassengerCar.chassis.SerialNumber = 234;

            PassengerCar.transmission.Manufacturer = "ZF";
            PassengerCar.transmission.GearsNumber = 5;
            PassengerCar.transmission.Type = "automatic";

            Car Truck = new Car();
            Truck.Model = "Truck";
            Truck.maxSpeed = 120;
            Truck.Color = "White";

            Truck.engine.EngineType = "Diesel";
            Truck.engine.SerialNumber = 345;
            Truck.engine.Volume = 6.4m;
            Truck.engine.Power = 220;

            Truck.chassis.WheelsNumber = 6;
            Truck.chassis.Load = 12000;
            Truck.chassis.SerialNumber = 456;

            Truck.transmission.Manufacturer = "Bonfiglioli";
            Truck.transmission.GearsNumber = 12;
            Truck.transmission.Type = "manual";

            Car Bus = new Car();
            Bus.Model = "Bus";
            Bus.maxSpeed = 140;
            Bus.Color = "Grey";

            Bus.engine.EngineType = "Diesel";
            Bus.engine.SerialNumber = 567;
            Bus.engine.Volume = 5.4m;
            Bus.engine.Power = 210;

            Bus.chassis.WheelsNumber = 4;
            Bus.chassis.Load = 8000;
            Bus.chassis.SerialNumber = 678;

            Bus.transmission.Manufacturer = "Linda";
            Bus.transmission.GearsNumber = 10;
            Bus.transmission.Type = "manual";

            Car Scooter = new Car();
            Scooter.Model = "Scooter";
            Scooter.maxSpeed = 80;
            Scooter.Color = "Red";

            Scooter.engine.EngineType = "Gas";
            Scooter.engine.SerialNumber = 789;
            Scooter.engine.Volume = 0.15m;
            Scooter.engine.Power = 10;

            Scooter.chassis.WheelsNumber = 2;
            Scooter.chassis.Load = 200;
            Scooter.chassis.SerialNumber = 890;

            Scooter.transmission.Manufacturer = "CF";
            Scooter.transmission.GearsNumber = 1;
            Scooter.transmission.Type = "Variator";

            Console.WriteLine("Car Park\n");
            Console.WriteLine("\n");
            PassengerCar.CarPropertiesOutput();
            Truck.CarPropertiesOutput();
            Bus.CarPropertiesOutput();
            Scooter.CarPropertiesOutput();
        }
    }
}