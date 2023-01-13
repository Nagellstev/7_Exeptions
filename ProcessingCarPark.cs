using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            int.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("\tColor:");
            color = Console.ReadLine();
            Console.WriteLine("\tInput Max Speed:");
            int.TryParse(Console.ReadLine(), out maxSpeed);
            return new Car(
                model, number, color, maxSpeed,
                InputNewEngine(),
                InputNewTransmission(),
                InputNewChassis()
                );
        }
        static Engine InputNewEngine()
        {
            string type;
            int SN;
            decimal power;
            decimal volume;
            Console.WriteLine("Input New Engine:");
            Console.WriteLine("\tType:");
            type = Console.ReadLine();
            Console.WriteLine("\tSerial Number:");
            int.TryParse(Console.ReadLine(), out SN);
            Console.WriteLine("\tPower:");
            decimal.TryParse(Console.ReadLine(), out power);
            Console.WriteLine("\tVolume:");
            decimal.TryParse(Console.ReadLine(), out volume);
            return new Engine(type, SN, power, volume);
        }
        static Transmission InputNewTransmission()
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
            int.TryParse(Console.ReadLine(), out gearsNumber);
            return new Transmission(type, manufacturer, gearsNumber);
        }
        static Chassis InputNewChassis()
        {
            int wheelsNumber;
            int SN;
            decimal load;
            Console.WriteLine("Input New Chassis:");
            Console.WriteLine("\tWheels Number:");
            int.TryParse(Console.ReadLine(), out wheelsNumber);
            Console.WriteLine("\tSerial Number:");
            int.TryParse(Console.ReadLine(), out SN);
            Console.WriteLine("\tMax Load:");
            decimal.TryParse(Console.ReadLine(), out load);
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
        static void EngineOutput(Engine engine)
        {
            Console.WriteLine("  Engine Characteristics: ");
            Console.WriteLine("\tType: " + engine.EngineType);
            Console.WriteLine("\tSerial Number: " + engine.SerialNumber);
            Console.WriteLine("\tPower: " + engine.Power + "hp");
            Console.WriteLine("\tVolume: " + engine.Volume + "l\n");
        }
        static void ChassisOutput(Chassis chassis)
        {
            Console.WriteLine("  Chassis Characteristics: ");
            Console.WriteLine("\tWheels Number: " + chassis.WheelsNumber);
            Console.WriteLine("\tSerial Number: " + chassis.SerialNumber);
            Console.WriteLine("\tLoad: " + chassis.Load + "kg\n");
        }
        static void TransmissionOutput(Transmission transmission)
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
        static XElement EngineXmlOutput(Engine engine)
        {
            XElement Xengine = new XElement("Engine",
                new XElement("EngineType", engine.EngineType),
                new XElement("SerialNumber", engine.SerialNumber.ToString()),
                new XElement("Power", engine.Power.ToString()),
                new XElement("Volume", engine.Volume.ToString())
                );
            return Xengine;
        }
        static XElement ChassisXmlOutput(Chassis chassis)
        {
            XElement Xchassis = new XElement("Chassis",
                new XElement("WheelsNumber", chassis.WheelsNumber.ToString()),
                new XElement("SerialNumber", chassis.SerialNumber.ToString()),
                new XElement("Load", chassis.Load.ToString())
                );
            return Xchassis;
        }
        static XElement TransmissionXmlOutput(Transmission transmission)
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

            DeleteCar(cars, carNumber);

            Console.WriteLine("Input New Car:");
            Console.WriteLine("\tInput Model:");
            model = Console.ReadLine();
            Console.WriteLine("\tColor:");
            color = Console.ReadLine();
            Console.WriteLine("\tInput Max Speed:");
            int.TryParse(Console.ReadLine(), out maxSpeed);

            cars.Add(
                new Car(model, carNumber, color, maxSpeed,
                InputNewEngine(),
                InputNewTransmission(),
                InputNewChassis()
                )
                );
        }
        static void XmlFileWriter(string filename, XElement xe)
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
