using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    //定义 老婆 类
    class Wife
    {
        //数据成员
        //字段：存储数据    老板
        private string name;

        //属性：保护字字段(本质2个方法GetName   SetName)   助理
        public string Name
        {
            //需要赋值时被调用
            set
            { this.name = value; }
            //需要获取数据时执行
            get
            { return name; }
            //value : 要写入的数据(理解为：SetName的参数) 
        }

        private int age;

        public int Age
        {
            get
            { return this.age; }
            set
            {
                if (value >= 18 && value <= 30)
                    this.age = value;
                else
                    throw new Exception("我不要");
            }
        }

        //构造函数：提供了创建对象的方式，用于初始化(仅1次，开始)对象的特殊方法。
        //特点：
        //1.创建对象时，自动调用（不能手动调用）。
        //2.没有返回值位置
        //3.与类同名

        //若一个类没有构造函数，编译器会自动提供一个无参数构造函数
        //            具有                         不会提供
        public Wife() 
        {
            Console.WriteLine("创建对象就执行！");
        }

        public Wife(string name):this()
        {
            this.name = name;//如果赋值给字段，那么属性是不会执行的。
        }

        public Wife(string name, int age) : this(name)
        {
            //Wife();
            //this.name = name;//如果赋值给字段，那么属性是不会执行的。
            this.Age = age;  
        }

         
        //方法成员
        public void SetName(string name)
        {//this 这个对象的引用
            this.name = name;
            //SetName(name);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetAge(int age)
        {
            if (age >= 18 && age <= 30)
                this.age = age;
            else
                throw new Exception("我不要");
        }

        public int GetAge()
        {
            return this.age;
        }
    }
}
