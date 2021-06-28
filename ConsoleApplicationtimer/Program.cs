using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace 字典
{
    class Program
    {
        static void Main(string[] args)
        {
            startWrite("");
            Console .ReadLine();


        }

        //这是一个字符数组，二十六个字母不是随便排列的，是根据那个字母最常用，排在最前面，提高提前破解出的时间
        static char[] chars = new char[]{ 'e', 'a', 't', 'o', 'i', 'n', 'h','s', 'r', 'd', 'l','u', 'c',
                                'm','f', 'g', 'w', 'p', 'b', 'y', 'v', 'k', 'q', 'x', 'j', 'z' };
        //因为下面的方法是递归调用，所以要把这个StreamWriter 写到方法外边，字典保存到当前目录下
       static  StreamWriter sw = new StreamWriter("字典.dic");
        
        /// <summary>
        /// 传进来一个字符串，然后在这个字符串后面加上不同的字符，然后保存到硬盘，继续递归调用
        /// </summary>
        /// <param name="s">传进来的字符串</param>
        public static void startWrite(string s)
        {
            //传进来一个字符串，会根据二十六个字母，生成一个字符串数组
            string[] str = new string[26];
            //依次初始化字符串数组
            for (int i = 0; i < 26; i++)
            {
                //将字符追加到字符串中 
                str[i] += s + chars[i];
                //写一行到文件中
                sw.WriteLine(str[i]);
            }
            
            //刷新缓存，把数据写入硬盘
            sw.Flush();

            //根据字符串长度，判断是否继续递归调用，默认是破解4位数一下的。4位就得两兆，五位得八十兆。哇，这是个Bug，你硬盘够吗，而且如果位数多了的话，照我这写法，堆栈可能会蹦的。
            if (str[1].Length == 4 )
                return;
            //依次递归
            for (int i = 0; i < 26; i++)
            {
                startWrite(str[i]);
            }

        }
    }
} 
