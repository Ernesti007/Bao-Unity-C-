using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3_08查找数组里的最大值
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("你想比较几个数？");
            int n = int.Parse(Console.ReadLine());
            float[] a = new float[n] ;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("请输入第{0}个数", i+1);
                a[i] = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("数组里的最大数为：" + GetMax(a));
            Console.ReadLine();
        }
        private static float GetMax(float[] array)
        {
            float max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                bool pd = max < array[i];
                if (pd)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }

}
