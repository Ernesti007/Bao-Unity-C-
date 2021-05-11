using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4_01
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("输入完成,以下为输入的学生成绩：");
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine("第{1}个学生：{0}",g[i],i+1);
            }
            Console.ReadLine();
        }
    }
}
