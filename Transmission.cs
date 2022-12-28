using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPark
{
    class Transmission
    {
        public string Type;
        public string Manufacturer;
        public int GearsNumber;
        public void TransmissionOutput()
        {
            Console.WriteLine("  Transmission Characteristics: ");
            Console.WriteLine("\tType: " + Type);
            Console.WriteLine("\tManufacturer: " + Manufacturer);
            Console.WriteLine("\tGearsNumber: " + GearsNumber + "\n");
        }
        public Transmission(string type, string manuf, int gearsNum)
        {
            Type = type;
            Manufacturer = manuf;
            GearsNumber = gearsNum;
        }
        public Transmission()
        {
            Type = "";
            Manufacturer = "";
            GearsNumber = 0;
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
