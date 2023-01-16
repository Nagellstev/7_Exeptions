/// The program described in README.md

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark
{
    class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();
            bool endApp = false;

            Console.WriteLine("Practical Task: Exeptions\r");
            Console.WriteLine("Car Park Processing\r");
            Console.WriteLine("-----------\n");
            while (endApp != true)
            {
                Console.WriteLine("Choose action:");
                Console.WriteLine("\ta - add new car to list");
                Console.WriteLine("\ts - save cars to XML file");
                Console.WriteLine("\tl - load cars from XML file");
                Console.WriteLine("\td - delete car");
                Console.WriteLine("\tr - replace car");
                Console.WriteLine("\tg - get cars by parameter");
                Console.WriteLine("\tu - get cars by user parameter");
                Console.WriteLine("\tp - print cars in list");
                //Console.WriteLine("\to - print car by number");
                Console.WriteLine("\te - exit\n");
                switch (Console.ReadLine())
                {
                    case "a":
                        try
                        {
                            cars.Add(ProcessingCarPark.InputNewCar());
                        }
                        catch (AddExeption e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message + " Can't add a car.");
                            Console.ResetColor();
                        }
                        break;
                    case "s":
                        Console.WriteLine("Input name of new file:");
                        ProcessingCarPark.SaveCars(Console.ReadLine(), cars);
                        break;
                    case "l":
                        Console.WriteLine("Input name of file to load:");
                        cars = ProcessingCarPark.LoadCars(Console.ReadLine());
                        break;
                    case "d":
                        Console.WriteLine("Input number of car to delete from list:");
                        ProcessingCarPark.DeleteCar(cars, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "r":
                        Console.WriteLine("Input number of car to replace in list:");
                        ProcessingCarPark.ReplaceCar(cars, Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "p":
                        Console.WriteLine("Here's all cars in list:");
                        foreach (Car car in cars)
                        {
                            ProcessingCarPark.CarPropertiesOutput(car);
                        }
                        break;
                    case "g":
                        Console.WriteLine("Input parameters to select cars:");
                        cars = ProcessingCarPark.GetAutoByParameters(cars);
                        break;
                    case "u":
                        try
                        {
                            Console.WriteLine("Input name of parameter and value of parameter:");
                            cars = ProcessingCarPark.GetAutoByUserParameter(cars, Console.ReadLine(), Console.ReadLine());
                        }
                        catch (IncorrectParameterExeption)
                        {
                            Console.WriteLine("Incorrect name of parameter");
                        }
                        break;
                    case "e":
                        Console.WriteLine("Exit? y/n");
                        if (Console.ReadLine() == "y")
                        {
                            endApp = true;
                        }
                        break;
                    //case "o":
                    //    Console.WriteLine("Input Car Number:");
                    //    int.TryParse(Console.ReadLine(), out int carNumber);
                    //    var oCar = from car in cars
                    //               //where car.Model == Console.ReadLine()
                    //               where car.Number == carNumber
                    //               select car;
                    //    foreach (Car car in oCar)
                    //    {
                    //        ProcessingCarPark.CarPropertiesOutput(car);
                    //    }
                    //    break;
                    default:
                        Console.WriteLine("You have not chosen anything.");
                        break;
                }
                Console.WriteLine("\n");
            }
        }
    }
}