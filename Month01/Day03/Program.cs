using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main1(string[] args)
        {
            //循环语句   跳转语句    方法
            //选择语句 if  else    switch case    循环 for     while      do while   

            /*
            if (bool条件)
            { 
                 满足条件(true)执行的语句  
            }
            else if(  )
            { 
                不满足条件(false)执行的语句
            }
             */

            //预定次数
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("ok");
            }

            //数据类型 变量名;
            //变量名  = 数据;

            //数据类型 变量名 = 数据;


        }

        //while
        static void Main2()
        {
            /*
            while (条件bool)
            { 
                 满足条件(true)执行的语句
            }
             * */
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("刚哥");
                i++;
            }
            //一个球从100米高度落下，每次弹回原高度一半
            //计算：经过？次最终落地(最小弹起高度为0.01米)
            //         总共经过？米

            float height = 100;
            int count = 0;//计数器
            float distance = height;//经过距离
            //如果弹起高度大于等于0.01
            while (height / 2 >= 0.01f)
            {
                //高度减半
                height /= 2;
                //计数
                count++;
                distance += height * 2;//累加起落距离
                Console.WriteLine("第{0}次弹起高度为：{1}。", count, height);
            }
            Console.WriteLine("总共弹起{0}次。", count);
            Console.WriteLine("总共经过{0:f1}米。", distance);
        }

        //do  while
        static void Main3()
        {
            /*
                do
                {
                     满足条件执行的语句
                } while (条件bool);
                先执行，再判断条件
            */
            //程序产生1--100之间的随机数
            //在控制台中，让用户重复猜测，直到猜对未知。
            //每次提示：大了、小了、终于猜对了，总共猜了?次。

            //创建一个随机数工具
            Random random = new Random();
            //产生一个随机数
            int randomNumber = random.Next(1, 101);
            int inputNumber;
            int count = 0;
            do
            {
                count++;
                Console.WriteLine("请输入数字：");
                inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber > randomNumber)
                    Console.WriteLine("大了");
                else if (inputNumber < randomNumber)
                    Console.WriteLine("小了");
                else
                    Console.WriteLine("终于猜对了，总共猜了{0}次。", count);
            } while (randomNumber != inputNumber);//如果没猜对   继续循环
        }

        static void Main4()
        {
            //创建一个随机数工具
            Random random = new Random();
            //产生一个随机数
            int randomNumber = random.Next(1, 101);
            int count = 0;
            while (true)
            {
                count++;
                Console.WriteLine("请输入数字：");
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber > randomNumber)
                    Console.WriteLine("大了");
                else if (inputNumber < randomNumber)
                    Console.WriteLine("小了");
                else
                {
                    Console.WriteLine("终于猜对了，总共猜了{0}次。", count);
                    break;//退出循环体
                }
            }
        }

        //方法
        static void Main5()
        {
            Console.WriteLine("请输入姓名：");
            string input = Console.ReadLine();

            //调用方法：通过方法名称，执行方法体中的代码
            Fun1();
            //声明返回值类型的变量，接收方法的结果
            string input02 = Fun2();

            //调用方法(必须与形参一一对应[类型、数量、顺序])
            //实参：实际参数，调用方法时传递的信息
            Fun3(200, "ok");

            //调用方法
            string str = "我爱Unity！";
            //string result = str.Insert(1, "特");
            //string result = str.Remove(2);
            string result = str.Replace('我', '你');

            //1.看名字猜功能，看描述信息了解功能。
            //2.看参数(类型、名称、描述)
            //3.看返回值
            //4.测试
            int index = str.IndexOf('n');
        }

        //做方法
        /*
          public
          private
         访问级别  static  返回值类型 方法名称(参数)
         {
       
         }
         方法：表示一个功能/行为
         返回值：该功能的结果
         类型：结果的数据类型，如果没有结果，写void(空)关键字
         方法名称：所有单词首字母大写，选择动词
         参数：方法调用者 传递给 方法定义者的信息
         */

        private static void Fun1()
        {//如果逻辑发生修改，只需要修改方法体
            Console.WriteLine("Fun1执行喽");
            return;//没有返回值类型的方法，return关键字也可以写
            //退出方法 
            Console.WriteLine();
        }

        private static string Fun2()
        {//如果逻辑发生修改，只需要修改方法体
            Console.WriteLine("Fun2执行喽");
            //"并非所有的代码路径都返回值"  --> 方法体中缺少return关键字
            return "oo"; //返回 数据; 
        }

        //形参：形式参数，定义方法时声明的变量
        private static void Fun3(int a, string b)
        {
            //a = 100;  调用方法时，进行赋值操作
            Console.WriteLine(a);//可以直接使用
        }

        static void Main6()
        {
            Console.WriteLine("请输入第一个数：");
            int one = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入第二个数：");
            int two = int.Parse(Console.ReadLine());

            int result = Add(one, two);

            Console.WriteLine("结果为:" + result);
        }

        //两个整数相加的方法
        private static int Add(int one, int two)
        {
            int result = one + two;
            return result;
        }

        /*1. 在控制台中显示年历的方法
           -- 调用12次显示月历方法
           2. 在控制台中显示月历的方法
         *-- 显示表头Console.WriteLine("日\t一\t……");
         *-- 计算当月1日星期数（显示空白\t）
         *-- 计算当月总天数（显示每天） Console.Write("1\t") Console.Write("2\t")
         *-- 计算当天星期数(逢六换行) Console.WriteLine();
         *3.(赠送)根据年月日计算星期数的方法
           4.根据年月计算天数
         *5.根据年份判断是否为闰年
         * */

        private static bool IsLeapYear(int year)
        {
            //if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
            //    return true;
            //else
            //    return false;

            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }

        private static int GetDaysByMonth(int year, int month)
        {
            if (month < 1 || month > 12) return 0;

            switch (month)
            {
                case 2:
                    //if (IsLeapYear(year))
                    //    return 29;
                    //else
                    //    return 28; 
                    return IsLeapYear(year) ? 29 : 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }

        /// <summary>
        /// 根据天计算星期数
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天</param>
        /// <returns>星期数</returns>
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }

        private static void PrintMonthCalendar(int year, int month)
        {
            Console.WriteLine("{0}年{1}月", year, month);
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");
            int week = GetWeekByDay(year, month, 1);//3
            for (int i = 0; i < week; i++)
            {
                Console.Write("\t");
            }
            int days = GetDaysByMonth(year, month);//30
            for (int i = 1; i <= days; i++)
            {
                Console.Write(i + "\t");
                if (GetWeekByDay(year, month, i) == 6)
                {
                    Console.WriteLine();
                }
            }
        }

        private static void PrintYearCalendar(int year)
        {
            for (int i = 1; i <= 12; i++)
            {
                PrintMonthCalendar(year, i);
                Console.WriteLine();
            }
        }

        static void Main()
        {
            //Console.WriteLine("请输入年份：");
            //int year = int.Parse(Console.ReadLine());
            //PrintYearCalendar(year);

            //计算总秒数，记忆3个方法。
            int second = GetTotalSecondByMinuiteHour(3, 1);

            //方法重载：名称相同，参数不同。
            //作用：在不同的条件下，解决同一类问题。
            //优点：简化了调用者的记忆量
            int second02 = GetTotalSecond(3, 1);
             
            //感觉调用了1个方法
            Console.WriteLine();
            Console.WriteLine("ok");
            Console.WriteLine(1.1);
            Console.WriteLine(true);  
        }

        /*
         * 练习：
         * 1.定义根据分钟计算秒数的方法
         * 2.            分钟、小时
            3.           分钟、小时、天
         */

        private static int GetTotalSecondByMinuite(int minute)
        {//分钟 --> 秒
            return minute * 60;
        }
        private static int GetTotalSecondByMinuiteHour(int minute, int hour)
        { //小时 --> 分钟
            return GetTotalSecondByMinuite(hour * 60 + minute);
        }
        private static int GetTotalSecondByMinuiteHourDay(int minute, int hour, int day)
        { //天 --> 小时
            return GetTotalSecondByMinuiteHour(minute, hour + day * 24);
        }
          
        private static int GetTotalSecond(int minute)
        {//分钟 --> 秒
            return minute * 60;
        } 
        private static int GetTotalSecond(int minute, int hour)
        { //小时 --> 分钟
            return GetTotalSecond(hour * 60 + minute);
        }
        private static int GetTotalSecond(int minute, int hour, int day)
        { //天 --> 小时
            return GetTotalSecond(minute, hour + day * 24);
        }
    }
}
