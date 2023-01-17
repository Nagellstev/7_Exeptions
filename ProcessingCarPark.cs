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
using CarPark.Entities;

namespace CarPark
{
    class ProcessingCarPark
    {
        public static Car InputNewCar()
        {
            string model;
            int number;
            string color;
            int maxSpeed;
            Console.WriteLine("Input New Car:");
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
            return new Car(
                model, number, color, maxSpeed,
                InputNewEngine(),
                InputNewTransmission(),
                InputNewChassis()
                );
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
        public static void CarPropertiesOutput(Car car)
        {
            Console.WriteLine(car.Model + " Characteristics: ");
            Console.WriteLine("\tNumber: " + car.Number);
            Console.WriteLine("\tColor: " + car.Color);
            Console.WriteLine("\tMax Speed: " + car.maxSpeed + "km/h");
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
        public static XElement CarXmlOutput(Car car)
        {
            XElement Xcar = new XElement("Vehicle",
                new XElement("Model", car.Model),
                new XElement("Number", car.Number),
                new XElement("Color", car.Color),
                new XElement("maxSpeed", car.maxSpeed),
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
        public static void SaveCars(string filename, List<Car> cars)
        {
            List<XElement> carsToSave = new List<XElement>();
            foreach (Car car in cars)
            {
                carsToSave.Add(CarXmlOutput(car));
            }
            XmlFileWriter(filename, new XElement("Vehicles", carsToSave));
        }
        public static List<Car> LoadCars(string filename)
        {
            List<Car> cars = new List<Car>();
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

                cars.Add(new Car(
                    model, number, color, maxSpeed,
                    new Engine(engineType, engineSN, power, volume),
                    new Transmission(transmType, transmManuf, gearsNum),
                    new Chassis(wheelsNum, chassisSN, load)
                    ));
            }
            return cars;
        }
        public static void DeleteCar(List<Car> cars, int carNumber)
        {
            var carToDelete = from theCar in cars
                                        where theCar.Number == carNumber
                                        orderby theCar.Number
                                        select theCar;
            if (carToDelete.Count() <= 0)
            {
                throw new RemoveAutoException("No cars with such number.");
            }
            foreach (Car car in carToDelete)
            {
                cars.Remove(car);
            }
        }
        public static void ReplaceCar(List<Car> cars, int carNumber)
        {
            string model;
            string color;
            int maxSpeed;

            var carToDelete = from theCar in cars
                              where theCar.Number == carNumber
                              orderby theCar.Number
                              select theCar;
            if (carToDelete.Count() <= 0)
            {
                throw new UpdateAutoException("No cars with such number.");
            }

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

            Car car = new Car(model, carNumber, color, maxSpeed,
                InputNewEngine(),
                InputNewTransmission(),
                InputNewChassis()
                );

            DeleteCar(cars, carNumber);
            cars.Add(car);
        }
        public static List<Car> LoadAutoByParameters(string filename)
        {
            Car carForComparision = InputNewCar();

            List<Car> cars = new List<Car>();

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
                Car loadedCar = new Car(
                        model, number, color, maxSpeed,
                        new Engine(engineType, engineSN, power, volume),
                        new Transmission(transmType, transmManuf, gearsNum),
                        new Chassis(wheelsNum, chassisSN, load)
                        );
                if (
                    (carForComparision.Model == loadedCar.Model || carForComparision.Model == "") &&
                    (carForComparision.Number == loadedCar.Number || carForComparision.Number == 0) &&
                    (carForComparision.Color == loadedCar.Color || carForComparision.Color == "") &&
                    (carForComparision.maxSpeed == loadedCar.maxSpeed || carForComparision.maxSpeed == 0) &&
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
        public static List<Car> GetAutoByUserParameter(List<Car> cars, string parameter, string value)
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
                               (maxSpeedComp == car.maxSpeed || maxSpeedComp == 0) &&
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
        public static List<Car> GetAutoByParameters(List<Car> cars)
        {
            Car carForComparision = InputNewCar();

            var selectedCars = from car in cars
                                     where (
                                     (carForComparision.Model == car.Model || carForComparision.Model == "") &&
                                     (carForComparision.Number == car.Number || carForComparision.Number == 0) &&
                                     (carForComparision.Color == car.Color || carForComparision.Color == "") &&
                                     (carForComparision.maxSpeed == car.maxSpeed || carForComparision.maxSpeed == 0) &&
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
