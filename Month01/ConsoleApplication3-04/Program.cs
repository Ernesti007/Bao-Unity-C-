using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3_04
{
    class Program
    {
        static void Main(string[] args)
        {

            for (; true; )
            {
                Console.WriteLine("请输入天数");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入小时数");
                int hour = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入分钟数");
                int minite = int.Parse(Console.ReadLine());
                Console.WriteLine(GetSecondsByminite(GetMinitesByHour(GetHoursByDay(day) + hour) + minite));
                Console.ReadLine();
            }
        }
        private static int GetSecondsByminite(int minite)
        {
            return minite * 60;
        }
        private static int GetMinitesByHour(int hour)
        {
            return hour * 60;
        }
        private static int GetHoursByDay(int day)
        {
            return day * 12;
        }
    }
}
