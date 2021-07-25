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
            Console.WriteLine("你要创建几组用户：");
            int num = int.Parse(Console.ReadLine());
            UserList listUser = new UserList(num);
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("请输入第{0}个用户的名字：", i + 1);
                string name = Console.ReadLine();
                Console.WriteLine("请输入第{0}个用户的年龄：", i + 1);
                int age = int.Parse(Console.ReadLine());
                listUser.Add(new User(name, age));
            }
            for (int i = 0; i < num; i++)
            {
                User tempUser = listUser.GetElement(i);
                Console.WriteLine("用户{0}的名字是{1}", i + 1, tempUser.Name);
                Console.WriteLine("用户{0}的年龄是{1}", i + 1, tempUser.Age);
            }
            listUser.Insert(new User ("a", 9 ), 1);
            Console.WriteLine();
            Console.ReadLine();
        }

        /*static void Main(string[] args)
        {
            Man man = new Man(5,7);
            Console.ReadLine();
        }*/

        /*static void Main(string[] args)
        {
            Wife wife01 = new Wife();
            wife01.SetName("a");
            wife01.SetAge(16);
            string wina = wife01.GetName();
            Console.WriteLine(wina);
            Wife d = new Wife();
            d.Name ="sedfsedfwawdedawedawedawgse";

            Man a = new Man();
            a.HP  = 5;
            Console.WriteLine(a.HP);
            int b = a.HP;
            Console.WriteLine(b);
            a.HP=2;             
            Console.WriteLine(a.HP);
            Console.ReadLine();
        }*/



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
