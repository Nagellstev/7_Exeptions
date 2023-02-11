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
        static void Main()
        {
            List<Vehicle> cars = new List<Vehicle>();

            PassengerCar passengerCar = new PassengerCar(
                "Passenger Car", "Blue", 200, "Sedan", 
                new Engine("Gas", 123, 180, 2.4m),
                new Transmission("automatic", "ZF", 5),
                new Chassis(4, 234, 2000)
                );
            cars.Add(passengerCar);

            Truck truck = new Truck(
                "Truck", "White", 120, 6,
                new Engine("Diesel", 345, 220, 6.4m),
                new Transmission("manual", "Bonfiglioli", 12),
                new Chassis(6, 456, 12000)
                );
            cars.Add(truck);

            Bus bus = new Bus(
                "Bus", "Grey", 140, 50,
                new Engine("Diesel", 567, 210, 5.4m),
                new Transmission("manual", "Linda", 10),
                new Chassis(4, 678, 8000)
                );
            cars.Add(bus);

            Scooter scooter= new Scooter(
                "Scooter", "Red", 80, "Disk",
                new Engine("Gas", 789, 10, 0.15m),
                new Transmission("variator", "CF", 1),
                new Chassis(2, 890, 200)
                );
            cars.Add(scooter);

            Console.WriteLine("Car Park\n");
            Console.WriteLine("\n");

            foreach (Vehicle car in cars)
            {
                car.PropertiesOutput();
            }
            /// <summary>
            /// build XElement with cars with engine volume > 1.5l. 
            /// Write it to the file "\bin\Debug\net6.0\HighVolVehicles.xml"
            /// </summary>
            #region 
            var subsetHighVolVehicles = from theCar in cars
                                        where theCar.engine.Volume > 1.5m
                                        orderby theCar.engine.Volume
                                        select theCar;

            List<XElement> highVolVehicles = new List<XElement>();

            foreach (Vehicle car in subsetHighVolVehicles)
            {
                highVolVehicles.Add(car.PropertiesXmlOutput());
            }

            XElement HVV = new XElement("Vehicles", highVolVehicles);

            XmlFileWriter(@"HighVolVehicles.xml", HVV);

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

            foreach (Vehicle car in subsetTrucksAndBuses)
            {
                XElement vehicle = new XElement(car.Model,
                    new XElement("EngineType", car.engine.EngineType),
                    new XElement("SerialNumber", car.engine.SerialNumber),
                    new XElement("Power", car.engine.Power)
                    );
                trucksAndBuses.Add(vehicle);
            }

            XElement TB = new XElement("TrucksAndBuses", trucksAndBuses);

            XmlFileWriter(@"TrucksAndBuses.xml", TB);

            #endregion

            /// <summary>
            /// build XElement with information about all vehicles, grouped by transmission type. 
            /// Write it to the file "\bin\Debug\net6.0\Transmission___.xml"
            /// </summary>
            #region

            //create list with transmission types without duplicates
            List<string> transmTypes = new List<string>();
            foreach (Vehicle car in cars)
            {
                transmTypes.Add(car.transmission.Type);
            }
            transmTypes = transmTypes.Distinct().ToList();
            //

            foreach (string trTy in transmTypes)
            {
                var subsetTransmType = from theCar in cars
                                       where theCar.transmission.Type == trTy
                                       orderby theCar.engine.Volume
                                       select theCar;

                List<XElement> trTyCars = new List<XElement>();
                foreach (Vehicle car in subsetTransmType)
                {
                    trTyCars.Add(car.PropertiesXmlOutput());
                }

                XElement TTY = new XElement(trTy, trTyCars);

                XmlFileWriter(@"Transmission " + trTy + ".xml", TTY);

            }

            #endregion
        }
        public static void XmlFileWriter(string filename, XElement xe)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, false)
                    )
                {
                    writer.WriteLine(xe);
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