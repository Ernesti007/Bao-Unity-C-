using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_02
{
    class User
    {
        private string name;
        private int age;
        private static string n = "0";
        public User()
            : this(n, 0)
        {
        }
        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}
