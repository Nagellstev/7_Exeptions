using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Exeptions
{
    public class AddExeption : Exception
    {
        public AddExeption() : base() { }
        public AddExeption(string message) : base(message) { }
        public AddExeption(string message, Exception inner) : base(message, inner) { }

    }
}
