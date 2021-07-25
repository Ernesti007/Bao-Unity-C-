using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        //运算符
        static void Main1(string[] args)
        {
            //.NET简介   编译过程     变量
            //源代码  —CLS—  中间语言 exe  —CLR—  机器码0  1
            //int     float        bool         char   string
            // 10    10.0f    true/false      ‘1’      “1”
            //数据类型 变量名;  --->  在内存中开辟一块空间
            //变量名  =  数据;   --->  在该空间存储数据

            //数据的基本运算(运算符    类型转换)
            //语句(选择语句   循环语句  跳转语句)

            //一、算数运算符
            //一次声明多个同类型变量
            int num01 = 5, num02 = 2;
            int r1 = num01 / num02;//2 截断删除  算数运算

            string str01 = "我", str02 = "你";
            string r2 = str01 + str02;//"52"  字符串拼接

            //%
            int r3 = num01 % num02;//1
            //作用：1.判断一个数能否被另外一个数整除

            int year = 2015;

            //作用：2.获取整数的个位
            int num = year % 10;

            //二、比较运算符    等于 ==  不等于 !=    >    <    >=     <=
            bool r4 = str01 == str02;//判断两个字符串中的文字是否相同

            //三、逻辑运算符  与&&  或||    非!
            //判断两个bool的关系
            bool r5 = true && true;//真  与   真  结果：真
            r5 = true && false;//真  与   假  结果：假
            r5 = false && true;//假  与   真  结果：假
            r5 = false && false;//假  与   假  结果：假
            //总结：一假俱假  

            bool r6 = true || true;//真  或   真  结果：真
            r6 = true || false;//真  或   假  结果：真
            r6 = false || true;//假  或   真  结果：真
            r6 = false || false;//假 或   假  结果：假
            //总结：一真俱真

            bool r7 = !true;//false

            //如果到达最左边 并且  还想向左移动    或者   到达最右边 并且 还想向右移动
            //停

            //闰年：年份能被4整除   但是 不能被100整除
            //          年份能被 400 整除

            //2016
            //bool isLeapYear = year % 4 == 0;  //true
            //bool isLeapYear = year %  100 != 0;//true  
            //bool isLeapYear = year % 400 == 0;//false
            //true  是闰年   false 不是闰年
            bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;

            //四、快捷运算符  +=   -=   *=   /=  %=
            int a = 1;
            //a = a + 1;//一个变量 加上 另外一个数 再赋值给自身
            a += 1;
            Console.WriteLine(a);//2

            //五、一元运算符(具有1个操作数的运算符) 自增++    自减--
            int number01 = 1;
            number01++;
            Console.WriteLine(number01);//?

            int number02 = 1;
            ++number02;
            Console.WriteLine(number02);//?
            //1.无论操作数在++前或后，对于下一条指令，都是增加1之后的结果
            //2. ++在操作数后，则后自增，先返回结果
            //    ++在操作数前，则先自增，后返回结果

            int number03 = 1;
            Console.WriteLine(number03++);//1
            Console.WriteLine(number03);//2

            int number04 = 1;
            Console.WriteLine(++number04);//2
            //Console.WriteLine(number04);//2

            //六、三元运算符  数据类型 变量名 =  条件 bool ?  满足条件的结果  : 不满足条件的结果;
            //作用：根据条件进行赋值
            int numberResult = true ? 0 : 1;//0

            string strResult = false ? "ok" : "no";//“no”
        }

        //数据类型转换
        static void Main2()
        {
            string strBulletCount = "100.1";
            //1.Parse转换：字符串类型 转换为 其他类型
            //语法： 数据类型.Parse(字符串)
            //备注：如果字符串不是该类型的数据，将抛出异常。
            //int intBulletCount = int.Parse(strBulletCount);
            float floatBulletCount = float.Parse(strBulletCount);

            //2.其他类型转换为字符串类型
            //语法： 其他数据.ToString()
            string strResult = floatBulletCount.ToString();

            //3.隐式转换：由小范围 到 大范围的自动类型转换(一定可以成功)
            byte bt01 = 100;
            int num01 = bt01;

            //4.显式转换：由大范围 到 小范围的强制类型转换(有可能丢失精度)
            int num02 = 500;
            byte bt02 = (byte)num02;//244
            //通常发生在数值之间

            //多种类型变量参与的运算，类型会自动提升
            short number01 = 200;
            byte number02 = 200;
            long result = (number01 + number02);

        }

        //练习：让用户在控制台中录入4位整数1234
        //         计算每位相加和1+2+3+4  ==》 10 
        static void Main3()
        { 
            //准备数据
            Console.WriteLine("请输入4位整数：");
            string strNumber = Console.ReadLine(); //"1234"
            int number = int.Parse(strNumber);//1234

            //解决方案1：数学方法
            //逻辑处理
            int result = number % 10; // 个位
            //result += number / 10 % 10;// 十位 1234 / 10 -->  123 %10 --> 3
            result = result + number / 10 % 10;
            result += number / 100 % 10;// 百位 1234 / 100 -->  12 %10 --> 2
            result += number / 1000;// 百位 1234 / 1000  -->  1 
            //显示结果
            Console.WriteLine("结果为：" + result);

            //解决方案2：从字符串中获取每个字符  "1234"
            //获取第一个字符
            char c1 = strNumber[0];//"1234" -->  '1':{'1','2','3','4'}
            //'1' -->  "1"
            string s1 = c1.ToString();
            //"1" --> 1
            int result02 = int.Parse(s1);

            result02 += int.Parse(strNumber[1].ToString());
            result02 += int.Parse(strNumber[2].ToString());
            result02 += int.Parse(strNumber[3].ToString());
            Console.WriteLine("结果为：" + result02);
        }

        //语句   选择语句   循环语句  跳转语句
        static void Main4()
        {
            /* if（条件bool)
             * {
             *       满足条件时执行
             * }
                else
             * {
             *       不满足条件时执行
             *  }
             * */

            Console.WriteLine("请输入性别：");
            string sex = Console.ReadLine();
            //如果 
            if (sex == "男")
            {
                Console.WriteLine("您好，先生！"); 
            } 
            else if (sex == "女")
            {
                Console.WriteLine("您好，女士！");
            } 
            else
            {
                Console.WriteLine("性别未知");
            }
            //else 输入上面的if

            //if (sex == "男")
            //{
            //    Console.WriteLine("您好，先生！");
            //} 
            //if (sex == "女")
            //{
            //    Console.WriteLine("您好，女士！");
            //} 
            //if(sex  != "男" && sex !="女")
            //{
            //    Console.WriteLine("性别未知");
            //} 
        }

        static void Main5()
        { 
            //练习：让用户在控制台中录入2个数字，1个运算符。
            //         根据运算符 计算 数字
            //"请输入第一个数字："
            //"请输入第二个数字："
            //"请输入运算符(+ - * /)：" 

            //准备数据
            Console.WriteLine("请输入第一个数字：");
            string strNumberOne = Console.ReadLine();
            int numberOne = int.Parse(strNumberOne); 
            Console.WriteLine("请输入第二个数字："); 
            int numberTwo = int.Parse(Console.ReadLine()); 
            Console.WriteLine("请输入运算符：");
            string op = Console.ReadLine();//“+” 

            //逻辑处理
            int result;
            if (op == "+")
            {
                result = numberOne + numberTwo;
            }
            else if (op == "-")
            {
                result = numberOne - numberTwo;
            }
            else if (op == "*")
            {
                result = numberOne * numberTwo;
            }
            else if (op == "/")
            {
                result = numberOne / numberTwo;
            }
            else
            {
                result = 0;
            }

            //显示结果
            //如果运算符输入无误
            if (op == "+" || op == "-" || op == "*" || op == "/")
            {
                Console.WriteLine("结果为:" + result);
            }
            else
            {
                Console.WriteLine("运算符输入有误！"); 
            }
        }

        //练习：
        //让用户在控制台中，输入一个成绩
        //根据成绩判断等级
        //优秀  良好   及格   不及格  成绩有误(不考虑其他字符)
        static void Main6()
        {
            //准备数据
            Console.WriteLine("请输入成绩：");
            int score = int.Parse(Console.ReadLine());

            string message;
            if (score < 0 || score > 100)
            {
                message = "成绩有误";
            }
            else if (score >= 90)
            {
                message = "优秀";
            }
            else if (score >= 80)
            {
                message = "良好";
            }
            else if (score >= 60)
            {
                message = "及格";
            }
            else
            {
                message = "不及格";
            } 
            Console.WriteLine(message);
        }

        static void Main7()
        { 
            Console.WriteLine("请输入第一个数字：");
            string strNumberOne = Console.ReadLine();
            int numberOne = int.Parse(strNumberOne);
            Console.WriteLine("请输入第二个数字：");
            int numberTwo = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符：");
            string op = Console.ReadLine();//“+” 

            int result;

            //if (op == "+")
            //    result = numberOne + numberTwo;
            //else if (op == "-")
            //    result = numberOne - numberTwo;
            //else if (op == "*")
            //    result = numberOne * numberTwo;
            //else if (op == "/")
            //    result = numberOne / numberTwo;
            //else
            //    result = 0;
        
            switch (op)
            { 
                case "+":
                    result = numberOne + numberTwo;
                    break;//打断switch语句
                case "-":
                    result = numberOne - numberTwo;
                    break;
                case "*":
                    result = numberOne - numberTwo;
                    break;
                case "/":
                    result = numberOne - numberTwo;
                    break;
                default://默认  
                    result = 0;
                    break;
            }

            if (op == "+" || op == "-" || op == "*" || op == "/")
                Console.WriteLine("结果为:" + result);
            else
                Console.WriteLine("运算符输入有误！");
        }

        //练习：让用户在控制台中录入一个月份
        //根据月份计算天数
        //1  3  5   7  8   10  12     有31天
        //4   6  9  11     有30天
        //2     有28天
        static void Main8()
        {   
            //作用域：起作用的范围
            //从声明开始  到 }  结束 
            Console.WriteLine("请输入月份：");
            int month = int.Parse(Console.ReadLine());

            int days = -1;
            if (month >= 1 && month <= 12)
            { 
                switch (month)
                {
                    case 2:
                        days = 28;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        days = 30;
                        break;
                    default:
                        days = 31;
                        break;
                }
            } 
            //显示结果
            Console.WriteLine("{0}月具有{1}天。", month, days); 
        }

        //循环语句
        static void Main()
        {
            //预定次数的循环for
            /*
            for ( 初始值 ;  循环条件  ;   增减变量 )
            { 
                  循环体
            }
             * */

            int sum = 0;//存储累加和
            for (int i = 1; i <= 100; i++)
            {//   
                //如果能被3整除则累加
                //if (i % 3 == 0)
                //{
                //    //            0  +  1
                //    //            1  +  2
                //    //            3  +  3
                //    //            6  +  4
                //    sum = sum + i;
                //}
                //如果不能被3整除
                if (i % 3 != 0)
                {
                    continue;//跳过本次循环，继续下次循环
                }
                sum += i;
            }
            //累加1--100之间能被3整除的数字
            Console.WriteLine(sum);

            //练习：一张纸的厚度为0.01毫米
            //请计算对折30次之后的厚度为多少米。
            float thickness = 0.00001f;
            for (int i = 0; i < 30; i++)
            {
                thickness *= 2;
            }
            Console.WriteLine(thickness);
        }
    }
}
