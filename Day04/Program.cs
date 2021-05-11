using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        static void Main1(string[] args)
        {
            //方法
            //定义方法
            /*
               private   static
             访问级别  可选修饰符  返回值类型  方法名称(参数列表)
             {
                    方法体
             }
             方法:表示一个功能
             返回值：功能的结果(方法定义者告诉方法调用者的结果)
             参数：
                -- 形参，定义方法时声明的变量
                -- 实参，调用方法时传递的变量
             调用：方法名称(实参列表);
             */
            //      for                      while                                       do while
            //预定次数循环          先判断条件，再执行循环体            先执行循环体，再判断条件

            //声明
            int[] array;
            //初始化
            array = new int[5];
            //赋值
            array[0] = 1;
            array[1] = 2;
            array[3] = 4;

            //显示：命名空间.类名
            //Console.WriteLine(array);

            //读取数组所有元素
            //array.Length  表示数组长度(元素总数)  5
            for (int i = 0; i < array.Length; i++)
            {
                //Console.WriteLine(array[i]);
                array[i] = 0;
            }
            //倒序获取所有元素
            //4   3   2  1 0 
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }

            //依次获取数组全部元素
            //优点：使用简洁。方便
            /*foreach (元素类型 变量名 in 数组名)
            { 
                 变量名 就是 数组每个元素
            }*/

            foreach (int element in array)
            {
                Console.WriteLine(element);
                //element = 0;  不能修改数组元素
            }

            //练习1：在控制台中录入学生成绩：float[]
            //要求：成绩范围0--100
            //"请输入学生总数："
            //"请输入第1个学生成绩："
            //"输入的成绩有误"

            //练习2：计算数组元素最大值float[]
        }

        static void Main2()
        {
            float[] scoreArray = CreateScoreArray();

            float max = GetMax(scoreArray);

            Console.WriteLine("最高分为：" + max);

            //数组写法1：声明 + 初始化 
            int[] arr01 = new int[10];

            //数组写法2：初始化 +  赋值
            int[] arr02 = new int[3] { 1, 2, 3 };

            //数组写法3：声明 + 初始化 +  赋值
            int[] arr03 = { 1, 2, 3 };

            PrintArray(new int[3] { 1, 2, 3 });

            //练习：定义一个方法
            //根据年月日计算，当天是本年的第几天
            //5月3日
            //累加前4个月的总天数
            //再累加3
            //每月总天数 存储到 数组中
            //31  28  31 30
        }

        private static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }

        private static float[] CreateScoreArray()
        {
            Console.WriteLine("请输入学生总数：");
            int count = int.Parse(Console.ReadLine());
            float[] scoreArray = new float[count];

            for (int i = 0; i < count; )
            {
                Console.WriteLine("请输入第{0}个学生成绩：", i + 1);
                float score = float.Parse(Console.ReadLine());
                if (score >= 0 && score <= 100)
                    scoreArray[i++] = score;
                else
                    Console.WriteLine("成绩输入有误");
            }

            return scoreArray;
        }

        //假设 8   1   3    5   2    10   20
        //获取第一个数
        //与第二个元素
        //如果比第二个元素小 则使用第二个元素继续与后面进行比较
        private static float GetMax(float[] array)
        {
            //查找最大值的算法 
            //假设第一个元素为最大值
            float max = array[0];
            for (int i = 1; i <= array.Length - 1; i++)
            //for (int i = 1; i < array.Length; i++)
            {
                //如果发现更大的数据
                if (max < array[i])
                {//则替换
                    max = array[i];
                }
            }
            return max;
        }

        private static void Main3()
        {
            int total = GetTotalDay(2016, 11, 7);
        }

        //2016    5    5           
        private static int GetTotalDay(int year, int month, int day)
        {
            //存储每月天数
            int[] dayOfMonth = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int totalDay = 0;
            //累加前几个月总天数
            for (int i = 0; i < month - 1; i++)
            {
                totalDay += dayOfMonth[i];
            }
            //累加当月天数
            totalDay += day;
            return totalDay;
        }

        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }

        //参数数组
        static void Main4()
        {
            int sum01 = Add(new int[] { 3, 32, 54, 56, 67, 7 });
            //每次调用方法，需要传递数组。
            int sum02 = Add(3, 32, 54, 56, 67, 7);
            int sum03 = Add();

            Console.WriteLine("{0}---{1}", new object[] { 1, 2 });
            Console.WriteLine("{0}---{1}", 1, 2);
        }

        //需求：整数相加的功能   个数不确定 
        //对于调用者而言：可以传递数组，传递一组数据类型相同的变量，还以不传参
        //对于定义者而言：就是个普通数组
        private static int Add(params int[] arr)
        {
            int sum = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    sum += arr[i];
            //}
            foreach (int item in arr)
            {
                sum += item;
            }
            return sum;
        }

        //类中 方法外
        static Random random = new Random();
        //其他语法知识 
        static void Main5()
        {
            int a = 1;
            //声明object类型的变量 可以赋值任意类型
            //object 是所有类型的父类(万类之祖)
            object o1 = 1;
            o1 = "ok";
            o1 = true;
            o1 = 1.1f;

            //声明Array类型的变量 可以赋值数组
            //Array 是数组的父(基)类
            Array arr01 = new int[1];
            Array arr02 = new float[1];
            Array arr03 = new string[1];

            //var 推断类型：根据数据 推断类型
            //适用性：当所赋值类型较长时使用
            //缺点：代码可读性下降
            var v1 = 1;
            var v2 = true;
            var v3 = "ok";

            //自学Array类 相关方法

            int[] array01 = new int[3] { 100, 23, 4 };
            int[] array02 = new int[5];
            //Array.Clear(array01, 0, 2);
            //Array.Copy(array01,1, array02, 0,2);
            //array01.CopyTo(array02, 1);

            int[] obj = (int[])array01.Clone();
            int num = obj[0];

            //判断array01数组中是否存在100  
            bool result = Array.IndexOf(array01, 100) != -1;



            /*
             彩票生成器
             红球：1--33之间       6个       不能重复
             蓝球：1--16之间       1个
             * 
             * 1.定义 在控制台中购买彩票的方法 new int[7]
             *   -- 范围、数量、红球不能重复
             * 
             *  2.定义随机产生一注彩票的方法
             *   -- 红球不能重复
             *   -- 红球号码按照从小到大顺序排列
             *   
             *  3.定义两注彩票比较的方法
             *  -- 计算红球、蓝球号码中奖数量
             *  
             * 4.测试
             * 
             * 提示： //类中 方法外
                          static Random random = new Random();
             */
        }

        //***************彩票生成器*************************

        static void Main()
        {
            int[] myTicket  = BuyTicket(); 
            Console.Clear();

            Console.WriteLine("我买的彩票：");

            PrintTicket(myTicket);
            Console.WriteLine("验证我的中奖潜力……");

            int count = 0;
            int level;
            do
            {
                count++;
                int[] ticket = CreateTicket();
                //购买彩票与开奖彩票对比
                level = TicketEquals(myTicket, ticket);

                Console.WriteLine("*********开奖号码：*********");
                PrintTicket(ticket);

                if (level != 0)
                    Console.WriteLine("恭喜，{0}等奖。累计花费：{1}元", level, count * 2);
            } while (level != 1);
        }
      
 
        static int[] BuyTicket()
        {
            int[] ticket = new int[7];

            for (int i = 0; i < ticket.Length - 1; )
            {
                Console.WriteLine("请输入第{0}个红球号码：", i + 1);
                int redNumber = int.Parse(Console.ReadLine());
               
                if (redNumber < 1 || redNumber > 33)
                    Console.WriteLine("您输入的数字超过红球号码范围：1--33");
                else if (Array.IndexOf(ticket, redNumber) != -1)
                    Console.WriteLine("当前数字已经存在，请重新录入");
                else 
                    ticket[i++] = redNumber;  
            }

            int blueNumber;
            do
            {
                Console.WriteLine("请输入篮球号码：");
                blueNumber = int.Parse(Console.ReadLine());
                if (blueNumber >= 1 && blueNumber <= 16)
                    ticket[6] = blueNumber;
                else
                    Console.WriteLine("请输入数字超过篮球号码：1--16");
            } while (blueNumber < 1 || blueNumber > 16);//数字不在1--16之间 再次执行

            return ticket;
        }

        static Random ran = new Random();
        static int[] CreateTicket()
        {//随机产生多个不重复的随机数
            int[] ticket = new int[7];
            for (int i = 0; i < ticket.Length - 1; )
            {
                int num = ran.Next(1, 34);
                if (Array.IndexOf(ticket, num) == -1) 
                    ticket[i++] = num;  
            }
            ticket[6] = ran.Next(1, 17);
            //前6个红球号码排序
            Array.Sort(ticket, 0, 6);
            return ticket;
        }

        static int TicketEquals(int[] myTicket1, int[] ranTicket2)
        {
            int redCount = 0, blueCount = 0;
            for (int i = 0; i < myTicket1.Length - 1; i++)
            {
                if (Array.IndexOf(ranTicket2, myTicket1[i], 0, 6) != -1)//如果true，有相同的球
                    redCount++;
            }
            blueCount = myTicket1[6] == ranTicket2[6] ? 1 : 0;

            int level;
            if (redCount + blueCount == 7)
                level = 1;
            else if (redCount == 6)
                level = 2;
            else if (redCount + blueCount == 6)
                level = 3;
            else if (redCount + blueCount == 5)
                level = 4;
            else if (redCount + blueCount == 4)
                level = 5;
            else if (blueCount == 1)
                level = 6;
            else
                level = 0;
            return level;
        }

        static void PrintTicket(int[] ticket)
        {
            for (int i = 0; i < ticket.Length; i++)
            {
                Console.Write(ticket[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
