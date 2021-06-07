using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4_03彩票生成器
{
    class Program
    {
        static void Main()
        {
            foreach (var item in BuyTicket())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        private static int[] BuyTicket()
        {
            int[] ticket = new int[7];
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("请选择第{0}注红色彩票号码：，要求范围在1~33之间，且不重复", i + 1);
                int test = int.Parse(Console.ReadLine());
                if (test > 0 && test < 34)
                {
                    if (Array.IndexOf(ticket, test, 0, i) < 0)
                        ticket[i] = test;
                    else
                    {
                        Console.WriteLine("号码重复");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("输入范围有误");
                    i--;
                }
            }
            Console.WriteLine("请选择第7注蓝色彩票号码：");
            ticket[6] = int.Parse(Console.ReadLine());
            return ticket;
        }
        private static int[] Randomticket()
        {
         /*   int[] random = new int[7];
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int rannumber = ran.Next(1, 34);
                if (Array.IndexOf(random, rannumber, 0, i) < 0)
                    random[i] = rannumber;
                else
                {
                    i--;
                }
            }
            return random;*/
        }
        private static int TicketEq(int[] My, int[] Ran)
        {
            int blue = My[6] == Ran[6] ? 1 : 0;

            int jiang = 0;
            return jiang;
        }
    }
}
