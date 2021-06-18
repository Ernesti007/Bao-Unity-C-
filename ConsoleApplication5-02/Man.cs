using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5_02
{
    class Man
    {
        private static string hit;
        private static int hp;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                int hp = value;
            }
        }
        public string Hit
        {
            get
            {
                return hit;
            }
            set
            {
                string hit = value;
            }
        }
    }
}
