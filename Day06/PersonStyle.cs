using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    [Flags]
    enum PersonStyle
    {
        //Tall=0,//000000000
        //Rich = 1,//000000001
        //Handsome = 2,//000000010
        //White = 3,//000000011
        //Beauty = 4//000000100

        Tall = 1,//000000001
        Rich = 2,//000000010
        Handsome = 4,//000000100
        White = 8,//000001000
        Beauty = 16//000010000
    }
    /*
     二进制运算符：|         &
     按位或 |：对应的两个二进制位中，有一个为1，结果位为1。
     按位与 &：对应的两个二进制位中，都一个为1，结果位为1。
     * 
     * 例如：Rich |  Beauty  =>000000010  |   000010000  => 000010010 
     * 
     * 标志枚举：可以选择多个枚举值的枚举
     * 条件：
     * 1. 任意多个枚举做 | 运算的结果，不能与其他枚举值相同。
     * 2. 使用  [Flags]  特性修饰
     * 
     * 选择多个枚举值，如何判断包含关系？
     * 使用 &；
     * 例如：判断000010010  包含  000000010
     * 000010010  &  000000010  =>  000000010
     */
}
