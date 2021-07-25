using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4_01
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[3] { 1, 2, 3 };
            printall(arr);
            Console.ReadLine();
        }
        private static void printall(Array a)
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


        }
        static void Main1(string[] args)
        {
            Console.WriteLine("请输入学生总数：");
            int all = int.Parse(Console.ReadLine());
            float[] g = new float[all];
            for (int i = 0; i < all; )
            {
                Console.WriteLine("请输入第{0}个学生成绩：", i + 1);
                float gs = float.Parse(Console.ReadLine());
                if (gs >= 0 && gs <= 100)
                {
                    g[i] = gs;
                    i++;
                }
                else
                {
                    Console.WriteLine("输入的成绩有误");
                }
            }
            //数组倒排
            float[] h = new float[all];
            for (int o = g.Length;
                o > 0; o--)
            {
                h[all - o] = g[o - 1];
            }
            Console.WriteLine("输入完成,以下为输入的学生成绩倒排：");
            foreach (int item in h)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            /*for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine("第{0}个学生：{1}", i + 1, g[i]);
            }
            Console.ReadLine();*/
        }
    }
}
