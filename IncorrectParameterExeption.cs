using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class IncorrectParameterExeption : Exception
    {
        public IncorrectParameterExeption() : base() { }
        public IncorrectParameterExeption(string message) : base(message) { }
        public IncorrectParameterExeption(string message, Exception inner) : base(message, inner) { }

    }
}
