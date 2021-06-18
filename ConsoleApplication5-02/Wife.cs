using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_02
{
    class Wife
    {
        public  string Name;

        private int Age;
        public string mmmm
        {
            get
            {
                return Name; 
            } 
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public void SetAge(int age)
        {
            this.Age = age;
        }
        public int GetAge()
        {
            return Age;
        }
        public string GetName()
        {
            return Name;
        }
    }
}
