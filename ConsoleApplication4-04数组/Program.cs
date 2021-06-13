using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4_04数组
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("你想创建几个人的数组：");
            int H = int.Parse(Console.ReadLine());
            H++;
            Console.WriteLine("你想创建几个科目的数组：");
            int L = int.Parse(Console.ReadLine());
            L++;
            int[,] C = CreatArray(H, L);
            Console.Write("\t");
            for (int h = 0; h < H; h++)
            {
                if (h == 0)
                {
                    for (int l = 1; l < L; l++)
                    {
                        Console.Write("科目{0}\t", l);
                    }
                }
                else
                {
                    Console.Write("\n学生{0}\t", h);
                    for (int l = 1; l < L; l++)
                    {
                        Console.Write(C[h, l] + "\t");
                    }

                }

            }
            Console.ReadLine();
        }
        private static int[,] CreatArray(int H, int L)
        {
            int[,] Creat = new int[H, L];
            for (int i = 1; i < H; i++)
            {
                for (int z = 1; z < L; z++)
                {
                    Console.WriteLine("请输入学生{0}科目{1}成绩\t", i, z);
                    Creat[i, z] = int.Parse(Console.ReadLine());
                }
            }
            return Creat;
        }



        /*
        static void Main2(string[] args)
        {
            Console.WriteLine(Same(load()));
            Console.ReadLine();
        }
        private static bool Same(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int r = 1; r < array.Length - 1; r++)
                {
                    if (array[i] == array[r])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static int[] load()
        {
            Console.WriteLine("请输入几位数组：");
            int num = int.Parse(Console.ReadLine());
            int[] lod = new int[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("请输入第{0}位数组：", i + 1);
                lod[i] = int.Parse(Console.ReadLine());
            }
            return lod;
        }*/
        
    }
}
