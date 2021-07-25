using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    class Program
    {
        private static GameCore core;
        //界面
        static void Main(string[] args)
        {
            core = new GameCore();

            core.GenerateNumber();
            core.GenerateNumber();

            //画界面
            PrintMap();

            while (true)
            {
                //等待用户输入  ，  调用Move方法 
                KeyDown();

                //如果地图发生改变 
                if (core.IsChange)
                {
                    core.GenerateNumber();
                    //画界面
                    PrintMap();
                    //如果游戏结束(没有空位置/不能在合并)
                    if (core.IsOver())
                        Console.WriteLine("游戏结束");
                }
            }
        }

        private static void PrintMap()
        {
            Console.Clear();

            for (int r = 0; r < core.Map.GetLength(0); r++)
            {
                for (int c = 0; c < core.Map.GetLength(1); c++)
                {
                    Console.Write(core.Map[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void KeyDown()
        {
            switch (Console.ReadLine())
            { 
                case "w":
                    core.Move(MoveDirection.Up);
                    break;
                case "s":
                    core.Move(MoveDirection.Down);
                    break;
                case "a":
                    core.Move(MoveDirection.Left);
                    break;
                case "d":
                    core.Move(MoveDirection.Right);
                    break;
            }
        }
    }
}
