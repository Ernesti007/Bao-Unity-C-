using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_01
{
     class GameCore
    {
        private  int[,] map;//原二维数组
        private  int[] coche;//第一次获取的缓存数组以及去零操作的数组
        private int[] zeroIndex;//记录所有0元素的索引,两个位置记录一个索引代表一个坐标点
        private int i2;//记录有几个坐标点已经记录到上面了
         private Random  random;//用于随机选择 是0元素 的坐标
        public GameCore()
        {
            map = new int[4, 4]
            {
          {2,2,4,2},
          {2,0,0,2},
          {2,4,4,0},
          {2,2,2,0}
            };
            PrintMap();
            coche=new int[4];
            zeroIndex = new int[32];
            i2 = 0;
            random =new Random() ;
        }
        private  void RemoveZero()//移动0到末尾！！！！！！！！！！！！
        {
            int t = 0;//记录已经填过的索引
            for (int i = 0; i < coche.Length; i++)
            {      //拿一个数
                if (coche[i] == 0) continue;
                else
                {
                    if (t == i) coche[t] = coche[i];                //移和填是同一位
                    else if (t != i)                //不是同一位
                    {
                        coche[t] = coche[i];
                        coche[i] = 0;
                    }
                    t++;
                }
            }
        }
        private  void Sum()//相邻相同的相加
        {
            for (int i = 0; i < coche .Length - 1; i++)
            {
                if (coche[i] != 0 && coche[i] == coche[i + 1])
                {
                    coche[i] += coche[i + 1];
                    coche[i + 1] = 0;
                }
            }
        }
        private  void  UpLoad( int Lie)//上移
        {
            for (int i = 0; i < map.GetLength(0); i++)//获取数组行数
            {
                coche[i] = map[i, Lie];
            }
        }
        private  void  DownLoad(int Lie)//下移
        {
            for (int i = map.GetLength(0) - 1; i >= 0; i--)//获取数组行数
            {
                coche[3-i] = map[i, Lie];
            }
        }
        private  void  LeftLoad(int Hang)//左移
        {
            for (int i = 0; i < map.GetLength(1); i++)//获取数组列数
            {
                coche[i] = map[Hang, i];
            }
        }
        private  void  RightLoad(int Hang)//右移
        {
            
            for (int i = map.GetLength(1) - 1; i >= 0; i--)//获取数组列数
            {
                coche[3-i] = map[Hang, i];
            }
        }
        private  void  ReUpLoad( int Lie)//还原上移
        {
            for (int i = 0; i < coche.Length; i++)//获取数组行数
            {
               map[i, Lie] = coche[i];
            }
        }
        private void ReDownLoad(int Lie)//还原下移
        {
            for (int i = 0; i < coche.Length; i++)//获取数组行数
            {
                map[3-i, Lie] = coche[i];
            }
        }
        private  void  ReLeftLoad(int Hang)//还原左移
        {
            for (int i = 0; i < coche.Length; i++)//获取数组列数
            {
                map[Hang, i] = coche[i];
            }
        }
        private void  ReRightLoad(int Hang)//还原右移
        {
            for (int i = 0; i < coche.Length; i++)//获取数组列数
            {
                map[Hang, 3-i] = coche[i];
            }
        }
        public   void Move(MoveDirection direction)
        {
            Console.Clear();
            switch (direction)
            {
                case MoveDirection.w:
                    MoveUp();
                    break;
                case MoveDirection.s:
                    MoveDown();
                    break;
                case MoveDirection.a:
                    MoveLeft();
                    break;
                case MoveDirection.d:
                    MoveRight();
                    break;
            }
        }


        private  void MoveUp()
        {
            for (int i = 0; i < map.GetLength(1); i++)//读取数组列数
            {
                UpLoad(i);         //获取一列的数组
                RemoveZero();              //去0   
                Sum();           //加
                RemoveZero();              //去0
                ReUpLoad(i);      //复原
            }
            CreateNumber();
            PrintMap();
        }
        private  void MoveDown()
        {
            for (int i = 0; i < map.GetLength(1); i++)//读取数组列数
            {
                DownLoad(i);         //获取每一列的数组
                RemoveZero();              //去0   
                Sum();           //加
                RemoveZero();              //去0
                ReDownLoad(i);      //复原
            }
            CreateNumber();
            PrintMap();
        }
        private  void MoveLeft()
        {
            for (int i = 0; i < map.GetLength(0); i++)//读取数组行数
            {
                LeftLoad(i);         //获取每一行的数组
                RemoveZero();              //去0   
                Sum();                     //加
                RemoveZero();              //去0
                ReLeftLoad(i);      //复原
            }
            CreateNumber();
            PrintMap();
        }
        private  void MoveRight()
        {
            for (int i = 0; i <map .GetLength(0); i++)//读取数组行数
            {
                RightLoad(i);         //获取每一行的数组
                RemoveZero();              //去0   
                Sum();                     //加
                RemoveZero();              //去0
                ReRightLoad(i);      //复原
            }
            CreateNumber();
            PrintMap();
        }
        private  void PrintMap()
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    Console.Write(map[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }
        private void CreateNumber()
        {
            FindZeroNumber();
            i2=random.Next(0,i2);
            if (random .Next (0,10)==5)
            {
                map[zeroIndex[i2 * 2], zeroIndex[i2 * 2 + 1]] = 4;
            }
            else map[zeroIndex[i2 * 2], zeroIndex[i2 * 2 + 1]] = 2;
        }
        private void FindZeroNumber()
        {
            i2 = 0;
            for (int i = 0; i < map.GetLength(0) ; i++)
            {
                for (int r = 0; r <map.GetLength(1); r++)
                {
                    if (map[i, r] == 0)
                    {
                        zeroIndex[i2*2] = i;
                        zeroIndex[i2*2+1] = r;
                        i2++;
                    }
                }
            }
        }
    }
}
