using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Data
{
    public class SimpleMath
    {
        public int Plus(int x,int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }
        public int Multiply(int x, int y) { return x * y; }
        public int Divide(int x, int y) { return x / y; }
        public int Factorial(int x)
        {
            if (x == 0 || x == 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }
    }
}
