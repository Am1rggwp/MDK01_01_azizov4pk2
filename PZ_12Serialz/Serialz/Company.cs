using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialz
{
    public class Company
    {
        public string Name { get; set; } = "Undefined";

        // стандартный конструктор без параметров
        public Company() { }

        public Company(string name) => Name = name;

    }
}
