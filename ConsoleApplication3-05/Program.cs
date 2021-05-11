using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3_05
{
    class Program
    {
        static void Main(string[] args)
        {
            bool d=true ;
            for (;d; )
            {
                Random ran = new Random();
                int a = ran.Next(0, 121);
                for (; true; )
                {
                    Console.WriteLine("请输入一个0~120的整数");
                    int b = int.Parse(Console.ReadLine());
                    if (b >= 0 && b <= 120)
                    {
                        if (a > b)
                        {
                            Console.WriteLine("小了");
                        }
                        else if (a < b)
                        {
                            Console.WriteLine("大了");
                        }
                        else
                        {
                            Console.WriteLine("对了");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("输入数据不符合范围要求");
                    }
                }
                Console.WriteLine("是否进行下一轮？(输入y；n)");
                string c = Console.ReadLine();
                d= c == "y" ? true : false;
            }
        }
    }
}
