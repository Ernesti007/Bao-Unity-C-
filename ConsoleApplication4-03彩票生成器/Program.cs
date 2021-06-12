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
            int []my = BuyTicket();
            foreach (var item in my)
            {
                Console.WriteLine(item);
            }
            int[] ran = Randomticket();
            foreach (var item2 in ran )
            {
                Console.WriteLine(item2);
            }
            int money=TicketEq(my,ran);
            Console.WriteLine("你获得了{0}等奖",money);
            Console.ReadLine();
        }
        private static int[] BuyTicket()
        {//在控制台中购买彩票的方法
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
            for (; true; )
            {
                int bluetest = int.Parse(Console.ReadLine());
                if (bluetest > 0 && bluetest < 17)
                {
                    ticket[6] = bluetest;
                    break;
                }
                else
                {
                    Console.WriteLine("输入有误，请重新输入1~16范围的数：");
                }
            }
            return ticket;
        }
        private static int[] Randomticket()
        {//定义随机产生一注彩票的方法
            int[] random = new int[7];
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int Rannumber = ran.Next(1, 34);
                if (Array.IndexOf(random, Rannumber, 0, i) < 0)
                    random[i] = Rannumber;
                else
                {
                    i--;
                }
            }
            random[6] = ran.Next(1, 17);
            return random;
        }
        private static int TicketEq(int[] My, int[] Ran)
        {//定义两注彩票比较的方法
            int blue = My[6] == Ran[6] ? 1 : 0;
            int jiang = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Array.IndexOf(Ran, My[i], 0, 6) != -1)
                {
                    jiang++;
                }
            }
            jiang += blue;
            return jiang;
        }
    }
}
