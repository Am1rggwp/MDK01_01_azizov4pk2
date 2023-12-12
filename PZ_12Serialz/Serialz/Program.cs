using System.Xml.Serialization;

namespace Serialz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var microsoft = new Company("Microsoft");
            var google = new Company("Google");

            var Famel = new Gender("Famel", 1986);
            var Meh = new Gender("I'm mehanik", 1982);


            Person[] people = new Person[]
            {
                new Person("Alisa", 37, microsoft, Famel,Famel),
                new Person("Bob", 41, google, Meh, Meh)

            };
            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                Person[]? newpeople = formatter.Deserialize(fs) as Person[];

                if (newpeople != null)
                {
                    foreach (Person person in newpeople)
                    {
                        Console.WriteLine($"Name: {person.Name}");
                        Console.WriteLine($"Age: {person.Age}");
                        Console.WriteLine($"Company: {person.Company.Name}");
                        Console.WriteLine($"Gender: {person.Gender.Name}");
                        Console.WriteLine($"Year birthday: {person.Gender.Date}\n");
                    }

                }

            }
        }
    }


}