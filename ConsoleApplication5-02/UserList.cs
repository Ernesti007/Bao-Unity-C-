using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_02
{
    class UserList
    {
        private User[] list;
        private int index;
        public UserList()
            : this(2)
        {

        }
        public UserList(int capacity)
        {
            list = new User[capacity];
        }
        /// <summary>
        /// 最大有效索引
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return index;
        }
        /// <summary>
        /// 获取对应索引的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public User GetElement(int index)
        {
            return list[index];
        }
        public void Add(User data)
        {
            CheckCapacity();
            list[index] = data;
            index++;
        }
        public void CheckCapacity()
        {
            if (index >= list.Length)
            {
                User[] list2 = new User[list.Length * 2];
                list.CopyTo(list2, 0);
                list = list2;
            }
        }
        public void Insert(User data, int startIndex)//提供用户数据以及要插入的位置索引
        {

            CheckCapacity();//执行完后，索引停留在最后一个空位
            int temp = index;
            for (int i = 0; i < index - startIndex; i++)
            {
                list[temp] = list[temp - 1];
                list[temp - 1] = null;
                temp--;
            }
            list[startIndex] = data;
        }
        public void Remove(int removeIndex)//提供用户数据以及要插入的位置索引
        {
            int temp = removeIndex;
            for (int i = 0; i < index - removeIndex-1; i++)
            {
                list[temp] = list[temp + 1];
                list[temp + 1] = null;
                temp++;
            }
        }
    }
}
