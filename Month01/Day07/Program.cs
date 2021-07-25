using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    class Program
    {
        //复习
        static void Main1(string[] args)
        {
             /*值类型与引用类型
               局部变量：声明在方法内部的变量
               1.因为方法执行在栈中，所以局部变量存储在栈中。
               2.又因为值类型存储数据，所以数据存储在栈中。
               3.引用类型存储数据的引用，数据存储在堆中。
               4.分清 修改栈引用，还是修改堆中数据。
            */
            int a = 1;

            int[] arr01 = new int[] { 1, 2 };

            arr01[0] = 100;//堆中数据
            arr01 = new int[] { 3, 4 };//栈中引用

            string[] arr02 = new string[] { "a", "b" };
            arr02[0] = "A";//修改数组第一个元素中存储的字符串引用 
        }

        //类和对象
        static void Main2()
        {
            //声明 Wife类型 的引用
            Wife wife01;
            //指向Wife类型的对象(实例化对象)
            wife01 = new Wife();

            wife01.SetName("王美丽");
            wife01.SetAge(18);

            Console.WriteLine(wife01.GetName());
            Console.WriteLine(wife01.GetAge());

            Wife wife02 = wife01;//赋值引用
            //wife02 = new Wife();
            wife02.SetName("俊辰"); 
            Console.WriteLine(wife01.GetName());//?

            Wife wife03 = new Wife();
            //wife03.SetAge(50);
            //wife03.age = 60;
            wife03.Name = "美丽";
            wife03.Age = 20;
            Console.WriteLine(wife03.Name);
            Console.WriteLine(wife03.Age);

            //调用2个参数构造函数 --》 调用1个参数 --》 调用0个参数
            Wife wife04 = new Wife("美丽", 20);


        }

        static void Main3()
        {
            Wife w01 = new Wife("w01", 28);
            Wife w02 = new Wife("w02", 25);

            Wife[] wifeArray;
            wifeArray = new Wife[5];
            wifeArray[0] = w01;
            wifeArray[1] = w02;
            wifeArray[2] = new Wife("w03", 26);
            wifeArray[3] = new Wife("w04", 20);
            wifeArray[4] = new Wife("w05", 23);

            Wife min = GetWifeByMinimumAge(wifeArray);
            Console.WriteLine("臣妾：{0},芳龄：{1}",min.Name,min.Age);
        }

        //练习1：查找年级最小的老婆（对象的引用）   
        private static Wife GetWifeByMinimumAge(Wife[] wifes)
        {
            Wife minWife = wifes[0];
            for (int i = 1; i < wifes.Length; i++)
            {
                if (minWife.Age > wifes[i].Age)
                {
                    minWife = wifes[i];
                }
            }
            return minWife;
        }

        //练习2：自定义集合类
        //将多个基础数据类型 包装为 一种自定义数据类型，并提供相关方法。
        static void Main4()
        {
            User u01 = new User("zs", "123");
            User u02 = new User("ls", "123");
            u01.PrintUser();

            User[] userArray = new User[5];
            //每次向数组添加元素 必须 指定索引
            userArray[0] = u01;
            userArray[1] = u02;
            //容量一旦确定，不能改变。

            //UserList list01 = new UserList();
            UserList list01 = new UserList(2);//建议初始大小
            list01.Add(u01);
            list01.Add(u02);
            list01.Add(new User()); 

            for (int i = 0; i < list01.Count; i++)
            {
                User user = list01.GetElement(i);
                user.PrintUser();
            }

            /*
             用户集合类 UserList 
             {//核心思想：包装数组，提供更实用的方法。
                //**********字段***********
                private User[] data;
                private int index;
             * //有效元素个数
             * public int Count
             * {
             *    get
             *    { return index; }  
             * }
                //**********构造函数***********
                public UserList()
                {
                  data   = new User[8];
                }
                public UserList(int capacity)
                {
                  data   = new User[capacity];
                }
             * 
             * //**********方法***********
                public void Add(User value)
             * {
             *     //检查是否需要扩容(开辟更大空间、复制原有数据、替换引用)
             *     data[index++] = value;
             * }
             * 
             * public User GetElement(int index)
             * {
             *      return data[index]; 
             * }
             } 
             * 
             * 使用：
             *  //UserList list01 = new UserList();
             *  UserList list01 = new UserList(5);//建议初始大小
             *  list01.Add(u01);
                 list01.Add(u02);
             * 
             *  User one = list01.GetElement(0);
             *  
             * for(int i=0;i< list01.Count ; i++)
             * {
             *    User user = list01.GetElement(i);
             *    user.Print();
             * }
             */ 
             
        }

        static void Main()
        {
            //c# 泛型集合类

            //User[] list01  = new User[4];
            List<User> list01 = new List<User>(4);
            list01.Add(new User());
            list01.Add(new User()); 
            list01.Add(new User()); 
            list01.Add(new User());
            list01.Add(new User());

            list01.RemoveAt(0);
            list01.Insert(0, new User()); 

            for (int i = 0; i < list01.Count; i++)
            {
                User user = list01[i];
                user.PrintUser();
            } 
        }
    }
}
