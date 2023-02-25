using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark.VehicleDetails
{
    class Transmission
    {
        public bool IsValid
        {
            get
            {
                return propertiesIsValid;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill transmission type");
                    propertiesIsValid = false;
                }
                else
                {
                    type = value;
                }
            }
        }
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine($"{GetType().Name}: Please, fill manufacturer");
                    propertiesIsValid = false;
                }
                else
                {
                    manufacturer = value;
                }
            }
        }
        public int GearsNumber
        {
            get
            {
                return gearsNumber;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine($"{GetType().Name}: Gears number must be >= 1");
                    propertiesIsValid = false;
                }
                else
                {
                    gearsNumber = value;
                }
            }
        }

        private string type = "default";
        private string manufacturer = "default";
        private int gearsNumber = 1;
        private bool propertiesIsValid = true;

        public Transmission(string type, string manufacturer, int gearsNumber)
        {
            Type = type;
            Manufacturer = manufacturer;
            GearsNumber = gearsNumber;
        }

        public Transmission()
        {
            Type = type;
            Manufacturer = manufacturer;
            GearsNumber = gearsNumber;
        }

        public void TransmissionOutput()
        {
            Console.WriteLine("Transmission Characteristics: ");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"GearsNumber: {GearsNumber}\n");
        }

        public XElement TransmissionXmlOutput()
        {
            XElement transmission = new XElement("Transmission",
                new XElement("Type", Type),
                new XElement("Manufacturer", Manufacturer),
                new XElement("GearsNumber", GearsNumber.ToString())
                );

            return transmission;
        }
    }
}
