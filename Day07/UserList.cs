using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    /// <summary>
    /// 用户集合类
    /// </summary>
    class UserList
    {
        //**********字段***********
        private User[] data;
        private int index;
        //有效元素个数
        public int Count
        {
            get
            { return index; }
        }
        //**********构造函数***********
        public UserList()
            : this(8)
        { 
        }

        public UserList(int capacity)
        {
            data = new User[capacity];
        }

        //**********方法***********
        public void Add(User value)
        {
            //检查是否需要扩容(开辟更大空间、复制原有数据、替换引用)
            CheckCapacity();
            data[index++] = value;
        }
         
        private void CheckCapacity()
        { 
            //如果 需要使用的索引大于数组索引最大值
            if (index  > data.Length - 1)
            {
               //则扩容
                User[] newData = new User[data.Length * 2];
                data.CopyTo(newData, 0);
                data = newData;
            }
        }

        public User GetElement(int index)
        {
            return data[index];
        }
    }
}
