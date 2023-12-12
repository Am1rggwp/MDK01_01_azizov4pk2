using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialz
{

    public class Person
    {

        public string Name { get; set; } = "Undefined";
        public int Age { get; set; } = 1;
        public Company Company { get; set; } = new Company();
        public Gender Gender{ get; set; } = new Gender();
        public Gender Date{ get; set; } = new Gender();


        public Person() { }
        public Person(string name, int age, Company company, Gender gender, Gender date)
        {
            Name = name;
            Age = age;
            Company = company;
            Gender = gender;
            Date = date;
        }


    }
}
