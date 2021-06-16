using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_01
{
    /// <summary>
    /// 移动
    /// </summary>
   
    enum MoveDirection : int
    {
        Up,
        Down,
        Left,
        Right
    }
    [Flags]
    enum Person
    {
        tall = 2,
        speek = 4,
        bai = 8,
        hei = 16
    }

}
