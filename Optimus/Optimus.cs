using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    public class Optimus
    {
        public ulong Prime { get; set; }
        public ulong ModInverse { get; set; }
        public ulong Random { get; set; }
        //Does not check if prime is actually a prime number but does not work correctly if it not a prime number
        public Optimus(ulong prime, ulong modInverse, ulong random)
        {
            Prime = prime;
            ModInverse = modInverse;
            Random = random;
        }

        public uint Encode(uint number)
        {
            var encoded = ((number * Prime) & int.MaxValue) ^ Random;
            return (uint)encoded;
        }

        public uint Decode(uint number)
        {
            var decoded = ((number ^ Random) * ModInverse) & int.MaxValue;
            return (uint)decoded;
        }

        public long GetModInverseOfPrime(ulong prime)
        {
            var max = ((long)int.MaxValue + 1);
            var inverse = GetModInverse((long)prime, max);
            return inverse;
        }

        //Code taken from https://stackoverflow.com/a/21919260 by Samuel Allan
        //Seems to work fine
        public long GetModInverse(long a, long n)
        {
            long i = n, v = 0, d = 1;
            while (a > 0)
            {
                long t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
