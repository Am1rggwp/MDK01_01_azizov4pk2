using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialz
{
    public class Gender
    {
        public string Name { get; set; } = "Undefined";
        public int Date { get; set; } = 0000;

        // стандартный конструктор без параметров
        public Gender() { }

        public Gender(string name, int date)
        {
            Name = name;
            Date = date;
        }
       
    }
}
