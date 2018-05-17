using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    class Program
    {
        static void Main(string[] args)
        {
            var optimus = new Optimus(2123809381, 1885413229, 146808189);
            var number = 15u;
            Console.WriteLine("OriginalValue: " + number);
            var newId = optimus.Encode(number);
            Console.WriteLine("Encode: " + newId);
            Console.WriteLine("Decode: " + optimus.Decode(newId));

            //Console.WriteLine("Modinverse: " + optimus.GetModInverseOfPrime(2123809381));
        }
    }
}
