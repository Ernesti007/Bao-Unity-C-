using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Wife wife01 = new Wife();
            wife01.SetName("a");
            wife01.SetAge(16);
            string wina = wife01.GetName();
            Console.WriteLine(wina);
            Wife d = new Wife();
            d.Name ="sedfsedfwawdedawedawedawgse";
            Console.WriteLine(d.Name  );
            Console.ReadLine();
        }



        /*static void Main(string[] args)
        {
            int Long = 4;
            int Kuan = 5;
            int S;
            int C;
            SandC(Long, Kuan, out S, out C);
            Console.WriteLine(S);
            Console.WriteLine(C);
            Console.ReadLine();
        }
        private static void SandC(int Long, int Kuan, out int S, out int C)
        {
            S = Long * Kuan;
            C = (Long + Kuan) * 2;
        }*/
    }

}
