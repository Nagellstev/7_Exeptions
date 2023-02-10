using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CarPark.Exeptions;
using CarPark.Vehicles;
using CarPark.VehicleDetails;

namespace CarPark
{
    class ProcessingCarPark
    {
        public static Vehicle InputNewCar()
        {
            string model;
            int carType;
            int passengerCaparsity;
            int truckBodyVolume;
            string bodyType;
            string brakesType;
            int number;
            string color;
            int maxSpeed;

            Console.WriteLine("Input New Car:");
            Console.WriteLine("Input Car type:");
            Console.WriteLine("\t1 - Truck");
            Console.WriteLine("\t2 - Bus");
            Console.WriteLine("\t3 - Scooter");
            Console.WriteLine("\t4 - Passenger Car");

            if (int.TryParse(Console.ReadLine(), out carType) != true ||
                carType < 1 ||
                carType > 5)
            {
                throw new AddExeption("Car type is incorrect.");
            }

            Console.WriteLine("\tInput Model:");
            model = Console.ReadLine();
            Console.WriteLine("\tNumber:");

            if (int.TryParse(Console.ReadLine(), out number) != true)
            {
                throw new AddExeption("Number is incorrect.");
            }

            Console.WriteLine("\tColor:");
            color = Console.ReadLine();
            Console.WriteLine("\tInput Max Speed:");

            if (int.TryParse(Console.ReadLine(), out maxSpeed) != true)
            {
                throw new AddExeption("Max Speed is incorrect.");
            }

            switch (carType)
            {
                case 1:
                    Console.WriteLine("\tInput truck body volume:");

                    if (int.TryParse(Console.ReadLine(), out truckBodyVolume) != true)
                    {
                        throw new AddExeption("Max Speed is incorrect.");
                    }

                    return new Truck(
                        model, color, number, maxSpeed, truckBodyVolume,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        );

                    break;

                case 2:
                    Console.WriteLine("\tInput passenger caparsity:");

                    if (int.TryParse(Console.ReadLine(), out passengerCaparsity) != true)
                    {
                        throw new AddExeption("Max Speed is incorrect.");
                    }

                    return new Truck(
                        model, color, number, maxSpeed, passengerCaparsity,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        );

                    break;

                case 3:
                    Console.WriteLine("\tInput brakes type:");
                    brakesType = Console.ReadLine();

                    return new Scooter(
                        model, color, number, maxSpeed, brakesType,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        );

                    break;

                case 4:
                    Console.WriteLine("\tInput body type:");
                    bodyType = Console.ReadLine();

                    return new Scooter(
                        model, color, number, maxSpeed, bodyType,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        );

                    break;

                default:
                    break;
            }

            return new Vehicle();
        }

        private static Engine InputNewEngine()
        {
            string type;
            int SN;
            decimal power;
            decimal volume;

            Console.WriteLine("Input New Engine:");
            Console.WriteLine("\tType:");
            type = Console.ReadLine();
            Console.WriteLine("\tSerial Number:");

            if (!int.TryParse(Console.ReadLine(), out SN))
            {
                throw new AddExeption("Serial Number is incorrect.");
            }

            Console.WriteLine("\tPower:");

            if (!decimal.TryParse(Console.ReadLine(), out power))
            {
                throw new AddExeption("Serial Number is incorrect.");
            }

            Console.WriteLine("\tVolume:");

            if (!decimal.TryParse(Console.ReadLine(), out volume))
            {
                throw new AddExeption("Serial Number is incorrect.");
            }

            return new Engine(type, SN, power, volume);
        }

        private static Transmission InputNewTransmission()
        {
            string type;
            string manufacturer;
            int gearsNumber;

            Console.WriteLine("Input New Transmission:");
            Console.WriteLine("\tType:");
            type = Console.ReadLine();
            Console.WriteLine("\tManufacturer:");
            manufacturer = Console.ReadLine();
            Console.WriteLine("\tGears Number:");

            if (!int.TryParse(Console.ReadLine(), out gearsNumber))
            {
                throw new AddExeption("Gears Number is incorrect.");
            }

            return new Transmission(type, manufacturer, gearsNumber);
        }

        private static Chassis InputNewChassis()
        {
            int wheelsNumber;
            int SN;
            decimal load;

            Console.WriteLine("Input New Chassis:");
            Console.WriteLine("\tWheels Number:");

            if (int.TryParse(Console.ReadLine(), out wheelsNumber) != true)
            {
                throw new AddExeption("Wheels Number is incorrect.");
            }

            Console.WriteLine("\tSerial Number:");

            if (!int.TryParse(Console.ReadLine(), out SN))
            {
                throw new AddExeption("Serial Number is incorrect.");
            }

            Console.WriteLine("\tMax Load:");

            if (!decimal.TryParse(Console.ReadLine(), out load))
            {
                throw new AddExeption("Serial Number is incorrect.");
            }

            return new Chassis(wheelsNumber, SN, load);
        }

        public static void CarPropertiesOutput(Vehicle car)
        {
            Console.WriteLine(car.Model + " Characteristics: ");
            Console.WriteLine("\tNumber: " + car.Number);
            Console.WriteLine("\tColor: " + car.Color);
            Console.WriteLine("\tMax Speed: " + car.MaxSpeed + "km/h");
            Console.WriteLine("\tPower: " + car.Power + "hp");
            Console.WriteLine("\tMax Load: " + car.MaxLoad + "kg\n");

            EngineOutput(car.engine);
            ChassisOutput(car.chassis);
            TransmissionOutput(car.transmission);

            Console.WriteLine("\n");
        }

        private static void EngineOutput(Engine engine)
        {
            Console.WriteLine("  Engine Characteristics: ");
            Console.WriteLine("\tType: " + engine.EngineType);
            Console.WriteLine("\tSerial Number: " + engine.SerialNumber);
            Console.WriteLine("\tPower: " + engine.Power + "hp");
            Console.WriteLine("\tVolume: " + engine.Volume + "l\n");
        }

        private static void ChassisOutput(Chassis chassis)
        {
            Console.WriteLine("  Chassis Characteristics: ");
            Console.WriteLine("\tWheels Number: " + chassis.WheelsNumber);
            Console.WriteLine("\tSerial Number: " + chassis.SerialNumber);
            Console.WriteLine("\tLoad: " + chassis.Load + "kg\n");
        }

        private static void TransmissionOutput(Transmission transmission)
        {
            Console.WriteLine("  Transmission Characteristics: ");
            Console.WriteLine("\tType: " + transmission.Type);
            Console.WriteLine("\tManufacturer: " + transmission.Manufacturer);
            Console.WriteLine("\tGearsNumber: " + transmission.GearsNumber + "\n");
        }

        public static XElement CarXmlOutput(Vehicle car)
        {
            XElement Xcar = new XElement("Vehicle",
                new XElement("Model", car.Model),
                new XElement("Number", car.Number),
                new XElement("Color", car.Color),
                new XElement("maxSpeed", car.MaxSpeed),
                EngineXmlOutput(car.engine),
                ChassisXmlOutput(car.chassis),
                TransmissionXmlOutput(car.transmission)
                );

            return Xcar;
        }

        private static XElement EngineXmlOutput(Engine engine)
        {
            XElement Xengine = new XElement("Engine",
                new XElement("EngineType", engine.EngineType),
                new XElement("SerialNumber", engine.SerialNumber.ToString()),
                new XElement("Power", engine.Power.ToString()),
                new XElement("Volume", engine.Volume.ToString())
                );

            return Xengine;
        }

        private static XElement ChassisXmlOutput(Chassis chassis)
        {
            XElement Xchassis = new XElement("Chassis",
                new XElement("WheelsNumber", chassis.WheelsNumber.ToString()),
                new XElement("SerialNumber", chassis.SerialNumber.ToString()),
                new XElement("Load", chassis.Load.ToString())
                );

            return Xchassis;
        }

        private static XElement TransmissionXmlOutput(Transmission transmission)
        {
            XElement Xtransmission = new XElement("Transmission",
                new XElement("Type", transmission.Type),
                new XElement("Manufacturer", transmission.Manufacturer),
                new XElement("GearsNumber", transmission.GearsNumber.ToString())
                );

            return Xtransmission;
        }

        public static void SaveCars(string filename, List<Vehicle> cars)
        {
            List<XElement> carsToSave = new List<XElement>();

            foreach (Vehicle car in cars)
            {
                carsToSave.Add(CarXmlOutput(car));
            }

            XmlFileWriter(filename, new XElement("Vehicles", carsToSave));
        }

        public static List<Vehicle> LoadCars(string filename)
        {
            List<Vehicle> cars = new List<Vehicle>();

            foreach (XElement xElement in XElement.Load(filename).Elements("Vehicle"))
            {
                string engineType = "";
                int engineSN = 0;
                decimal power = 0;
                decimal volume = 0;
                string transmType = "";
                string transmManuf = "";
                int gearsNum = 0;
                int wheelsNum = 0;
                int chassisSN = 0;
                decimal load = 0;

                string model = xElement.Element("Model").Value;
                int number = Convert.ToInt32(xElement.Element("Number").Value);
                string color = xElement.Element("Color").Value;
                int maxSpeed = Convert.ToInt32(xElement.Element("maxSpeed").Value);
                string carType = xElement.Element("VehicleType").Value;
                int passengerCaparsity = Convert.ToInt32(xElement.Element("PassengerCaparsity").Value);
                int truckBodyVolume = Convert.ToInt32(xElement.Element("TruckBodyVolume").Value);
                string bodyType = xElement.Element("BodyType").Value;
                string brakesType = xElement.Element("BrakesType").Value;

                foreach (XElement xElementL2 in xElement.Elements("Engine"))
                {
                    engineType = xElementL2.Element("EngineType").Value;
                    engineSN = Convert.ToInt32(xElementL2.Element("SerialNumber").Value);
                    power = Convert.ToDecimal(xElementL2.Element("Power").Value);
                    volume = Convert.ToDecimal(xElementL2.Element("Volume").Value);
                }

                foreach (XElement xElementL2 in xElement.Elements("Transmission"))
                {
                    transmType = xElementL2.Element("Type").Value;
                    transmManuf = xElementL2.Element("Manufacturer").Value;
                    gearsNum = Convert.ToInt32(xElementL2.Element("GearsNumber").Value);
                }

                foreach (XElement xElementL2 in xElement.Elements("Chassis"))
                {
                    wheelsNum = Convert.ToInt32(xElementL2.Element("WheelsNumber").Value);
                    chassisSN = Convert.ToInt32(xElementL2.Element("SerialNumber").Value);
                    load = Convert.ToDecimal(xElementL2.Element("Load").Value);
                }

                switch (carType)
                {
                    case "Bus":
                        cars.Add(new Bus(
                            model, color, maxSpeed, number, passengerCaparsity,
                            new Engine(engineType, engineSN, power, volume),
                            new Transmission(transmType, transmManuf, gearsNum),
                            new Chassis(wheelsNum, chassisSN, load)
                            ));

                        break;

                    case "Truck":
                        cars.Add(new Truck(
                            model, color, maxSpeed, number, truckBodyVolume,
                            new Engine(engineType, engineSN, power, volume),
                            new Transmission(transmType, transmManuf, gearsNum),
                            new Chassis(wheelsNum, chassisSN, load)
                            ));

                        break;

                    case "Scooter":
                        cars.Add(new Scooter(
                            model, color, maxSpeed, number, brakesType,
                            new Engine(engineType, engineSN, power, volume),
                            new Transmission(transmType, transmManuf, gearsNum),
                            new Chassis(wheelsNum, chassisSN, load)
                            ));

                        break;

                    case "PassengerCar":
                        cars.Add(new Scooter(
                            model, color, maxSpeed, number, bodyType,
                            new Engine(engineType, engineSN, power, volume),
                            new Transmission(transmType, transmManuf, gearsNum),
                            new Chassis(wheelsNum, chassisSN, load)
                            ));

                        break;

                    default:
                        break;
                }
            }
            return cars;
        }

        public static void DeleteCar(List<Vehicle> cars, int carNumber)
        {
            var carToDelete = from theCar in cars
                                        where theCar.Number == carNumber
                                        orderby theCar.Number
                                        select theCar;

            if (carToDelete.Count() <= 0)
            {
                throw new RemoveAutoException("No cars with such number.");
            }

            foreach (Vehicle car in carToDelete)
            {
                cars.Remove(car);
            }
        }

        public static void ReplaceCar(List<Vehicle> cars, int carNumber)
        {
            string model;
            string color;
            int maxSpeed;
            int passengerCaparsity;
            int truckBodyVolume;
            string brakesType;
            string bodyType;

            var carToDelete = from theCar in cars
                              where theCar.Number == carNumber
                              orderby theCar.Number
                              select theCar;

            if (carToDelete.Count() <= 0)
            {
                throw new UpdateAutoException("No cars with such number.");
            }

            string carType = carToDelete.GetType().Name;

            Console.WriteLine("Input New Car:");
            Console.WriteLine("\tInput Model:");
            model = Console.ReadLine();
            Console.WriteLine("\tColor:");
            color = Console.ReadLine();
            Console.WriteLine("\tInput Max Speed:");

            if (!int.TryParse(Console.ReadLine(), out maxSpeed))
            {
                throw new UpdateAutoException("Number is incorrect.");
            }

            switch (carType)
            {
                case "Bus":
                    Console.WriteLine("\tInput Passenger caparsity:");

                    if (!int.TryParse(Console.ReadLine(), out passengerCaparsity))
                    {
                        throw new UpdateAutoException("Number is incorrect.");
                    }

                    cars.Add(new Bus(
                        model, color, maxSpeed, carNumber, passengerCaparsity,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        ));

                    break;

                case "Truck":
                    Console.WriteLine("\tInput truck Body Volume:");

                    if (!int.TryParse(Console.ReadLine(), out truckBodyVolume))
                    {
                        throw new UpdateAutoException("Number is incorrect.");
                    }

                    cars.Add(new Truck(
                        model, color, maxSpeed, carNumber, truckBodyVolume,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        ));

                    break;

                case "Scooter":
                    Console.WriteLine("\tInput brakes type:");
                    brakesType = Console.ReadLine();

                    cars.Add(new Scooter(
                        model, color, maxSpeed, carNumber, brakesType,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        ));

                    break;

                case "PassengerCar":
                    Console.WriteLine("\tInput brakes type:");
                    bodyType = Console.ReadLine();

                    cars.Add(new PassengerCar(
                        model, color, maxSpeed, carNumber, bodyType,
                        InputNewEngine(),
                        InputNewTransmission(),
                        InputNewChassis()
                        ));

                    break;

                default:
                    break;
            }
            DeleteCar(cars, carNumber);
        }

        public static List<Vehicle> LoadAutoByParameters(string filename)
        {
            Vehicle carForComparision = InputNewCar();
            List<Vehicle> cars = new List<Vehicle>();

            foreach (XElement xElement in XElement.Load(filename).Elements("Vehicle"))
            {
                string engineType = "";
                int engineSN = 0;
                decimal power = 0;
                decimal volume = 0;
                string transmType = "";
                string transmManuf = "";
                int gearsNum = 0;
                int wheelsNum = 0;
                int chassisSN = 0;
                decimal load = 0;

                string model = xElement.Element("Model").Value;
                int number = Convert.ToInt32(xElement.Element("Number").Value);
                string color = xElement.Element("Color").Value;
                int maxSpeed = Convert.ToInt32(xElement.Element("maxSpeed").Value);
                string vehicleType = xElement.Element("VehicleType").Value;
                int passengerCaparcity = Convert.ToInt32(xElement.Element("PassengerCaparcity").Value);
                int truckBodyVolume = Convert.ToInt32(xElement.Element("TruckBodyVolume").Value);
                string brakesType = xElement.Element("BrakesType").Value;
                string bodyType = xElement.Element("BodyType").Value;

                foreach (XElement xElementL2 in xElement.Elements("Engine"))
                {
                    engineType = xElementL2.Element("EngineType").Value;
                    engineSN = Convert.ToInt32(xElementL2.Element("SerialNumber").Value);
                    power = Convert.ToDecimal(xElementL2.Element("Power").Value);
                    volume = Convert.ToDecimal(xElementL2.Element("Volume").Value);
                    volume = Convert.ToDecimal(xElementL2.Element("Volume").Value);
                }

                foreach (XElement xElementL2 in xElement.Elements("Transmission"))
                {
                    transmType = xElementL2.Element("Type").Value;
                    transmManuf = xElementL2.Element("Manufacturer").Value;
                    gearsNum = Convert.ToInt32(xElementL2.Element("GearsNumber").Value);
                }

                foreach (XElement xElementL2 in xElement.Elements("Chassis"))
                {

                    wheelsNum = Convert.ToInt32(xElementL2.Element("WheelsNumber").Value);
                    chassisSN = Convert.ToInt32(xElementL2.Element("SerialNumber").Value);
                    load = Convert.ToDecimal(xElementL2.Element("Load").Value);
                }

                Vehicle loadedCar;

                switch (vehicleType)
                {
                    case "Bus":
                        loadedCar = new Bus(
                                model, color, number, maxSpeed, passengerCaparcity,
                                new Engine(engineType, engineSN, power, volume),
                                new Transmission(transmType, transmManuf, gearsNum),
                                new Chassis(wheelsNum, chassisSN, load)
                                );

                        break;

                    case "Truck":
                        loadedCar = new Truck(
                                model, color, number, maxSpeed, truckBodyVolume,
                                new Engine(engineType, engineSN, power, volume),
                                new Transmission(transmType, transmManuf, gearsNum),
                                new Chassis(wheelsNum, chassisSN, load)
                                );

                        break;

                    case "Scooter":
                        loadedCar = new Scooter(
                                model, color, number, maxSpeed, brakesType,
                                new Engine(engineType, engineSN, power, volume),
                                new Transmission(transmType, transmManuf, gearsNum),
                                new Chassis(wheelsNum, chassisSN, load)
                                );

                        break;

                    case "PassengerCar":
                        loadedCar = new PassengerCar(
                                model, color, number, maxSpeed, bodyType,
                                new Engine(engineType, engineSN, power, volume),
                                new Transmission(transmType, transmManuf, gearsNum),
                                new Chassis(wheelsNum, chassisSN, load)
                                );

                        break;

                    default:
                        loadedCar = new Vehicle();
                        break;
                }

                if (
                    (carForComparision.Model == loadedCar.Model || carForComparision.Model == "") &&
                    (carForComparision.Number == loadedCar.Number || carForComparision.Number == 0) &&
                    (carForComparision.Color == loadedCar.Color || carForComparision.Color == "") &&
                    (carForComparision.MaxSpeed == loadedCar.MaxSpeed || carForComparision.MaxSpeed == 0) &&
                    (carForComparision.engine.EngineType == loadedCar.engine.EngineType || carForComparision.engine.EngineType == "") &&
                    (carForComparision.engine.SerialNumber == loadedCar.engine.SerialNumber || carForComparision.engine.SerialNumber == 0) &&
                    (carForComparision.engine.Power == loadedCar.engine.Power || carForComparision.engine.Power == 0) &&
                    (carForComparision.engine.Volume == loadedCar.engine.Volume || carForComparision.engine.Volume == 0) &&
                    (carForComparision.transmission.Type == loadedCar.transmission.Type || carForComparision.transmission.Type == "") &&
                    (carForComparision.transmission.Manufacturer == loadedCar.transmission.Manufacturer || carForComparision.transmission.Manufacturer == "") &&
                    (carForComparision.transmission.GearsNumber == loadedCar.transmission.GearsNumber || carForComparision.transmission.GearsNumber == 0) &&
                    (carForComparision.chassis.WheelsNumber == loadedCar.chassis.WheelsNumber || carForComparision.chassis.WheelsNumber == 0) &&
                    (carForComparision.chassis.SerialNumber == loadedCar.chassis.SerialNumber || carForComparision.chassis.SerialNumber == 0) &&
                    (carForComparision.chassis.Load == loadedCar.chassis.Load || carForComparision.chassis.Load == 0)
                    )
                {
                    cars.Add(loadedCar);
                }
            }

            return cars;
        }

        public static List<Vehicle> GetAutoByUserParameter(List<Vehicle> cars, string parameter, string value)
        {
            string modelComp = "";
            int numberComp = 0;
            string colorComp = "";
            int maxSpeedComp = 0;
            string engineTypeComp = "";
            int engineSnComp = 0;
            decimal powerComp = 0;
            decimal volumeComp = 0;
            string transmTypeComp = "";
            string transmManufComp = "";
            int gearsNumComp = 0;
            int wheelsNumComp = 0;
            int chassisSnComp = 0;
            decimal loadComp = 0;

            switch (parameter)
            {
                case "Model":
                    modelComp = value;
                    break;

                case "Number":
                    if (!int.TryParse(value, out numberComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Number.");
                    }

                    break;

                case "Color":
                    colorComp = value;
                    break;

                case "maxSpeed":
                    if (!int.TryParse(value, out maxSpeedComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Max Speed.");
                    }

                    break;

                case "EngineType":
                    engineTypeComp = value;
                    break;

                case "Engine SN":
                    if (!int.TryParse(value, out engineSnComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Engine SN.");
                    }

                    break;

                case "Power":
                    if (!decimal.TryParse(value, out powerComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Power.");
                    }

                    break;

                case "Volume":
                    if (!decimal.TryParse(value, out volumeComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Volume.");
                    }

                    break;

                case "Type":
                    transmTypeComp = value;
                    break;

                case "Manufacturer":

                    transmManufComp = value;
                    break;

                case "GearsNumber":
                    if (!int.TryParse(value, out gearsNumComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Gears Number.");
                    }

                    break;

                case "WheelsNumber":
                    if (!int.TryParse(value, out wheelsNumComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Wheels Number.");
                    }

                    break;

                case "Chassis SN":
                    if (!int.TryParse(value, out chassisSnComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Chassis SN.");
                    }

                    break;

                case "Load":
                    if (!decimal.TryParse(value, out loadComp))
                    {
                        throw new GetAutoByParameterException("Incorrect Load.");
                    }

                    break;

                default:
                    throw new GetAutoByParameterException("Parameter name is incorrect.");
                    break;
            }

            var selectedCars = from car in cars
                               where (
                               (modelComp == car.Model || modelComp == "") &&
                               (numberComp == car.Number || numberComp == 0) &&
                               (colorComp == car.Color || colorComp == "") &&
                               (maxSpeedComp == car.MaxSpeed || maxSpeedComp == 0) &&
                               (engineTypeComp == car.engine.EngineType || engineTypeComp == "") &&
                               (engineSnComp == car.engine.SerialNumber || engineSnComp == 0) &&
                               (powerComp == car.engine.Power || powerComp == 0) &&
                               (volumeComp == car.engine.Volume || volumeComp == 0) &&
                               (transmTypeComp == car.transmission.Type || transmTypeComp == "") &&
                               (transmManufComp == car.transmission.Manufacturer || transmManufComp == "") &&
                               (gearsNumComp == car.transmission.GearsNumber || gearsNumComp == 0) &&
                               (wheelsNumComp == car.chassis.WheelsNumber || wheelsNumComp == 0) &&
                               (chassisSnComp == car.chassis.SerialNumber || chassisSnComp == 0) &&
                               (loadComp == car.chassis.Load || loadComp == 0)
                               )
                               select car;

            if (selectedCars == null || selectedCars.Count() <= 0 )
            {
                throw new GetAutoByParameterException("No cars with such parameter found.");
            }

            return selectedCars.ToList();
        }

        public static List<Vehicle> GetAutoByParameters(List<Vehicle> cars)
        {
            Vehicle carForComparision = InputNewCar();

            var selectedCars = from car in cars
                                     where (
                                     (carForComparision.Model == car.Model || carForComparision.Model == "") &&
                                     (carForComparision.Number == car.Number || carForComparision.Number == 0) &&
                                     (carForComparision.Color == car.Color || carForComparision.Color == "") &&
                                     (carForComparision.MaxSpeed == car.MaxSpeed || carForComparision.MaxSpeed == 0) &&
                                     (carForComparision.engine.EngineType == car.engine.EngineType || carForComparision.engine.EngineType == "") &&
                                     (carForComparision.engine.SerialNumber == car.engine.SerialNumber || carForComparision.engine.SerialNumber == 0) &&
                                     (carForComparision.engine.Power == car.engine.Power || carForComparision.engine.Power == 0) &&
                                     (carForComparision.engine.Volume == car.engine.Volume || carForComparision.engine.Volume == 0) &&
                                     (carForComparision.transmission.Type == car.transmission.Type || carForComparision.transmission.Type == "") &&
                                     (carForComparision.transmission.Manufacturer == car.transmission.Manufacturer || carForComparision.transmission.Manufacturer == "") &&
                                     (carForComparision.transmission.GearsNumber == car.transmission.GearsNumber || carForComparision.transmission.GearsNumber == 0) &&
                                     (carForComparision.chassis.WheelsNumber == car.chassis.WheelsNumber || carForComparision.chassis.WheelsNumber == 0) &&
                                     (carForComparision.chassis.SerialNumber == car.chassis.SerialNumber || carForComparision.chassis.SerialNumber == 0) &&
                                     (carForComparision.chassis.Load == car.chassis.Load || carForComparision.chassis.Load == 0)
                                     )
                                     select car;

            if (selectedCars == null || selectedCars.Count() <= 0)
            {
                throw new GetAutoByParameterException("No cars with such parameters found.");
            }

            return selectedCars.ToList();
        }

        private static void XmlFileWriter(string filename, XElement xe)
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
