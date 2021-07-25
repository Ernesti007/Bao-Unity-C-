using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void Main1(string[] args)
        {
            //forfor       
            //数组：一组数据类型相同的变量集合
            //分类：
            //  -- 一维数组  int[]    float[]    string[]
            //  -- 多(二)维数组
            //  -- 交错数组

            //2048 游戏算法

            /*
             float[] arr
             
             
             */

            float[] arr01;
            arr01 = new float[4];
            arr01[0] = 10;
            arr01[2] = 3;
            //arr01[4] = 4;  

            //从？开始       到？结束     增减？
            for (int i = arr01.Length - 1; i >= 0; i--)
            {// 
                Console.WriteLine(arr01[i]);
            }
            //简单明了的读取数组元素方式
            foreach (var item in arr01)
            {
                Console.WriteLine(item);
            }
            bool result = Array.IndexOf(arr01, 3) != -1;
        }

        //forfor
        static void Main2()
        {
            for (int r = 0; r < 4; r++)//     0               1                2                3
            {
                for (int c = 0; c < 3; c++)//0 1  2     0  1 2        0  1 2          0  1 2
                {//一行显示
                    Console.Write("老宋\t");
                }
                //换行
                Console.WriteLine();
            }
            /*
             外层    4   次           内层
             #                              1
             ##                            2
             ###                          3
             ####                        4 
             */
            for (int r = 0; r < 4; r++)
            {                                          //0         1         2             3
                for (int c = 0; c <= r; c++)//0       0 1     0  1 2       0  1 2 3
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            /*
           外层    4   次           内层    空格      #
           ####                                0         4
             ###                                1         3
               ##                                2         2
                 #                                3         1
           */

            for (int r = 0; r < 4; r++)
            {// 0             1          2             3
                //                0         0 1         0  1  2
                for (int c = 0; c < r; c++)
                {
                    Console.Write(" ");
                }
                //0 1 2 3   0 1 2    0 1      0
                //for (int c = 0; c < 4 - r; c++)
                //{
                //    Console.Write("#");
                //}
                //4  3  2 1    4  3  2    4  3   4
                for (int c = 4; c > r; c--)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        //练习：
        //检查数组中是否存在相同元素int[]
        //5     2     7     3    7
        //每两个元素进行比较(相同)
        //--(1)取出需要与后面元素进行比较的元素(除最后一个)
        //--(2)与后面进行比较
        //例如：(1)取出 arr[0]  元素  (2)  与 arr[1]  arr[2]  arr[3]  ……
        //         (1)取出 arr[1]  元素  (2)  与  arr[2]  arr[3]  ……

        //5     2     7     3    7
        private static bool IsRepeating(int[] array)
        {
            //取元素
            for (int r = 0; r < array.Length - 1; r++)
            {
                //作比较
                for (int c = r+1; c < array.Length; c++)
                {
                    //发现相同
                    if (array[r] == array[c])
                        return true;//退出方法 返回真
                }
            }
            return false;
        }

        //定义冒泡排序算法（从小到大）
        //2   8    6    1
        /*
         1    8   6   2    
         1    2   8   6   交换了2次
         1    2   6   8
         */
        //每个元素进行比较( 如果发现更小的元素则交换  ) 
        private static void OrderBy1(int[] array)
        {
            for (int r = 0; r < array.Length-1; r++)//        0              1          2 
            {
                for (int c = r+1; c < array.Length; c++)//1  2 3      2   3        3
                { 
                    if(array[r]  >  array[c])
                    {
                        int temp = array[r];
                        array[r] = array[c];
                        array[c] = temp;
                    }
                }
            }
            //return array;
        }

        //选择排序
        //避免同一轮交换多次数据
        //每个元素进行比较( 如果发现最小的元素则交换  )
        private static int[] OrderBy2(int[] array)
        {
            for (int r = 0; r < array.Length - 1; r++)//        0              1          2 
            {
                int minIndex = r;//假设的最小索引
                for (int c = r + 1; c < array.Length; c++)//1  2 3      2   3        3
                {
                    //如果假设的最小元素  大于  后面元素
                    if (array[minIndex] > array[c]) minIndex = c; 
                } 
                if (minIndex != r)
                {  //交换
                    int temp = array[minIndex];
                    array[minIndex] = array[r];
                    array[r] = temp;
                }
            }
            return array;
        }

        static void Main3()
        {
            int[] arr = { 2, 8, 6, 1 };
            //arr = OrderBy1(arr); 
            OrderBy1(arr);
        }

        //二维数组
        static void Main4()
        { 
            //一维数组   多维数组   交错数组
            int[,] array;
            array =new int[4,5];
            array[1, 0] = 1;
            array[1, 4] = 2;
            array[2, 2] = 3;
            array[3, 3] = 4;
             
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            //array.Length 数组元素总数4  *  5  ==》 20
            // array.GetLength(0)  获取二维数组行数  4
            // array.GetLength(1)  获取二维数组列数  5
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    Console.Write(array[r, c] + "\t");
                }
                Console.WriteLine();
            } 
        }

       
        //交错数组
        static void Main5()
        {
            //具有4个元素的交错数组
            //每个元素都是新的一维数组
            int[][] array;
            array = new int[4][];
            array[0] = new int[3];
            array[1] = new int[5];
            array[2] = new int[4];
            array[3] = new int[1];
            //将数据1赋值给交错数组的第二个元素的第一个元素
            array[1][0] = 1;
            array[1][4] = 2;
            array[2][2] = 3;

            //遍历交错数组
            foreach (var item in array)
            {//遍历交错数组每个元素(数组)
                foreach (var element in item)
                {
                    Console.WriteLine(element);
                }
            }

            //array[0][0]  array[0][1]  array[0][2]
            for (int r = 0; r < array.Length; r++)
            {
                for (int c = 0; c < array[r].Length; c++)
                {
                    Console.Write(array[r][c] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main6()
        {
            int[][] scoreArray = CreateJaggedArray(); 
        }

        //二维数组练习：
        //在控制台中录入学生信息 
        //                 科目1              科目2
        //学生一：
        //学生二： 
        //请输入学生总数：
        //请输入科目总数： 
        //请输入第1个学生的第1门成绩：
        //请输入第1个学生的第2门成绩： 
        private static int[,] CreateDoubleArray()
        {
            Console.WriteLine("请输入学生总数：");
            int studentCount = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入科目总数：");
            int subjectCount = int.Parse(Console.ReadLine());

            int[,] scoreArray = new int[studentCount, subjectCount];

            for (int r = 0; r < studentCount; r++)
            {
                for (int c = 0; c < subjectCount; c++)
                {
                    Console.WriteLine("请输入第{0}个学生第{1}门成绩：",r+1, c + 1);
                    scoreArray[r, c] = int.Parse(Console.ReadLine());
                }
            }

            return scoreArray;
        } 

        //交错数组练习：
        //在控制台中录入学生信息 
        //                 科目1              科目2
        //学生一：
        //学生二： 
        //请输入学生总数：
        //请输入第1个学生参考科目数： 
        //请输入第1个学生的第1门成绩：
        //请输入第1个学生的第2门成绩：

        //请输入第2个学生参考科目数： 
        //请输入第2个学生的第1门成绩：
        //请输入第2个学生的第2门成绩：
        private static int[][] CreateJaggedArray()
        {
            Console.WriteLine("请输入学生总数：");
            int studentCount = int.Parse(Console.ReadLine());
            int[][] scoreArray = new int[studentCount][];
            for (int r = 0; r < studentCount; r++)
            {
                Console.WriteLine("请输入第{0}个学生科目数：", r + 1);
                int subjectCount = int.Parse(Console.ReadLine());
                scoreArray[r] = new int[subjectCount];
                for (int c = 0; c < subjectCount; c++)
                {
                    Console.WriteLine("请输入第{0}个学生的第{1}个科目：", r + 1, c + 1);
                    scoreArray[r][c] = int.Parse(Console.ReadLine());
                }
            }
            return scoreArray;
        }

        //****************2048游戏核心算法*************************************
         
        /*
         1.0版本
         * 1. 上移动
         *    -- 获取每列数据(将二维数组  -->  一维数组)4    2    0    2                   4  4   2  2
         *    -- 将零元素移动到末尾4    2    2    0
         *    -- 相邻相同则合并 4   4   0   0                  8   0  4  0
         *       -- 将后一个元素累加到前一个元素上
         *       -- 将后一个元素清零
               -- 将零元素移动到末尾 
         *    -- 还原每列数据
         *     
         * 2. 下移动
         *  -- 获取每列数据(将二维数组  -->  一维数组)
         *  -- 将零元素移动到开头 
             -- 相邻相同则合并 
         *       -- 将前一个元素累加到后一个元素上
         *       -- 将前一个元素清零
         *  -- 将零元素移动到开头 
         *  -- 还原每列数据 
         *  
         * 
         * 2.0版本
         * 1. 上移动
         *    -- 从上到下获取每列数据(将二维数组  -->  一维数组)4    2    0    2                   4  4   2  2
         *    -- 调用合并数据方法
         *    -- 还原每列数据
         *     
         * 2. 下移动
         *  -- 从下到上获取每列数据(将二维数组  -->  一维数组)
             -- 调用合并数据方法
         *  -- 还原每列数据
         
         * 3.合并数据 2   2   2   0    -->   4  2  0  0
         *  -- 调用去零方法
         *    -- 相邻相同则合并 4   4   0   0                  8   0  4  0
         *       -- 将后一个元素累加到前一个元素上
         *       -- 将后一个元素清零
            -- 调用去零方法
         * 
         * 4.移动零元素方法( 将零元素移动到末尾 )2   0   2   0  -->  2   2   0  0
         */

        private static void Main()
        {
            int[] arr = { 2, 0, 0, 2 };
            RemoveZero(arr);

            int[,] map = new int[4, 4]
            {
                  {2,2,0,2},
                  {2,4,2,0},
                  {4,0,4,0},
                  {2,2,4,2}
            };
            PrintMap(map);
            Console.WriteLine("上移动");
            //MoveUp(map);
            Move(map,MoveDirection.Up);
            PrintMap(map);

            Console.WriteLine("下移动");
            //MoveDown(map);
            Move(map, MoveDirection.Down);
            PrintMap(map);
        }

        //2   0   4   2  -->  2  4   2  0
        private static void RemoveZero(int[] array)
        { 
            //将非零元素 依次 移入新数组
            int[] newArray = new int[array.Length];//2 4 2 0

            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                    newArray[index++] = array[i];
            }

            //return newArray;
            //array = newArray;//修改栈中的数组引用
            //array[0] = newArray[0];//修改堆中数据
            newArray.CopyTo(array, 0); 
        }

        //2  0  2  0
        private static void Merge(int[] array)
        {
            //array = RemoveZero(array);// 2 2  0  0
            RemoveZero(array);
            //非零 且 相邻相同则合并
            for (int i = 0; i < array.Length -1; i++)//4  0  0  0
            {
                if (array[i] != 0 && array[i] == array[i + 1])
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0; 
                }
            } 
            //array = RemoveZero(array);
            RemoveZero(array);
            //return array;
        }

        private static void MoveUp(int[,] map)
        { 
            //从上到下获取列数据
            //00   10    20    30
            int[] mergeArray = new int[map.GetLength(0)]; 
            for (int c = 0; c < map.GetLength(1); c++)
            { 
                for (int r = 0; r < map.GetLength(0); r++) 
                    mergeArray[r] = map[r, c]; 

                //mergeArray = Merge(mergeArray);
                Merge(mergeArray); 

                for (int r = 0; r < map.GetLength(0); r++) 
                    map[r, c] = mergeArray[r]; 
            } 
            //return map;
        }

        private static void MoveDown(int[,] map)
        { 
            //从下到上获取 列 数据
            //第一列   //第二列   //第三列   //第四列
            //  00      //  01      //  02      //  03
            //  10      //  11      //  12      //  13
            //  20      //  21      //  22      //  23
            //  30      //  31      //  32      //  33

            int[] mergeArray = new int[map.GetLength(0)];
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = map.GetLength(0) - 1; r >= 0; r--)//3  2  1   0
                {
                    mergeArray[3 - r] = map[r, c];//存入一维数组顺序：0  1 2  3
                }

               Merge(mergeArray);

                for (int r = map.GetLength(0) - 1; r >= 0; r--)//3  2  1   0
                {
                    map[r, c] = mergeArray[3 - r];
                }
            }
            //return map; 
        }

        private static void PrintMap(int[,] map)
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    Console.Write(map[r,c] +"\t");
                }
                Console.WriteLine();
            }
        }

        //分发
        //int                      0   1    2  3  4
        private static void Move(int[,] map,int direction)
        {
            switch (direction)
            { 
                case 0:
                    MoveUp(map);
                    break;
                case 1:
                    MoveDown(map);
                    break;
            }
        }

        //MoveDirection   Up  Down  ……
        private static void Move(int[,] map, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection. Up:
                    MoveUp(map);
                    break;
                case MoveDirection.Down:
                    MoveDown(map);
                    break;
            }
        }

    }
}
