/// The program described in README.md

using CarPark.Vehicles;
using CarPark.VehicleDetails;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark
{
    public class Program
    {
        public static void Main()
        {
            List<Vehicle> cars = new List<Vehicle>();

            PassengerCar passengerCar = new PassengerCar(
                "Passenger Car", "Blue", 200, 10, "Sedan", 
                new Engine("Gas", 123, 180, 2.4m),
                new Transmission("automatic", "ZF", 5),
                new Chassis(4, 234, 2000)
                );

            if (passengerCar.IsValid())
            {
                cars.Add(passengerCar);
            }
            else
            {
                Console.WriteLine("Bad news. Car is not valid!\n");
            }

            Truck truck = new Truck(
                "Truck", "White", 120, 11, 6,
                new Engine("Diesel", 345, 220, 6.4m),
                new Transmission("manual", "Bonfiglioli", 12),
                new Chassis(6, 456, 12000)
                );

            if (truck.IsValid())
            {
                cars.Add(truck);
            }
            else
            {
                Console.WriteLine("Bad news. Car is not valid!\n");
            }

            Bus bus = new Bus(
                "Bus", "Grey", 140, 12, 50,
                new Engine("Diesel", 567, 210, 5.4m),
                new Transmission("manual", "Linda", 10),
                new Chassis(4, 678, 8000)
                );

            if (bus.IsValid())
            {
                cars.Add(bus);
            }
            else
            {
                Console.WriteLine("Bad news. Car is not valid!\n");
            }

            Scooter scooter = new Scooter(
                "Scooter", "Red", 80, 13, "Disk",
                new Engine("Gas", 789, 10, 0.15m),
                new Transmission("variator", "CF", 1),
                new Chassis(2, 890, 200)
                );

            if (scooter.IsValid())
            {
                cars.Add(scooter);
            }
            else
            {
                Console.WriteLine("Bad news. Car is not valid!\n");
            }

            Console.WriteLine("Car Park\n");

            foreach (Vehicle car in cars)
            {
                if (car is PassengerCar)
                {
                    PassengerCar car1 = (PassengerCar)car;
                    car1.PropertiesOutput();
                }
                else if (car is Bus)
                {
                    Bus car1 = (Bus)car;
                    car1.PropertiesOutput();
                }
                else if (car is Truck)
                {
                    Truck car1 = (Truck)car;
                    car1.PropertiesOutput();
                }
                else if (car is Scooter)
                {
                    Scooter car1 = (Scooter)car;
                    car1.PropertiesOutput();
                }
                else
                {
                    Console.WriteLine("No such car!\n");
                }
            }
            /// <summary>
            /// build XElement with cars with engine volume > 1.5l. 
            /// Write it to the file "\bin\Debug\net6.0\HighVolVehicles.xml"
            /// </summary>
            #region 
            var subsetHighVolumeVehicles = from theCar in cars
                                        where theCar.engine.Volume > 1.5m
                                        orderby theCar.engine.Volume
                                        select theCar;

            List<XElement> highVolumeVehicles = new List<XElement>();

            foreach (var car in subsetHighVolumeVehicles)
            {
                if (car is PassengerCar)
                {
                    PassengerCar car1 = (PassengerCar)car;
                    highVolumeVehicles.Add(car1.PropertiesXmlOutput());
                }
                else if (car is Bus)
                {
                    Bus car1 = (Bus)car;
                    highVolumeVehicles.Add(car1.PropertiesXmlOutput());
                }
                else if (car is Truck)
                {
                    Truck car1 = (Truck)car;
                    highVolumeVehicles.Add(car1.PropertiesXmlOutput());
                }
                else if (car is Scooter)
                {
                    Scooter car1 = (Scooter)car;
                    highVolumeVehicles.Add(car1.PropertiesXmlOutput());
                }
                else
                {
                    Console.WriteLine("No such car!\n");
                }
                //highVolumeVehicles.Add(car.PropertiesXmlOutput());
            }

            XElement xHighVolumeVehicles = new XElement("Vehicles", highVolumeVehicles);

            XmlFileWriter(@"HighVolVehicles.xml", xHighVolumeVehicles);

            #endregion

            /// <summary>
            /// build XElement with Engine type, serial number and power rating for all buses and trucks. 
            /// Write it to the file "\bin\Debug\net6.0\BusesAndTrucks.xml"
            /// <summary>
            #region 
            var subsetTrucksAndBuses = from theCar in cars
                                       where (theCar.Model == "Truck") || (theCar.Model == "Bus")
                                       orderby theCar.engine.Volume
                                       select theCar;

            List<XElement> trucksAndBuses = new List<XElement>();

            foreach (var car in subsetTrucksAndBuses)
            {
                XElement vehicle = new XElement(car.Model,
                    new XElement("EngineType", car.engine.EngineType),
                    new XElement("SerialNumber", car.engine.SerialNumber),
                    new XElement("Power", car.engine.Power)
                    );

                trucksAndBuses.Add(vehicle);
            }

            XElement xTrucksAndBuses = new XElement("TrucksAndBuses", trucksAndBuses);

            XmlFileWriter(@"TrucksAndBuses.xml", xTrucksAndBuses);

            #endregion

            /// <summary>
            /// build XElement with information about all vehicles, grouped by transmission type. 
            /// Write it to the file "\bin\Debug\net6.0\Transmission___.xml"
            /// </summary>
            #region

            //create list with transmission types without duplicates
            List<string> transmissionTypes = new List<string>();

            foreach (var car in cars)
            {
                transmissionTypes.Add(car.transmission.Type);
            }

            transmissionTypes = transmissionTypes.Distinct().ToList();
            //

            foreach (string transmissionType in transmissionTypes)
            {
                var subsetTransmissionType = from theCar in cars
                                       where theCar.transmission.Type == transmissionType
                                       orderby theCar.engine.Volume
                                       select theCar;

                List<XElement> carsSortedByTransmissionType = new List<XElement>();

                foreach (var car in subsetTransmissionType)
                {
                    if (car is PassengerCar)
                    {
                        PassengerCar car1 = (PassengerCar)car;
                        carsSortedByTransmissionType.Add(car1.PropertiesXmlOutput());
                    }
                    else if (car is Bus)
                    {
                        Bus car1 = (Bus)car;
                        carsSortedByTransmissionType.Add(car1.PropertiesXmlOutput());
                    }
                    else if (car is Truck)
                    {
                        Truck car1 = (Truck)car;
                        carsSortedByTransmissionType.Add(car1.PropertiesXmlOutput());
                    }
                    else if (car is Scooter)
                    {
                        Scooter car1 = (Scooter)car;
                        carsSortedByTransmissionType.Add(car1.PropertiesXmlOutput());
                    }
                    else
                    {
                        Console.WriteLine("No such car!\n");
                    }
                    //carsSortedByTransmissionType.Add(car.PropertiesXmlOutput());
                }

                XElement xCarsSortedByTransmissionType = new XElement(transmissionType, carsSortedByTransmissionType);

                XmlFileWriter($"Transmission {transmissionType}.xml", xCarsSortedByTransmissionType);
            }

            #endregion
        }
        public static void XmlFileWriter(string fileName, XElement xElement)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false)
                    )
                {
                    writer.WriteLine(xElement);
                    writer.Close();
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}