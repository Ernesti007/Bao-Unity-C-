using System;
//引入命名空间

//命名空间[住址]:对类进行逻辑上的划分，避免重名
namespace Day01
{
    //定义类[做工具]
    class Program
    {
        //定义方法[做功能] 
        static void Main1()
        {
            //自上而下逐语句执行
            //***************从本行开始执行******************** 
            System.Console.Title = "俺的第一个程序";
            //程序：程序员对计算机下达的一系列指令
            //字面意思：控制台.写一行("内容");
            //作用： 将括号中的文本   写到 控制台中(黑窗口)
            Console.WriteLine("请输入姓名：");  // 调用方法[使用功能]
            //字面意思：控制台.读一行();
            //作用： 暂停程序，等待用户输入。==》 将用户输入的内容   读取到程序（变量 name）中来
            string name = Console.ReadLine();
            Console.WriteLine("您好：" + name);
            Console.ReadLine();
            //***************从本行结束********************
            //调试[能力]
            //让程序中断，按F11，执行1条指令
            //步骤：加断点  --》 按F5启动调试  --> 按F11(逐语句执行)

            //Console  是 类 [工具]
            //WriteLine()/ReadLine()   方法[动词的行为/功能]
            // Title  属性[名词 的 描述]

            //写代码（.cs文本文件） --> 生成  -->双击 exe（\SolutionBase\Day01\bin\Debug\Day01.exe）
            //源代码（人的语言）     —编译—  中间语言IL  — 编译 — 机器码 0  1
            //编译错误(语法错误)
            //运行时错误(异常 、逻辑错误 )      
        }

        //变量
        static void Main2()
        {
            //数据类型 变量名;
            //变量名  =   数据; 
            //100
            int number;

            number = 100;

            //男
            string sex = "男";

            //1 >  2
            //声明 + 赋值
            bool r1 = 1 > 2;

            //因为浮点型，在内存中近似存储，所以在运算过程中有误差。
            bool r2 = 1.0f - 0.9f == 0.1f;
            bool r3 = 1.0d - 0.9d == 0.1d;
            //128位数据类型，可以避免误差
            bool r4 = 1.0m - 0.9m == 0.1m;

            //同一范围，同一变量不能重复声明
            //int a;
            //string a ;

            //同一变量，可以重复赋值
            int a = 1;
            a = 2;

            //变量使用前，必须赋值
            //int b; 
            //Console.WriteLine(b);

        }

        //程序的入口[主方法]
        static void Main3()
        {
            //转义符 ： 改变了字符串的原始含义
            //    \"     \'      \0     \\    \t     \r\n回车换行
            string str = "我\t爱\"Unity!\"";
            char c1 = '\'';// '
            char c2 = '\0';//空字符
            string path = "C:\\MSOCache\\All Users\\00-C";
            string path02 = @"C:\MSOCache\All Users\00-C";
            string strNumber = "123\r\n456789";

            string name = "老宋";
            int age = 30;
            //在字符串中插入变量：
            //字符串的拼接
            Console.WriteLine("名字是：" + name + ",年龄是：" + age + "。");
            //占位符  {位置的编号}
            Console.WriteLine("名字是：{0},年龄是：{1}。", name, age);
            //string.Format("格式",变量……);
            string str02 = string.Format("名字是：{0},年龄是：{1}。", name, age);
            Console.WriteLine(str02);

            //标准数字格式字符串
            Console.WriteLine("{0:c}", 10);//￥10.00  货币 
            Console.WriteLine("{0:d3}", 10);//010  不足指定位数，使用0填充
            Console.WriteLine("{0:f2}", 1.126);//1.13 根据精度四舍五入保留小数
            Console.WriteLine("{0:p0}", 0.1);//0.1% 以百分数显示

        }

        //练习：在控制台中录入枪的信息（类型、攻击力、弹匣容量、当前弹匣内子弹数、剩余子弹数）
        //"请输入枪的类型："
        //……
        //"请录入攻击力："
        //……
        //类型为：xxx,攻击力是：xxx,弹匣容量：xxx,当前弹匣内子弹数：xx,剩余子弹数：xx。
        static void Main()
        {
            //读写
            Console.WriteLine("请输入枪的类型：");
            Console.WriteLine("请输入攻击力：");
            string atk = Console.ReadLine();
            Console.WriteLine("请输入弹匣容量：");
            string ammoCapacity = Console.ReadLine();
            Console.WriteLine("请输入当前弹匣内子弹数：");
            string currentAmmoBullets = Console.ReadLine();
            Console.WriteLine("请输入剩余子弹：");
            string remainBullets = Console.ReadLine();
            string name = Console.ReadLine() ;
            Console.WriteLine("类型为：{0},攻击力是：{1},弹匣容量：{2},当前弹匣内子弹数：{3},剩余子弹数：{4}。",  atk, ammoCapacity, currentAmmoBullets, remainBullets);
        } 
    }
}
