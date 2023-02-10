using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Exeptions
{
    internal class UpdateAutoException : Exception
    {
        public UpdateAutoException() { }

        public UpdateAutoException(string message) : base(message) { }

        public UpdateAutoException(string message, Exception inner) : base(message, inner) { }
    }
}
