using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Program
    {
        //继承语法
        static void Main1(string[] args)
        { 
            //声明 父类型 引用 指向 父类型对象
            //只能访问父类的成员
            Person p01 = new Person();
            p01.Name = "";

            //声明 子类型 引用 指向 子类对象
            //可以访问自身成员 及 父类成员
            Student s01 = new Student();
            s01.Score = 100;
            s01.Name = "";

            //声明 父类型 引用  指向 子类对象
            //受类型限制 只能访问 父类成员
            Person p02 = new Student();
            p02.Name = "";

            //通过显式类型转化 可以访问子类成员
            Student s02 = (Student)p02;
            s02.Name = "";
            s02.Score = 100;

            //显式转换如果转换失败，则异常
            //Teacher t02 = (Teacher)p02;
            //t02.Salary = 100000;

            //强制转换as：如果转换失败 则为null，不会发生异常
            Teacher t03 = p02 as Teacher;
            if (t03 != null)
            {//如果确实可以转换
                t03.Salary = 1000;
            }
        }

        //静态   
        static void Main2()
        {  
            //对象计数器
            Person p1;//加载类，初始化静态数据成员

            p1 = new Person();//0  -->  1  初始化当前对象的实例成员
            Person p2 = new Person();//0  -->  1
            Person p3 = new Person();//0  -->  1

            p1.Fun1();
            p2.Fun1();
            p3.Fun1();

            Person.Fun3();
             
            //通过对象引用调用实例成员
            Console.WriteLine(p3.InstanceCount);//1
            //通过类名调用静态成员
            Console.WriteLine(Person.StaticCount);
             
            //Random.Range(1, 101); 
        }

        //练习
        static void Main3()
        {
            string[,] array = new string[4, 5];
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    array[r, c] = r.ToString() + c.ToString();
                }
            }

            /*
                   00    01    02   03    04
                   10    11    12   13    14
                   20    21    22   23    24
                   30    31    32   33    34 
             */

            //0   1
            Direction dir = Direction.Right;
            string[] result = DoubleArrayHelper.GetElements(array, 2, 0, Direction.Up, 10);
        }

        //  结构体 
        static void Main()
        {
            Fun1();
        }

        private static void Fun1()
        {
            Direction dir01 = new Direction(1, 2); 

            Direction[] arr = new Direction[1000];
        }
    }
}
