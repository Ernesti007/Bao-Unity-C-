using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3_06
{
    class Program
    {
        static void Main(string[] args)
        {Console .WriteLine ("请输入要乘的最大数：");
            int n=int.Parse ( Console.ReadLine ());
            int m = n * num(n - 1);
            Console.WriteLine(m);
            Console.ReadLine();
        }
        private static int num(int n)
        {
            if (n == 1) return 1;
            return n * num(n - 1);
        }
    }
}
