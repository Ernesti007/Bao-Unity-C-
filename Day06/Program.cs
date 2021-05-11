using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        //值类型 和 引用类型
        static void Main1(string[] args)
        {
            //数据类型         
            //forfor    多维数组     交错数组

            //因为方法执行在栈中，所以在方法内部声明的变量，都在栈中。
            int a;
            //又因为值类型直接存储数据，所以数据1存储在栈中。
            a = 1;
            int b = a;
            a = 2;
            Console.WriteLine(b);//？1

            int[] arr01;
            //因为引用类型所以数据存储在堆中,arr存储数组对象的引用
            arr01 = new int[1] { 1 };
            int[] arr02 = arr01;
            //arr01[0] = 2;//修改堆中的数据
            arr01 = new int[] { 2 };//修改栈中存储的引用
            Console.WriteLine(arr02[0]);//?

            //s1在栈中，"老王"在堆中
            string s1 = "老王";
            //赋值 "老王"的引用
            string s2 = s1;
            //修改s1存储的引用  
            s1 = "老宋";
            //s1[1] = '宋';
            Console.WriteLine(s2);//?

            //object 引用类型 
            object o1 = 1;//数据1存储在堆中 
            object o2 = o1;
            o1 = 2;//修改o1存储的引用
            Console.WriteLine(o2);//？1 
        }

        #region 方法参数
        static void Main2()
        {
            int a01 = 1;
            int[] arr01 = new int[] { 1 };
            //存储数据1  传递数据1
            Fun1(a01, arr01);
            Console.WriteLine(a01);//1
            Console.WriteLine(arr01[0]);//?  2

            int a2 = 1;
            Fun2(ref a2);//传递a2自身地址
            Console.WriteLine(a2);

            //区别2：输出参数传参之前可以不赋值
            int a3;
            Fun3(out a3);
            Console.WriteLine(a3);
             
            int one = 1, two = 2;
            SwopNumber(ref one, ref two);

            int area , perimeter;
            CalculateRect(10, 20, out area, out perimeter);

            string str = "250+";
            //int number = int.Parse(str);
             int result ;
             //TryParsec 尝试着转换，如果成功返回值为true，结果通过输出参数返回。
             //                                    如果不成功返回值为false，结果为0。
             if (int.TryParse(str, out result))
                 Console.WriteLine("成功喽");
            else
                 Console.WriteLine("失败喽");  
        } 

        //值参数：按值传递 -- 传递实参变量所存储的内容
        //作用：传递信息
        private static void Fun1(int a,int[] arr)
        {
            a = 2;
            arr[0] = 2;//修改堆中数据  方法外受影响  2
            //arr = new int[] { 2 };//修改栈中引用 方法外不受影响  1
        }

        //引用参数：按引用传递 -- 传递实参变量自身的地址
        //作用：改变数据
        private static void Fun2(ref int a)
        {//在方法内部修改形参，等同于修改方法外的实参
            a = 2;
        }

        //输出参数：按引用传递 -- 传递实参变量自身的地址
        //作用：返回结果
        private static void Fun3(out int a)
        {//区别1：方法内部必须修改输出参数 
            a = 2;
        }

        //练习1：定义两个整数交换的方法
        private static void SwopNumber(ref int one, ref int two)
        {
            int temp = one;
            one = two;
            two = temp;
        } 

        //练习2：计算矩形面积(长 * 宽) 与周长((长 + 宽)*2)的方法
        private static void CalculateRect(int length, int width,out int area,out int perimeter)
        {
            area = length * width;
            perimeter = (length + width) * 2;
        }
        #endregion
         
        //装拆箱
        static void Main3()
        {
            //int a = 1;
            ////装箱操作[性能"最"差]
            //object o = a;
            ////拆箱操作[性能"较"好]
            //int b = (int)o;
            ////[性能最好]
            //int c = a;

            //Fun3(1);

            int num = 100;
            //装箱： 
            //string strNumber01 = num.ToString();
    
            string str = "数字是：" + num;//装箱：int --> object
            //string.Concat("数字是：",num)
            //避免方式： string str = "数字是：" + num.ToString(); 
        } 
        //如果形参为Object类型 实参传递值类型，会发生拆装箱
        //解决方案：1.重载   2.泛型
        private static void Fun3(object o)
        { 
        
        }

        //枚举
        static void Main4()
        {
            PrintPersonStyle(PersonStyle.Rich | PersonStyle.Beauty);

            //与其他类型转换
            //int -->  Enum
            PersonStyle style01 =(PersonStyle)2;
            //Enum --> int
            int num = (int)PersonStyle.Handsome;

            //Enum --> String
            string strEnum = PersonStyle.Handsome.ToString();
            // String --> Enum 
            PersonStyle style02 =
                (PersonStyle)Enum.Parse(typeof(PersonStyle), strEnum);
        }

        private static void PrintPersonStyle(PersonStyle style)
        { 
            if((style & PersonStyle.Tall) == PersonStyle.Tall)
                Console.WriteLine("大个子");
            if((style & PersonStyle.Rich) == PersonStyle.Rich)
                Console.WriteLine("土豪");
            if((style & PersonStyle.Handsome) != 0)
                Console.WriteLine("帅气");
            if((style & PersonStyle.White) !=0)
                Console.WriteLine("洁白");
            if((style& PersonStyle.Beauty) == PersonStyle.Beauty)
                Console.WriteLine("漂亮");
        }

        //String
        static void Main()
        {
            //特性1：字符串池   
            //字符串常量在创建时，都会先在字符串池中查找是否具有相同的文本。
            //如果不存在则开辟空间存储，如果存储在直接返回引用。
            //作用：提高内存利用率
            string str01 = "八戒";
            string str02 = "八戒";//是同一对象 
             
            //不是同一对象
            string str03 = new string(new char[] { '八', '戒' });
            string str04 = new string(new char[] { '八', '戒' });

            bool r1 = object.ReferenceEquals(str03, str04);

            //特性2：不可变性
            string name = "悟空";
            name = "老孙";//将文本"悟空" 修改为 文本 "老孙" ?  错误
            //重新开辟空间，存储"老孙",再替换name中存储的引用
            //"悟空" 去哪了？？  --> 垃圾
            Console.WriteLine(name);

            object o1 = 1;
            o1 = 1.1d;

            int[] arr = new int[] { 1};
            arr[0] = 100;


           
        

            string[] arr02 = new string[1];
            arr02[0] = "abc";
            arr02[0] = "abcdefg";

            //string strNumber = "";
            //for (int i = 0; i < 10; i++)
            //{
            //    每次循环 都会产生一个新的字符串对象，替换引用，产生垃圾
            //    //                      ""   +  "0"
            //    //                      "0"   +  "1"
            //    //                      "01"  +"2"
            //    strNumber = strNumber + i.ToString();
            //} 
            //Console.WriteLine(strNumber);//0 1 2 3 4 5  6 7 8 9

            //可变字符串  一次在内存中开辟可以容纳10个字符大小的空间
            StringBuilder builder = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {//每次追加新字符串，都在原有空间，避免产生垃圾
                builder.Append(i);
            }
            builder.Insert(0, "ok");
            //builder.Remove
            //builder.Replace 
            Console.WriteLine(builder);
            string s1 = "abc";
            s1 = s1.Insert(0, "ok");



            /*
             练习1：单词反转 How are you  -->   you  are  How
             *           
             练习2：字符反转 How are you  -->  uoy era woH
             *           
             练习3：查找指定字符串中不重复的文字(重复的文字仅仅保留1个)
             */

        } 
    } 
}
