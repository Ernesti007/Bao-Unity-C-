using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入年份");
            int year = int.Parse(Console.ReadLine());
            PrintYearCalendar(year);
            Console.ReadLine();
        }
        //根据年份判断是否为闰年
        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
        //根据年月计算天数
        private static int GetDayByMonth(int year, int month)
        {
            if (month < 1 || month > 12) return 0;
            switch (month)
            {
                case 2:
                    return IsLeapYear(year) ? 29 : 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }
        //(赠送)根据年月日计算星期数的方法
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }
        //在控制台中显示月历的方法
        private static void PrintMonthCalendar(int year, int month)
        {
            Console.WriteLine("\n"+"\n" +"{0}年{1}月", year, month);
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");
            int week = GetWeekByDay(year, month, 1);
            for (int i = 0; i < week; i++)
            {
                Console.Write("\t");
            }
            int days = GetDayByMonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                int weeks = GetWeekByDay(year, month, i);
                if (weeks == 6)
                {
                    Console.Write(i + "\n");
                }
                else
                {
                    Console.Write(i + "\t");
                }
            }
        }
        private static void PrintYearCalendar(int year)
        {
            for (int month = 1; month < 13; month++)
            {
                PrintMonthCalendar(year, month);
            }
		}
    }
}
