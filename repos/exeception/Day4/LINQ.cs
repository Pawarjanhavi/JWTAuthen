using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class LINQ
    {
        /*public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }*/

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }
    
        public static void Main()
        {
            /*string[] names = { "will", "Janhavi", "Tanu" };
            var myLinq = from name in names
                             // where name == "will"
                        where name.Contains('i')
                         select name;

            //select name from names where name = "will"
            //select name from names where na,e like "%i%"

            foreach ( var item in myLinq)
            {
                Console.WriteLine(item);
            }*/



            //example 1
            /*Student[] students = new Student[]
            {
                new Student() { Id = 1, Name = "K", Age = 12},
                new Student() { Id = 2, Name = "L", Age = 13},
                new Student() { Id = 3, Name = "M", Age = 15},
                new Student() { Id = 4, Name = "N", Age = 18},
                new Student() { Id = 5, Name = "Q", Age = 19}
            }

            Student[] newstu = students.Where(s => s.Age >= 14 && s.Age <= 18).ToArray();

            Student stu = students.Where(s=>s.Name=="k").FirstOrDefault();
            Student StuById = students.Where(s => s.Id == 8).FirstOrDefault();*/

            //execreise 2
            /*List<Employee> emp = new List <Employee>
            {
                new Employee() { Id = 1, FirstName = "Janhavi", LastName = "Pawar" },
                new Employee() { Id = 2, FirstName = "Tanu", LastName = "Shah" },
                new Employee() { Id = 3, FirstName = "Paranav", LastName = "Mishra" },
                new Employee() { Id = 4, FirstName = "Arru", LastName = "Sonal" }

            };

            var SortedEmp = emp.OrderBy(e => e.LastName).ToList();

            Console.WriteLine("Employees list :");
            foreach(var employee in SortedEmp)
            {
                Console.WriteLine($"Id : {employee.Id}, Name : {employee.FirstName} {employee.LastName}");
            }
            */

            //exercise 3

            /* int[] numbers = new int[] { 10, 20, 50, 70, 100 };

             int totalsum = numbers.Sum(n => n);

             Console.WriteLine(totalsum);*/

            //exercise 4

            List<string> words = new List<string>
            {
                "Apple","banana","Cheery","Mango"
            };

            var uppercase = words.Select(words => words.ToUpper()).ToList();

            //Console.WriteLine(uppercase);
            foreach(var word in uppercase)
            {
                Console.WriteLine(word);
            }
   

        }


       
    }
}
