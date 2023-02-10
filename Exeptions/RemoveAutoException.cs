using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Exeptions
{
    internal class RemoveAutoException : Exception
    {
        public RemoveAutoException() { }

        public RemoveAutoException(string message) : base(message) { }

        public RemoveAutoException(string message, Exception inner) : base(message, inner) { }
    }
}
